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
        private readonly IMessageIdResolver _messageIdResolver; // ✅ Injected resolver

        public StatusWebhookProcessor(
            AppDbContext context,
            ILogger<StatusWebhookProcessor> logger,
            IMessageIdResolver messageIdResolver) // ✅ Accept resolver in constructor
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
                //var timestamp = status.TryGetProperty("timestamp", out var ts) ? ts.GetInt64() : 0;
                //var timestamp = status.TryGetProperty("timestamp", out var ts) ? ts.GetInt64() : 0;

                long timestamp = 0;

                if (status.TryGetProperty("timestamp", out var ts))
                {
                    if (ts.ValueKind == JsonValueKind.String && long.TryParse(ts.GetString(), out var parsed))
                    {
                        timestamp = parsed;
                    }
                    else if (ts.ValueKind == JsonValueKind.Number)
                    {
                        timestamp = ts.GetInt64();
                    }
                }

                var time = DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
                _logger.LogDebug("🕓 Parsed timestamp: {0} from raw type: {1}", timestamp, ts.ValueKind);
                // ✅ Resolve the correct CampaignSendLog ID using the new resolver
                var logId = await _messageIdResolver.ResolveCampaignSendLogIdAsync(messageId);

                if (logId == null)
                {
                    _logger.LogWarning($"⚠️ No matching CampaignSendLog for MessageId: {messageId}");
                    continue;
                }

                // 🔍 Now load the row by resolved ID
                var log = await _context.CampaignSendLogs.FirstOrDefaultAsync(l => l.Id == logId.Value);
                if (log != null)
                {
                    log.SendStatus = statusText switch
                    {
                        "sent" => "Sent",
                        "delivered" => "Delivered",
                        "read" => "Read",
                        _ => log.SendStatus
                    };

                    if (statusText == "delivered") log.DeliveredAt = time;
                    if (statusText == "read") log.ReadAt = time;

                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"✅ CampaignSendLog updated for MessageId: {messageId} → {statusText}");
                }
            }
        }

        // 🔁 Entry point from webhook dispatcher
        public async Task ProcessStatusUpdateAsync(JsonElement payload)
        {
            _logger.LogWarning("🔍 Incoming timestamp raw value: {0}", payload.ToString());
            var entry = payload.GetProperty("entry")[0];
            var changes = entry.GetProperty("changes")[0];
            var value = changes.GetProperty("value");

            await ProcessAsync(value); // ✅ Unified internal call
        }
    }
}
