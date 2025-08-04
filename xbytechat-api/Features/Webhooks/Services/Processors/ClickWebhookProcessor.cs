using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO.Pipelines;
using System.Text.Json;
using System.Threading.Tasks;
using xbytechat.api;
using xbytechat.api.DTOs.Messages;
using xbytechat.api.Features.CampaignTracking.Models;
using xbytechat.api.Features.CTAFlowBuilder.Services;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat.api.Features.Tracking.DTOs;
using xbytechat.api.Features.Tracking.Models;
using xbytechat.api.Features.Tracking.Services;
using xbytechat.api.Features.Webhooks.Services.Resolvers;
using xbytechat.api.Helpers;
using xbytechat.api.Shared.TrackingUtils;

namespace xbytechat.api.Features.Webhooks.Services.Processors
{
    public class ClickWebhookProcessor : IClickWebhookProcessor
    {
        private readonly ILogger<ClickWebhookProcessor> _logger;
        private readonly IMessageIdResolver _messageIdResolver;
        private readonly ITrackingService _trackingService;
        private readonly AppDbContext _context;
        private readonly IMessageEngineService _messageEngine;
        private readonly ICTAFlowService _flowService;

        public ClickWebhookProcessor(
            ILogger<ClickWebhookProcessor> logger,
            IMessageIdResolver messageIdResolver,
            ITrackingService trackingService,
            AppDbContext context,
            IMessageEngineService messageEngine,
            ICTAFlowService flowService)
        {
            _logger = logger;
            _messageIdResolver = messageIdResolver;
            _trackingService = trackingService;
            _context = context;
            _messageEngine = messageEngine;
            _flowService = flowService;
        }


        //public async Task ProcessClickAsync(JsonElement value)
        //{
        //    _logger.LogWarning("📥 [ENTERED CLICK PROCESSOR]");

        //    try
        //    {
        //        _logger.LogWarning("📥 [DEBUG] Click processor entered with value: " + value.ToString());

        //        if (!value.TryGetProperty("messages", out var messages)) return;
        //        var message = messages[0];

        //        if (message.GetProperty("type").GetString() != "button") return;

        //        var clickMessageId = message.GetProperty("id").GetString();
        //        var originalMessageId = message.GetProperty("context").GetProperty("id").GetString();
        //        var from = message.GetProperty("from").GetString();
        //        var buttonText = message.GetProperty("button").GetProperty("text").GetString()?.Trim().ToLower();

        //        _logger.LogInformation("🖱️ Button Click ␦ From: {From}, ClickMsgId: {ClickId}, OriginalMsgId: {OrigId}, Text: {Text}",
        //            from, clickMessageId, originalMessageId, buttonText);

        //        Guid businessId = Guid.Empty;
        //        Guid? contactId = null;
        //        string contactPhone = from;
        //        Guid? campaignId = null;
        //        Guid? sendLogId = null;
        //        string sourceType = "catalog";
        //        Guid? sourceId = null;

        //        // 1️⃣ Try CampaignSendLog
        //        var campaignLog = await _context.CampaignSendLogs
        //            .Include(l => l.Campaign)
        //            .Include(l => l.Contact)
        //            .FirstOrDefaultAsync(l => l.MessageId == originalMessageId);

        //        if (campaignLog != null)
        //        {
        //            _logger.LogInformation("📊 CampaignSendLog matched via context.id");

        //            businessId = campaignLog.Campaign?.BusinessId ?? Guid.Empty;
        //            contactId = campaignLog.ContactId;
        //            contactPhone = campaignLog.Contact?.PhoneNumber ?? from;
        //            campaignId = campaignLog.CampaignId;
        //            sendLogId = campaignLog.Id;
        //            sourceType = "campaign";
        //            sourceId = campaignLog.CampaignId;

        //            // 🔁 Auto Follow-Up
        //            if (buttonText == "interested" &&
        //                !string.IsNullOrWhiteSpace(campaignLog.Campaign?.FollowUpTemplateId))
        //            {
        //                var followUpDto = new SimpleTemplateMessageDto
        //                {
        //                    BusinessId = businessId,
        //                    RecipientNumber = contactPhone,
        //                    TemplateName = campaignLog.Campaign.FollowUpTemplateId,
        //                    TemplateParameters = new() // Phase 1 → no variables
        //                };

        //                var result = await _messageEngine.SendTemplateMessageSimpleAsync(followUpDto);
        //                _logger.LogInformation(result.Success
        //                    ? "✅ Follow-up message sent successfully."
        //                    : $"❌ Follow-up failed: {result.Message}");
        //            }
        //        }
        //        else
        //        {
        //            _logger.LogWarning("⚠️ CampaignSendLog not found. Trying fallback to MessageLogs.");

        //            var log = await _context.MessageLogs
        //                .FirstOrDefaultAsync(m =>
        //                    m.MessageId == originalMessageId ||
        //                    m.Id.ToString() == originalMessageId ||
        //                    m.RawResponse.Contains(originalMessageId));

        //            if (log != null)
        //            {
        //                businessId = log.BusinessId;
        //                contactId = log.ContactId;
        //                contactPhone = log.RecipientNumber ?? from;
        //                sourceType = "flow";
        //                _logger.LogInformation("✅ Fallback matched MessageLog. BusinessId: {BusinessId}", businessId);
        //            }
        //            else
        //            {
        //                _logger.LogWarning("❌ Fallback to MessageLogs failed. No message found for: {OriginalId}", originalMessageId);
        //            }
        //        }

        //        if (businessId == Guid.Empty)
        //        {
        //            _logger.LogWarning("❌ TrackingLog failed: No BusinessId available for click.");
        //            return;
        //        }

        //        // 2️⃣ Save Tracking
        //        var dto = new TrackingLogDto
        //        {
        //            BusinessId = businessId,
        //            CampaignId = campaignId,
        //            CampaignSendLogId = sendLogId,
        //            ContactId = contactId,
        //            ContactPhone = contactPhone,
        //            MessageId = originalMessageId,
        //            MessageLogId = null,
        //            SourceType = sourceType,
        //            SourceId = sourceId,
        //            ButtonText = buttonText,
        //            CTAType = buttonText,
        //            ClickedVia = "webhook",
        //            ClickedAt = DateTime.UtcNow,
        //            Browser = "WhatsApp",
        //            IPAddress = "webhook",
        //            DeviceType = DeviceHelper.GetDeviceType("WhatsApp"),
        //            Country = await GeoHelper.GetCountryFromIP("webhook"),
        //            RawJson = value.ToString()
        //        };

        //        var resultLog = await _trackingService.LogCTAClickWithEnrichmentAsync(dto);
        //        _logger.LogInformation("📥 Tracking Result: {Result}", resultLog?.Message ?? "N/A");

        //        // 3️⃣ Match Flow → Trigger Next Step (if any)
        //        try
        //        {
        //            if (!string.IsNullOrWhiteSpace(dto.ButtonText))
        //            {
        //                var matchedStep = await _flowService.MatchStepByButtonAsync(
        //                    businessId,
        //                    dto.ButtonText.Trim().ToLower(),
        //                    "quick_reply",
        //                    campaignLog?.Campaign?.MessageTemplate ?? "",  // currentTemplateName
        //                    campaignId
        //                );

        //                if (matchedStep != null)
        //                {
        //                    ResponseResult sendResult;

        //                    switch (matchedStep.TemplateType?.ToLower())
        //                    {
        //                        case "image_template":
        //                            var imageDto = new ImageTemplateMessageDto
        //                            {
        //                                BusinessId = businessId,
        //                                RecipientNumber = contactPhone,
        //                                TemplateName = matchedStep.TemplateToSend,
        //                                LanguageCode = "en_US"
        //                            };
        //                            sendResult = await _messageEngine.SendImageTemplateMessageAsync(imageDto);
        //                            break;

        //                        case "text_template":
        //                            var textDto = new SimpleTemplateMessageDto
        //                            {
        //                                BusinessId = businessId,
        //                                RecipientNumber = contactPhone,
        //                                TemplateName = matchedStep.TemplateToSend,
        //                                TemplateParameters = new() // Phase 1 = No placeholders
        //                            };
        //                            sendResult = await _messageEngine.SendTemplateMessageSimpleAsync(textDto);
        //                            break;

        //                        default:
        //                            _logger.LogWarning("❌ Unsupported template type in flow step: {Type}", matchedStep.TemplateType);
        //                            return;
        //                    }

        //                    if (sendResult.Success)
        //                    {
        //                        _logger.LogInformation("⚡ CTA Flow matched! Sent template: {Template}", matchedStep.TemplateToSend);
        //                    }
        //                    else
        //                    {
        //                        _logger.LogWarning("❌ Failed to send matched CTA template: {Message}", sendResult.Message);
        //                    }
        //                }
        //                else
        //                {
        //                    _logger.LogInformation("🟡 No CTA Flow matched for button: {Text}", dto.ButtonText);
        //                }
        //            }
        //        }
        //        catch (Exception flowEx)
        //        {
        //            _logger.LogError(flowEx, "❌ CTA Flow trigger failed.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "❌ Failed to process button click.");
        //    }
        //}

        public async Task ProcessClickAsync(JsonElement value)
        {
            _logger.LogWarning("📥 [ENTERED CLICK PROCESSOR]");

            try
            {
                if (!value.TryGetProperty("messages", out var messages)) return;
                var message = messages[0];

                if (message.GetProperty("type").GetString() != "button") return;

                var clickMessageId = message.GetProperty("id").GetString();
                var originalMessageId = message.GetProperty("context").GetProperty("id").GetString();
                var from = message.GetProperty("from").GetString();
                var buttonText = message.GetProperty("button").GetProperty("text").GetString()?.Trim();

                _logger.LogInformation("🖱️ Button Click → From: {From}, ClickId: {ClickId}, OrigMsgId: {OrigId}, Text: {Text}",
                    from, clickMessageId, originalMessageId, buttonText);

                Guid businessId = Guid.Empty;
                Guid? contactId = null;
                string contactPhone = from;
                Guid? campaignId = null;
                Guid? sendLogId = null;
                string sourceType = "catalog";
                Guid? sourceId = null;

                // 1️⃣ Try CampaignSendLog
                var campaignLog = await _context.CampaignSendLogs
                    .Include(l => l.Campaign)
                    .Include(l => l.Contact)
                    .FirstOrDefaultAsync(l => l.MessageId == originalMessageId);

                if (campaignLog != null)
                {
                    _logger.LogInformation("📊 CampaignSendLog matched via context.id");

                    businessId = campaignLog.Campaign?.BusinessId ?? Guid.Empty;
                    contactId = campaignLog.ContactId;
                    contactPhone = campaignLog.Contact?.PhoneNumber ?? from;
                    campaignId = campaignLog.CampaignId;
                    sendLogId = campaignLog.Id;
                    sourceType = "campaign";
                    sourceId = campaignLog.CampaignId;
                }
                else
                {
                    var log = await _context.MessageLogs
                        .FirstOrDefaultAsync(m =>
                            m.MessageId == originalMessageId ||
                            m.Id.ToString() == originalMessageId ||
                            m.RawResponse.Contains(originalMessageId));

                    if (log != null)
                    {
                        businessId = log.BusinessId;
                        contactId = log.ContactId;
                        contactPhone = log.RecipientNumber ?? from;
                        sourceType = "flow";
                        _logger.LogInformation("✅ Fallback matched MessageLog. BusinessId: {BusinessId}", businessId);
                    }
                }

                if (businessId == Guid.Empty)
                {
                    _logger.LogWarning("❌ TrackingLog failed: No BusinessId available.");
                    return;
                }

                // 2️⃣ Save Click Log with enrichment
                var dto = new TrackingLogDto
                {
                    BusinessId = businessId,
                    CampaignId = campaignId,
                    CampaignSendLogId = sendLogId,
                    ContactId = contactId,
                    ContactPhone = contactPhone,
                    MessageId = originalMessageId,
                    MessageLogId = null,
                    SourceType = sourceType,
                    SourceId = sourceId,
                    ButtonText = buttonText,
                    CTAType = buttonText,
                    ClickedVia = "webhook",
                    ClickedAt = DateTime.UtcNow,
                    Browser = "WhatsApp",
                    IPAddress = "webhook",
                    DeviceType = DeviceHelper.GetDeviceType("WhatsApp"),
                    Country = await GeoHelper.GetCountryFromIP("webhook"),
                    RawJson = value.ToString()
                };

                var resultLog = await _trackingService.LogCTAClickWithEnrichmentAsync(dto);
                _logger.LogInformation("📥 Click Tracked → Result: {Msg}", resultLog?.Message ?? "N/A");

                // ✅ Extract TrackingLog.Id from result
                if (resultLog?.Success != true || resultLog.Data is not Guid trackingLogId)
                {
                    _logger.LogWarning("⚠️ Skipping flow execution: Tracking ID not found.");
                    return;
                }

                // 3️⃣ Match Flow Step and trigger flow
                if (!string.IsNullOrWhiteSpace(dto.ButtonText))
                {
                    var matchedStep = await _flowService.MatchStepByButtonAsync(
                        businessId,
                        dto.ButtonText.Trim(),
                        "quick_reply",
                        campaignLog?.Campaign?.MessageTemplate ?? "",
                        campaignId
                    );

                    if (matchedStep != null)
                    {
                        _logger.LogInformation("🔁 Matched CTA Step → {StepId}", matchedStep.Id);

                        await _flowService.ExecuteVisualFlowAsync(
                            businessId,
                            matchedStep.Id,
                            trackingLogId
                        );

                        _logger.LogInformation("⚡ Visual flow triggered via CTA click.");
                    }
                    else
                    {
                        _logger.LogInformation("🟡 No visual flow matched for this button: {Text}", dto.ButtonText);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Failed to process CTA button click.");
            }
        }

    }
}
