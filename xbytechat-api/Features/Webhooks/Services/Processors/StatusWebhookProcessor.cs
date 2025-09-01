using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using xbytechat.api.Features.CampaignTracking.Models;
using xbytechat.api.Features.Webhooks.Services.Resolvers;

namespace xbytechat.api.Features.Webhooks.Services.Processors
{
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

        // 🔄 Extract statuses from the payload and route them to log resolver
        public async Task ProcessAsync(JsonElement value)
        {
            if (!value.TryGetProperty("statuses", out var statuses))
            {
                _logger.LogWarning("⚠️ 'statuses' field missing in webhook payload.");
                return;
            }

            foreach (var status in statuses.EnumerateArray())
            {
                var messageId = status.GetProperty("id").GetString();
                var statusText = status.GetProperty("status").GetString();

                // timestamp parsing (works for string or number)
                long unix = 0;
                JsonValueKind? tsKind = null;
                if (status.TryGetProperty("timestamp", out var ts))
                {
                    tsKind = ts.ValueKind;
                    if (ts.ValueKind == JsonValueKind.String && long.TryParse(ts.GetString(), out var parsed))
                        unix = parsed;
                    else if (ts.ValueKind == JsonValueKind.Number)
                        unix = ts.GetInt64();
                }
                var time = unix > 0
                    ? DateTimeOffset.FromUnixTimeSeconds(unix).UtcDateTime
                    : DateTime.UtcNow;

                _logger.LogDebug("🕓 Parsed timestamp(s): {Unix} kind={Kind}", unix, tsKind?.ToString() ?? "n/a");

                // ✅ First try resolving a CampaignSendLog row via resolver
                var logId = await _messageIdResolver.ResolveCampaignSendLogIdAsync(messageId);

                if (logId != null)
                {
                    var log = await _context.CampaignSendLogs.FirstOrDefaultAsync(l => l.Id == logId.Value);
                    if (log != null)
                    {
                        // Normalize statuses to your app's values
                        log.SendStatus = statusText switch
                        {
                            "sent" => "Sent",
                            "delivered" => "Delivered",
                            "read" => "Read",
                            _ => log.SendStatus
                        };

                        if (statusText == "delivered") log.DeliveredAt = time;
                        if (statusText == "read") log.ReadAt = time;
                        // If provider reports "sent" late and we missed SentAt, keep it consistent
                        if (statusText == "sent" && log.SentAt == null) log.SentAt = time;

                        await _context.SaveChangesAsync();
                        _logger.LogInformation("✅ CampaignSendLog updated for MessageId: {MessageId} → {Status}", messageId, statusText);
                        continue; // done with this status item
                    }
                }

                // 🔁 Fallback: update MessageLogs (flow-driven sends) when there's no CampaignSendLog
                var msg = await _context.MessageLogs.FirstOrDefaultAsync(m => m.MessageId == messageId);
                if (msg != null)
                {
                    switch (statusText)
                    {
                        case "sent":
                            msg.Status = "Sent";
                            msg.SentAt ??= time;
                            break;
                        case "delivered":
                            msg.Status = "Delivered";
                            // keep SentAt if it was not set for some reason
                            msg.SentAt ??= time;
                            break;
                        case "read":
                            msg.Status = "Read";
                            msg.SentAt ??= time;
                            break;
                        default:
                            // leave as-is for unknown statuses
                            break;
                    }

                    await _context.SaveChangesAsync();
                    _logger.LogInformation("ℹ️ MessageLog updated for MessageId: {MessageId} → {Status}", messageId, statusText);
                }
                else
                {
                    // lower severity; common when a send failed before obtaining a message id
                    _logger.LogInformation("ⓘ No matching CampaignSendLog/MessageLog for MessageId: {MessageId}", messageId);
                }
            }
        }

        // 🔁 Entry point from webhook dispatcher
        public async Task ProcessStatusUpdateAsync(JsonElement payload)
        {
            _logger.LogDebug("status_webhook_in");

            if (payload.ValueKind == JsonValueKind.Object &&
                payload.TryGetProperty("entry", out var entry) &&
                entry.ValueKind == JsonValueKind.Array && entry.GetArrayLength() > 0 &&
                entry[0].TryGetProperty("changes", out var changes) &&
                changes.ValueKind == JsonValueKind.Array && changes.GetArrayLength() > 0 &&
                changes[0].TryGetProperty("value", out var valueFromEnvelope) &&
                valueFromEnvelope.ValueKind == JsonValueKind.Object)
            {
                await ProcessAsync(valueFromEnvelope);
                return;
            }

            if (payload.ValueKind == JsonValueKind.Object &&
                (payload.TryGetProperty("statuses", out _) || payload.TryGetProperty("messages", out _)))
            {
                await ProcessAsync(payload);
                return;
            }

            _logger.LogWarning("Unrecognized status payload shape.");
        }

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
//        private readonly IMessageIdResolver _messageIdResolver; // ✅ Injected resolver

//        public StatusWebhookProcessor(
//            AppDbContext context,
//            ILogger<StatusWebhookProcessor> logger,
//            IMessageIdResolver messageIdResolver) // ✅ Accept resolver in constructor
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
//                //var timestamp = status.TryGetProperty("timestamp", out var ts) ? ts.GetInt64() : 0;
//                //var timestamp = status.TryGetProperty("timestamp", out var ts) ? ts.GetInt64() : 0;

//                long timestamp = 0;

//                if (status.TryGetProperty("timestamp", out var ts))
//                {
//                    if (ts.ValueKind == JsonValueKind.String && long.TryParse(ts.GetString(), out var parsed))
//                    {
//                        timestamp = parsed;
//                    }
//                    else if (ts.ValueKind == JsonValueKind.Number)
//                    {
//                        timestamp = ts.GetInt64();
//                    }
//                }

//                var time = DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
//                _logger.LogDebug("🕓 Parsed timestamp: {0} from raw type: {1}", timestamp, ts.ValueKind);
//                // ✅ Resolve the correct CampaignSendLog ID using the new resolver
//                var logId = await _messageIdResolver.ResolveCampaignSendLogIdAsync(messageId);

//                if (logId == null)
//                {
//                    _logger.LogWarning($"⚠️ No matching CampaignSendLog for MessageId: {messageId}");
//                    continue;
//                }

//                // 🔍 Now load the row by resolved ID
//                var log = await _context.CampaignSendLogs.FirstOrDefaultAsync(l => l.Id == logId.Value);
//                if (log != null)
//                {
//                    log.SendStatus = statusText switch
//                    {
//                        "sent" => "Sent",
//                        "delivered" => "Delivered",
//                        "read" => "Read",
//                        _ => log.SendStatus
//                    };

//                    if (statusText == "delivered") log.DeliveredAt = time;
//                    if (statusText == "read") log.ReadAt = time;

//                    await _context.SaveChangesAsync();
//                    _logger.LogInformation($"✅ CampaignSendLog updated for MessageId: {messageId} → {statusText}");
//                }
//            }
//        }

//        // 🔁 Entry point from webhook dispatcher
//        public async Task ProcessStatusUpdateAsync(JsonElement payload)
//        {
//            _logger.LogWarning("🔍 Incoming timestamp raw value: {0}", payload.ToString());
//            var entry = payload.GetProperty("entry")[0];
//            var changes = entry.GetProperty("changes")[0];
//            var value = changes.GetProperty("value");

//            await ProcessAsync(value); // ✅ Unified internal call
//        }
//    }
//}
