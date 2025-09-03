using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

// 👇 where your AppDbContext lives
using xbytechat.api;

using xbytechat.api.Features.CampaignTracking.Models;   // CampaignSendLog
using xbytechat.api.Features.MessageManagement.DTOs;    // MessageLog
using xbytechat.api.Features.Webhooks.Services.Resolvers;

namespace xbytechat.api.Features.Webhooks.Services.Processors
{
    /// <summary>
    /// Legacy status processor (back-compat).
    /// - Extracts statuses from the payload
    /// - Resolves CampaignSendLog via IMessageIdResolver when possible
    /// - Updates CampaignSendLog / MessageLog idempotently
    /// New provider-aware flow should go through the dispatcher -> WhatsAppWebhookService.
    /// </summary>
    public class StatusWebhookProcessor : IStatusWebhookProcessor
    {
        private readonly AppDbContext _context;
        private readonly ILogger<StatusWebhookProcessor> _logger;
        private readonly IMessageIdResolver _messageIdResolver;

        public StatusWebhookProcessor(
            AppDbContext context,
            ILogger<StatusWebhookProcessor> logger,
            IMessageIdResolver messageIdResolver)
        {
            _context = context;
            _logger = logger;
            _messageIdResolver = messageIdResolver;
        }

        /// <summary>
        /// Entry point from dispatcher (legacy path).
        /// Normalizes Meta envelope to a "value" object, then processes.
        /// </summary>
        public async Task ProcessStatusUpdateAsync(JsonElement payload)
        {
            _logger.LogDebug("status_webhook_in (legacy) \n{Payload}", payload.ToString());

            // 1) Envelope → value
            if (TryExtractValue(payload, out var value))
            {
                await ProcessAsync(value);
                return;
            }

            // 2) Already value-like (adapter flattened)
            if (payload.ValueKind == JsonValueKind.Object &&
                (payload.TryGetProperty("statuses", out _) || payload.TryGetProperty("messages", out _)))
            {
                await ProcessAsync(payload);
                return;
            }

            _logger.LogWarning("Unrecognized status payload shape (legacy path).");
        }

        /// <summary>
        /// Extract statuses from a Meta-like "value" object and update DB.
        /// </summary>
        public async Task ProcessAsync(JsonElement value)
        {
            if (!value.TryGetProperty("statuses", out var statuses) || statuses.ValueKind != JsonValueKind.Array)
            {
                _logger.LogWarning("⚠️ 'statuses' array missing in webhook payload (legacy path).");
                return;
            }

            foreach (var status in statuses.EnumerateArray())
            {
                if (status.ValueKind != JsonValueKind.Object) continue;

                // message id (WAMID)
                var messageId = status.TryGetProperty("id", out var idEl) && idEl.ValueKind == JsonValueKind.String
                    ? idEl.GetString()
                    : null;

                // status text
                var statusText = status.TryGetProperty("status", out var stEl) && stEl.ValueKind == JsonValueKind.String
                    ? stEl.GetString()
                    : null;

                if (string.IsNullOrWhiteSpace(messageId) || string.IsNullOrWhiteSpace(statusText))
                {
                    _logger.LogWarning("⚠️ Missing messageId or status in webhook payload (legacy path).");
                    continue;
                }

                // timestamp (string or number)
                DateTime? eventTime = null;
                if (status.TryGetProperty("timestamp", out var tsEl))
                {
                    if (tsEl.ValueKind == JsonValueKind.String && long.TryParse(tsEl.GetString(), out var epochS))
                        eventTime = DateTimeOffset.FromUnixTimeSeconds(epochS).UtcDateTime;
                    else if (tsEl.ValueKind == JsonValueKind.Number && tsEl.TryGetInt64(out var epochN))
                        eventTime = DateTimeOffset.FromUnixTimeSeconds(epochN).UtcDateTime;
                }

                _logger.LogDebug("🕓 Parsed timestamp: {Time} (raw kind={Kind})",
                    eventTime?.ToString("o") ?? "n/a", status.TryGetProperty("timestamp", out var tsDbg) ? tsDbg.ValueKind.ToString() : "n/a");

                // ✅ First try resolving a CampaignSendLog row via resolver
                Guid? sendLogId = null;
                try
                {
                    sendLogId = await _messageIdResolver.ResolveCampaignSendLogIdAsync(messageId);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "MessageId resolver failed for {MessageId}", messageId);
                }

                if (sendLogId is Guid sid)
                {
                    var log = await _context.Set<CampaignSendLog>()
                                            .FirstOrDefaultAsync(l => l.Id == sid);

                    if (log != null)
                    {
                        bool changed = false;

                        var newStatus = MapMetaStatus(statusText);
                        if (!string.IsNullOrEmpty(newStatus) &&
                            !string.Equals(log.SendStatus, newStatus, StringComparison.Ordinal))
                        {
                            log.SendStatus = newStatus;
                            changed = true;
                        }

                        if (statusText == "sent" && (log.SentAt == null || log.SentAt == default) && eventTime.HasValue)
                        {
                            log.SentAt = eventTime.Value;
                            changed = true;
                        }
                        if (statusText == "delivered" && (log.DeliveredAt == null || log.DeliveredAt == default) && eventTime.HasValue)
                        {
                            log.DeliveredAt = eventTime.Value;
                            changed = true;
                        }
                        if (statusText == "read" && (log.ReadAt == null || log.ReadAt == default) && eventTime.HasValue)
                        {
                            log.ReadAt = eventTime.Value;
                            changed = true;
                        }

                        if (changed)
                        {
                            await _context.SaveChangesAsync();
                            _logger.LogInformation("✅ CampaignSendLog updated (legacy) for MessageId: {MessageId} → {Status}", messageId, newStatus ?? statusText);
                        }
                        else
                        {
                            _logger.LogInformation("🔁 Duplicate status '{Status}' skipped for MessageId: {MessageId} (legacy)", statusText, messageId);
                        }

                        continue; // done with this status item
                    }
                }

                // 🔁 Fallback: update MessageLog when there’s no CampaignSendLog
                var msg = await _context.Set<MessageLog>()
                                        .FirstOrDefaultAsync(m => m.MessageId == messageId);

                if (msg != null)
                {
                    bool changed = false;

                    switch (statusText)
                    {
                        case "sent":
                            if (!EqualsIgnoreCase(msg.Status, "Sent"))
                            {
                                msg.Status = "Sent";
                                changed = true;
                            }
                            if ((msg.SentAt == null || msg.SentAt == default) && eventTime.HasValue)
                            {
                                msg.SentAt = eventTime.Value;
                                changed = true;
                            }
                            break;

                        case "delivered":
                            // no DeliveredAt column on MessageLog; just progression
                            if (!EqualsIgnoreCase(msg.Status, "Read") &&
                                !EqualsIgnoreCase(msg.Status, "Delivered"))
                            {
                                msg.Status = "Delivered";
                                changed = true;
                            }
                            if ((msg.SentAt == null || msg.SentAt == default) && eventTime.HasValue)
                            {
                                msg.SentAt = eventTime.Value; // ensure SentAt eventually set
                                changed = true;
                            }
                            break;

                        case "read":
                            if (!EqualsIgnoreCase(msg.Status, "Read"))
                            {
                                msg.Status = "Read";
                                changed = true;
                            }
                            if ((msg.SentAt == null || msg.SentAt == default) && eventTime.HasValue)
                            {
                                msg.SentAt = eventTime.Value;
                                changed = true;
                            }
                            break;

                        default:
                            // leave as-is for unknown statuses
                            break;
                    }

                    if (changed)
                    {
                        await _context.SaveChangesAsync();
                        _logger.LogInformation("ℹ️ MessageLog updated (legacy) for MessageId: {MessageId} → {Status}", messageId, msg.Status);
                    }
                    else
                    {
                        _logger.LogInformation("🔁 Duplicate status '{Status}' skipped for MessageId: {MessageId} (legacy)", statusText, messageId);
                    }
                }
                else
                {
                    // lower severity; common when a send failed before obtaining a message id
                    _logger.LogInformation("ⓘ No matching CampaignSendLog/MessageLog for MessageId: {MessageId} (legacy)", messageId);
                }
            }
        }

        // ----------------- helpers -----------------

        private static bool TryExtractValue(JsonElement payload, out JsonElement value)
        {
            value = default;
            if (payload.ValueKind != JsonValueKind.Object) return false;
            if (!payload.TryGetProperty("entry", out var entry) || entry.ValueKind != JsonValueKind.Array || entry.GetArrayLength() == 0) return false;

            var e0 = entry[0];
            if (!e0.TryGetProperty("changes", out var changes) || changes.ValueKind != JsonValueKind.Array || changes.GetArrayLength() == 0) return false;

            var c0 = changes[0];
            if (!c0.TryGetProperty("value", out var v) || v.ValueKind != JsonValueKind.Object) return false;

            value = v;
            return true;
        }

        private static string? MapMetaStatus(string? s) =>
            (s ?? "").ToLowerInvariant() switch
            {
                "sent" => "Sent",
                "delivered" => "Delivered",
                "read" => "Read",
                "failed" => "Failed",
                "deleted" => "Deleted",
                _ => null
            };

        private static bool EqualsIgnoreCase(string? a, string? b) =>
            string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }
}


//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Text.Json;
//using System.Threading.Tasks;
//using xbytechat.api.Features.CampaignTracking.Models;
//using xbytechat.api.Features.Webhooks.Services.Resolvers;

//namespace xbytechat.api.Features.Webhooks.Services.Processors
//{
//    public class StatusWebhookProcessor : IStatusWebhookProcessor
//    {
//        private readonly AppDbContext _context;
//        private readonly ILogger<StatusWebhookProcessor> _logger;
//        private readonly IMessageIdResolver _messageIdResolver;

//        public StatusWebhookProcessor(
//            AppDbContext context,
//            ILogger<StatusWebhookProcessor> logger,
//            IMessageIdResolver messageIdResolver)
//        {
//            _context = context;
//            _logger = logger;
//            _messageIdResolver = messageIdResolver;
//        }

//        // 🔄 Extract statuses from the payload and route them to log resolver
//        public async Task ProcessAsync(JsonElement value)
//        {
//            if (!value.TryGetProperty("statuses", out var statuses))
//            {
//                _logger.LogWarning("⚠️ 'statuses' field missing in webhook payload.");
//                return;
//            }

//            foreach (var status in statuses.EnumerateArray())
//            {
//                var messageId = status.GetProperty("id").GetString();
//                var statusText = status.GetProperty("status").GetString();

//                // timestamp parsing (works for string or number)
//                long unix = 0;
//                JsonValueKind? tsKind = null;
//                if (status.TryGetProperty("timestamp", out var ts))
//                {
//                    tsKind = ts.ValueKind;
//                    if (ts.ValueKind == JsonValueKind.String && long.TryParse(ts.GetString(), out var parsed))
//                        unix = parsed;
//                    else if (ts.ValueKind == JsonValueKind.Number)
//                        unix = ts.GetInt64();
//                }
//                var time = unix > 0
//                    ? DateTimeOffset.FromUnixTimeSeconds(unix).UtcDateTime
//                    : DateTime.UtcNow;

//                _logger.LogDebug("🕓 Parsed timestamp(s): {Unix} kind={Kind}", unix, tsKind?.ToString() ?? "n/a");

//                // ✅ First try resolving a CampaignSendLog row via resolver
//                var logId = await _messageIdResolver.ResolveCampaignSendLogIdAsync(messageId);

//                if (logId != null)
//                {
//                    var log = await _context.CampaignSendLogs.FirstOrDefaultAsync(l => l.Id == logId.Value);
//                    if (log != null)
//                    {
//                        // Normalize statuses to your app's values
//                        log.SendStatus = statusText switch
//                        {
//                            "sent" => "Sent",
//                            "delivered" => "Delivered",
//                            "read" => "Read",
//                            _ => log.SendStatus
//                        };

//                        if (statusText == "delivered") log.DeliveredAt = time;
//                        if (statusText == "read") log.ReadAt = time;
//                        // If provider reports "sent" late and we missed SentAt, keep it consistent
//                        if (statusText == "sent" && log.SentAt == null) log.SentAt = time;

//                        await _context.SaveChangesAsync();
//                        _logger.LogInformation("✅ CampaignSendLog updated for MessageId: {MessageId} → {Status}", messageId, statusText);
//                        continue; // done with this status item
//                    }
//                }

//                // 🔁 Fallback: update MessageLogs (flow-driven sends) when there's no CampaignSendLog
//                var msg = await _context.MessageLogs.FirstOrDefaultAsync(m => m.MessageId == messageId);
//                if (msg != null)
//                {
//                    switch (statusText)
//                    {
//                        case "sent":
//                            msg.Status = "Sent";
//                            msg.SentAt ??= time;
//                            break;
//                        case "delivered":
//                            msg.Status = "Delivered";
//                            // keep SentAt if it was not set for some reason
//                            msg.SentAt ??= time;
//                            break;
//                        case "read":
//                            msg.Status = "Read";
//                            msg.SentAt ??= time;
//                            break;
//                        default:
//                            // leave as-is for unknown statuses
//                            break;
//                    }

//                    await _context.SaveChangesAsync();
//                    _logger.LogInformation("ℹ️ MessageLog updated for MessageId: {MessageId} → {Status}", messageId, statusText);
//                }
//                else
//                {
//                    // lower severity; common when a send failed before obtaining a message id
//                    _logger.LogInformation("ⓘ No matching CampaignSendLog/MessageLog for MessageId: {MessageId}", messageId);
//                }
//            }
//        }


//        //public async Task ProcessStatusUpdateAsync(JsonElement payload)
//        //{
//        //    _logger.LogDebug("status_webhook_in");

//        //    if (payload.ValueKind == JsonValueKind.Object &&
//        //        payload.TryGetProperty("entry", out var entry) &&
//        //        entry.ValueKind == JsonValueKind.Array && entry.GetArrayLength() > 0 &&
//        //        entry[0].TryGetProperty("changes", out var changes) &&
//        //        changes.ValueKind == JsonValueKind.Array && changes.GetArrayLength() > 0 &&
//        //        changes[0].TryGetProperty("value", out var valueFromEnvelope) &&
//        //        valueFromEnvelope.ValueKind == JsonValueKind.Object)
//        //    {
//        //        await ProcessAsync(valueFromEnvelope);
//        //        return;
//        //    }

//        //    if (payload.ValueKind == JsonValueKind.Object &&
//        //        (payload.TryGetProperty("statuses", out _) || payload.TryGetProperty("messages", out _)))
//        //    {
//        //        await ProcessAsync(payload);
//        //        return;
//        //    }

//        //    _logger.LogWarning("Unrecognized status payload shape.");
//        //}

//        public async Task ProcessStatusUpdateAsync(JsonElement payload)
//        {
//            _logger.LogDebug("status_webhook_in");

//            // 1) Normalize to "value" object when envelope present
//            if (TryExtractValue(payload, out var value))
//            {
//                // If there are statuses and we can resolve tenant+provider, use the unified updater
//                if (value.TryGetProperty("statuses", out var statuses) && statuses.ValueKind == JsonValueKind.Array)
//                {
//                    if (await TryResolveProviderAndBusinessIdAsync(payload, value) is (string provider, Guid businessId))
//                    {
//                        await HandleStatusesWithUpdaterAsync(businessId, provider, statuses);
//                        return; // handled via unified updater; clicks/messages remain unchanged below
//                    }
//                }

//                // Fallback to your existing handler (non-breaking)
//                await ProcessAsync(value);
//                return;
//            }

//            // 2) Already a value-like object (adapter might have provided directly)
//            if (payload.ValueKind == JsonValueKind.Object &&
//                (payload.TryGetProperty("statuses", out _) || payload.TryGetProperty("messages", out _)))
//            {
//                // Same attempt: updater first when possible
//                if (payload.TryGetProperty("statuses", out var statuses2) && statuses2.ValueKind == JsonValueKind.Array)
//                {
//                    if (await TryResolveProviderAndBusinessIdAsync(payload, payload) is (string provider2, Guid biz2))
//                    {
//                        await HandleStatusesWithUpdaterAsync(biz2, provider2, statuses2);
//                        return;
//                    }
//                }

//                // Fallback to existing behavior
//                await ProcessAsync(payload);
//                return;
//            }

//            _logger.LogWarning("Unrecognized status payload shape.");
//        }

//        #region helpers (local to this class)

//        private static bool TryExtractValue(JsonElement payload, out JsonElement value)
//        {
//            value = default;
//            if (payload.ValueKind != JsonValueKind.Object) return false;
//            if (!payload.TryGetProperty("entry", out var entry) || entry.ValueKind != JsonValueKind.Array || entry.GetArrayLength() == 0) return false;
//            var e0 = entry[0];
//            if (!e0.TryGetProperty("changes", out var changes) || changes.ValueKind != JsonValueKind.Array || changes.GetArrayLength() == 0) return false;
//            var c0 = changes[0];
//            if (!c0.TryGetProperty("value", out var v) || v.ValueKind != JsonValueKind.Object) return false;
//            value = v;
//            return true;
//        }

//        /// <summary>
//        /// Best-effort provider + tenant resolution:
//        /// - Meta: from value.metadata.phone_number_id (uses IMetaTenantResolver)
//        /// - Pinnacle: if adapter stamped provider, or if account fields exist (optional future hook)
//        /// Returns (provider, businessId) when resolvable; else null.
//        /// </summary>
//        private async Task<(string provider, Guid businessId)?> TryResolveProviderAndBusinessIdAsync(JsonElement envelopeOrValue, JsonElement value)
//        {
//            // Heuristic #1: Meta envelope => provider = meta_cloud
//            if (value.TryGetProperty("metadata", out var md) && md.ValueKind == JsonValueKind.Object &&
//                md.TryGetProperty("phone_number_id", out var pnEl) && pnEl.ValueKind == JsonValueKind.String)
//            {
//                var provider = "meta_cloud";
//                var phoneNumberId = pnEl.GetString();
//                try
//                {
//                    if (!string.IsNullOrWhiteSpace(phoneNumberId) && _metaTenantResolver != null)
//                    {
//                        var biz = await _metaTenantResolver.ResolveBusinessIdAsync(envelopeOrValue);
//                        if (biz.HasValue) return (provider, biz.Value);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    _logger.LogWarning(ex, "Tenant resolve failed for Meta phone_number_id.");
//                }
//            }

//            // Heuristic #2: Adapter stamped provider (optional; add this in your adapter if not present)
//            // e.g., payload["provider"] = "pinnacle" or value["provider"] = "pinnacle"
//            string? providerHint = null;
//            if (envelopeOrValue.TryGetProperty("provider", out var prov1) && prov1.ValueKind == JsonValueKind.String)
//                providerHint = prov1.GetString();
//            else if (value.TryGetProperty("provider", out var prov2) && prov2.ValueKind == JsonValueKind.String)
//                providerHint = prov2.GetString();

//            if (!string.IsNullOrWhiteSpace(providerHint))
//            {
//                // If you have a Pinnacle tenant resolver, plug it here (account/sender id → BusinessId).
//                // Without a resolver, return null to fall back.
//                // Example (pseudo):
//                // if (string.Equals(providerHint, "pinnacle", StringComparison.OrdinalIgnoreCase))
//                // {
//                //     var accountId = TryExtractAccountId(value);
//                //     var biz = await _pinnacleTenantResolver.ResolveAsync(accountId);
//                //     if (biz.HasValue) return ("pinnacle", biz.Value);
//                // }
//            }

//            return null;
//        }

//        private async Task HandleStatusesWithUpdaterAsync(Guid businessId, string provider, JsonElement statuses)
//        {
//            for (int i = 0; i < statuses.GetArrayLength(); i++)
//            {
//                var s = statuses[i];
//                if (s.ValueKind != JsonValueKind.Object) continue;

//                // id (provider message id)
//                string? msgId = null;
//                if (s.TryGetProperty("id", out var idEl) && idEl.ValueKind == JsonValueKind.String)
//                    msgId = idEl.GetString();

//                // status (string)
//                string? rawStatus = null;
//                if (s.TryGetProperty("status", out var stEl) && stEl.ValueKind == JsonValueKind.String)
//                    rawStatus = stEl.GetString();

//                // timestamp (epoch seconds in string commonly)
//                DateTimeOffset? eventTime = null;
//                if (s.TryGetProperty("timestamp", out var tsEl))
//                {
//                    if (tsEl.ValueKind == JsonValueKind.String && long.TryParse(tsEl.GetString(), out var epoch))
//                        eventTime = DateTimeOffset.FromUnixTimeSeconds(epoch);
//                    else if (tsEl.ValueKind == JsonValueKind.Number && tsEl.TryGetInt64(out var epochNum))
//                        eventTime = DateTimeOffset.FromUnixTimeSeconds(epochNum);
//                }

//                if (string.IsNullOrWhiteSpace(msgId) || string.IsNullOrWhiteSpace(rawStatus))
//                    continue;

//                await _statusUpdater.UpdateAsync(new xbytechat.api.Features.Webhooks.Status.UpdateMessageStatusRequest
//                {
//                    BusinessId = businessId,
//                    Provider = provider,
//                    MessageId = msgId!,
//                    RawStatus = rawStatus!,
//                    EventTime = eventTime,
//                    RawPayloadJson = s.GetRawText()
//                });
//            }
//        }

//        #endregion


//    }
//}


////using Microsoft.EntityFrameworkCore;
////using Microsoft.Extensions.Logging;
////using System;
////using System.Text.Json;
////using System.Threading.Tasks;
////using xbytechat.api.Features.CampaignTracking.Models;
////using xbytechat.api.Features.Webhooks.Services.Resolvers;

////namespace xbytechat.api.Features.Webhooks.Services.Processors
////{
////    public class StatusWebhookProcessor : IStatusWebhookProcessor
////    {
////        private readonly AppDbContext _context;
////        private readonly ILogger<StatusWebhookProcessor> _logger;
////        private readonly IMessageIdResolver _messageIdResolver; // ✅ Injected resolver

////        public StatusWebhookProcessor(
////            AppDbContext context,
////            ILogger<StatusWebhookProcessor> logger,
////            IMessageIdResolver messageIdResolver) // ✅ Accept resolver in constructor
////        {
////            _context = context;
////            _logger = logger;
////            _messageIdResolver = messageIdResolver;
////        }

////        // 🔄 Extract statuses from the payload and route them to log resolver
////        public async Task ProcessAsync(JsonElement value)
////        {
////            if (!value.TryGetProperty("statuses", out var statuses))
////            {
////                _logger.LogWarning("⚠️ 'statuses' field missing in webhook payload.");
////                return;
////            }

////            foreach (var status in statuses.EnumerateArray())
////            {
////                var messageId = status.GetProperty("id").GetString();
////                var statusText = status.GetProperty("status").GetString();
////                //var timestamp = status.TryGetProperty("timestamp", out var ts) ? ts.GetInt64() : 0;
////                //var timestamp = status.TryGetProperty("timestamp", out var ts) ? ts.GetInt64() : 0;

////                long timestamp = 0;

////                if (status.TryGetProperty("timestamp", out var ts))
////                {
////                    if (ts.ValueKind == JsonValueKind.String && long.TryParse(ts.GetString(), out var parsed))
////                    {
////                        timestamp = parsed;
////                    }
////                    else if (ts.ValueKind == JsonValueKind.Number)
////                    {
////                        timestamp = ts.GetInt64();
////                    }
////                }

////                var time = DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
////                _logger.LogDebug("🕓 Parsed timestamp: {0} from raw type: {1}", timestamp, ts.ValueKind);
////                // ✅ Resolve the correct CampaignSendLog ID using the new resolver
////                var logId = await _messageIdResolver.ResolveCampaignSendLogIdAsync(messageId);

////                if (logId == null)
////                {
////                    _logger.LogWarning($"⚠️ No matching CampaignSendLog for MessageId: {messageId}");
////                    continue;
////                }

////                // 🔍 Now load the row by resolved ID
////                var log = await _context.CampaignSendLogs.FirstOrDefaultAsync(l => l.Id == logId.Value);
////                if (log != null)
////                {
////                    log.SendStatus = statusText switch
////                    {
////                        "sent" => "Sent",
////                        "delivered" => "Delivered",
////                        "read" => "Read",
////                        _ => log.SendStatus
////                    };

////                    if (statusText == "delivered") log.DeliveredAt = time;
////                    if (statusText == "read") log.ReadAt = time;

////                    await _context.SaveChangesAsync();
////                    _logger.LogInformation($"✅ CampaignSendLog updated for MessageId: {messageId} → {statusText}");
////                }
////            }
////        }

////        // 🔁 Entry point from webhook dispatcher
////        public async Task ProcessStatusUpdateAsync(JsonElement payload)
////        {
////            _logger.LogWarning("🔍 Incoming timestamp raw value: {0}", payload.ToString());
////            var entry = payload.GetProperty("entry")[0];
////            var changes = entry.GetProperty("changes")[0];
////            var value = changes.GetProperty("value");

////            await ProcessAsync(value); // ✅ Unified internal call
////        }
////    }
////}
