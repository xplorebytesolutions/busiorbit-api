using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using xbytechat.api.Features.Webhooks.Services.Processors;
using static System.Net.Mime.MediaTypeNames;

namespace xbytechat.api.Features.Webhooks.Services
{
    /// <summary>
    /// Central dispatcher for WhatsApp webhook events.
    /// Routes payloads to the appropriate processor based on payload type.
    /// </summary>
    public class WhatsAppWebhookDispatcher : IWhatsAppWebhookDispatcher
    {
        private readonly IStatusWebhookProcessor _statusProcessor;
        private readonly ITemplateWebhookProcessor _templateProcessor;
        private readonly ILogger<WhatsAppWebhookDispatcher> _logger;
        private readonly IClickWebhookProcessor _clickProcessor;
        private readonly IInboundMessageProcessor _inboundMessageProcessor;
        public WhatsAppWebhookDispatcher(
            IStatusWebhookProcessor statusProcessor,
            ITemplateWebhookProcessor templateProcessor,
            ILogger<WhatsAppWebhookDispatcher> logger,
            IClickWebhookProcessor clickProcessor,
            IInboundMessageProcessor inboundMessageProcessor)
        {
            _statusProcessor = statusProcessor;
            _templateProcessor = templateProcessor;
            _logger = logger;
            _clickProcessor = clickProcessor;
            _inboundMessageProcessor = inboundMessageProcessor;
        }


        //public async Task DispatchAsync(JsonElement payload)
        //{
        //    //throw new Exception("🧪 Simulated webhook dispatch failure for testing.");
        //    _logger.LogWarning("📦 Dispatcher Raw Payload:\n" + payload.ToString());
        //    try
        //    {
        //        if (!payload.TryGetProperty("entry", out var entries)) return;

        //        foreach (var entry in entries.EnumerateArray())
        //        {
        //            if (!entry.TryGetProperty("changes", out var changes)) continue;

        //            foreach (var change in changes.EnumerateArray())
        //            {
        //                if (!change.TryGetProperty("value", out var value)) continue;

        //                // 📨 Status Updates
        //                if (value.TryGetProperty("statuses", out _))
        //                {
        //                    _logger.LogInformation("📦 Routing to Status Processor");
        //                    await _statusProcessor.ProcessStatusUpdateAsync(payload);
        //                    continue;
        //                }

        //                // 🧾 Template Events
        //                if (value.TryGetProperty("event", out var eventType)
        //                    && eventType.GetString()?.StartsWith("template_") == true)
        //                {
        //                    _logger.LogInformation("📦 Routing to Template Processor");
        //                    await _templateProcessor.ProcessTemplateUpdateAsync(payload);
        //                    continue;
        //                }

        //                // 🎯 Click Events
        //                if (value.TryGetProperty("messages", out var messages)
        //                    && messages.GetArrayLength() > 0
        //                    && messages[0].TryGetProperty("type", out var type)
        //                    && type.GetString() == "button")
        //                {
        //                    _logger.LogInformation("👉 Routing to Click Processor");
        //                    await _clickProcessor.ProcessClickAsync(value);
        //                    continue;
        //                }
        //                // 📥 Inbound text/image/audio messages from customer
        //                if (value.TryGetProperty("messages", out var messages) &&
        //                    messages.GetArrayLength() > 0 &&
        //                    messages[0].TryGetProperty("type", out var typeProp))
        //                {
        //                    var type = typeProp.GetString();

        //                    if (type is "text" or "image" or "audio")
        //                    {
        //                        _logger.LogInformation("💬 Routing to InboundMessageProcessor (type: {Type})", type);
        //                        await _inboundProcessor.ProcessAsync(value);
        //                        continue;
        //                    }
        //                }

        //                _logger.LogWarning("⚠️ No matching event processor found.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "❌ Dispatcher failed to process WhatsApp webhook.");
        //    }
        //}

        //public async Task DispatchAsync(JsonElement payload)
        //{
        //    //clickMessages for button clicks
        //    // inboundMessages for text / image / audio

        //    _logger.LogWarning("📦 Dispatcher Raw Payload:\n" + payload.ToString());

        //    try
        //    {
        //        if (!payload.TryGetProperty("entry", out var entries)) return;

        //        foreach (var entry in entries.EnumerateArray())
        //        {
        //            if (!entry.TryGetProperty("changes", out var changes)) continue;

        //            foreach (var change in changes.EnumerateArray())
        //            {
        //                if (!change.TryGetProperty("value", out var value)) continue;

        //                // 📨 Status Updates
        //                if (value.TryGetProperty("statuses", out _))
        //                {
        //                    _logger.LogInformation("📦 Routing to Status Processor");
        //                    await _statusProcessor.ProcessStatusUpdateAsync(payload);
        //                    continue;
        //                }

        //                // 🧾 Template Events
        //                if (value.TryGetProperty("event", out var eventType)
        //                    && eventType.GetString()?.StartsWith("template_") == true)
        //                {
        //                    _logger.LogInformation("📦 Routing to Template Processor");
        //                    await _templateProcessor.ProcessTemplateUpdateAsync(payload);
        //                    continue;
        //                }

        //                // 🎯 Click Events (button type)
        //                if (value.TryGetProperty("messages", out var clickMessages)
        //                    && clickMessages.GetArrayLength() > 0
        //                    && clickMessages[0].TryGetProperty("type", out var clickType)
        //                    && clickType.GetString() == "button")
        //                {
        //                    _logger.LogInformation("👉 Routing to Click Processor");
        //                    await _clickProcessor.ProcessClickAsync(value);
        //                    continue;
        //                }

        //                // 💬 Inbound Messages (text/image/audio)
        //                if (value.TryGetProperty("messages", out var inboundMessages)
        //                    && inboundMessages.GetArrayLength() > 0
        //                    && inboundMessages[0].TryGetProperty("type", out var inboundType))
        //                {
        //                    var type = inboundType.GetString();

        //                    if (type is "text" or "image" or "audio")
        //                    {
        //                        _logger.LogInformation("💬 Routing to InboundMessageProcessor (type: {Type})", type);
        //                        await _inboundMessageProcessor.ProcessChatAsync(value);
        //                        continue;
        //                    }
        //                }

        //                _logger.LogWarning("⚠️ No matching event processor found.");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "❌ Dispatcher failed to process WhatsApp webhook.");
        //    }
        //}
        public async Task DispatchAsync(JsonElement payload)
        {
            _logger.LogWarning("📦 Dispatcher Raw Payload:\n{Payload}", payload.ToString());

            try
            {
                if (!payload.TryGetProperty("entry", out var entries)) return;

                foreach (var entry in entries.EnumerateArray())
                {
                    if (!entry.TryGetProperty("changes", out var changes)) continue;

                    foreach (var change in changes.EnumerateArray())
                    {
                        if (!change.TryGetProperty("value", out var value)) continue;

                        // 📨 Status Updates
                        if (value.TryGetProperty("statuses", out _))
                        {
                            _logger.LogInformation("📦 Routing to Status Processor");
                            await _statusProcessor.ProcessStatusUpdateAsync(payload);
                            continue;
                        }

                        // 🧾 Template Events
                        if (value.TryGetProperty("event", out var eventType)
                            && eventType.GetString()?.StartsWith("template_") == true)
                        {
                            _logger.LogInformation("📦 Routing to Template Processor");
                            await _templateProcessor.ProcessTemplateUpdateAsync(payload);
                            continue;
                        }

                        // 🎯 Messages block
                        if (!value.TryGetProperty("messages", out var msgs) || msgs.GetArrayLength() == 0)
                        {
                            _logger.LogDebug("ℹ️ No 'messages' array present.");
                            continue;
                        }

                        foreach (var m in msgs.EnumerateArray())
                        {
                            if (!m.TryGetProperty("type", out var typeProp))
                            {
                                _logger.LogDebug("ℹ️ Message without 'type' field.");
                                continue;
                            }

                            var type = typeProp.GetString();

                            // (A) Legacy quick-reply button
                            if (type == "button")
                            {
                                _logger.LogInformation("👉 Routing to Click Processor (legacy 'button')");
                                await _clickProcessor.ProcessClickAsync(value);
                                continue;
                            }

                            // (B) Interactive: button_reply OR list_reply
                            if (type == "interactive" && m.TryGetProperty("interactive", out var interactive))
                            {
                                // button_reply
                                if (interactive.TryGetProperty("type", out var interactiveType) &&
                                    interactiveType.GetString() == "button_reply")
                                {
                                    _logger.LogInformation("👉 Routing to Click Processor (interactive/button_reply)");
                                    await _clickProcessor.ProcessClickAsync(value);
                                    continue;
                                }

                                // list_reply (list menu selections are also "clicks" in our flow)
                                if (interactive.TryGetProperty("list_reply", out _))
                                {
                                    _logger.LogInformation("👉 Routing to Click Processor (interactive/list_reply)");
                                    await _clickProcessor.ProcessClickAsync(value);
                                    continue;
                                }
                            }

                            // (C) Inbound plain message types
                            if (type is "text" or "image" or "audio")
                            {
                                _logger.LogInformation("💬 Routing to InboundMessageProcessor (type: {Type})", type);
                                await _inboundMessageProcessor.ProcessChatAsync(value);
                                continue;
                            }

                            _logger.LogDebug("ℹ️ Message type '{Type}' not handled by dispatcher.", type);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Dispatcher failed to process WhatsApp webhook.");
            }
        }

    }
}

