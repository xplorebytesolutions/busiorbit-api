using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.MessagesEngine.PayloadBuilders;
using xbytechat.api.Features.PlanManagement.Services;
using xbytechat.api.Helpers;
using xbytechat.api.Shared;
using xbytechat.api;
using xbytechat_api.WhatsAppSettings.Models;
using System.Text;
using xbytechat.api.Features.CampaignModule.DTOs;
using xbytechat.api.Features.CampaignTracking.Models;
using System.IO.Pipelines;
using System.Net.Http;
using xbytechat.api.Shared.utility;
//using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using xbytechat.api.Features.Inbox;
using xbytechat.api.Features.Inbox.Hubs;
using System.Text.Json;
using xbytechat.api.Features.Webhooks.Services.Resolvers;
using xbytechat.api.CRM.Interfaces;
using xbytechat.api.Features.MessageManagement.DTOs;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.ReportingModule.DTOs;


namespace xbytechat.api.Features.MessagesEngine.Services
{
    public class MessageEngineService : IMessageEngineService
    {
        private readonly AppDbContext _db;
        private readonly HttpClient _http;
        private readonly TextMessagePayloadBuilder _textBuilder;
        private readonly ImageMessagePayloadBuilder _imageBuilder;
        private readonly TemplateMessagePayloadBuilder _templateBuilder;
        private readonly CtaMessagePayloadBuilder _ctaBuilder;
        private readonly IPlanManager _planManager;
        private readonly IHubContext<InboxHub> _hubContext;
        private readonly IMessageIdResolver _messageIdResolver;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IContactService _contactService;
        // 🔄 Basic cache for WhatsApp settings to reduce DB load
        private static readonly Dictionary<Guid, (WhatsAppSettingEntity setting, DateTime expiresAt)> _settingsCache = new();

        public MessageEngineService(
            AppDbContext db,
            HttpClient http,
            TextMessagePayloadBuilder textBuilder,
            ImageMessagePayloadBuilder imageBuilder,
            TemplateMessagePayloadBuilder templateBuilder,
            CtaMessagePayloadBuilder ctaBuilder,
            IPlanManager planManager, IHubContext<InboxHub> hubContext, IMessageIdResolver messageIdResolver, IHttpContextAccessor httpContextAccessor,
            IContactService contactService
            )
        {
            _db = db;
            _http = http;
            _textBuilder = textBuilder;
            _imageBuilder = imageBuilder;
            _templateBuilder = templateBuilder;
            _ctaBuilder = ctaBuilder;
            _planManager = planManager;
            _hubContext = hubContext;
            _messageIdResolver = messageIdResolver;
            _httpContextAccessor = httpContextAccessor;
            _contactService = contactService;
               
        }

        public async Task<ResponseResult> SendToWhatsAppAsync(object payload, Guid businessId)
        {
            var settings = await GetBusinessWhatsAppSettingsAsync(businessId);
            var token = settings.ApiToken;
            var phoneId = settings.PhoneNumberId;
            var baseUrl = settings.ApiUrl?.TrimEnd('/') ?? "https://graph.facebook.com/v18.0";
            var url = $"{baseUrl}/{phoneId}/messages";

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Console.WriteLine("🚀 Final Payload:");
            Console.WriteLine(JsonConvert.SerializeObject(payload, Formatting.Indented));

            var response = await _http.SendAsync(request);
            // 🌐 Status
            Console.WriteLine($"Status: {(int)response.StatusCode} {response.ReasonPhrase}");

            // 📋 Headers
            Console.WriteLine("Headers:");
            foreach (var header in response.Headers)
            {
                Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
            }
            foreach (var header in response.Content.Headers)
            {
                Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
            }
            // 📦 Body (content)
            var body = await response.Content.ReadAsStringAsync();

            // ❌ Handle token errors or failure
            if (!response.IsSuccessStatusCode)
            {
                if (body.Contains("invalid_token") || body.Contains("Error validating access token"))
                {
                    return ResponseResult.ErrorInfo(
                        "❌ WhatsApp token has expired. Please update your token.",
                        "Access token expired",
                        body
                    );
                }

                return ResponseResult.ErrorInfo(
                    "❌ WhatsApp API returned an error.",
                    "API returned error",
                    body
                );
            }

            // ✅ Parse WAMID safely
            string? wamid = null;
            try
            {
                dynamic parsed = JsonConvert.DeserializeObject<dynamic>(body);
                wamid = parsed?.messages?[0]?.id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Failed to parse WAMID: " + ex.Message);
            }

            // ✅ Use object initializer style
            var result = ResponseResult.SuccessInfo("✅ Message sent successfully", data: null, raw: body);
            result.MessageId = wamid;
            return result;
        }
        public async Task<ResponseResult> SendTemplateMessageAsync(SendMessageDto dto)
        {
            try
            {
                Console.WriteLine($"📨 Sending template message to {dto.RecipientNumber} via BusinessId {dto.BusinessId}");

                // ✅ Validate message type
                if (dto.MessageType != MessageTypeEnum.Template)
                    return ResponseResult.ErrorInfo("Only template messages are supported in this method.");

                // ✅ Quota check
                var quotaCheck = await _planManager.CheckQuotaBeforeSendingAsync(dto.BusinessId);
                if (!quotaCheck.Success)
                {
                    Console.WriteLine($"❌ Quota check failed: {quotaCheck.Message}");
                    return quotaCheck;
                }

                // ✅ Build payload
                var payload = _templateBuilder.BuildPayload(dto);
                Console.WriteLine("🔧 Built WhatsApp payload:");
                Console.WriteLine(JsonConvert.SerializeObject(payload, Formatting.Indented));

                // 🚀 Send to WhatsApp API
                var sendResult = await SendToWhatsAppAsync(payload, dto.BusinessId);
                Console.WriteLine("✅ WhatsApp API response:");
                Console.WriteLine(JsonConvert.SerializeObject(sendResult, Formatting.Indented));

                // ✅ Build the rendered body before saving
                var resolvedBody = TemplateParameterHelper.FillPlaceholders(
                    dto.TemplateBody ?? "",
                    dto.TemplateParameters?.Values.ToList() ?? new List<string>()
                );

                // 📝 Log success
                var log = new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = dto.BusinessId,
                    RecipientNumber = dto.RecipientNumber,
                    MessageContent = dto.TemplateName ?? "N/A",
                    RenderedBody = resolvedBody,
                    MediaUrl = null,
                    Status = "Sent",
                    ErrorMessage = null,
                    RawResponse = JsonConvert.SerializeObject(sendResult),
                    CreatedAt = DateTime.UtcNow,
                    SentAt = DateTime.UtcNow,
                    CTAFlowConfigId = dto.CTAFlowConfigId,
                    CTAFlowStepId = dto.CTAFlowStepId,
                };

                await _db.MessageLogs.AddAsync(log);

                // 📉 Decrement remaining quota
                var planInfo = await _db.BusinessPlanInfos
                    .FirstOrDefaultAsync(p => p.BusinessId == dto.BusinessId);

                if (planInfo != null && planInfo.RemainingMessages > 0)
                {
                    planInfo.RemainingMessages -= 1;
                    planInfo.UpdatedAt = DateTime.UtcNow;
                }

                await _db.SaveChangesAsync();

                // 📡 Send real-time message to SignalR group
                await _hubContext.Clients
                    .Group($"business_{dto.BusinessId}")
                    .SendAsync("ReceiveMessage", new
                    {
                        Id = log.Id,
                        RecipientNumber = log.RecipientNumber,
                        MessageContent = log.RenderedBody,
                        MediaUrl = log.MediaUrl,
                        Status = log.Status,
                        CreatedAt = log.CreatedAt,
                        SentAt = log.SentAt
                    });

                return ResponseResult.SuccessInfo("✅ Template message sent successfully.", sendResult, log.RawResponse);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                var fullError = $"🧨 Error ID: {errorId}\n{ex}";

                Console.WriteLine(fullError);

                await _db.MessageLogs.AddAsync(new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = dto.BusinessId,
                    RecipientNumber = dto.RecipientNumber,
                    MessageContent = dto.TemplateName ?? "N/A",
                    RenderedBody = TemplateParameterHelper.FillPlaceholders(
                        dto.TemplateBody ?? "",
                        dto.TemplateParameters?.Values.ToList() ?? new List<string>()
                    ),
                    Status = "Failed",
                    ErrorMessage = ex.Message,
                    RawResponse = ex.ToString(),
                    CreatedAt = DateTime.UtcNow
                });

                await _db.SaveChangesAsync();

                return ResponseResult.ErrorInfo(
                    $"❌ Exception occurred while sending template message. [Ref: {errorId}]",
                    ex.ToString()
                );
            }
        }

        private async Task<WhatsAppSettingEntity> GetBusinessWhatsAppSettingsAsync(Guid businessId)
        {
            if (_settingsCache.TryGetValue(businessId, out var cached) && cached.expiresAt > DateTime.UtcNow)
                return cached.setting;

            var business = await _db.Businesses
                .Include(b => b.WhatsAppSettings)
                .FirstOrDefaultAsync(b => b.Id == businessId);

            if (business == null || business.WhatsAppSettings == null)
                throw new Exception("WhatsApp settings not found.");

            _settingsCache[businessId] = (business.WhatsAppSettings, DateTime.UtcNow.AddMinutes(5));
            return business.WhatsAppSettings;
        }

           public async Task<ResponseResult> SendTextDirectAsync(TextMessageSendDto dto)
        {
            try
            {
                 //✅ Resolve business ID from context
                var businessId = _httpContextAccessor.HttpContext?.User?.GetBusinessId()
                     ?? throw new UnauthorizedAccessException("❌ Cannot resolve BusinessId from context.");


                // 🔍 Optionally associate with Contact
                Guid? contactId = null;
                try
                {
                    var contact = await _contactService.FindOrCreateAsync(businessId, dto.RecipientNumber);
                    contactId = contact.Id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Failed to resolve or create contact: {ex.Message}");
                }

                // ✅ Step 1: Build WhatsApp payload
                var payload = new
                {
                    messaging_product = "whatsapp",
                    to = dto.RecipientNumber,
                    type = "text",
                    text = new
                    {
                        preview_url = false,
                        body = dto.TextContent
                    }
                };

                Console.WriteLine("✅ WhatsApp Text Payload:");
                Console.WriteLine(JsonConvert.SerializeObject(payload, Formatting.Indented));

                // ✅ Step 2: Send to WhatsApp
                var sendResult = await SendToWhatsAppAsync(payload, businessId);

                // ✅ Step 3: Extract MessageId from response
                string? messageId = null;
                var raw = sendResult?.RawResponse;

                if (!string.IsNullOrWhiteSpace(raw))
                {
                    try
                    {
                        if (raw.TrimStart().StartsWith("{"))
                        {
                            var parsed = JsonDocument.Parse(raw);
                            if (parsed.RootElement.TryGetProperty("messages", out var messages) && messages.GetArrayLength() > 0)
                            {
                                messageId = messages[0].GetProperty("id").GetString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️ JSON parsing failed: {ex.Message} | Raw: {raw}");
                    }
                }

                // ✅ Step 4: Save MessageLog
                var log = new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = businessId,
                    RecipientNumber = dto.RecipientNumber,
                    MessageContent = dto.TextContent,
                    RenderedBody = dto.TextContent,
                    ContactId = contactId,
                    MediaUrl = null,
                    Status = "Sent",
                    ErrorMessage = null,
                    RawResponse = JsonConvert.SerializeObject(sendResult),
                    CreatedAt = DateTime.UtcNow,
                    SentAt = DateTime.UtcNow,
                    MessageId = messageId
                };

                await _db.MessageLogs.AddAsync(log);
                await _db.SaveChangesAsync();

                // ✅ Step 5: Optional campaign log mapping
                Guid? campaignSendLogId = null;
                if (dto.Source == "campaign" && !string.IsNullOrEmpty(messageId))
                {
                    try
                    {
                        campaignSendLogId = await _messageIdResolver.ResolveCampaignSendLogIdAsync(messageId);
                        Console.WriteLine($"📦 CampaignSendLog resolved: {campaignSendLogId}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️ Failed to resolve campaign log for {messageId}: {ex.Message}");
                    }
                }

                // ✅ Step 6: Return structured result
                return new ResponseResult
                {
                    Success = true,
                    Message = "✅ Text message sent successfully.",
                    Data = new
                    {
                        Success = true,
                        MessageId = messageId,
                        LogId = log.Id,
                        CampaignSendLogId = campaignSendLogId
                    },
                    RawResponse = JsonConvert.SerializeObject(sendResult),
                    MessageId = messageId,
                    LogId = log.Id
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception in SendTextDirectAsync: {ex.Message}");

                // ❌ Log failed attempt with partial context
                try
                {
                    var businessId = _httpContextAccessor.HttpContext?.User?.GetBusinessId()
                               ?? throw new UnauthorizedAccessException("❌ Cannot resolve BusinessId in failure path.");

                    await _db.MessageLogs.AddAsync(new MessageLog
                    {
                        Id = Guid.NewGuid(),
                        BusinessId = businessId,
                        RecipientNumber = dto.RecipientNumber,
                        MessageContent = dto.TextContent,
                        Status = "Failed",
                        ErrorMessage = ex.Message,
                        CreatedAt = DateTime.UtcNow
                    });

                    await _db.SaveChangesAsync();
                }
                catch (Exception logEx)
                {
                    Console.WriteLine($"❌ Failed to log failure to DB: {logEx.Message}");
                }

                return ResponseResult.ErrorInfo("❌ Failed to send text message.", ex.ToString());
            }
        }
        public async Task<ResponseResult> SendAutomationReply(TextMessageSendDto dto)
        {
            try
            {
                // ✅ Resolve business ID from DTO or claims
                var businessId = (dto.BusinessId != Guid.Empty)
                    ? dto.BusinessId
                    : _httpContextAccessor.HttpContext?.User?.GetBusinessId()
                      ?? throw new UnauthorizedAccessException("❌ Cannot resolve BusinessId from context or DTO.");

                // 🔍 Optionally associate with Contact
                Guid? contactId = null;
                try
                {
                    var contact = await _contactService.FindOrCreateAsync(businessId, dto.RecipientNumber);
                    contactId = contact.Id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Failed to resolve or create contact: {ex.Message}");
                }

                // ✅ Step 1: Build WhatsApp payload
                var payload = new
                {
                    messaging_product = "whatsapp",
                    to = dto.RecipientNumber,
                    type = "text",
                    text = new
                    {
                        preview_url = false,
                        body = dto.TextContent
                    }
                };

                Console.WriteLine("✅ WhatsApp Text Payload:");
                Console.WriteLine(JsonConvert.SerializeObject(payload, Formatting.Indented));

                // ✅ Step 2: Send to WhatsApp
                var sendResult = await SendToWhatsAppAsync(payload, businessId);

                // ✅ Step 3: Extract MessageId from response
                string? messageId = null;
                var raw = sendResult?.RawResponse;

                if (!string.IsNullOrWhiteSpace(raw))
                {
                    try
                    {
                        if (raw.TrimStart().StartsWith("{"))
                        {
                            var parsed = JsonDocument.Parse(raw);
                            if (parsed.RootElement.TryGetProperty("messages", out var messages) && messages.GetArrayLength() > 0)
                            {
                                messageId = messages[0].GetProperty("id").GetString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️ JSON parsing failed: {ex.Message} | Raw: {raw}");
                    }
                }

                // ✅ Step 4: Save MessageLog
                var log = new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = businessId,
                    RecipientNumber = dto.RecipientNumber,
                    MessageContent = dto.TextContent,
                    RenderedBody = dto.TextContent,
                    ContactId = contactId,
                    MediaUrl = null,
                    Status = "Sent",
                    ErrorMessage = null,
                    RawResponse = JsonConvert.SerializeObject(sendResult),
                    CreatedAt = DateTime.UtcNow,
                    SentAt = DateTime.UtcNow,
                    MessageId = messageId
                };

                await _db.MessageLogs.AddAsync(log);
                await _db.SaveChangesAsync();

                // ✅ Step 5: Optional campaign log mapping
                Guid? campaignSendLogId = null;
                if (dto.Source == "campaign" && !string.IsNullOrEmpty(messageId))
                {
                    try
                    {
                        campaignSendLogId = await _messageIdResolver.ResolveCampaignSendLogIdAsync(messageId);
                        Console.WriteLine($"📦 CampaignSendLog resolved: {campaignSendLogId}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️ Failed to resolve campaign log for {messageId}: {ex.Message}");
                    }
                }

                // ✅ Step 6: Return structured result
                return new ResponseResult
                {
                    Success = true,
                    Message = "✅ Text message sent successfully.",
                    Data = new
                    {
                        Success = true,
                        MessageId = messageId,
                        LogId = log.Id,
                        CampaignSendLogId = campaignSendLogId
                    },
                    RawResponse = JsonConvert.SerializeObject(sendResult),
                    MessageId = messageId,
                    LogId = log.Id
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception in SendAutomationReply: {ex.Message}");

                // ❌ Log failed attempt with partial context
                try
                {
                    var businessId = (dto.BusinessId != Guid.Empty)
                        ? dto.BusinessId
                        : _httpContextAccessor.HttpContext?.User?.GetBusinessId()
                          ?? throw new UnauthorizedAccessException("❌ Cannot resolve BusinessId in failure path.");

                    await _db.MessageLogs.AddAsync(new MessageLog
                    {
                        Id = Guid.NewGuid(),
                        BusinessId = businessId,
                        RecipientNumber = dto.RecipientNumber,
                        MessageContent = dto.TextContent,
                        Status = "Failed",
                        ErrorMessage = ex.Message,
                        CreatedAt = DateTime.UtcNow
                    });

                    await _db.SaveChangesAsync();
                }
                catch (Exception logEx)
                {
                    Console.WriteLine($"❌ Failed to log failure to DB: {logEx.Message}");
                }

                return ResponseResult.ErrorInfo("❌ Failed to send text message.", ex.ToString());
            }
        }


        //public async Task<ResponseResult> SendTemplateMessageSimpleAsync(SimpleTemplateMessageDto dto)
        //{
        //    try
        //    {
        //        // ✅ Build WhatsApp template payload with body only
        //        var payload = new
        //        {
        //            messaging_product = "whatsapp",
        //            to = dto.RecipientNumber,
        //            type = "template",
        //            template = new
        //            {
        //                name = dto.TemplateName,
        //                language = new { code = "en_US" },
        //                components = new[]
        //                {
        //            new
        //            {
        //                type = "body",
        //                parameters = dto.TemplateParameters.Select(p => new
        //                {
        //                    type = "text",
        //                    text = p
        //                }).ToArray()
        //            }
        //        }
        //            }
        //        };

        //        Console.WriteLine("📦 Template Payload (no buttons):");
        //        Console.WriteLine(JsonConvert.SerializeObject(payload, Formatting.Indented));

        //        var sendResult = await SendToWhatsAppAsync(payload, dto.BusinessId);

        //        // ✅ Log success
        //        var log = new MessageLog
        //        {
        //            Id = Guid.NewGuid(),
        //            BusinessId = dto.BusinessId,
        //            RecipientNumber = dto.RecipientNumber,
        //            MessageContent = dto.TemplateName,
        //            RenderedBody = TemplateParameterHelper.FillPlaceholders(dto.TemplateBody ?? "", dto.TemplateParameters),

        //            MediaUrl = null,
        //            Status = "Sent", 
        //            ErrorMessage = null,
        //            RawResponse = JsonConvert.SerializeObject(sendResult),
        //            CreatedAt = DateTime.UtcNow,
        //            SentAt = DateTime.UtcNow,
        //            CTAFlowConfigId = dto.CTAFlowConfigId,
        //            CTAFlowStepId = dto.CTAFlowStepId,

        //        };

        //        await _db.MessageLogs.AddAsync(log);
        //        await _db.SaveChangesAsync();

        //        return ResponseResult.SuccessInfo("✅ Template sent successfully.", sendResult, log.RawResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        // ❌ Log failure
        //        // ❌ Log failure
        //        await _db.MessageLogs.AddAsync(new MessageLog
        //        {
        //            Id = Guid.NewGuid(),
        //            BusinessId = dto.BusinessId,
        //            RecipientNumber = dto.RecipientNumber,
        //            MessageContent = dto.TemplateName,

        //            RenderedBody = TemplateParameterHelper.FillPlaceholders(dto.TemplateBody ?? "", dto.TemplateParameters), // ✅ Add this
        //            Status = "Failed",
        //            ErrorMessage = ex.Message,
        //            CreatedAt = DateTime.UtcNow,
        //            CTAFlowConfigId = dto.CTAFlowConfigId,
        //            CTAFlowStepId = dto.CTAFlowStepId,
        //        });


        //        await _db.SaveChangesAsync();

        //        return ResponseResult.ErrorInfo("❌ Error sending template.", ex.ToString());
        //    }
        //}

        public async Task<ResponseResult> SendTemplateMessageSimpleAsync(Guid businessId, SimpleTemplateMessageDto dto)
        {
            try
            {
                var payload = new
                {
                    messaging_product = "whatsapp",
                    to = dto.RecipientNumber,
                    type = "template",
                    template = new
                    {
                        name = dto.TemplateName,
                        language = new { code = "en_US" },
                        components = new[]
                        {
                    new
                    {
                        type = "body",
                        parameters = dto.TemplateParameters.Select(p => new
                        {
                            type = "text",
                            text = p
                        }).ToArray()
                    }
                }
                    }
                };

                var sendResult = await SendToWhatsAppAsync(payload, businessId);

                var log = new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = businessId,
                    RecipientNumber = dto.RecipientNumber,
                    MessageContent = dto.TemplateName,
                    RenderedBody = TemplateParameterHelper.FillPlaceholders(dto.TemplateBody ?? "", dto.TemplateParameters),
                    Status = "Sent",
                    RawResponse = JsonConvert.SerializeObject(sendResult),
                    SentAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                };

                await _db.MessageLogs.AddAsync(log);
                await _db.SaveChangesAsync();

                return ResponseResult.SuccessInfo("✅ Template sent successfully.", sendResult);
            }
            catch (Exception ex)
            {
                var log = new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = businessId,
                    RecipientNumber = dto.RecipientNumber,
                    MessageContent = dto.TemplateName,
                    RenderedBody = TemplateParameterHelper.FillPlaceholders(dto.TemplateBody ?? "", dto.TemplateParameters),
                    Status = "Failed",
                    ErrorMessage = ex.Message,
                    CreatedAt = DateTime.UtcNow
                };

                await _db.MessageLogs.AddAsync(log);
                await _db.SaveChangesAsync();

                return ResponseResult.ErrorInfo("❌ Template send failed", ex.Message);
            }
        }

        public async Task<ResponseResult> SendImageCampaignAsync(Guid campaignId, Guid businessId, string sentBy)
        {
            try
            {
                var campaign = await _db.Campaigns
                    .Include(c => c.MultiButtons)
                    .FirstOrDefaultAsync(c => c.Id == campaignId && c.BusinessId == businessId);

                if (campaign == null)
                    return ResponseResult.ErrorInfo("❌ Campaign not found or unauthorized.");

                var recipients = await _db.CampaignRecipients
                    .Include(r => r.Contact)
                    .Where(r => r.CampaignId == campaignId && r.BusinessId == businessId)
                    .ToListAsync();

                if (recipients.Count == 0)
                    return ResponseResult.ErrorInfo("⚠️ No recipients assigned to this campaign.");

                // ✅ Early Validation (Avoid WhatsApp 400 errors)
                if (string.IsNullOrWhiteSpace(campaign.ImageCaption))
                    return ResponseResult.ErrorInfo("❌ Campaign caption (ImageCaption) is required.");

                var validButtons = campaign.MultiButtons
                    ?.Where(b => !string.IsNullOrWhiteSpace(b.Title))
                    .Select(b => new CtaButtonDto
                    {
                        Title = b.Title,
                        Value = b.Value
                    })
                    .ToList();

                if (validButtons == null || validButtons.Count == 0)
                    return ResponseResult.ErrorInfo("❌ At least one CTA button with a valid title is required.");

                int successCount = 0, failCount = 0;

                foreach (var recipient in recipients)
                {
                    if (recipient.Contact == null || string.IsNullOrWhiteSpace(recipient.Contact.PhoneNumber))
                    {
                        Console.WriteLine($"⚠️ Skipping invalid contact: {recipient.Id}");
                        failCount++;
                        continue;
                    }

                    var dto = new SendMessageDto
                    {
                        BusinessId = businessId,
                        RecipientNumber = recipient.Contact.PhoneNumber,
                        MessageType = MessageTypeEnum.Image,
                        MediaUrl = campaign.ImageUrl,
                        TextContent = campaign.MessageTemplate,
                        CtaButtons = validButtons,

                        // Tracking metadata
                        CampaignId = campaign.Id,
                        SourceModule = "image-campaign",
                        CustomerId = recipient.Contact.Id.ToString(),
                        CustomerName = recipient.Contact.Name,
                        CustomerPhone = recipient.Contact.PhoneNumber,
                        CTATriggeredFrom = "campaign"


                    };

                    var result = await SendImageWithCtaAsync(dto); // Central engine

                    var sendLog = new CampaignSendLog
                    {
                        Id = Guid.NewGuid(),
                        CampaignId = campaign.Id,
                        ContactId = recipient.Contact.Id,
                        RecipientId = recipient.Id,
                        MessageLogId = result?.LogId,
                        SendStatus = result.Success ? "Sent" : "Failed",
                        SentAt = DateTime.UtcNow,
                        CreatedBy = sentBy,
                        BusinessId = businessId,
                    };

                    await _db.CampaignSendLogs.AddAsync(sendLog);

                    if (result.Success) successCount++;
                    else failCount++;
                }

                await _db.SaveChangesAsync();

                return ResponseResult.SuccessInfo(
                    $"✅ Campaign sent.\n📤 Success: {successCount}, ❌ Failed: {failCount}"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error sending image campaign: {ex.Message}");
                return ResponseResult.ErrorInfo("❌ Unexpected error while sending image campaign.", ex.ToString());
            }
        }
                   
        public async Task<ResponseResult> SendImageWithCtaAsync(SendMessageDto dto)
        {
            try
            {
                Console.WriteLine($"📤 Sending image+CTA to {dto.RecipientNumber}");

                // ✅ Early validation: TextContent and at least one button
                if (string.IsNullOrWhiteSpace(dto.TextContent))
                    return ResponseResult.ErrorInfo("❌ Image message caption (TextContent) cannot be empty.");

                var validButtons = dto.CtaButtons?
                    .Where(b => !string.IsNullOrWhiteSpace(b.Title))
                    .Take(3)
                    .Select((btn, index) => new
                    {
                        type = "reply",
                        reply = new
                        {
                            id = $"btn_{index + 1}_{Guid.NewGuid().ToString("N").Substring(0, 8)}",
                            title = btn.Title
                        }
                    }).ToList();

                if (validButtons == null || validButtons.Count == 0)
                    return ResponseResult.ErrorInfo("❌ At least one CTA button with a valid title is required.");

                // 🧱 Build the payload
                var payload = new
                {
                    messaging_product = "whatsapp",
                    to = dto.RecipientNumber,
                    type = "interactive",
                    interactive = new
                    {
                        type = "button",
                        body = new { text = dto.TextContent },
                        action = new
                        {
                            buttons = validButtons
                        }
                    },
                    image = string.IsNullOrWhiteSpace(dto.MediaUrl) ? null : new
                    {
                        link = dto.MediaUrl
                    }
                };

                Console.WriteLine("📦 Final payload:");
                Console.WriteLine(JsonConvert.SerializeObject(payload, Formatting.Indented));

                // 🔁 Send to WhatsApp
                var sendResult = await SendToWhatsAppAsync(payload, dto.BusinessId);
                var rawJson = JsonConvert.SerializeObject(sendResult);

                // 📝 Log to DB
                var log = new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = dto.BusinessId,
                    RecipientNumber = dto.RecipientNumber,
                    MessageContent = dto.TextContent ?? "[Image with CTA]",
                    RenderedBody = dto.TextContent ?? "",
                    MediaUrl = dto.MediaUrl,
                    Status = "Sent",
                    RawResponse = rawJson,
                    CreatedAt = DateTime.UtcNow,
                    SentAt = DateTime.UtcNow,
                    CTAFlowConfigId = dto.CTAFlowConfigId,
                    CTAFlowStepId = dto.CTAFlowStepId,
                };

                await _db.MessageLogs.AddAsync(log);
                await _db.SaveChangesAsync();

                var response = ResponseResult.SuccessInfo("✅ Image+CTA message sent.", null, rawJson);
                response.MessageId = log.Id.ToString();
                response.LogId = log.Id;
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Exception in SendImageWithCtaAsync: " + ex.Message);

                await _db.MessageLogs.AddAsync(new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = dto.BusinessId,
                    RecipientNumber = dto.RecipientNumber,
                    MessageContent = dto.TextContent ?? "[Image CTA Failed]",
                    RenderedBody = dto.TextContent ?? "[Failed image CTA]",
                    Status = "Failed",
                    ErrorMessage = ex.Message,
                    RawResponse = ex.ToString(),
                    CreatedAt = DateTime.UtcNow,
                    CTAFlowConfigId = dto.CTAFlowConfigId,
                    CTAFlowStepId = dto.CTAFlowStepId,
                });

                await _db.SaveChangesAsync();

                return ResponseResult.ErrorInfo("❌ Failed to send image+CTA.", ex.ToString());
            }
        }

        //public async Task<ResponseResult> SendImageTemplateMessageAsync(ImageTemplateMessageDto dto)
        public async Task<ResponseResult> SendImageTemplateMessageAsync(ImageTemplateMessageDto dto, Guid businessId)
        {
            try
            {
                List<object> components = new List<object>();

                // ✅ Header (Image) component — optional
                if (!string.IsNullOrWhiteSpace(dto.HeaderImageUrl))
                {
                    components.Add(new
                    {
                        type = "header",
                        parameters = new[]
                        {
                    new
                    {
                        type = "image",
                        image = new
                        {
                            link = dto.HeaderImageUrl
                        }
                    }
                }
                    });
                }

                // ✅ Body (Template Parameters)
                components.Add(new
                {
                    type = "body",
                    parameters = dto.TemplateParameters.Select(p => new
                    {
                        type = "text",
                        text = p
                    }).ToArray()
                });

                // ✅ Buttons — dynamic (up to 3), skip invalid entries
                for (int i = 0; i < dto.ButtonParameters.Count && i < 3; i++)
                {
                    var btn = dto.ButtonParameters[i];
                    string subType = btn.ButtonType?.ToLower();

                    // 🛑 Skip if ButtonType or TargetUrl is missing
                    if (string.IsNullOrWhiteSpace(subType) || string.IsNullOrWhiteSpace(btn.TargetUrl))
                        continue;

                    var button = new Dictionary<string, object>
                    {
                        ["type"] = "button",
                        ["sub_type"] = subType,
                        ["index"] = i.ToString()
                    };

                    // 🧠 Add required parameters based on button subtype
                    if (subType == "quick_reply")
                    {
                        button["parameters"] = new[]
                        {
                    new
                    {
                        type = "payload",
                        payload = btn.TargetUrl
                    }
                };
                    }
                    else if (subType == "url")
                    {
                        button["parameters"] = new[]
                        {
                    new
                    {
                        type = "text",
                        text = btn.TargetUrl
                    }
                };
                    }
                    // ✅ Do not add parameters for phone/call type

                    components.Add(button);
                }

                // ✅ Final Payload
                var payload = new
                {
                    messaging_product = "whatsapp",
                    to = dto.RecipientNumber,
                    type = "template",
                    template = new
                    {
                        name = dto.TemplateName,
                        language = new
                        {
                            code = dto.LanguageCode ?? "en_US"
                        },
                        components = components
                    }
                };

                Console.WriteLine("📦 Sending Image Template Payload:");
                Console.WriteLine(JsonConvert.SerializeObject(payload, Formatting.Indented));

                // ✅ Send to WhatsApp API
                object sendResult = await SendToWhatsAppAsync(payload, businessId);
                // ✅ Prepare rendered body (new)
                var renderedBody = TemplateParameterHelper.FillPlaceholders(
                    dto.TemplateBody ?? "",
                    dto.TemplateParameters ?? new List<string>()
                );

                // ✅ Save log on success
                var log = new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = businessId,
                    RecipientNumber = dto.RecipientNumber,
                    MessageContent = dto.TemplateName,
                    MediaUrl = dto.HeaderImageUrl,
                    Status = "Sent",
                    ErrorMessage = null,
                    RawResponse = JsonConvert.SerializeObject(sendResult),
                    CreatedAt = DateTime.UtcNow,
                    SentAt = DateTime.UtcNow,
                    CTAFlowConfigId = dto.CTAFlowConfigId,
                    CTAFlowStepId = dto.CTAFlowStepId,


                };

                await _db.MessageLogs.AddAsync(log);
                await _db.SaveChangesAsync();

                return ResponseResult.SuccessInfo("✅ Image template sent successfully.", sendResult, log.RawResponse);
            }
            catch (Exception ex)
            {
                // 🛑 Log failure
                await _db.MessageLogs.AddAsync(new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = dto.BusinessId,
                    RecipientNumber = dto.RecipientNumber,
                    MessageContent = dto.TemplateName,
                    RenderedBody = TemplateParameterHelper.FillPlaceholders(dto.TemplateBody ?? "", dto.TemplateParameters),

                    MediaUrl = dto.HeaderImageUrl,
                    Status = "Failed",
                    ErrorMessage = ex.Message,
                    CreatedAt = DateTime.UtcNow,
                    CTAFlowConfigId = dto.CTAFlowConfigId,
                    CTAFlowStepId = dto.CTAFlowStepId,
                });

                await _db.SaveChangesAsync();
                return ResponseResult.ErrorInfo("❌ Error sending image template.", ex.ToString());
            }
        }
        public async Task<IEnumerable<RecentMessageLogDto>> GetLogsByBusinessIdAsync(Guid businessId)
        {
            var logs = await _db.MessageLogs
                .Where(m => m.BusinessId == businessId)
                .OrderByDescending(m => m.CreatedAt)
                .Take(1000)
                .Select(m => new RecentMessageLogDto
                {
                    Id = m.Id,
                    RecipientNumber = m.RecipientNumber,
                    MessageContent = m.MessageContent,
                    Status = m.Status,
                    CreatedAt = m.CreatedAt,
                    SentAt = m.SentAt,
                    ErrorMessage = m.ErrorMessage
                })
                .ToListAsync();

            return logs;
        }
    }

}

