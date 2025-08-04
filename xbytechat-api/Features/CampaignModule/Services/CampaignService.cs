using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Serilog;
using xbytechat.api.Features.CampaignModule.DTOs;
using xbytechat.api.Features.CampaignModule.Models;
using xbytechat.api.Shared;
using xbytechat.api.Features.CampaignTracking.Models;
using xbytechat.api.Services.Messages.Interfaces;
using xbytechat.api.DTOs.Messages;
using Microsoft.Extensions.DependencyInjection;
using xbytechat.api.Features.xbTimeline.Services;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat.api.CRM.Dtos;
using Newtonsoft.Json;
using xbytechat.api.Helpers;
using xbytechat_api.WhatsAppSettings.Services;
using xbytechat.api.Shared.utility;
using xbytechat.api.Features.MessagesEngine.PayloadBuilders;
using xbytechat.api.WhatsAppSettings.DTOs;
using xbytechat.api.Features.BusinessModule.Models;

namespace xbytechat.api.Features.CampaignModule.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly AppDbContext _context;
        private readonly IMessageService _messageService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILeadTimelineService _timelineService;
        private readonly IMessageEngineService _messageEngineService;
        private readonly IWhatsAppTemplateFetcherService _templateFetcherService;
        public CampaignService(AppDbContext context, IMessageService messageService,
                               IServiceProvider serviceProvider,
                               ILeadTimelineService timelineService,
                               IMessageEngineService messageEngineService,
                               IWhatsAppTemplateFetcherService templateFetcherService)
        {
            _context = context;
            _messageService = messageService;
            _serviceProvider = serviceProvider;
            _timelineService = timelineService; // ✅ new
            _messageEngineService = messageEngineService;
            _templateFetcherService = templateFetcherService;

        }


        #region Get All Types of Get and Update and Delete Methods

        public async Task<List<CampaignSummaryDto>> GetAllCampaignsAsync(Guid businessId)
        {
            return await _context.Campaigns
                .Where(c => c.BusinessId == businessId)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CampaignSummaryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Status = c.Status,
                    ScheduledAt = c.ScheduledAt,
                    CreatedAt = c.CreatedAt,

                })
                .ToListAsync();
        }
        public async Task<CampaignDto?> GetCampaignByIdAsync(Guid campaignId, Guid businessId)
        {
            var campaign = await _context.Campaigns
                .Include(c => c.Cta) // if CTA is stored in a separate table
                .Include(c => c.MultiButtons) // assuming EF Core relation
                .FirstOrDefaultAsync(c => c.Id == campaignId && c.BusinessId == businessId);

            if (campaign == null) return null;

            return new CampaignDto
            {
                Id = campaign.Id,
                Name = campaign.Name,
                MessageTemplate = campaign.MessageTemplate,
                MessageBody = campaign.MessageBody,
                TemplateId = campaign.TemplateId,
                CampaignType = campaign.CampaignType,
                Status = campaign.Status,
                ImageUrl = campaign.ImageUrl,
                ImageCaption = campaign.ImageCaption,
                CreatedAt = campaign.CreatedAt,
                ScheduledAt = campaign.ScheduledAt,
                CtaId = campaign.CtaId,
                Cta = campaign.Cta == null ? null : new CtaPreviewDto
                {
                    Title = campaign.Cta.Title,
                    ButtonText = campaign.Cta.ButtonText
                },
                MultiButtons = campaign.MultiButtons?
                    .Select(b => new CampaignButtonDto
                    {
                        ButtonText = b.Title,// ButtonText,
                        ButtonType = b.Type,//ButtonType,
                        TargetUrl = b.Value
                    }).ToList() ?? new List<CampaignButtonDto>()
            };
        }

        public async Task<List<CampaignSummaryDto>> GetAllCampaignsAsync(Guid businessId, string? type = null)
        {
            var query = _context.Campaigns
                .Where(c => c.BusinessId == businessId)
                .AsQueryable();

            if (!string.IsNullOrEmpty(type))
                query = query.Where(c => c.CampaignType == type);

            return await query
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CampaignSummaryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Status = c.Status,
                    ScheduledAt = c.ScheduledAt,
                    CreatedAt = c.CreatedAt,
                    ImageUrl = c.ImageUrl,            // ✅ Now mapped
                    ImageCaption = c.ImageCaption,    // ✅ Now mapped
                    CtaTitle = c.Cta != null ? c.Cta.Title : null,  // optional
                    RecipientCount = c.Recipients.Count()
                })
                .ToListAsync();
        }

        public async Task<List<ContactDto>> GetRecipientsByCampaignIdAsync(Guid campaignId, Guid businessId)
        {
            var recipients = await _context.CampaignRecipients
                .Include(r => r.Contact)
                .Where(r => r.CampaignId == campaignId && r.Contact.BusinessId == businessId)
                .Select(r => new ContactDto
                {
                    Id = r.Contact.Id,
                    Name = r.Contact.Name,
                    PhoneNumber = r.Contact.PhoneNumber,
                    Email = r.Contact.Email,
                    LeadSource = r.Contact.LeadSource,
                    CreatedAt = r.Contact.CreatedAt
                })
                .ToListAsync();

            return recipients;
        }

        public async Task<PaginatedResponse<CampaignSummaryDto>> GetPaginatedCampaignsAsync(Guid businessId, PaginatedRequest request)
        {
            var query = _context.Campaigns
                .Where(c => c.BusinessId == businessId)
                .OrderByDescending(c => c.CreatedAt);

            var total = await query.CountAsync();

            var items = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new CampaignSummaryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Status = c.Status,
                    ScheduledAt = c.ScheduledAt,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();

            return new PaginatedResponse<CampaignSummaryDto>
            {
                Items = items,
                TotalCount = total,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
        public async Task<bool> UpdateCampaignAsync(Guid id, CampaignCreateDto dto)
        {
            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign == null || campaign.Status != "Draft")
                return false;

            // ✅ Extract BusinessId from current campaign
            var businessId = campaign.BusinessId;

            // ✅ Optional CTA ownership validation
            if (dto.CtaId.HasValue)
            {
                var cta = await _context.CTADefinitions
                    .FirstOrDefaultAsync(c => c.Id == dto.CtaId && c.BusinessId == businessId && c.IsActive);

                if (cta == null)
                    throw new UnauthorizedAccessException("❌ The selected CTA does not belong to your business or is inactive.");
            }

            // ✏️ Update campaign fields
            campaign.Name = dto.Name;
            campaign.MessageTemplate = dto.MessageTemplate;
            campaign.TemplateId = dto.TemplateId;
            campaign.FollowUpTemplateId = dto.FollowUpTemplateId;
            campaign.CampaignType = dto.CampaignType;
            campaign.CtaId = dto.CtaId;
            campaign.ImageUrl = dto.ImageUrl;
            campaign.ImageCaption = dto.ImageCaption;
            campaign.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCampaignAsync(Guid id)
        {
            var campaign = await _context.Campaigns
                .Include(c => c.Recipients)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (campaign == null || campaign.Status != "Draft")
                return false;

            _context.CampaignRecipients.RemoveRange(campaign.Recipients);
            _context.Campaigns.Remove(campaign);

            await _context.SaveChangesAsync();
            Log.Information("🗑️ Campaign deleted: {Id}", id);
            return true;
        }

        #endregion

        #region // 🆕 CreateCampaignAsync(Text/Image)
        public async Task<Guid?> CreateTextCampaignAsync(CampaignCreateDto dto, Guid businessId, string createdBy)
        {
            try
            {
                var campaignId = Guid.NewGuid();

                // 🔁 Parse template parameters into list
                var parsedParams = TemplateParameterHelper.ParseTemplateParams(
                    JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>())
                );

                // 🧠 Fetch template (for body + buttons)
                var template = await _templateFetcherService.GetTemplateByNameAsync(businessId, dto.TemplateId, true);

                // 🧠 Fill message body
                var resolvedBody = TemplateParameterHelper.FillPlaceholders(
                    template?.Body ?? dto.MessageTemplate,
                    parsedParams
                );

                // ✅ Step 1: Create campaign object
                var campaign = new Campaign
                {
                    Id = campaignId,
                    BusinessId = businessId,
                    Name = dto.Name,
                    MessageTemplate = dto.MessageTemplate,
                    TemplateId = dto.TemplateId,
                    FollowUpTemplateId = dto.FollowUpTemplateId,
                    CampaignType = dto.CampaignType ?? "text",
                    CtaId = dto.CtaId,
                    ScheduledAt = dto.ScheduledAt,
                    CreatedBy = createdBy,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Status = "Draft",
                    ImageUrl = dto.ImageUrl,
                    ImageCaption = dto.ImageCaption,
                    TemplateParameters = JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>()),
                    MessageBody = resolvedBody // ✅ final resolved message
                };

                await _context.Campaigns.AddAsync(campaign);

                // ✅ Step 2: Assign contacts if provided
                if (dto.ContactIds != null && dto.ContactIds.Any())
                {
                    var recipients = dto.ContactIds.Select(contactId => new CampaignRecipient
                    {
                        Id = Guid.NewGuid(),
                        CampaignId = campaignId,
                        ContactId = contactId,
                        BusinessId = businessId,
                        Status = "Pending",
                        SentAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    });

                    await _context.CampaignRecipients.AddRangeAsync(recipients);
                }

                // ✅ Step 3a: Save manual buttons from frontend
                if (dto.MultiButtons != null && dto.MultiButtons.Any())
                {
                    var buttons = dto.MultiButtons
                        .Where(btn => !string.IsNullOrWhiteSpace(btn.ButtonText) && !string.IsNullOrWhiteSpace(btn.TargetUrl))
                        .Take(3)
                        .Select((btn, index) => new CampaignButton
                        {
                            Id = Guid.NewGuid(),
                            CampaignId = campaignId,
                            Title = btn.ButtonText,
                            Type = btn.ButtonType ?? "url",
                            Value = btn.TargetUrl,
                            Position = index + 1,
                            IsFromTemplate = false
                        });

                    await _context.CampaignButtons.AddRangeAsync(buttons);
                }

                // ✅ Step 3b: Save buttons auto-fetched from WhatsApp Template
                if (template != null && template.ButtonParams?.Count > 0)
                {
                    var autoButtons = template.ButtonParams
                        .Take(3)
                        .Select((btn, index) => new CampaignButton
                        {
                            Id = Guid.NewGuid(),
                            CampaignId = campaignId,
                            Title = btn.Text,
                            Type = btn.Type,
                            // Value = btn.SubType == "url" ? "https://your-redirect.com" : btn.SubType,
                            Value = btn.ParameterValue,
                            Position = index + 1,
                            IsFromTemplate = true
                        });

                    await _context.CampaignButtons.AddRangeAsync(autoButtons);
                }

                // ✅ Final Save
                await _context.SaveChangesAsync();

                Log.Information("✅ Campaign '{Name}' created with {Contacts} recipients, {ManualButtons} user buttons, {TemplateButtons} template buttons and {Params} template parameters",
                    dto.Name,
                    dto.ContactIds?.Count ?? 0,
                    dto.MultiButtons?.Count ?? 0,
                    template?.ButtonParams?.Count ?? 0,
                    dto.TemplateParameters?.Count ?? 0
                );

                return campaignId;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "❌ Failed to create campaign");
                return null;
            }
        }
        public async Task<Guid> CreateImageCampaignAsync(Guid businessId, CampaignCreateDto dto, string createdBy)
        {
            // 🔐 Optional CTA validation
            if (dto.CtaId.HasValue)
            {
                var cta = await _context.CTADefinitions
                    .FirstOrDefaultAsync(c => c.Id == dto.CtaId && c.BusinessId == businessId && c.IsActive);

                if (cta == null)
                    throw new UnauthorizedAccessException("❌ The selected CTA does not belong to your business or is inactive.");
            }

            // 🎯 Create campaign
            var campaign = new Campaign
            {
                Id = Guid.NewGuid(),
                BusinessId = businessId,
                Name = dto.Name,
                MessageTemplate = dto.MessageTemplate,
                TemplateId = dto.TemplateId,
                FollowUpTemplateId = dto.FollowUpTemplateId,
                CampaignType = "image",
                ImageUrl = dto.ImageUrl,
                ImageCaption = dto.ImageCaption,
                CtaId = dto.CtaId,
                CreatedBy = createdBy,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = "Draft"
            };

            await _context.Campaigns.AddAsync(campaign);

            // 🔘 Save manual buttons from UI
            if (dto.MultiButtons?.Any() == true)
            {
                var buttons = dto.MultiButtons
                    .Where(btn => !string.IsNullOrWhiteSpace(btn.ButtonText) && !string.IsNullOrWhiteSpace(btn.TargetUrl))
                    .Take(3)
                    .Select((btn, index) => new CampaignButton
                    {
                        Id = Guid.NewGuid(),
                        CampaignId = campaign.Id,
                        Title = btn.ButtonText,
                        Type = string.IsNullOrWhiteSpace(btn.ButtonType) ? "url" : btn.ButtonType,
                        Value = btn.TargetUrl,
                        Position = index + 1,
                        IsFromTemplate = false
                    }).ToList();

                if (buttons.Any())
                    await _context.CampaignButtons.AddRangeAsync(buttons);
            }

            // 🔘 Save template buttons (from Meta) with proper dynamic/static handling
            if (dto.ButtonParams?.Any() == true)
            {
                var templateButtons = dto.ButtonParams
                    .Where(btn => !string.IsNullOrWhiteSpace(btn.Text) && !string.IsNullOrWhiteSpace(btn.Type))
                    .Take(3)
                    .Select((btn, index) =>
                    {
                        var subType = btn.SubType?.ToLower();
                        var isDynamic = subType == "url" || subType == "flow" || subType == "copy_code";

                        // ✅ Prefer user-provided value if dynamic, fallback to Meta value
                        var userInput = dto.MultiButtons?.ElementAtOrDefault(index)?.TargetUrl?.Trim();
                        var valueToSave = isDynamic && !string.IsNullOrWhiteSpace(userInput)
                            ? userInput
                            : btn.Value;

                        return new CampaignButton
                        {
                            Id = Guid.NewGuid(),
                            CampaignId = campaign.Id,
                            Title = btn.Text,
                            Type = btn.Type,
                            Value = valueToSave,
                            Position = index + 1,
                            IsFromTemplate = true
                        };
                    })
                    .Where(btn => !string.IsNullOrWhiteSpace(btn.Value)) // ✅ Prevent null insert error
                    .ToList();

                if (templateButtons.Any())
                    await _context.CampaignButtons.AddRangeAsync(templateButtons);
            }

            await _context.SaveChangesAsync();
            return campaign.Id;
        }
        #endregion

        public async Task<bool> SendCampaignAsync(Guid campaignId, string ipAddress, string userAgent)
        {
            var campaign = await _context.Campaigns
                .Include(c => c.Recipients)
                .ThenInclude(r => r.Contact)
                .FirstOrDefaultAsync(c => c.Id == campaignId);

            if (campaign == null || campaign.Recipients.Count == 0)
            {
                Log.Warning("🚫 Campaign not found or has no recipients");
                return false;
            }

            campaign.Status = "Sending";
            campaign.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            int throttleLimit = 5;

            await Parallel.ForEachAsync(campaign.Recipients, new ParallelOptions { MaxDegreeOfParallelism = throttleLimit }, async (recipient, ct) =>
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var scopedDb = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    // 🟢 Use SimpleTemplateMessageDto instead of raw text
                    var dto = new SimpleTemplateMessageDto
                    {
                        RecipientNumber = recipient.Contact.PhoneNumber,
                        TemplateName = campaign.MessageTemplate,
                        TemplateParameters = new List<string> { recipient.Contact.Name ?? "Customer" }
                    };

                    var result = await _messageEngineService.SendTemplateMessageSimpleAsync(campaign.BusinessId, dto);

                    var sendLog = new CampaignSendLog
                    {
                        Id = Guid.NewGuid(),
                        CampaignId = campaign.Id,
                        ContactId = recipient.ContactId,
                        RecipientId = recipient.Id,
                        TemplateId = campaign.TemplateId,
                        MessageBody = campaign.MessageTemplate,
                        MessageId = null,
                        SendStatus = result.Success ? "Sent" : "Failed",
                        ErrorMessage = result.Message,
                        SentAt = DateTime.UtcNow,
                        CreatedAt = DateTime.UtcNow,
                        SourceChannel = "whatsapp",
                        IpAddress = ipAddress,
                        DeviceInfo = userAgent
                    };

                    scopedDb.CampaignSendLogs.Add(sendLog);

                    var recipientToUpdate = await scopedDb.CampaignRecipients.FirstOrDefaultAsync(r => r.Id == recipient.Id);
                    if (recipientToUpdate != null)
                    {
                        recipientToUpdate.Status = result.Success ? "Sent" : "Failed";
                        recipientToUpdate.MessagePreview = campaign.MessageTemplate;
                        recipientToUpdate.SentAt = DateTime.UtcNow;
                        recipientToUpdate.UpdatedAt = DateTime.UtcNow;
                    }

                    await scopedDb.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "❌ Send failed for recipient: {RecipientId}", recipient.Id);
                }
            });

            campaign.Status = "Sent";
            campaign.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            Log.Information("📤 Campaign {CampaignId} sent via template to {Count} recipients", campaign.Id, campaign.Recipients.Count);
            return true;
        }
        public async Task<bool> SendCampaignInParallelAsync(Guid campaignId, string ipAddress, string userAgent)
        {
            var campaign = await _context.Campaigns
                .Include(c => c.Recipients)
                .ThenInclude(r => r.Contact)
                .FirstOrDefaultAsync(c => c.Id == campaignId);

            if (campaign == null || campaign.Recipients.Count == 0)
            {
                Log.Warning("🚫 Campaign not found or has no recipients");
                return false;
            }

            campaign.Status = "Sending";
            campaign.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            int maxParallelism = 5;

#if NET6_0_OR_GREATER
            await Parallel.ForEachAsync(campaign.Recipients, new ParallelOptions
            {
                MaxDegreeOfParallelism = maxParallelism
            },
            async (recipient, cancellationToken) =>
            {
                await SendToRecipientAsync(campaign, recipient, ipAddress, userAgent);
            });
#else
    var tasks = campaign.Recipients.Select(recipient =>
        SendToRecipientAsync(campaign, recipient, ipAddress, userAgent)
    );
    await Task.WhenAll(tasks);
#endif

            campaign.Status = "Sent";
            campaign.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            Log.Information("📤 Campaign {CampaignId} sent in parallel to {Count} recipients", campaign.Id, campaign.Recipients.Count);
            return true;
        }
        private async Task SendToRecipientAsync(Campaign campaign, CampaignRecipient recipient, string ip, string ua)
        {
            try
            {
                var dto = new SimpleTemplateMessageDto
                {
                    RecipientNumber = recipient.Contact.PhoneNumber,
                    TemplateName = campaign.MessageTemplate,
                    TemplateParameters = new List<string> { recipient.Contact.Name ?? "Customer" }
                };

                var result = await _messageEngineService.SendTemplateMessageSimpleAsync(campaign.BusinessId, dto);


                var log = new CampaignSendLog
                {
                    Id = Guid.NewGuid(),
                    CampaignId = campaign.Id,
                    ContactId = recipient.ContactId,
                    RecipientId = recipient.Id,
                    TemplateId = campaign.TemplateId,
                    MessageBody = campaign.MessageTemplate,
                    MessageId = null,
                    SendStatus = result.Success ? "Sent" : "Failed",
                    ErrorMessage = result.Message,
                    SentAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    SourceChannel = "whatsapp",
                    IpAddress = ip,
                    DeviceInfo = ua
                };

                lock (_context)
                {
                    _context.CampaignSendLogs.Add(log);
                    recipient.Status = result.Success ? "Sent" : "Failed";
                    recipient.MessagePreview = campaign.MessageTemplate;
                    recipient.SentAt = DateTime.UtcNow;
                    recipient.UpdatedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "❌ Failed to send template to recipient: {RecipientId}", recipient.Id);
            }
        }

        public async Task<bool> RemoveRecipientAsync(Guid businessId, Guid campaignId, Guid contactId)
        {
            var entry = await _context.CampaignRecipients
                .FirstOrDefaultAsync(r =>
                    r.CampaignId == campaignId &&
                    r.ContactId == contactId &&
                    r.Campaign.BusinessId == businessId); // ✅ Filter by related Campaign.BusinessId

            if (entry == null)
                return false;

            _context.CampaignRecipients.Remove(entry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignContactsToCampaignAsync(Guid campaignId, Guid businessId, List<Guid> contactIds)
        {
            var campaign = await _context.Campaigns
                .Include(c => c.Recipients)
                .FirstOrDefaultAsync(c => c.Id == campaignId && c.BusinessId == businessId);

            if (campaign == null)
                return false;

            var newRecipients = contactIds.Select(id => new CampaignRecipient
            {
                Id = Guid.NewGuid(),
                CampaignId = campaignId,
                ContactId = id,
                BusinessId = businessId,
                Status = "Pending",
                SentAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });

            _context.CampaignRecipients.AddRange(newRecipients);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<ResponseResult> SendTemplateCampaignAsync(Guid campaignId)
        {
            try
            {
                var campaign = await _context.Campaigns
                    .Include(c => c.Recipients)
                        .ThenInclude(r => r.Contact) // 🧠 include contact details
                    .Include(c => c.MultiButtons)
                    .FirstOrDefaultAsync(c => c.Id == campaignId && !c.IsDeleted);

                if (campaign == null)
                    return ResponseResult.ErrorInfo("❌ Campaign not found.");

                if (campaign.Recipients == null || !campaign.Recipients.Any())
                    return ResponseResult.ErrorInfo("❌ No recipients assigned to this campaign.");

                var templateName = campaign.MessageTemplate;
                var templateId = campaign.TemplateId;
                var language = "en_US"; // Optional: make dynamic later
                var isImageTemplate = !string.IsNullOrEmpty(campaign.ImageUrl);

                var templateParams = JsonConvert.DeserializeObject<List<string>>(campaign.TemplateParameters ?? "[]");

                int success = 0, failed = 0;

                foreach (var recipient in campaign.Recipients)
                {
                    var messageDto = new ImageTemplateMessageDto
                    {
                       // BusinessId = campaign.BusinessId,
                        RecipientNumber = recipient.Contact.PhoneNumber,
                        TemplateName = templateName,
                        LanguageCode = language,
                        HeaderImageUrl = isImageTemplate ? campaign.ImageUrl : null,
                        TemplateParameters = templateParams,
                        ButtonParameters = campaign.MultiButtons
                            .OrderBy(b => b.Position)
                            .Take(3)
                            .Select(btn => new CampaignButtonDto
                            {
                                ButtonText = btn.Title,
                                ButtonType = btn.Type,
                                TargetUrl = btn.Value
                            }).ToList()
                    };

                    // ✅ Call the image/template sender
                    var sendResult = await _messageEngineService.SendImageTemplateMessageAsync(messageDto, campaign.BusinessId);
                    var isSuccess = sendResult.ToString().ToLower().Contains("messages");

                    var log = new MessageLog
                    {
                        Id = Guid.NewGuid(),
                        BusinessId = campaign.BusinessId,
                        RecipientNumber = recipient.Contact.PhoneNumber,
                        MessageContent = templateName,
                        MediaUrl = campaign.ImageUrl,
                        Status = isSuccess ? "Sent" : "Failed",
                        ErrorMessage = isSuccess ? null : "API Failure",
                        RawResponse = JsonConvert.SerializeObject(sendResult),
                        CreatedAt = DateTime.UtcNow,
                        SentAt = DateTime.UtcNow
                    };

                    await _context.MessageLogs.AddAsync(log);

                    if (isSuccess) success++;
                    else failed++;
                }

                await _context.SaveChangesAsync();
                return ResponseResult.SuccessInfo($"✅ Sent: {success}, ❌ Failed: {failed}");
            }
            catch (Exception ex)
            {
                return ResponseResult.ErrorInfo("❌ Unexpected error during campaign send.", ex.ToString());
            }
        }

        #region  This region include all the code related to sending text and image based

        // Detection - which type of campaign to send (text based or Image based)
        public async Task<ResponseResult> SendTemplateCampaignWithTypeDetectionAsync(Guid campaignId)
        {
            var campaign = await _context.Campaigns
                .Include(c => c.Recipients)
                    .ThenInclude(r => r.Contact)
                .Include(c => c.MultiButtons)
                .FirstOrDefaultAsync(c => c.Id == campaignId && !c.IsDeleted);

            if (campaign == null)
                return ResponseResult.ErrorInfo("❌ Campaign not found.");

            // Template Type Detection
            return campaign.CampaignType?.ToLower() switch
            {
                "text" => await SendTextTemplateCampaignAsync(campaign),
                "image" => await SendImageTemplateCampaignAsync(campaign),
                _ => ResponseResult.ErrorInfo("❌ Unsupported campaign type.")
            };
        }

        // This is used for "Text" based campaigns sending
        public async Task<ResponseResult> SendTextTemplateCampaignAsync(Campaign campaign)
        {
            try
            {
                if (campaign == null || campaign.IsDeleted)
                {
                    Log.Warning("❌ Campaign is null or marked as deleted.");
                    return ResponseResult.ErrorInfo("❌ Invalid campaign.");
                }

                if (campaign.Recipients == null || !campaign.Recipients.Any())
                {
                    Log.Warning("⚠️ Campaign has no assigned recipients.");
                    return ResponseResult.ErrorInfo("⚠️ No recipients assigned to this campaign.");
                }

                var businessId = campaign.BusinessId;
                var templateName = campaign.TemplateId;
                var templateParams = TemplateParameterHelper.ParseTemplateParams(campaign.TemplateParameters);
                var buttons = campaign.MultiButtons?.ToList();

                // ✅ Fetch WhatsApp template metadata
                var templateMeta = await _templateFetcherService.GetTemplateByNameAsync(businessId, templateName, includeButtons: true);
                if (templateMeta == null)
                {
                    Log.Error("❌ Could not fetch template metadata for {Template}.", templateName);
                    return ResponseResult.ErrorInfo("Template metadata not found.");
                }

                if (templateParams.Count != templateMeta.PlaceholderCount)
                {
                    Log.Warning("⚠️ Template expects {Expected} body parameters but received {Actual}.",
                        templateMeta.PlaceholderCount, templateParams.Count);
                }

                int successCount = 0, failureCount = 0;

                foreach (var recipient in campaign.Recipients)
                {
                    if (recipient?.Contact == null)
                    {
                        Log.Warning("⚠️ Skipping recipient: recipient or contact is null. Recipient ID: {RecipientId}", recipient?.Id);
                        continue;
                    }

                    Log.Information("📨 Preparing to send to {Phone}", recipient.Contact.PhoneNumber);

                    var components = BuildTextTemplateComponents(templateParams, buttons, templateMeta);

                    var payload = new
                    {
                        messaging_product = "whatsapp",
                        to = recipient.Contact.PhoneNumber,
                        type = "template",
                        template = new
                        {
                            name = templateName,
                            language = new { code = templateMeta.Language ?? "en_US" },
                            components = components
                        }
                    };

                    Log.Debug("📦 WhatsApp Payload:\n{Payload}", JsonConvert.SerializeObject(payload, Formatting.Indented));

                    ResponseResult sendResult = await _messageEngineService.SendToWhatsAppAsync(payload, businessId);
                    Log.Information("📬 Send result: {Result}", JsonConvert.SerializeObject(sendResult));

                    var messageLog = new MessageLog
                    {
                        Id = Guid.NewGuid(),
                        BusinessId = businessId,
                        CampaignId = campaign.Id,
                        ContactId = recipient.ContactId,
                        RecipientNumber = recipient.Contact.PhoneNumber,
                        MessageContent = campaign.MessageTemplate ?? templateName,
                        Status = sendResult.Success ? "Sent" : "Failed",
                        MessageId = sendResult.MessageId,
                        ErrorMessage = sendResult.ErrorMessage,
                        RawResponse = sendResult.RawResponse,
                        CreatedAt = DateTime.UtcNow,
                        SentAt = sendResult.Success ? DateTime.UtcNow : null
                    };

                    await _context.MessageLogs.AddAsync(messageLog);
                    Log.Information("✅ Added MessageLog for {Recipient}", recipient.Contact.PhoneNumber);

                    await _context.CampaignSendLogs.AddAsync(new CampaignSendLog
                    {
                        Id = Guid.NewGuid(),
                        CampaignId = campaign.Id,
                        ContactId = recipient.ContactId,
                        RecipientId = recipient.Id,
                        MessageBody = campaign.MessageBody ?? templateName,
                        TemplateId = templateName,
                        SendStatus = sendResult.Success ? "Sent" : "Failed",
                        MessageLogId = messageLog.Id,
                        MessageId = sendResult.MessageId,
                        CreatedAt = DateTime.UtcNow,
                        SentAt = DateTime.UtcNow,
                        CreatedBy = campaign.CreatedBy
                    });

                    Log.Information("📘 Added CampaignSendLog for recipient {Recipient}", recipient.Id);

                    if (sendResult.Success) successCount++;
                    else failureCount++;
                }

                Log.Information("💾 Saving all DB changes...");
                await _context.SaveChangesAsync();
                Log.Information("✅ All saved successfully.");

                return ResponseResult.SuccessInfo($"📤 Sent to {successCount} contacts. ❌ Failed for {failureCount}.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "❌ Error while sending text template campaign");
                return ResponseResult.ErrorInfo("🚨 Unexpected error while sending campaign.", ex.ToString());
            }
        }

        private List<object> BuildTextTemplateComponents(List<string> templateParams, List<CampaignButton>? buttonList, TemplateMetadataDto templateMeta)
        {
            var components = new List<object>();

            // ✅ 1. Optional Header
            if (templateMeta.HasImageHeader)
            {
                Log.Information("ℹ️ Header detected, but skipping image as it's a text template.");
                // If you ever support header text, you can handle here
            }

            // ✅ 2. Body parameters
            if (templateParams != null && templateParams.Count > 0)
            {
                components.Add(new
                {
                    type = "body",
                    parameters = templateParams.Select(p => new
                    {
                        type = "text",
                        text = p
                    }).ToArray()
                });
            }
            else if (templateMeta.PlaceholderCount > 0)
            {
                Log.Warning("⚠️ Body params missing but template expects {Count} placeholders.", templateMeta.PlaceholderCount);
            }

            // ✅ 3. Footer (optional, static — Meta doesn’t accept dynamic footer
            // ly)
            // If you want to support footer with text later, it can go like this:
            // components.Add(new { type = "footer", parameters = new[] { new { type = "text", text = "Your footer text" } } });

            // ✅ 4. Buttons
            if (buttonList != null && buttonList.Any())
            {
                for (int i = 0; i < buttonList.Count && i < templateMeta.ButtonParams.Count; i++)
                {
                    var btn = buttonList[i];
                    var meta = templateMeta.ButtonParams[i];

                    string index = i.ToString();
                    string subtype = meta.SubType?.ToLower() ?? "url";
                    string? value = btn.Value?.Trim();
                    string? metaParam = meta.ParameterValue?.Trim();

                    // 🔍 Determine if this is a dynamic param (contains {{}})
                    bool isDynamic = metaParam != null && metaParam.Contains("{{");

                    // ✅ Skip entire button if static and no dynamic value
                    if (!isDynamic)
                    {
                        Log.Information("⏩ Skipping static button '{Title}' as it requires no parameters", btn.Title);
                        continue;
                    }

                    var paramType = subtype switch
                    {
                        "url" => "text",
                        "copy_code" => "coupon_code",
                        "phone_number" => "phone_number",
                        "flow" => "flow_id",
                        _ => "text"
                    };

                    var buttonPayload = new Dictionary<string, object>
        {
                        { "type", "button" },
                        { "sub_type", subtype },
                        { "index", index },
                        { "parameters", new[] {
                            new Dictionary<string, object>
                            {
                                { "type", paramType },
                                { paramType, value }
                            }
                        }}
                    };

                    components.Add(buttonPayload);
                }

            }

            return components;
        }


        // This is used for "Image" based campaigns sending
        public async Task<ResponseResult> SendImageTemplateCampaignAsync(Campaign campaign)
        {
            try
            {
                if (campaign == null || campaign.IsDeleted)
                {
                    Log.Warning("❌ Campaign is null or marked as deleted.");
                    return ResponseResult.ErrorInfo("❌ Invalid campaign.");
                }

                if (campaign.Recipients == null || !campaign.Recipients.Any())
                {
                    Log.Warning("⚠️ Campaign has no assigned recipients.");
                    return ResponseResult.ErrorInfo("⚠️ No recipients assigned to this campaign.");
                }

                var businessId = campaign.BusinessId;
                var templateName = campaign.TemplateId;
                var imageUrl = campaign.ImageUrl;
                var templateParams = TemplateParameterHelper.ParseTemplateParams(campaign.TemplateParameters);
                var buttons = campaign.MultiButtons?.ToList();

                var templateMeta = await _templateFetcherService.GetTemplateByNameAsync(businessId, templateName, includeButtons: true);
                if (templateMeta == null)
                {
                    Log.Error("❌ Could not fetch template metadata for {Template}.", templateName);
                    return ResponseResult.ErrorInfo("Template metadata not found.");
                }

                if (templateParams.Count != templateMeta.PlaceholderCount)
                {
                    Log.Warning("⚠️ Template expects {Expected} body parameters but received {Actual}.",
                        templateMeta.PlaceholderCount, templateParams.Count);
                }

                int successCount = 0, failureCount = 0;

                foreach (var recipient in campaign.Recipients)
                {
                    if (recipient?.Contact == null)
                    {
                        Log.Warning("⚠️ Skipping recipient: recipient or contact is null. Recipient ID: {RecipientId}", recipient?.Id);
                        continue;
                    }

                    Log.Information("📨 Preparing to send to {Phone}", recipient.Contact.PhoneNumber);

                    var components = BuildImageTemplateComponents(templateParams, imageUrl, buttons, templateMeta);

                    var payload = new
                    {
                        messaging_product = "whatsapp",
                        to = recipient.Contact.PhoneNumber,
                        type = "template",
                        template = new
                        {
                            name = templateName,
                            language = new { code = "en_US" },
                            components = components
                        }
                    };

                    Log.Debug("📦 Final WhatsApp Payload:\n{Payload}", JsonConvert.SerializeObject(payload, Formatting.Indented));

                    var sendResult = await _messageEngineService.SendToWhatsAppAsync(payload, businessId);
                    Log.Information("📬 Send result: {Result}", JsonConvert.SerializeObject(sendResult));

                    var messageLog = new MessageLog
                    {
                        Id = Guid.NewGuid(),
                        BusinessId = businessId,
                        CampaignId = campaign.Id,
                        ContactId = recipient.ContactId,
                        RecipientNumber = recipient.Contact.PhoneNumber,
                        MessageContent = campaign.MessageTemplate ?? templateName,
                        MediaUrl = imageUrl,
                        Status = sendResult.Success ? "Sent" : "Failed",
                        MessageId = sendResult.MessageId,
                        ErrorMessage = sendResult.ErrorMessage,
                        RawResponse = sendResult.RawResponse,
                        CreatedAt = DateTime.UtcNow,
                        SentAt = sendResult.Success ? DateTime.UtcNow : null
                    };

                    await _context.MessageLogs.AddAsync(messageLog);
                    Log.Information("📥 MessageLog saved for {Recipient}", recipient.Contact.PhoneNumber);

                    await _context.CampaignSendLogs.AddAsync(new CampaignSendLog
                    {
                        Id = Guid.NewGuid(),
                        CampaignId = campaign.Id,
                        BusinessId = businessId,
                        ContactId = recipient.ContactId,
                        RecipientId = recipient.Id,
                        MessageBody = campaign.MessageBody ?? templateName,
                        TemplateId = templateName,
                        SendStatus = sendResult.Success ? "Sent" : "Failed",
                        MessageLogId = messageLog.Id,
                        MessageId = sendResult.MessageId,
                        CreatedAt = DateTime.UtcNow,
                        SentAt = DateTime.UtcNow,
                        CreatedBy = campaign.CreatedBy
                    });

                    Log.Information("🗃️ CampaignSendLog saved for recipient {Recipient}", recipient.Id);

                    if (sendResult.Success) successCount++;
                    else failureCount++;
                }

                Log.Information("💾 Saving all DB changes...");
                await _context.SaveChangesAsync();
                Log.Information("✅ All saved successfully.");

                return ResponseResult.SuccessInfo($"📤 Sent to {successCount} contacts. ❌ Failed for {failureCount}.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "❌ Error while sending image template campaign");
                return ResponseResult.ErrorInfo("🚨 Unexpected error while sending campaign.", ex.ToString());
            }
        }

        private List<object> BuildImageTemplateComponents(List<string> templateParams, string? imageUrl, List<CampaignButton>? buttonList, TemplateMetadataDto templateMeta)
        {
            var components = new List<object>();

            // ✅ 1. Header image
            if (!string.IsNullOrWhiteSpace(imageUrl) && templateMeta.HasImageHeader)
            {
                components.Add(new
                {
                    type = "header",
                    parameters = new[]
                    {
                new
                {
                    type = "image",
                    image = new { link = imageUrl }
                }
            }
                });
            }

            // ✅ 2. Body parameters
            if (templateParams != null && templateParams.Count > 0)
            {
                components.Add(new
                {
                    type = "body",
                    parameters = templateParams.Select(p => new
                    {
                        type = "text",
                        text = p
                    }).ToArray()
                });
            }
            else if (templateMeta.PlaceholderCount > 0)
            {
                Log.Warning("⚠️ Body params missing but template expects {Count} placeholders.", templateMeta.PlaceholderCount);
            }

            // ✅ 3. Buttons with logic to exclude parameters for static values
            if (buttonList != null && buttonList.Any())
            {
                for (int i = 0; i < buttonList.Count && i < templateMeta.ButtonParams.Count; i++)
                {
                    var btn = buttonList[i];
                    var meta = templateMeta.ButtonParams[i];

                    string index = i.ToString();
                    string subtype = meta.SubType?.ToLower() ?? "url";
                    string? value = btn.Value?.Trim();
                    string? metaParam = meta.ParameterValue?.Trim();

                    var buttonPayload = new Dictionary<string, object>
            {
                { "type", "button" },
                { "sub_type", subtype },
                { "index", index }
            };

                    // 🔍 Determine if this is a dynamic param (contains {{}})
                    bool isDynamic = metaParam != null && metaParam.Contains("{{");

                    // ✅ Only add parameters for dynamic types
                    if (isDynamic && !string.IsNullOrWhiteSpace(value))
                    {
                        var paramType = subtype switch
                        {
                            "url" => "text",
                            "copy_code" => "coupon_code",
                            "phone_number" => "phone_number",
                            "flow" => "flow_id",
                            _ => "text"
                        };

                        buttonPayload["parameters"] = new[]
                        {
                    new Dictionary<string, object>
                    {
                        { "type", paramType },
                        { paramType, value }
                    }
                };
                    }
                    else
                    {
                        Log.Information("ℹ️ Skipping parameters for static button '{Title}' ({SubType})", btn.Title, subtype);
                    }

                    components.Add(buttonPayload);
                }
            }

            return components;
        }

        #endregion
    }

}
