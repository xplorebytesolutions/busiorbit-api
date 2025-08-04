using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace xbytechat.api.Features.Webhooks.Services
{
    public class WhatsAppWebhookService : IWhatsAppWebhookService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<WhatsAppWebhookService> _logger;

        public WhatsAppWebhookService(AppDbContext context, ILogger<WhatsAppWebhookService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task ProcessStatusUpdateAsync(JsonElement payload)
        {
            _logger.LogInformation("📦 Processing Webhook Status:\n" +
                JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true }));

            if (!payload.TryGetProperty("entry", out var entries))
            {
                _logger.LogWarning("⚠️ Payload missing 'entry' property.");
                return;
            }

            foreach (var entry in entries.EnumerateArray())
            {
                if (!entry.TryGetProperty("changes", out var changes)) continue;

                foreach (var change in changes.EnumerateArray())
                {
                    if (!change.TryGetProperty("value", out var value)) continue;

                    if (!value.TryGetProperty("statuses", out var statuses)) continue;

                    foreach (var status in statuses.EnumerateArray())
                    {
                        string? messageId = status.TryGetProperty("id", out var idProp) ? idProp.GetString() : null;
                        string? statusText = status.TryGetProperty("status", out var statusProp) ? statusProp.GetString() : null;
                        long timestamp = status.TryGetProperty("timestamp", out var tsProp) && tsProp.ValueKind == JsonValueKind.String
                                         && long.TryParse(tsProp.GetString(), out var parsedTs)
                                         ? parsedTs
                                         : (tsProp.ValueKind == JsonValueKind.Number ? tsProp.GetInt64() : 0);

                        if (string.IsNullOrEmpty(messageId) || string.IsNullOrEmpty(statusText))
                        {
                            _logger.LogWarning("⚠️ Missing messageId or statusText in webhook payload.");
                            continue;
                        }

                        var log = await _context.CampaignSendLogs
                            //.AsNoTracking()
                            .FirstOrDefaultAsync(l => l.MessageId == messageId);

                        if (log != null)
                        {
                            var time = DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;

                            //log.SendStatus = statusText switch
                            //{
                            //    "sent" => "Sent",
                            //    "delivered" => "Delivered",
                            //    "read" => "Read",
                            //    _ => log.SendStatus
                            //};

                            //if (statusText == "delivered") log.DeliveredAt = time;
                            //if (statusText == "read") log.ReadAt = time;

                            //await _context.SaveChangesAsync();
                            // 🔁 Avoid redundant updates
                            var newStatus = statusText switch
                            {
                                "sent" => "Sent",
                                "delivered" => "Delivered",
                                "read" => "Read",
                                _ => null
                            };

                            bool isUpdated = false;

                            if (!string.IsNullOrEmpty(newStatus) && log.SendStatus != newStatus)
                            {
                                log.SendStatus = newStatus;
                                isUpdated = true;
                            }

                            if (statusText == "delivered" && log.DeliveredAt == null)
                            {
                                log.DeliveredAt = time;
                                isUpdated = true;
                            }

                            if (statusText == "read" && log.ReadAt == null)
                            {
                                log.ReadAt = time;
                                isUpdated = true;
                            }

                            if (isUpdated)
                            {
                                await _context.SaveChangesAsync();
                                _logger.LogInformation($"✅ Log updated for MessageId: {messageId} → {newStatus}");
                            }
                            else
                            {
                                _logger.LogInformation($"🔁 Duplicate status '{statusText}' skipped for MessageId: {messageId}");
                            }

                            _logger.LogInformation($"✅ Log updated for MessageId: {messageId} → {statusText}");
                        }
                        else
                        {
                            _logger.LogWarning($"⚠️ No matching CampaignSendLog for MessageId: {messageId}");
                        }
                    }
                }
            }
        }

    }
}
