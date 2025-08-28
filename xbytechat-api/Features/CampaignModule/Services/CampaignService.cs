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
using xbytechat.api.CRM.Models;
using xbytechat.api.Features.Tracking.Services;

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
        private readonly IUrlBuilderService _urlBuilderService;
        public CampaignService(AppDbContext context, IMessageService messageService,
                               IServiceProvider serviceProvider,
                               ILeadTimelineService timelineService,
                               IMessageEngineService messageEngineService,
                               IWhatsAppTemplateFetcherService templateFetcherService,
                               IUrlBuilderService urlBuilderService)
        {
            _context = context;
            _messageService = messageService;
            _serviceProvider = serviceProvider;
            _timelineService = timelineService; // ✅ new
            _messageEngineService = messageEngineService;
            _templateFetcherService = templateFetcherService;
            _urlBuilderService = urlBuilderService;

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

        //#region
        //public async Task<Guid?> CreateTextCampaignAsync(CampaignCreateDto dto, Guid businessId, string createdBy)
        //{
        //    try
        //    {
        //        var campaignId = Guid.NewGuid();

        //        // 🔁 Parse template parameters into list
        //        var parsedParams = TemplateParameterHelper.ParseTemplateParams(
        //            JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>())
        //        );

        //        // 🧠 Fetch template (for body + buttons)
        //        var template = await _templateFetcherService.GetTemplateByNameAsync(businessId, dto.TemplateId, true);

        //        // 🧠 Fill message body
        //        var resolvedBody = TemplateParameterHelper.FillPlaceholders(
        //            template?.Body ?? dto.MessageTemplate,
        //            parsedParams
        //        );

        //        // ✅ Step 1: Create campaign object
        //        var campaign = new Campaign
        //        {
        //            Id = campaignId,
        //            BusinessId = businessId,
        //            Name = dto.Name,
        //            MessageTemplate = dto.MessageTemplate,
        //            TemplateId = dto.TemplateId,
        //            FollowUpTemplateId = dto.FollowUpTemplateId,
        //            CampaignType = dto.CampaignType ?? "text",
        //            CtaId = dto.CtaId,
        //            ScheduledAt = dto.ScheduledAt,
        //            CreatedBy = createdBy,
        //            CreatedAt = DateTime.UtcNow,
        //            UpdatedAt = DateTime.UtcNow,
        //            Status = "Draft",
        //            ImageUrl = dto.ImageUrl,
        //            ImageCaption = dto.ImageCaption,
        //            TemplateParameters = JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>()),
        //            MessageBody = resolvedBody // ✅ final resolved message
        //        };

        //        await _context.Campaigns.AddAsync(campaign);

        //        // ✅ Step 2: Assign contacts if provided
        //        if (dto.ContactIds != null && dto.ContactIds.Any())
        //        {
        //            var recipients = dto.ContactIds.Select(contactId => new CampaignRecipient
        //            {
        //                Id = Guid.NewGuid(),
        //                CampaignId = campaignId,
        //                ContactId = contactId,
        //                BusinessId = businessId,
        //                Status = "Pending",
        //                SentAt = DateTime.UtcNow,
        //                UpdatedAt = DateTime.UtcNow
        //            });

        //            await _context.CampaignRecipients.AddRangeAsync(recipients);
        //        }

        //        // ✅ Step 3a: Save manual buttons from frontend
        //        if (dto.MultiButtons != null && dto.MultiButtons.Any())
        //        {
        //            var buttons = dto.MultiButtons
        //                .Where(btn => !string.IsNullOrWhiteSpace(btn.ButtonText) && !string.IsNullOrWhiteSpace(btn.TargetUrl))
        //                .Take(3)
        //                .Select((btn, index) => new CampaignButton
        //                {
        //                    Id = Guid.NewGuid(),
        //                    CampaignId = campaignId,
        //                    Title = btn.ButtonText,
        //                    Type = btn.ButtonType ?? "url",
        //                    Value = btn.TargetUrl,
        //                    Position = index + 1,
        //                    IsFromTemplate = false
        //                });

        //            await _context.CampaignButtons.AddRangeAsync(buttons);
        //        }

        //        // ✅ Step 3b: Save buttons auto-fetched from WhatsApp Template
        //        if (template != null && template.ButtonParams?.Count > 0)
        //        {
        //            var autoButtons = template.ButtonParams
        //                .Take(3)
        //                .Select((btn, index) => new CampaignButton
        //                {
        //                    Id = Guid.NewGuid(),
        //                    CampaignId = campaignId,
        //                    Title = btn.Text,
        //                    Type = btn.Type,
        //                    // Value = btn.SubType == "url" ? "https://your-redirect.com" : btn.SubType,
        //                    Value = btn.ParameterValue,
        //                    Position = index + 1,
        //                    IsFromTemplate = true
        //                });

        //            await _context.CampaignButtons.AddRangeAsync(autoButtons);
        //        }

        //        // ✅ Final Save
        //        await _context.SaveChangesAsync();

        //        Log.Information("✅ Campaign '{Name}' created with {Contacts} recipients, {ManualButtons} user buttons, {TemplateButtons} template buttons and {Params} template parameters",
        //            dto.Name,
        //            dto.ContactIds?.Count ?? 0,
        //            dto.MultiButtons?.Count ?? 0,
        //            template?.ButtonParams?.Count ?? 0,
        //            dto.TemplateParameters?.Count ?? 0
        //        );

        //        return campaignId;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "❌ Failed to create campaign");
        //        return null;
        //    }
        //}
        //#endregion

        //public async Task<Guid?> CreateTextCampaignAsync(CampaignCreateDto dto, Guid businessId, string createdBy)
        //{
        //    try
        //    {
        //        var campaignId = Guid.NewGuid();
        //        var template = await _templateFetcherService.GetTemplateByNameAsync(businessId, dto.TemplateId, true);

        //        // Step 1: Create the main campaign object (logic is the same)
        //        var campaign = new Campaign
        //        {
        //            Id = campaignId,
        //            BusinessId = businessId,
        //            Name = dto.Name,
        //            MessageTemplate = dto.MessageTemplate,
        //            TemplateId = dto.TemplateId,
        //            CampaignType = dto.CampaignType,
        //            CtaId = dto.CtaId,
        //            ScheduledAt = dto.ScheduledAt,
        //            CreatedBy = createdBy,
        //            CreatedAt = DateTime.UtcNow,
        //            UpdatedAt = DateTime.UtcNow,
        //            Status = "Draft",

        //            TemplateParameters = JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>()),
        //        };
        //        await _context.Campaigns.AddAsync(campaign);

        //        // Step 2: Assign contacts (logic is the same)
        //        if (dto.ContactIds != null && dto.ContactIds.Any())
        //        {
        //            var recipients = dto.ContactIds.Select(contactId => new CampaignRecipient
        //            {
        //                Id = Guid.NewGuid(),
        //                CampaignId = campaignId,
        //                ContactId = contactId,
        //                BusinessId = businessId,
        //                Status = "Pending",
        //                SentAt = DateTime.UtcNow,
        //                UpdatedAt = DateTime.UtcNow
        //            });
        //            await _context.CampaignRecipients.AddRangeAsync(recipients);
        //        }

        //        // ======================== FIX STARTS HERE ========================
        //        // ✅ Step 3: Intelligently save buttons by merging template data with frontend input.
        //        if (template != null && template.ButtonParams?.Count > 0)
        //        {
        //            var buttonsToSave = new List<CampaignButton>();
        //            //var userButtons = dto.ButtonParams ?? new List<ButtonDto>(); // Use 'ButtonParams' from frontend
        //            var userButtons = dto.ButtonParams ?? new List<CampaignButtonParamFromMetaDto>();
        //            for (int i = 0; i < template.ButtonParams.Count; i++)
        //            {
        //                var templateButton = template.ButtonParams[i];
        //                var isDynamic = templateButton.ParameterValue?.Contains("{{1}}") == true;

        //                // Find the corresponding button data sent from the frontend by its position.
        //                var userButton = userButtons.FirstOrDefault(b => b.Position == i + 1);

        //                buttonsToSave.Add(new CampaignButton
        //                {
        //                    Id = Guid.NewGuid(),
        //                    CampaignId = campaignId,
        //                    Title = templateButton.Text,
        //                    Type = templateButton.Type,
        //                    // If the button is dynamic AND we have a value from the user, use it.
        //                    // Otherwise, fall back to the static value from the template.
        //                    Value = isDynamic && userButton != null
        //                        ? userButton.Value
        //                        : templateButton.ParameterValue,
        //                    Position = i + 1,
        //                    IsFromTemplate = true
        //                });
        //            }
        //            await _context.CampaignButtons.AddRangeAsync(buttonsToSave);
        //        }
        //        // ========================= FIX ENDS HERE =========================

        //        // ✅ Final Save
        //        await _context.SaveChangesAsync();
        //        Log.Information("✅ Campaign '{Name}' created successfully.", dto.Name);
        //        return campaignId;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "❌ Failed to create campaign");
        //        return null;
        //    }
        //}

        public async Task<Guid?> CreateTextCampaignAsync(CampaignCreateDto dto, Guid businessId, string createdBy)
        {
            try
            {
                var campaignId = Guid.NewGuid();

                // 🔁 Parse/normalize template parameters once
                var parsedParams = TemplateParameterHelper.ParseTemplateParams(
                    JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>())
                );

                // 🧠 Fetch template (for body + buttons)
                var template = await _templateFetcherService.GetTemplateByNameAsync(businessId, dto.TemplateId, true);

                // 🧠 Resolve message body using template body (if available) else dto.MessageTemplate
                var templateBody = template?.Body ?? dto.MessageTemplate ?? string.Empty;
                var resolvedBody = TemplateParameterHelper.FillPlaceholders(templateBody, parsedParams);

                // ✅ Step 1: Create campaign (restored all fields from old code)
                var campaign = new Campaign
                {
                    Id = campaignId,
                    BusinessId = businessId,
                    Name = dto.Name,
                    MessageTemplate = dto.MessageTemplate,               // original message template name/content
                    TemplateId = dto.TemplateId,
                    FollowUpTemplateId = dto.FollowUpTemplateId,            // restored
                    CampaignType = dto.CampaignType ?? "text",        // default to "text" (restored)
                    CtaId = dto.CtaId,
                    ScheduledAt = dto.ScheduledAt,
                    CreatedBy = createdBy,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Status = "Draft",
                    ImageUrl = dto.ImageUrl,                      // restored
                    ImageCaption = dto.ImageCaption,                  // restored
                    TemplateParameters = JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>()),
                    MessageBody = resolvedBody                        // restored: final resolved message
                };

                await _context.Campaigns.AddAsync(campaign);

                // ✅ Step 2: Assign contacts (keep semantics; set SentAt = null until actually sent)
                if (dto.ContactIds != null && dto.ContactIds.Any())
                {
                    var recipients = dto.ContactIds.Select(contactId => new CampaignRecipient
                    {
                        Id = Guid.NewGuid(),
                        CampaignId = campaignId,
                        ContactId = contactId,
                        BusinessId = businessId,
                        Status = "Pending",
                        SentAt = null,                  // <-- changed from UtcNow to null as requested
                        UpdatedAt = DateTime.UtcNow
                    });

                    await _context.CampaignRecipients.AddRangeAsync(recipients);
                }

                // ✅ Step 3a: Save manual buttons from frontend (unchanged from old code)
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

                // ======================== Dynamic buttons merge (your new logic, enhanced) ========================
                // ✅ Step 3b: Save buttons auto-fetched from template, merging with UI "buttonParams" for dynamic buttons
                if (template != null && template.ButtonParams?.Count > 0)
                {
                    var buttonsToSave = new List<CampaignButton>();

                    // Expecting dto.ButtonParams from the React page
                    var userButtons = dto.ButtonParams ?? new List<CampaignButtonParamFromMetaDto>();

                    var total = Math.Min(3, template.ButtonParams.Count);
                    for (int i = 0; i < total; i++)
                    {
                        var tplBtn = template.ButtonParams[i];
                        var isDynamic = (tplBtn.ParameterValue?.Contains("{{1}}") ?? false);

                        // Find matching UI-provided param by position (1-based)
                        var userBtn = userButtons.FirstOrDefault(b => b.Position == i + 1);

                        // If dynamic and user provided a value, use that; otherwise fall back to template's static parameter
                        var valueToSave = (isDynamic && userBtn != null)
                            ? userBtn.Value?.Trim()
                            : tplBtn.ParameterValue;

                        buttonsToSave.Add(new CampaignButton
                        {
                            Id = Guid.NewGuid(),
                            CampaignId = campaignId,
                            Title = tplBtn.Text,
                            Type = tplBtn.Type,
                            Value = valueToSave,
                            Position = i + 1,
                            IsFromTemplate = true
                        });
                    }

                    await _context.CampaignButtons.AddRangeAsync(buttonsToSave);
                }
                // ==================================================================================================

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

          //  Template Type Detection
            return campaign.CampaignType?.ToLower() switch
            {
                "text" => await SendTextTemplateCampaignAsync(campaign),
                "image" => await SendImageTemplateCampaignAsync(campaign),
                _ => ResponseResult.ErrorInfo("❌ Unsupported campaign type.")
            };
       


        }
        // strips control chars & trims (helps when values come from UI/DB with hidden characters)
        // Helpers (same class)
         public async Task<ResponseResult> SendTextTemplateCampaignAsync(Campaign campaign)
        {
            try
            {
                if (campaign == null || campaign.IsDeleted)
                    return ResponseResult.ErrorInfo("❌ Invalid campaign.");

                var businessId = campaign.BusinessId;

                var setting = await _context.WhatsAppSettings
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.BusinessId == businessId && s.IsActive);

                if (setting == null)
                {
                    return ResponseResult.ErrorInfo("❌ WhatsApp settings not found for this business.");
                }

                var providerKey = (setting.Provider ?? "meta_cloud").ToLowerInvariant();
                var templateName = campaign.TemplateId;
                var templateParams = TemplateParameterHelper.ParseTemplateParams(campaign.TemplateParameters);
                var buttons = campaign.MultiButtons?.ToList();
                var templateMeta = await _templateFetcherService.GetTemplateByNameAsync(businessId, templateName, includeButtons: true);

                if (templateMeta == null)
                    return ResponseResult.ErrorInfo("❌ Template metadata not found.");

                int successCount = 0, failureCount = 0;

                foreach (var recipient in campaign.Recipients)
                {
                    if (recipient?.Contact == null)
                    {
                        Log.Warning("Skipping recipient {RecipientId}: contact is null", recipient?.Id);
                        continue;
                    }

                    var campaignSendLogId = Guid.NewGuid();

                    List<object> components;
                    if (providerKey == "pinnacle")
                    {
                        // 👇 FIX: Pass 'recipient.Contact' to the helper method
                        components = BuildTextTemplateComponents_Pinnacle(templateParams, buttons, templateMeta, campaignSendLogId, recipient.Contact);
                    }
                    else // Default to Meta's rules
                    {
                        // 👇 FIX: Pass 'recipient.Contact' to the helper method
                        components = BuildTextTemplateComponents_Meta(templateParams, buttons, templateMeta, campaignSendLogId, recipient.Contact);
                    }

                    var payload = new
                    {
                        messaging_product = "whatsapp",
                        to = recipient.Contact.PhoneNumber,
                        type = "template",
                        template = new
                        {
                            name = templateName,
                            language = new { code = string.IsNullOrWhiteSpace(templateMeta.Language) ? "en_US" : templateMeta.Language },
                            components
                        }
                    };

                    var sendResult = await _messageEngineService.SendPayloadAsync(businessId, payload);

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
                        SentAt = sendResult.Success ? DateTime.UtcNow : (DateTime?)null,
                        Source = "campaign"
                    };
                    await _context.MessageLogs.AddAsync(messageLog);

                    await _context.CampaignSendLogs.AddAsync(new CampaignSendLog
                    {
                        Id = campaignSendLogId,
                        CampaignId = campaign.Id,
                        BusinessId = businessId,
                        ContactId = recipient.ContactId,
                        RecipientId = recipient.Id,
                        MessageBody = campaign.MessageBody ?? templateName,
                        TemplateId = templateName,
                        SendStatus = sendResult.Success ? "Sent" : "Failed",
                        MessageLogId = messageLog.Id,
                        MessageId = sendResult.MessageId,
                        ErrorMessage = sendResult.Success ? null : sendResult.Message,
                        CreatedAt = DateTime.UtcNow,
                        SentAt = DateTime.UtcNow,
                        CreatedBy = campaign.CreatedBy
                    });

                    if (sendResult.Success) successCount++; else failureCount++;
                }

                await _context.SaveChangesAsync();
                return ResponseResult.SuccessInfo($"📤 Sent to {successCount} contacts. ❌ Failed for {failureCount}.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while sending text template campaign");
                return ResponseResult.ErrorInfo("🚨 Unexpected error while sending campaign.", ex.ToString());
            }
        }
        #region Text Component Builders New
        private string BuildTokenParam(Guid campaignSendLogId, int buttonIndex, string? buttonTitle, string destinationUrlAbsolute)
        {
            var full = _urlBuilderService.BuildTrackedButtonUrl(campaignSendLogId, buttonIndex, buttonTitle, destinationUrlAbsolute);
            var pos = full.LastIndexOf("/r/", StringComparison.OrdinalIgnoreCase);
            return (pos >= 0) ? full.Substring(pos + 3) : full; // fallback: if not found, return full (rare)
        }



        private List<object> BuildTextTemplateComponents_Pinnacle(
           List<string> templateParams,
           List<CampaignButton>? buttonList,
           TemplateMetadataDto templateMeta,
           Guid campaignSendLogId,
           Contact contact)
        {
            var components = new List<object>();

            // Body parameters
            if (templateParams != null && templateParams.Count > 0 && templateMeta.PlaceholderCount > 0)
            {
                components.Add(new
                {
                    type = "body",
                    parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray()
                });
            }

            // Buttons
            if (buttonList == null || buttonList.Count == 0 ||
                templateMeta.ButtonParams == null || templateMeta.ButtonParams.Count == 0)
                return components;

            var total = Math.Min(3, Math.Min(buttonList.Count, templateMeta.ButtonParams.Count));

            for (int i = 0; i < total; i++)
            {
                var btn = buttonList[i];
                var meta = templateMeta.ButtonParams[i];

                var subtype = (meta.SubType ?? "url").ToLowerInvariant();
                var metaParam = meta.ParameterValue?.Trim() ?? string.Empty;   // e.g. https://your-domain/r/{{1}}
                var btnValue = btn.Value?.Trim();                             // final destination (may contain {{1}} for phone)
                var isDynamic = metaParam.Contains("{{");

                // Non-dynamic button → send no parameters
                if (!isDynamic)
                {
                    components.Add(new Dictionary<string, object>
                    {
                        ["type"] = "button",
                        ["sub_type"] = subtype,
                        ["index"] = i
                    });
                    continue;
                }

                if (string.IsNullOrWhiteSpace(btnValue)) continue;

                // Normalize + encode phone for URL
                var phone = string.IsNullOrWhiteSpace(contact?.PhoneNumber)
                    ? ""
                    : (contact.PhoneNumber.StartsWith("+") ? contact.PhoneNumber : "+" + contact.PhoneNumber);
                var encodedPhone = Uri.EscapeDataString(phone);

                // Resolve phone placeholder in destination, if any
                var resolvedDestination = btnValue.Contains("{{1}}")
                    ? btnValue.Replace("{{1}}", encodedPhone)
                    : btnValue;

                // Build tracked URL (full) → extract token for {{1}}
                var tokenParam = BuildTokenParam(campaignSendLogId, i, btn.Title, resolvedDestination);

                var param = new Dictionary<string, object> { ["type"] = "text", ["text"] = tokenParam };

                components.Add(new Dictionary<string, object>
                {
                    ["type"] = "button",
                    ["sub_type"] = subtype, // "url"
                    ["index"] = i,          // Pinnacle can use numeric index
                    ["parameters"] = new[] { param }
                });
            }

            return components;
        }
        private static string CleanForUri(string s)
        {
            if (s is null) return string.Empty;
            var t = s.Trim();
            return new string(Array.FindAll(t.ToCharArray(), c => !char.IsControl(c)));
        }

        // CampaignService.cs
        private static string NormalizeAbsoluteUrlOrThrowForButton(string input, string buttonTitle, int buttonIndex)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException($"Destination is required for button '{buttonTitle}' (index {buttonIndex}).");

            // Trim + strip control chars
            var cleaned = new string(input.Trim().Where(c => !char.IsControl(c)).ToArray());
            if (cleaned.Length == 0)
                throw new ArgumentException($"Destination is required for button '{buttonTitle}' (index {buttonIndex}).");

            // ✅ Allow tel: and WhatsApp deep links
            if (cleaned.StartsWith("tel:", StringComparison.OrdinalIgnoreCase) ||
                cleaned.StartsWith("wa:", StringComparison.OrdinalIgnoreCase) ||
                cleaned.StartsWith("https://wa.me/", StringComparison.OrdinalIgnoreCase))
            {
                return cleaned; // Accept as-is
            }

            // ✅ Still allow normal web links
            if (Uri.TryCreate(cleaned, UriKind.Absolute, out var uri) &&
                (uri.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                 uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)))
            {
                return uri.ToString();
            }

            // ❌ Anything else is rejected
            throw new ArgumentException(
                $"Destination must be an absolute http/https/tel/wa URL for button '{buttonTitle}' (index {buttonIndex}). Got: '{input}'");
        }
        private static bool LooksLikeAbsoluteBaseUrlWithPlaceholder(string? templateUrl)
        {
            if (string.IsNullOrWhiteSpace(templateUrl)) return false;
            var s = templateUrl.Trim();
            if (!s.Contains("{{")) return false;
            var probe = s.Replace("{{1}}", "x").Replace("{{0}}", "x");
            return Uri.TryCreate(probe, UriKind.Absolute, out var abs) &&
                   (abs.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                    abs.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase));
        }

        private List<object> BuildTextTemplateComponents_Meta(
    List<string> templateParams,
    List<CampaignButton>? buttonList,
    TemplateMetadataDto templateMeta,
    Guid campaignSendLogId,
    Contact contact)
        {
            var components = new List<object>();

            // Body
            if (templateParams != null && templateParams.Count > 0 && templateMeta.PlaceholderCount > 0)
            {
                components.Add(new
                {
                    type = "body",
                    parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray()
                });
            }

            if (buttonList == null || buttonList.Count == 0 ||
                templateMeta.ButtonParams == null || templateMeta.ButtonParams.Count == 0)
                return components;

            // ✅ Ensure index alignment with the template by ordering by Position (then original index)
            var orderedButtons = buttonList
                .Select((b, idx) => new { Btn = b, idx })
                .OrderBy(x => (int?)x.Btn.Position ?? int.MaxValue) // if Position is null, push to the end
                .ThenBy(x => x.idx)
                .Select(x => x.Btn)
                .ToList();

            var total = Math.Min(3, Math.Min(orderedButtons.Count, templateMeta.ButtonParams.Count));

            for (int i = 0; i < total; i++)
            {
                var meta = templateMeta.ButtonParams[i];
                var subType = (meta.SubType ?? "url").ToLowerInvariant();
                var metaParam = meta.ParameterValue?.Trim();

                // Meta needs parameters ONLY for dynamic URL buttons
                if (subType != "url")
                    continue;

                var isDynamic = !string.IsNullOrWhiteSpace(metaParam) && metaParam.Contains("{{");
                if (!isDynamic)
                    continue;

                var btn = orderedButtons[i];
                var btnType = (btn?.Type ?? "URL").ToUpperInvariant();
                if (!string.Equals(btnType, "URL", StringComparison.OrdinalIgnoreCase))
                {
                    // Template expects URL+param at this index, but our button isn't URL → we cannot satisfy Meta.
                    throw new InvalidOperationException(
                        $"Template requires a dynamic URL at button index {i}, but campaign button type is '{btn?.Type}'.");
                }

                var valueRaw = btn.Value?.Trim();
                if (string.IsNullOrWhiteSpace(valueRaw))
                {
                    // Template expects a param here; missing value would cause 131008, so fail early with context.
                    throw new InvalidOperationException(
                        $"Template requires a dynamic URL at button index {i}, but campaign button value is empty.");
                }

                // Optional phone substitution in destination
                var phone = string.IsNullOrWhiteSpace(contact?.PhoneNumber)
                    ? ""
                    : (contact.PhoneNumber.StartsWith("+") ? contact.PhoneNumber : "+" + contact.PhoneNumber);
                var encodedPhone = Uri.EscapeDataString(phone);

                var resolvedDestination = valueRaw.Contains("{{1}}")
                    ? valueRaw.Replace("{{1}}", encodedPhone)
                    : valueRaw;

                resolvedDestination = NormalizeAbsoluteUrlOrThrowForButton(resolvedDestination, btn.Title, i);

                // Build both; choose which to send based on template base style
                var fullTrackedUrl = _urlBuilderService.BuildTrackedButtonUrl(
                    campaignSendLogId, i, btn.Title, resolvedDestination);

                var tokenParam = BuildTokenParam(campaignSendLogId, i, btn.Title, resolvedDestination);

                var templateHasAbsoluteBase = LooksLikeAbsoluteBaseUrlWithPlaceholder(metaParam);
                var valueToSend = templateHasAbsoluteBase ? tokenParam : fullTrackedUrl;

                components.Add(new Dictionary<string, object>
                {
                    ["type"] = "button",
                    ["sub_type"] = "url",
                    ["index"] = i.ToString(), // "0"/"1"/"2"
                    ["parameters"] = new[] {
                new Dictionary<string, object> { ["type"] = "text", ["text"] = valueToSend }
            }
                });
            }

            return components;
        }


        #endregion

        //    #region Text Component Builders

        //    /// <summary>
        //    /// Builds components for a Text Template for the Pinnacle API.
        //    /// This logic sends a component for every button and generates a tracking URL for dynamic ones.
        //    /// </summary>
        //    //  private List<object> BuildTextTemplateComponents_Pinnacle(
        //    //List<string> templateParams,
        //    //List<CampaignButton>? buttonList,
        //    //TemplateMetadataDto templateMeta,
        //    //Guid campaignSendLogId,
        //    //Contact contact) // 👇 FIX: Accept the Contact object as a parameter
        //    //  {
        //    //      var components = new List<object>();

        //    //      // Body parameters (with safeguard)
        //    //      if (templateParams != null && templateParams.Count > 0 && templateMeta.PlaceholderCount > 0)
        //    //      {
        //    //          components.Add(new { type = "body", parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray() });
        //    //      }

        //    //      // Button components
        //    //      if (buttonList != null && buttonList.Count > 0 && templateMeta.ButtonParams != null && templateMeta.ButtonParams.Count > 0)
        //    //      {
        //    //          var total = Math.Min(3, Math.Min(buttonList.Count, templateMeta.ButtonParams.Count));
        //    //          for (int i = 0; i < total; i++)
        //    //          {
        //    //              var btn = buttonList[i];
        //    //              var meta = templateMeta.ButtonParams[i];
        //    //              var subtype = (meta.SubType ?? "url").ToLowerInvariant();
        //    //              var metaParam = meta.ParameterValue?.Trim();
        //    //              var value = btn.Value?.Trim();
        //    //              bool isDynamic = !string.IsNullOrWhiteSpace(metaParam) && metaParam.Contains("{{");

        //    //              if (!isDynamic || string.IsNullOrWhiteSpace(value))
        //    //              {
        //    //                  components.Add(new Dictionary<string, object> { ["type"] = "button", ["sub_type"] = subtype, ["index"] = i.ToString() });
        //    //                  continue;
        //    //              }

        //    //              // 👇 FIX: Use the 'contact' object that was passed into this method
        //    //              var trackingUrl = _urlBuilderService.GenerateCampaignTrackingUrl(campaignSendLogId, btn.Title, value, contact.PhoneNumber);

        //    //              var param = subtype switch
        //    //              {
        //    //                  "url" => new Dictionary<string, object> { ["type"] = "text", ["text"] = trackingUrl },
        //    //                  _ => new Dictionary<string, object> { ["type"] = "text", ["text"] = trackingUrl },
        //    //              };

        //    //              components.Add(new Dictionary<string, object>
        //    //              {
        //    //                  ["type"] = "button",
        //    //                  ["sub_type"] = subtype,
        //    //                  ["index"] = i.ToString(),
        //    //                  ["parameters"] = new[] { param }
        //    //              });
        //    //          }
        //    //      }
        //    //      return components;
        //    //  }

        //    //  #region
        //    //  private List<object> BuildTextTemplateComponents_Pinnacle(
        //    //List<string> templateParams,
        //    //List<CampaignButton>? buttonList,
        //    //TemplateMetadataDto templateMeta,
        //    //Guid campaignSendLogId,
        //    //Contact contact)
        //    //  {
        //    //      var components = new List<object>();

        //    //      // Body parameters
        //    //      if (templateParams != null && templateParams.Count > 0 && templateMeta.PlaceholderCount > 0)
        //    //      {
        //    //          components.Add(new
        //    //          {
        //    //              type = "body",
        //    //              parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray()
        //    //          });
        //    //      }

        //    //      // Buttons (dynamic only)
        //    //      if (buttonList == null || buttonList.Count == 0 || templateMeta.ButtonParams == null || templateMeta.ButtonParams.Count == 0)
        //    //          return components;

        //    //      var total = Math.Min(3, Math.Min(buttonList.Count, templateMeta.ButtonParams.Count));

        //    //      for (int i = 0; i < total; i++)
        //    //      {
        //    //          var btn = buttonList[i];
        //    //          var meta = templateMeta.ButtonParams[i];

        //    //          var subtype = (meta.SubType ?? "url").ToLowerInvariant();
        //    //          var metaParam = meta.ParameterValue?.Trim() ?? string.Empty; // the template URL (with or without {{1}})
        //    //          var btnValue = btn.Value?.Trim();                           // what UI/DB stored for this button
        //    //          var isDynamic = metaParam.Contains("{{");

        //    //          // If this button isn't dynamic, Pinnacle expects no parameters for it
        //    //          // (inside the for loop, after you computed isDynamic and btnValue)
        //    //          if (!isDynamic)
        //    //          {
        //    //              components.Add(new Dictionary<string, object>
        //    //              {
        //    //                  ["type"] = "button",
        //    //                  ["sub_type"] = subtype,
        //    //                  ["index"] = i
        //    //              });
        //    //              continue;
        //    //          }
        //    //          if (string.IsNullOrWhiteSpace(btnValue)) continue;

        //    //          var phone = string.IsNullOrWhiteSpace(contact?.PhoneNumber)
        //    //              ? ""
        //    //              : (contact.PhoneNumber.StartsWith("+") ? contact.PhoneNumber : "+" + contact.PhoneNumber);

        //    //          var encodedPhone = Uri.EscapeDataString(phone);
        //    //          var resolvedDestination = btnValue.Contains("{{1}}")
        //    //              ? btnValue.Replace("{{1}}", encodedPhone)
        //    //              : btnValue;

        //    //          var token = TrackingToken.Create(new ClickToken(
        //    //              cid: campaignSendLogId,
        //    //              btnIndex: i,
        //    //              btnTitle: btn.Title,
        //    //              to: resolvedDestination,
        //    //              phone: phone
        //    //          ));

        //    //          var param = new Dictionary<string, object> { ["type"] = "text", ["text"] = token };

        //    //          components.Add(new Dictionary<string, object>
        //    //          {
        //    //              ["type"] = "button",
        //    //              ["sub_type"] = subtype,
        //    //              ["index"] = i, // keep numeric for Pinnacle if you like
        //    //              ["parameters"] = new[] { param }
        //    //          });


        //    //          // Guard: we need a value for dynamic
        //    //          if (string.IsNullOrWhiteSpace(btnValue))
        //    //              continue;

        //    //          // =====================================================================
        //    //          // IMPORTANT:
        //    //          // For dynamic URL buttons, the provider wants ONLY the value that
        //    //          // replaces {{1}} — NOT a full URL.
        //    //          //
        //    //          // Strategy:
        //    //          // - If your template base is your tracking domain (/r/{{1}}):
        //    //          //     -> supply a TOKEN as the {{1}} value (recommended for tracking).
        //    //          // - If your template base is the destination domain (dest.com/{{1}}):
        //    //          //     -> supply only the suffix (no redirect tracking possible).
        //    //          // =====================================================================

        //    //          // Normalize E.164 phone (leading '+')
        //    //          var phone = string.IsNullOrWhiteSpace(contact?.PhoneNumber)
        //    //              ? ""
        //    //              : (contact.PhoneNumber.StartsWith("+") ? contact.PhoneNumber : "+" + contact.PhoneNumber);

        //    //          // Does our template base look like a tracking base?
        //    //          bool templateIsTrackingBase =
        //    //              metaParam.StartsWith("https://", StringComparison.OrdinalIgnoreCase) &&
        //    //             (metaParam.Contains("/r/{{1}}", StringComparison.OrdinalIgnoreCase) ||
        //    //              metaParam.Contains("/api/tracking/redirect/{{1}}", StringComparison.OrdinalIgnoreCase));

        //    //          string parameterToSend; // the actual string that REPLACES {{1}}

        //    //          if (templateIsTrackingBase)
        //    //          {
        //    //              // --- Tracking base pattern ---
        //    //              // Build a token from the FINAL destination (btnValue may itself contain {{1}} for phone)
        //    //              var resolvedDestination = btnValue.Contains("{{1}}")
        //    //                  ? btnValue.Replace("{{1}}", phone) // put phone into the destination if required
        //    //                  : btnValue;

        //    //              // Option A: simple base64url token with JSON payload
        //    //              var payload = new
        //    //              {
        //    //                  to = resolvedDestination,
        //    //                  btn = btn.Title,
        //    //                  cid = campaignSendLogId,
        //    //                  phone = phone
        //    //              };
        //    //              parameterToSend = CreateBase64UrlToken(payload);

        //    //              // Option B (alternate): if your tracking template is "...?to={{1}}", then
        //    //              // parameterToSend must be the URL-encoded destination itself (skip token).
        //    //              // Uncomment if you use that template style:
        //    //              // parameterToSend = resolvedDestination;
        //    //          }
        //    //          else
        //    //          {
        //    //              // --- Destination base pattern ---
        //    //              // The template base is like "https://destination.com/{{1}}"
        //    //              // We can only send the suffix (no redirect tracking).
        //    //              // If btnValue contains {{1}}, replace with phone; otherwise use it as-is.
        //    //              var suffix = btnValue.Contains("{{1}}")
        //    //                  ? btnValue.Replace("{{1}}", phone)
        //    //                  : btnValue;

        //    //              // Ensure we don't accidentally pass a full URL as the suffix.
        //    //              // If a full URL was entered, strip the protocol/host so we pass only the path/query.
        //    //              if (Uri.TryCreate(suffix, UriKind.Absolute, out var abs))
        //    //              {
        //    //                  var normalized = abs.PathAndQuery.TrimStart('/');
        //    //                  parameterToSend = normalized;
        //    //              }
        //    //              else
        //    //              {
        //    //                  parameterToSend = suffix.TrimStart('/'); // clean leading slash
        //    //              }
        //    //          }

        //    //          var param = new Dictionary<string, object>
        //    //          {
        //    //              ["type"] = "text",
        //    //              ["text"] = parameterToSend
        //    //          };

        //    //          components.Add(new Dictionary<string, object>
        //    //          {
        //    //              ["type"] = "button",
        //    //              ["sub_type"] = subtype, // "url"
        //    //              ["index"] = i,       // keep numeric
        //    //              ["parameters"] = new[] { param }
        //    //          });
        //    //      }

        //    //      return components;
        //    //  }
        //    //  #endregion
        //    // Helper: tiny base64url token creator (same as earlier suggestion)

        //    private List<object> BuildTextTemplateComponents_Pinnacle(
        //List<string> templateParams,
        //List<CampaignButton>? buttonList,
        //TemplateMetadataDto templateMeta,
        //Guid campaignSendLogId,
        //Contact contact)
        //    {
        //        var components = new List<object>();

        //        // Body parameters
        //        if (templateParams != null && templateParams.Count > 0 && templateMeta.PlaceholderCount > 0)
        //        {
        //            components.Add(new
        //            {
        //                type = "body",
        //                parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray()
        //            });
        //        }

        //        // Buttons (dynamic only)
        //        if (buttonList == null || buttonList.Count == 0 ||
        //            templateMeta.ButtonParams == null || templateMeta.ButtonParams.Count == 0)
        //            return components;

        //        var total = Math.Min(3, Math.Min(buttonList.Count, templateMeta.ButtonParams.Count));

        //        for (int i = 0; i < total; i++)
        //        {
        //            var btn = buttonList[i];
        //            var meta = templateMeta.ButtonParams[i];

        //            var subtype = (meta.SubType ?? "url").ToLowerInvariant();
        //            var metaParam = meta.ParameterValue?.Trim() ?? string.Empty;   // template’s configured URL (likely https://yourdomain/{{1}})
        //            var btnValue = btn.Value?.Trim();                             // final destination you saved in DB (e.g., https://youtube/... )
        //            var isDynamic = metaParam.Contains("{{");

        //            // Non-dynamic buttons: send with no parameters
        //            if (!isDynamic)
        //            {
        //                components.Add(new Dictionary<string, object>
        //                {
        //                    ["type"] = "button",
        //                    ["sub_type"] = subtype,
        //                    ["index"] = i
        //                });
        //                continue;
        //            }

        //            // Need a value for dynamic buttons
        //            if (string.IsNullOrWhiteSpace(btnValue)) continue;

        //            // Normalize phone
        //            var phone = string.IsNullOrWhiteSpace(contact?.PhoneNumber)
        //                ? ""
        //                : (contact.PhoneNumber.StartsWith("+") ? contact.PhoneNumber : "+" + contact.PhoneNumber);

        //            // If your destination itself contains {{1}} (e.g., you want phone inside the destination),
        //            // resolve it ONCE here. Use URL-encoded phone because it goes into a URL.
        //            var encodedPhone = Uri.EscapeDataString(phone);
        //            var resolvedDestination = btnValue.Contains("{{1}}")
        //                ? btnValue.Replace("{{1}}", encodedPhone)
        //                : btnValue;

        //            // Build a tracking token to pass as {{1}}. The template base should be your backend:
        //            //   https://your-ngrok-subdomain.ngrok-free.app/{{1}}
        //            var token = TrackingToken.Create(new ClickToken(
        //                cid: campaignSendLogId,
        //                btnIndex: i,
        //                btnTitle: btn.Title,
        //                to: resolvedDestination,
        //                phone: phone
        //            ));

        //            var param = new Dictionary<string, object>
        //            {
        //                ["type"] = "text",
        //                ["text"] = token
        //            };

        //            components.Add(new Dictionary<string, object>
        //            {
        //                ["type"] = "button",
        //                ["sub_type"] = subtype,   // "url"
        //                ["index"] = i,         // Pinnacle accepts numeric index
        //                ["parameters"] = new[] { param }
        //            });
        //        }

        //        return components;
        //    }

        //    private static string CreateBase64UrlToken(object payload)
        //    {
        //        var json = System.Text.Json.JsonSerializer.Serialize(payload);
        //        var bytes = System.Text.Encoding.UTF8.GetBytes(json);
        //        return Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlEncode(bytes);
        //    }

        //    /// <summary>
        //    /// Builds components for a Text Template for the Meta Cloud API.
        //    /// This logic ONLY sends components for dynamic buttons and generates a tracking URL for each.
        //    /// </summary>
        //    private List<object> BuildTextTemplateComponents_Meta(
        //   List<string> templateParams,
        //   List<CampaignButton>? buttonList,
        //   TemplateMetadataDto templateMeta,
        //   Guid campaignSendLogId,
        //   Contact contact) // 👇 FIX: Accept the Contact object as a parameter
        //    {
        //        var components = new List<object>();

        //        // Body parameters (with safeguard)
        //        if (templateParams != null && templateParams.Count > 0 && templateMeta.PlaceholderCount > 0)
        //        {
        //            components.Add(new { type = "body", parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray() });
        //        }

        //        // Button components (Meta logic: only for dynamic buttons)
        //        if (buttonList != null && buttonList.Count > 0 && templateMeta.ButtonParams != null && templateMeta.ButtonParams.Count > 0)
        //        {
        //            var total = Math.Min(3, Math.Min(buttonList.Count, templateMeta.ButtonParams.Count));
        //            for (int i = 0; i < total; i++)
        //            {
        //                var meta = templateMeta.ButtonParams[i];
        //                var metaParam = meta.ParameterValue?.Trim();
        //                bool isDynamic = !string.IsNullOrWhiteSpace(metaParam) && metaParam.Contains("{{");

        //                // ...
        //                if (isDynamic)
        //                {
        //                    var btn = buttonList[i];
        //                    var value = btn.Value?.Trim();
        //                    if (string.IsNullOrWhiteSpace(value)) continue;

        //                    var phone = string.IsNullOrWhiteSpace(contact?.PhoneNumber)
        //                        ? ""
        //                        : (contact.PhoneNumber.StartsWith("+") ? contact.PhoneNumber : "+" + contact.PhoneNumber);

        //                    var encodedPhone = Uri.EscapeDataString(phone);
        //                    var resolvedDestination = value.Contains("{{1}}")
        //                        ? value.Replace("{{1}}", encodedPhone)
        //                        : value;

        //                    var token = TrackingToken.Create(new ClickToken(
        //                        cid: campaignSendLogId,
        //                        btnIndex: i,
        //                        btnTitle: btn.Title,
        //                        to: resolvedDestination,
        //                        phone: phone
        //                    ));

        //                    var param = new Dictionary<string, object> { ["type"] = "text", ["text"] = token };

        //                    components.Add(new Dictionary<string, object>
        //                    {
        //                        ["type"] = "button",
        //                        ["sub_type"] = (meta.SubType ?? "url").ToLowerInvariant(),
        //                        ["index"] = i.ToString(),
        //                        ["parameters"] = new[] { param }
        //                    });
        //                }


        //            }
        //        }
        //        return components;
        //    }

        //    #endregion

        //public async Task<ResponseResult> SendImageTemplateCampaignAsync(Campaign campaign)
        //{
        //    try
        //    {
        //        if (campaign == null || campaign.IsDeleted)
        //            return ResponseResult.ErrorInfo("❌ Invalid campaign.");

        //        var businessId = campaign.BusinessId;
        //        var setting = await _context.WhatsAppSettings.AsNoTracking().FirstOrDefaultAsync(s => s.BusinessId == businessId && s.IsActive);
        //        if (setting == null)
        //            return ResponseResult.ErrorInfo("❌ WhatsApp settings not found for this business.");

        //        var providerKey = (setting.Provider ?? "meta_cloud").ToLowerInvariant();
        //        var templateName = campaign.TemplateId;
        //        var imageUrl = campaign.ImageUrl;
        //        var templateParams = TemplateParameterHelper.ParseTemplateParams(campaign.TemplateParameters);
        //        var buttons = campaign.MultiButtons?.ToList();
        //        var templateMeta = await _templateFetcherService.GetTemplateByNameAsync(businessId, templateName, includeButtons: true);

        //        if (templateMeta == null)
        //            return ResponseResult.ErrorInfo("❌ Template metadata not found.");

        //        int successCount = 0, failureCount = 0;
        //        foreach (var recipient in campaign.Recipients)
        //        {
        //            if (recipient?.Contact == null) continue;

        //            var campaignSendLogId = Guid.NewGuid();

        //            List<object> components;
        //            if (providerKey == "pinnacle")
        //            {
        //                // 👇 FIX: Pass 'recipient.Contact' to the helper method
        //                components = BuildImageTemplateComponents_Pinnacle(imageUrl, templateParams, buttons, templateMeta, campaignSendLogId, recipient.Contact);
        //            }
        //            else
        //            {
        //                // 👇 FIX: Pass 'recipient.Contact' to the helper method
        //                components = BuildImageTemplateComponents_Meta(imageUrl, templateParams, buttons, templateMeta, campaignSendLogId, recipient.Contact);
        //            }

        //            var payload = new
        //            {
        //                messaging_product = "whatsapp",
        //                to = recipient.Contact.PhoneNumber,
        //                type = "template",
        //                template = new
        //                {
        //                    name = templateName,
        //                    language = new { code = string.IsNullOrWhiteSpace(templateMeta.Language) ? "en_US" : templateMeta.Language },
        //                    components
        //                }
        //            };

        //            var sendResult = await _messageEngineService.SendPayloadAsync(businessId, payload);

        //            var messageLog = new MessageLog
        //            {
        //                Id = Guid.NewGuid(),
        //                BusinessId = businessId,
        //                CampaignId = campaign.Id,
        //                ContactId = recipient.ContactId,
        //                RecipientNumber = recipient.Contact.PhoneNumber,
        //                MessageContent = campaign.MessageTemplate ?? templateName,
        //                MediaUrl = imageUrl,
        //                Status = sendResult.Success ? "Sent" : "Failed",
        //                MessageId = sendResult.MessageId,
        //                ErrorMessage = sendResult.ErrorMessage,
        //                RawResponse = sendResult.RawResponse,
        //                CreatedAt = DateTime.UtcNow,
        //                SentAt = sendResult.Success ? DateTime.UtcNow : (DateTime?)null,
        //                Source = "campaign"
        //            };
        //            await _context.MessageLogs.AddAsync(messageLog);

        //            await _context.CampaignSendLogs.AddAsync(new CampaignSendLog
        //            {
        //                Id = campaignSendLogId,
        //                CampaignId = campaign.Id,
        //                BusinessId = businessId,
        //                ContactId = recipient.ContactId,
        //                RecipientId = recipient.Id,
        //                MessageBody = campaign.MessageBody ?? templateName,
        //                TemplateId = templateName,
        //                SendStatus = sendResult.Success ? "Sent" : "Failed",
        //                ErrorMessage = sendResult.Success ? null : sendResult.Message,
        //                MessageLogId = messageLog.Id,
        //                MessageId = sendResult.MessageId,
        //                CreatedAt = DateTime.UtcNow,
        //                SentAt = DateTime.UtcNow,
        //                CreatedBy = campaign.CreatedBy
        //            });

        //            if (sendResult.Success) successCount++; else failureCount++;
        //        }

        //        await _context.SaveChangesAsync();
        //        return ResponseResult.SuccessInfo($"📤 Sent to {successCount} contacts. ❌ Failed for {failureCount}.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "Error while sending image template campaign");
        //        return ResponseResult.ErrorInfo("🚨 Unexpected error while sending campaign.", ex.ToString());
        //    }
        //}
        //#region Image Component Builders

        ///// <summary>
        ///// Builds components for an Image Template for the Pinnacle API.
        ///// It creates a component for every button and generates a tracking URL for dynamic ones.
        ///// </summary>
        //private List<object> BuildImageTemplateComponents_Pinnacle(
        //    string? imageUrl,
        //    List<string> templateParams,
        //    List<CampaignButton>? buttonList,
        //    TemplateMetadataDto templateMeta,
        //    Guid campaignSendLogId,
        //    Contact contact) // 👇 FIX: Accept the Contact object as a parameter
        //{
        //    var components = new List<object>();

        //    // Header component
        //    if (!string.IsNullOrWhiteSpace(imageUrl) && templateMeta.HasImageHeader)
        //    {
        //        components.Add(new { type = "header", parameters = new object[] { new { type = "image", image = new { link = imageUrl } } } });
        //    }

        //    // Body component (with safeguard)
        //    if (templateParams != null && templateParams.Count > 0 && templateMeta.PlaceholderCount > 0)
        //    {
        //        components.Add(new { type = "body", parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray() });
        //    }

        //    // Button components
        //    if (buttonList != null && buttonList.Count > 0 && templateMeta.ButtonParams != null && templateMeta.ButtonParams.Count > 0)
        //    {
        //        var total = Math.Min(3, Math.Min(buttonList.Count, templateMeta.ButtonParams.Count));
        //        for (int i = 0; i < total; i++)
        //        {
        //            var btn = buttonList[i];
        //            var meta = templateMeta.ButtonParams[i];
        //            var subtype = (meta.SubType ?? "url").ToLowerInvariant();
        //            var metaParam = meta.ParameterValue?.Trim();
        //            var value = btn.Value?.Trim();
        //            bool isDynamic = !string.IsNullOrWhiteSpace(metaParam) && metaParam.Contains("{{");

        //            var dict = new Dictionary<string, object> { ["type"] = "button", ["sub_type"] = subtype, ["index"] = i.ToString() };

        //            if (isDynamic && !string.IsNullOrWhiteSpace(value))
        //            {
        //                // 👇 FIX: Use the 'contact' object that was passed into this method
        //                var trackingUrl = _urlBuilderService.GenerateCampaignTrackingUrl(campaignSendLogId, btn.Title, value, contact.PhoneNumber);
        //                var param = new Dictionary<string, object> { ["type"] = "text", ["text"] = trackingUrl };
        //                dict["parameters"] = new[] { param };
        //            }
        //            components.Add(dict); 
        //            if (isDynamic && !string.IsNullOrWhiteSpace(value))
        //            {
        //                var phone = string.IsNullOrWhiteSpace(contact?.PhoneNumber)
        //                    ? ""
        //                    : (contact.PhoneNumber.StartsWith("+") ? contact.PhoneNumber : "+" + contact.PhoneNumber);

        //                var encodedPhone = Uri.EscapeDataString(phone);
        //                var resolvedDestination = value.Contains("{{1}}")
        //                    ? value.Replace("{{1}}", encodedPhone)
        //                    : value;

        //                var token = TrackingToken.Create(new ClickToken(
        //                    cid: campaignSendLogId,
        //                    btnIndex: i,
        //                    btnTitle: btn.Title,
        //                    to: resolvedDestination,
        //                    phone: phone
        //                ));

        //                var param = new Dictionary<string, object> { ["type"] = "text", ["text"] = token };
        //                dict["parameters"] = new[] { param };
        //            }

        //        }
        //    }
        //    return components;
        //}

        ///// <summary>
        ///// Builds components for an Image Template for the Meta Cloud API.
        ///// It correctly formats the header and ONLY includes components for dynamic buttons,
        ///// generating a tracking URL for each.
        ///// </summary>
        //private List<object> BuildImageTemplateComponents_Meta(
        //    string? imageUrl,
        //    List<string> templateParams,
        //    List<CampaignButton>? buttonList,
        //    TemplateMetadataDto templateMeta,
        //    Guid campaignSendLogId,
        //    Contact contact) // 👇 FIX: Accept the Contact object as a parameter
        //{
        //    var components = new List<object>();

        //    // Header component
        //    if (!string.IsNullOrWhiteSpace(imageUrl) && templateMeta.HasImageHeader)
        //    {
        //        components.Add(new { type = "header", parameters = new[] { new { type = "image", image = new { link = imageUrl } } } });
        //    }

        //    // Body component (with safeguard)
        //    if (templateParams != null && templateParams.Count > 0 && templateMeta.PlaceholderCount > 0)
        //    {
        //        components.Add(new { type = "body", parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray() });
        //    }

        //    // Button components (Meta logic: only for dynamic buttons)
        //    if (buttonList != null && buttonList.Count > 0 && templateMeta.ButtonParams != null && templateMeta.ButtonParams.Count > 0)
        //    {
        //        var total = Math.Min(3, Math.Min(buttonList.Count, templateMeta.ButtonParams.Count));
        //        for (int i = 0; i < total; i++)
        //        {
        //            var meta = templateMeta.ButtonParams[i];
        //            var metaParam = meta.ParameterValue?.Trim();
        //            bool isDynamic = !string.IsNullOrWhiteSpace(metaParam) && metaParam.Contains("{{");

        //            if (isDynamic)
        //            {
        //                var btn = buttonList[i];
        //                var value = btn.Value?.Trim();
        //                if (string.IsNullOrWhiteSpace(value)) continue;

        //                var subtype = (meta.SubType ?? "url").ToLowerInvariant();

        //                // 👇 FIX: Use the 'contact' object that was passed into this method
        //                var trackingUrl = _urlBuilderService.GenerateCampaignTrackingUrl(campaignSendLogId, btn.Title, value, contact.PhoneNumber);
        //                var param = new Dictionary<string, object> { ["type"] = "text", ["text"] = trackingUrl };

        //                components.Add(new Dictionary<string, object>
        //                {
        //                    ["type"] = "button",
        //                    ["sub_type"] = subtype,
        //                    ["index"] = i.ToString(),
        //                    ["parameters"] = new[] { param }
        //                });
        //            }
        //        }
        //    }
        //    return components;
        //}

        //#endregion

        #region SendImagetemplate
        public async Task<ResponseResult> SendImageTemplateCampaignAsync(Campaign campaign)
        {
            try
            {
                if (campaign == null || campaign.IsDeleted)
                    return ResponseResult.ErrorInfo("❌ Invalid campaign.");

                var businessId = campaign.BusinessId;
                var setting = await _context.WhatsAppSettings
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.BusinessId == businessId && s.IsActive);

                if (setting == null)
                    return ResponseResult.ErrorInfo("❌ WhatsApp settings not found for this business.");

                var providerKey = (setting.Provider ?? "meta_cloud").ToLowerInvariant();
                var templateName = campaign.TemplateId;
                var imageUrl = campaign.ImageUrl;
                var templateParams = TemplateParameterHelper.ParseTemplateParams(campaign.TemplateParameters);
                var buttons = campaign.MultiButtons?.ToList();
                var templateMeta = await _templateFetcherService.GetTemplateByNameAsync(businessId, templateName, includeButtons: true);

                if (templateMeta == null)
                    return ResponseResult.ErrorInfo("❌ Template metadata not found.");

                int successCount = 0, failureCount = 0;

                foreach (var recipient in campaign.Recipients)
                {
                    if (recipient?.Contact == null) continue;

                    var campaignSendLogId = Guid.NewGuid();

                    List<object> components =
                        providerKey == "pinnacle"
                        ? BuildImageTemplateComponents_Pinnacle(imageUrl, templateParams, buttons, templateMeta, campaignSendLogId, recipient.Contact)
                        : BuildImageTemplateComponents_Meta(imageUrl, templateParams, buttons, templateMeta, campaignSendLogId, recipient.Contact);

                    var payload = new
                    {
                        messaging_product = "whatsapp",
                        to = recipient.Contact.PhoneNumber,
                        type = "template",
                        template = new
                        {
                            name = templateName,
                            language = new { code = string.IsNullOrWhiteSpace(templateMeta.Language) ? "en_US" : templateMeta.Language },
                            components
                        }
                    };

                    var sendResult = await _messageEngineService.SendPayloadAsync(businessId, payload);

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
                        SentAt = sendResult.Success ? DateTime.UtcNow : (DateTime?)null,
                        Source = "campaign"
                    };
                    await _context.MessageLogs.AddAsync(messageLog);

                    await _context.CampaignSendLogs.AddAsync(new CampaignSendLog
                    {
                        Id = campaignSendLogId,
                        CampaignId = campaign.Id,
                        BusinessId = businessId,
                        ContactId = recipient.ContactId,
                        RecipientId = recipient.Id,
                        MessageBody = campaign.MessageBody ?? templateName,
                        TemplateId = templateName,
                        SendStatus = sendResult.Success ? "Sent" : "Failed",
                        ErrorMessage = sendResult.Success ? null : sendResult.Message,
                        MessageLogId = messageLog.Id,
                        MessageId = sendResult.MessageId,
                        CreatedAt = DateTime.UtcNow,
                        SentAt = DateTime.UtcNow,
                        CreatedBy = campaign.CreatedBy
                    });

                    if (sendResult.Success) successCount++; else failureCount++;
                }

                await _context.SaveChangesAsync();
                return ResponseResult.SuccessInfo($"📤 Sent to {successCount} contacts. ❌ Failed for {failureCount}.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while sending image template campaign");
                return ResponseResult.ErrorInfo("🚨 Unexpected error while sending campaign.", ex.ToString());
            }
        }
        private List<object> BuildImageTemplateComponents_Pinnacle(
            string? imageUrl,
            List<string> templateParams,
            List<CampaignButton>? buttonList,
            TemplateMetadataDto templateMeta,
            Guid campaignSendLogId,
            Contact contact)
        {
            var components = new List<object>();

            // Header (image header only if template supports it)
            if (!string.IsNullOrWhiteSpace(imageUrl) && templateMeta.HasImageHeader)
            {
                components.Add(new
                {
                    type = "header",
                    parameters = new object[]
                    {
                new { type = "image", image = new { link = imageUrl } }
                    }
                });
            }

            // Body
            if (templateParams != null && templateParams.Count > 0 && templateMeta.PlaceholderCount > 0)
            {
                components.Add(new
                {
                    type = "body",
                    parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray()
                });
            }

            // Buttons
            if (buttonList == null || buttonList.Count == 0 ||
                templateMeta.ButtonParams == null || templateMeta.ButtonParams.Count == 0)
                return components;

            var total = Math.Min(3, Math.Min(buttonList.Count, templateMeta.ButtonParams.Count));

            for (int i = 0; i < total; i++)
            {
                var btn = buttonList[i];
                var meta = templateMeta.ButtonParams[i];
                var subtype = (meta.SubType ?? "url").ToLowerInvariant();
                var metaParam = meta.ParameterValue?.Trim() ?? string.Empty;   // expects /r/{{1}} in template
                var btnValue = btn.Value?.Trim();
                var isDynamic = metaParam.Contains("{{");

                // Non-dynamic → no parameters
                if (!isDynamic)
                {
                    components.Add(new Dictionary<string, object>
                    {
                        ["type"] = "button",
                        ["sub_type"] = subtype,
                        ["index"] = i  // Pinnacle accepts numeric
                    });
                    continue;
                }

                if (string.IsNullOrWhiteSpace(btnValue)) continue;

                // Normalize phone and resolve inside destination if needed
                var phone = string.IsNullOrWhiteSpace(contact?.PhoneNumber)
                    ? ""
                    : (contact.PhoneNumber.StartsWith("+") ? contact.PhoneNumber : "+" + contact.PhoneNumber);
                var encodedPhone = Uri.EscapeDataString(phone);

                var resolvedDestination = btnValue.Contains("{{1}}")
                    ? btnValue.Replace("{{1}}", encodedPhone)
                    : btnValue;

                // Build full tracked URL then extract token for {{1}}
                var tokenParam = BuildTokenParam(campaignSendLogId, i, btn.Title, resolvedDestination);

                var param = new Dictionary<string, object> { ["type"] = "text", ["text"] = tokenParam };

                components.Add(new Dictionary<string, object>
                {
                    ["type"] = "button",
                    ["sub_type"] = subtype,
                    ["index"] = i,
                    ["parameters"] = new[] { param }
                });
            }

            return components;
        }
        private List<object> BuildImageTemplateComponents_Meta(
            string? imageUrl,
            List<string> templateParams,
            List<CampaignButton>? buttonList,
            TemplateMetadataDto templateMeta,
            Guid campaignSendLogId,
            Contact contact)
        {
            var components = new List<object>();

            // Header (image)
            if (!string.IsNullOrWhiteSpace(imageUrl) && templateMeta.HasImageHeader)
            {
                components.Add(new
                {
                    type = "header",
                    parameters = new[]
                    {
                new { type = "image", image = new { link = imageUrl } }
            }
                });
            }

            // Body
            if (templateParams != null && templateParams.Count > 0 && templateMeta.PlaceholderCount > 0)
            {
                components.Add(new
                {
                    type = "body",
                    parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray()
                });
            }

            // Buttons (Meta sends params only for dynamic ones)
            if (buttonList != null && buttonList.Count > 0 &&
                templateMeta.ButtonParams != null && templateMeta.ButtonParams.Count > 0)
            {
                var total = Math.Min(3, Math.Min(buttonList.Count, templateMeta.ButtonParams.Count));

                for (int i = 0; i < total; i++)
                {
                    var meta = templateMeta.ButtonParams[i];
                    var metaParam = meta.ParameterValue?.Trim();
                    bool isDynamic = !string.IsNullOrWhiteSpace(metaParam) && metaParam.Contains("{{");

                    if (!isDynamic) continue;

                    var btn = buttonList[i];
                    var value = btn.Value?.Trim();
                    if (string.IsNullOrWhiteSpace(value)) continue;

                    var subtype = (meta.SubType ?? "url").ToLowerInvariant();

                    // Normalize phone and resolve inside destination if needed
                    var phone = string.IsNullOrWhiteSpace(contact?.PhoneNumber)
                        ? ""
                        : (contact.PhoneNumber.StartsWith("+") ? contact.PhoneNumber : "+" + contact.PhoneNumber);
                    var encodedPhone = Uri.EscapeDataString(phone);

                    var resolvedDestination = value.Contains("{{1}}")
                        ? value.Replace("{{1}}", encodedPhone)
                        : value;

                    // Build full tracked URL then extract token for {{1}}
                    var tokenParam = BuildTokenParam(campaignSendLogId, i, btn.Title, resolvedDestination);

                    var param = new Dictionary<string, object> { ["type"] = "text", ["text"] = tokenParam };

                    components.Add(new Dictionary<string, object>
                    {
                        ["type"] = "button",
                        ["sub_type"] = subtype,       // "url"
                        ["index"] = i.ToString(),     // Meta uses "0"/"1"/"2"
                        ["parameters"] = new[] { param }
                    });
                }
            }

            return components;
        }


        #endregion
        #endregion

        #region Helper Method
        private static string NormalizePhoneForTel(string? raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return "";
            var p = raw.Trim();
            if (!p.StartsWith("+")) p = "+" + new string(p.Where(char.IsDigit).ToArray());
            return p;
        }

        #endregion

    }

}
