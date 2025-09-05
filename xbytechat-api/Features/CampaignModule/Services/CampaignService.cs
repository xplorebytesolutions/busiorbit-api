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
using Microsoft.Extensions.DependencyInjection;
using xbytechat.api.Features.xbTimeline.Services;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat.api.CRM.Dtos;
using xbytechat.api.Helpers;
using xbytechat_api.WhatsAppSettings.Services;
using xbytechat.api.Shared.utility;
using xbytechat.api.WhatsAppSettings.DTOs;
using xbytechat.api.CRM.Models;
using xbytechat.api.Features.Tracking.Services;
using xbytechat.api.Features.CTAFlowBuilder.Models;
using Newtonsoft.Json;
using System.Text;

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
                .Include(c => c.Cta)
                .Include(c => c.MultiButtons)
                .Include(c => c.CTAFlowConfig)
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
                        ButtonText = b.Title,
                        ButtonType = b.Type,
                        TargetUrl = b.Value
                    }).ToList() ?? new List<CampaignButtonDto>(),
                // ✅ Flow surface to UI
                CTAFlowConfigId = campaign.CTAFlowConfigId,
                CTAFlowName = campaign.CTAFlowConfig?.FlowName
            };
        }
        // Returns the entry step (no incoming links) and its template name.
        // If flow is missing/invalid, returns (null, null) and caller should ignore.
        private async Task<(Guid? entryStepId, string? entryTemplate)> ResolveFlowEntryAsync(Guid businessId, Guid? flowId)
        {
            if (!flowId.HasValue || flowId.Value == Guid.Empty) return (null, null);

            var flow = await _context.CTAFlowConfigs
                .Include(f => f.Steps)
                    .ThenInclude(s => s.ButtonLinks)
                .FirstOrDefaultAsync(f => f.Id == flowId.Value && f.BusinessId == businessId && f.IsActive);

            if (flow == null || flow.Steps == null || flow.Steps.Count == 0) return (null, null);

            var incoming = new HashSet<Guid>(
                flow.Steps.SelectMany(s => s.ButtonLinks)
                          .Where(l => l.NextStepId.HasValue)
                          .Select(l => l.NextStepId!.Value)
            );

            var entry = flow.Steps
                .OrderBy(s => s.StepOrder)
                .FirstOrDefault(s => !incoming.Contains(s.Id));

            return entry == null ? (null, null) : (entry.Id, entry.TemplateToSend);
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

                // 🔁 Parse/normalize template parameters once
                var parsedParams = TemplateParameterHelper.ParseTemplateParams(
                    JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>())
                );

                // 🔄 Flow id from UI (null/empty => no flow). We will persist this as-is.
                Guid? incomingFlowId = (dto.CTAFlowConfigId.HasValue && dto.CTAFlowConfigId.Value != Guid.Empty)
                    ? dto.CTAFlowConfigId.Value
                    : (Guid?)null;

                // We will save this value regardless of validation outcome
                Guid? savedFlowId = incomingFlowId;

                // ============================================================
                // 🧩 FLOW VALIDATION (only to align the starting template)
                // ============================================================
                string selectedTemplateName = dto.TemplateId ?? dto.MessageTemplate ?? string.Empty;

                CTAFlowConfig? flow = null;
                CTAFlowStep? entryStep = null;

                if (incomingFlowId.HasValue)
                {
                    // load flow with steps+links and verify ownership
                    flow = await _context.CTAFlowConfigs
                        .Include(f => f.Steps).ThenInclude(s => s.ButtonLinks)
                        .FirstOrDefaultAsync(f =>
                            f.Id == incomingFlowId.Value &&
                            f.BusinessId == businessId &&
                            f.IsActive);

                    if (flow == null)
                    {
                        Log.Warning("❌ Flow {FlowId} not found/active for business {Biz}. Will persist FlowId but not align template.",
                            incomingFlowId, businessId);
                    }
                    else
                    {
                        // compute entry step: step with NO incoming links
                        var allIncoming = new HashSet<Guid>(flow.Steps
                            .SelectMany(s => s.ButtonLinks)
                            .Where(l => l.NextStepId.HasValue)
                            .Select(l => l.NextStepId!.Value));

                        entryStep = flow.Steps
                            .OrderBy(s => s.StepOrder)
                            .FirstOrDefault(s => !allIncoming.Contains(s.Id));

                        if (entryStep == null)
                        {
                            Log.Warning("❌ Flow {FlowId} has no entry step. Persisting FlowId but not aligning template.", flow.Id);
                        }
                        else if (!string.Equals(selectedTemplateName, entryStep.TemplateToSend, StringComparison.OrdinalIgnoreCase))
                        {
                            Log.Information("ℹ️ Aligning selected template '{Sel}' to flow entry '{Entry}'.",
                                selectedTemplateName, entryStep.TemplateToSend);
                            selectedTemplateName = entryStep.TemplateToSend;
                        }
                    }
                }
                else
                {
                    Log.Information("ℹ️ No flow attached to campaign '{Name}'. Proceeding as plain template campaign.", dto.Name);
                }

                // 🧠 Fetch template (for body + buttons) using the aligned/selected template name
                var template = await _templateFetcherService.GetTemplateByNameAsync(
                    businessId,
                    selectedTemplateName,
                    includeButtons: true
                );

                // 🧠 Resolve message body using template body (if available) else dto.MessageTemplate
                var templateBody = template?.Body ?? dto.MessageTemplate ?? string.Empty;
                var resolvedBody = TemplateParameterHelper.FillPlaceholders(templateBody, parsedParams);

                // ✅ Step 1: Create campaign (CTAFlowConfigId now always = savedFlowId)
                var campaign = new Campaign
                {
                    Id = campaignId,
                    BusinessId = businessId,
                    Name = dto.Name,

                    // store the (possibly aligned) template name
                    MessageTemplate = dto.MessageTemplate,      // keep original text for UI if you use it
                    TemplateId = selectedTemplateName,          // ensure start template matches flow entry when available

                    FollowUpTemplateId = dto.FollowUpTemplateId,
                    CampaignType = dto.CampaignType ?? "text",
                    CtaId = dto.CtaId,
                    CTAFlowConfigId = savedFlowId,              // 👈 persist what UI sent (or null if no flow)

                    ScheduledAt = dto.ScheduledAt,
                    CreatedBy = createdBy,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Status = "Draft",
                    ImageUrl = dto.ImageUrl,
                    ImageCaption = dto.ImageCaption,
                    TemplateParameters = JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>()),
                    MessageBody = resolvedBody
                };

                await _context.Campaigns.AddAsync(campaign);

                // ✅ Step 2: Assign contacts (leave SentAt null until send)
                if (dto.ContactIds != null && dto.ContactIds.Any())
                {
                    var recipients = dto.ContactIds.Select(contactId => new CampaignRecipient
                    {
                        Id = Guid.NewGuid(),
                        CampaignId = campaignId,
                        ContactId = contactId,
                        BusinessId = businessId,
                        Status = "Pending",
                        SentAt = null,
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

                // ======================== Dynamic buttons merge ========================
                if (template != null && template.ButtonParams?.Count > 0)
                {
                    var buttonsToSave = new List<CampaignButton>();
                    var userButtons = dto.ButtonParams ?? new List<CampaignButtonParamFromMetaDto>();

                    var total = Math.Min(3, template.ButtonParams.Count);
                    for (int i = 0; i < total; i++)
                    {
                        var tplBtn = template.ButtonParams[i];
                        var isDynamic = (tplBtn.ParameterValue?.Contains("{{1}}") ?? false);

                        var userBtn = userButtons.FirstOrDefault(b => b.Position == i + 1);
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
                // ======================================================================

                await _context.SaveChangesAsync();

                Log.Information("✅ Campaign '{Name}' created | FlowId: {Flow} | EntryTemplate: {Entry} | Recipients: {Contacts} | UserButtons: {ManualButtons} | TemplateButtons: {TemplateButtons} | Params: {Params}",
                    dto.Name,
                    savedFlowId,
                    entryStep?.TemplateToSend ?? selectedTemplateName,
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
            var campaignId = Guid.NewGuid();

            // 🔁 Parse/normalize template parameters once
            var parsedParams = TemplateParameterHelper.ParseTemplateParams(
                JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>())
            );

            // 🔄 Flow id from UI (null/empty => no flow). We will persist this as-is.
            Guid? incomingFlowId = (dto.CTAFlowConfigId.HasValue && dto.CTAFlowConfigId.Value != Guid.Empty)
                ? dto.CTAFlowConfigId.Value
                : (Guid?)null;

            // We will save this value regardless of validation outcome
            Guid? savedFlowId = incomingFlowId;

            // ============================================================
            // 🧩 FLOW VALIDATION (only to align the starting template)
            // ============================================================
            string selectedTemplateName = dto.TemplateId ?? dto.MessageTemplate ?? string.Empty;

            CTAFlowConfig? flow = null;
            CTAFlowStep? entryStep = null;

            if (incomingFlowId.HasValue)
            {
                // load flow with steps+links and verify ownership
                flow = await _context.CTAFlowConfigs
                    .Include(f => f.Steps).ThenInclude(s => s.ButtonLinks)
                    .FirstOrDefaultAsync(f =>
                        f.Id == incomingFlowId.Value &&
                        f.BusinessId == businessId &&
                        f.IsActive);

                if (flow == null)
                {
                    Log.Warning("❌ Flow {FlowId} not found/active for business {Biz}. Will persist FlowId but not align template.",
                        incomingFlowId, businessId);
                }
                else
                {
                    // compute entry step: step with NO incoming links
                    var allIncoming = new HashSet<Guid>(flow.Steps
                        .SelectMany(s => s.ButtonLinks)
                        .Where(l => l.NextStepId.HasValue)
                        .Select(l => l.NextStepId!.Value));

                    entryStep = flow.Steps
                        .OrderBy(s => s.StepOrder)
                        .FirstOrDefault(s => !allIncoming.Contains(s.Id));

                    if (entryStep == null)
                    {
                        Log.Warning("❌ Flow {FlowId} has no entry step. Persisting FlowId but not aligning template.", flow.Id);
                    }
                    else if (!string.Equals(selectedTemplateName, entryStep.TemplateToSend, StringComparison.OrdinalIgnoreCase))
                    {
                        Log.Information("ℹ️ Aligning selected template '{Sel}' to flow entry '{Entry}'.",
                            selectedTemplateName, entryStep.TemplateToSend);
                        selectedTemplateName = entryStep.TemplateToSend;
                    }
                }
            }
            else
            {
                Log.Information("ℹ️ No flow attached to image campaign '{Name}'. Proceeding as plain template campaign.", dto.Name);
            }

            // 🧠 Fetch template (for body + buttons) using the aligned/selected template name
            var template = await _templateFetcherService.GetTemplateByNameAsync(
                businessId,
                selectedTemplateName,
                includeButtons: true
            );

            // 🧠 Resolve message body using template body (if available) else dto.MessageTemplate
            var templateBody = template?.Body ?? dto.MessageTemplate ?? string.Empty;
            var resolvedBody = TemplateParameterHelper.FillPlaceholders(templateBody, parsedParams);

            // 🎯 Step 1: Create campaign (CTAFlowConfigId now always = savedFlowId)
            var campaign = new Campaign
            {
                Id = campaignId,
                BusinessId = businessId,
                Name = dto.Name,

                // store the (possibly aligned) template name
                MessageTemplate = dto.MessageTemplate,      // keep original text for UI if you use it
                TemplateId = selectedTemplateName,          // ensure start template matches flow entry when available

                FollowUpTemplateId = dto.FollowUpTemplateId,
                CampaignType = "image",
                CtaId = dto.CtaId,
                CTAFlowConfigId = savedFlowId,              // 👈 persist what UI sent (or null if no flow)

                ScheduledAt = dto.ScheduledAt,
                CreatedBy = createdBy,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = "Draft",

                // image-specific fields
                ImageUrl = dto.ImageUrl,
                ImageCaption = dto.ImageCaption,

                // params/body snapshot (useful for previews & auditing)
                TemplateParameters = JsonConvert.SerializeObject(dto.TemplateParameters ?? new List<string>()),
                MessageBody = resolvedBody
            };

            await _context.Campaigns.AddAsync(campaign);

            // ✅ Step 2: Assign contacts (leave SentAt null until send)
            if (dto.ContactIds != null && dto.ContactIds.Any())
            {
                var recipients = dto.ContactIds.Select(contactId => new CampaignRecipient
                {
                    Id = Guid.NewGuid(),
                    CampaignId = campaignId,
                    ContactId = contactId,
                    BusinessId = businessId,
                    Status = "Pending",
                    SentAt = null,
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

            // ======================== Dynamic buttons merge ========================
            // EXACTLY mirrors your text-creator pattern to avoid type issues with ButtonMetadataDto
            if (template != null && template.ButtonParams?.Count > 0)
            {
                var buttonsToSave = new List<CampaignButton>();
                var userButtons = dto.ButtonParams ?? new List<CampaignButtonParamFromMetaDto>();

                var total = Math.Min(3, template.ButtonParams.Count);
                for (int i = 0; i < total; i++)
                {
                    var tplBtn = template.ButtonParams[i];                         // ButtonMetadataDto: Text, Type, SubType, Index, ParameterValue
                    var isDynamic = (tplBtn.ParameterValue?.Contains("{{1}}") ?? false);

                    var userBtn = userButtons.FirstOrDefault(b => b.Position == i + 1);
                    var valueToSave = (isDynamic && userBtn != null)
                        ? userBtn.Value?.Trim()                                    // user override for dynamic URL
                        : tplBtn.ParameterValue;                                   // pattern or static value from meta

                    buttonsToSave.Add(new CampaignButton
                    {
                        Id = Guid.NewGuid(),
                        CampaignId = campaignId,
                        Title = tplBtn.Text,                                       // from ButtonMetadataDto
                        Type = tplBtn.Type,                                        // from ButtonMetadataDto
                        Value = valueToSave,
                        Position = i + 1,
                        IsFromTemplate = true
                    });
                }

                await _context.CampaignButtons.AddRangeAsync(buttonsToSave);
            }
            // ======================================================================

            await _context.SaveChangesAsync();

            Log.Information("✅ Image campaign '{Name}' created | FlowId: {Flow} | EntryTemplate: {Entry} | Recipients: {Contacts} | UserButtons: {ManualButtons} | TemplateButtons: {TemplateButtons} | Params: {Params}",
                dto.Name,
                savedFlowId,
                entryStep?.TemplateToSend ?? selectedTemplateName,
                dto.ContactIds?.Count ?? 0,
                dto.MultiButtons?.Count ?? 0,
                template?.ButtonParams?.Count ?? 0,
                dto.TemplateParameters?.Count ?? 0
            );

            return campaignId;
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

        // This is the Entry point to send Temaplte (Text Based and Image Based)
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

        public async Task<ResponseResult> SendTemplateCampaignWithTypeDetectionAsync(Guid campaignId)
        {
            var campaign = await _context.Campaigns
                .Include(c => c.Recipients).ThenInclude(r => r.Contact)
                .Include(c => c.MultiButtons)
                .FirstOrDefaultAsync(c => c.Id == campaignId && !c.IsDeleted);

            if (campaign == null)
                return ResponseResult.ErrorInfo("❌ Campaign not found.");

            return campaign.CampaignType?.ToLower() switch
            {
                "image" => await SendImageTemplateCampaignAsync(campaign),
                "text" => await SendTextTemplateCampaignAsync(campaign),
                _ => ResponseResult.ErrorInfo("❌ Unsupported campaign type.")
            };
        }
        public async Task<ResponseResult> SendTextTemplateCampaignAsync(Campaign campaign)
        {
            try
            {
                if (campaign == null || campaign.IsDeleted)
                    return ResponseResult.ErrorInfo("❌ Invalid campaign.");

                if (campaign.Recipients == null || campaign.Recipients.Count == 0)
                    return ResponseResult.ErrorInfo("❌ No recipients to send.");

                var businessId = campaign.BusinessId;

                // 🔑 Use Flow entry template if flow is attached; else fallback to campaign.TemplateId/MessageTemplate
                var (_, entryTemplate) = await ResolveFlowEntryAsync(businessId, campaign.CTAFlowConfigId);
                var templateName = !string.IsNullOrWhiteSpace(entryTemplate)
                    ? entryTemplate!
                    : (campaign.TemplateId ?? campaign.MessageTemplate ?? "");

                // 🧠 Fetch template meta (+buttons if you need)
                var templateMeta = await _templateFetcherService
                    .GetTemplateByNameAsync(businessId, templateName, includeButtons: true);

                if (templateMeta == null)
                    return ResponseResult.ErrorInfo("❌ Template metadata not found.");

                // 🚫 Do not hardcode language; require provider meta language
                var languageCode = (templateMeta.Language ?? "").Trim();
                if (string.IsNullOrWhiteSpace(languageCode))
                    return ResponseResult.ErrorInfo("❌ Template language not resolved from provider meta.");

                var templateParams = TemplateParameterHelper.ParseTemplateParams(campaign.TemplateParameters);

                // Existing manual buttons (for dynamic URL values)
                var buttons = campaign.MultiButtons?.OrderBy(b => b.Position).ToList();

                // Provider detection (Meta vs anything else you support)
                var setting = await _context.WhatsAppSettings
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.BusinessId == businessId && s.IsActive);

                if (setting == null)
                    return ResponseResult.ErrorInfo("❌ WhatsApp settings not found.");

                var providerKey = (setting.Provider ?? "meta_cloud").ToLowerInvariant();

                // 🧭 Resolve entry step id (so we can persist context for click processing)
                Guid? entryStepId = null;
                if (campaign.CTAFlowConfigId.HasValue)
                {
                    entryStepId = await _context.CTAFlowSteps
                        .Where(s => s.CTAFlowConfigId == campaign.CTAFlowConfigId.Value)
                        .OrderBy(s => s.StepOrder)
                        .Select(s => (Guid?)s.Id)
                        .FirstOrDefaultAsync();
                }

                // 🧰 Build & freeze a "button bundle" (exact labels/positions user sees)
                // IMPORTANT: store zero-based 'i' and label 't' to match ProcessClickAsync mapping.
                string? buttonBundleJson = null;
                if (templateMeta.ButtonParams != null && templateMeta.ButtonParams.Count > 0)
                {
                    var bundle = templateMeta.ButtonParams
                        .Take(3)
                        .Select((b, i) => new
                        {
                            i = i,                                  // zero-based index used by provider & mapper
                            t = (b.Text ?? "").Trim(),              // label used for text matching
                            position = i + 1,                       // redundant (for readability in tools)
                            text = (b.Text ?? "").Trim(),
                            type = b.Type,
                            subType = b.SubType
                        })
                        .ToList();

                    buttonBundleJson = JsonConvert.SerializeObject(bundle);
                }

                int successCount = 0, failureCount = 0;

                foreach (var r in campaign.Recipients)
                {
                    if (r?.Contact == null) continue;

                    // 🔑 New run per recipient send (prevents cross-run mixing in journey)
                    var runId = Guid.NewGuid();

                    // Build provider components (use your existing builders)
                    var campaignSendLogId = Guid.NewGuid(); // used by tracked URLs
                    List<object> components = providerKey == "pinnacle"
                        ? BuildTextTemplateComponents_Pinnacle(templateParams, buttons, templateMeta, campaignSendLogId, r.Contact)
                        : BuildTextTemplateComponents_Meta(templateParams, buttons, templateMeta, campaignSendLogId, r.Contact);

                    var payload = new
                    {
                        messaging_product = "whatsapp",
                        to = r.Contact.PhoneNumber,
                        type = "template",
                        template = new
                        {
                            name = templateName,
                            language = new { code = languageCode }, // ✅ from provider meta
                            components
                        }
                    };

                    var result = await _messageEngineService.SendPayloadAsync(businessId, payload);

                    // 📌 Persist logs WITH flow context, RunId, and frozen button bundle
                    var logId = Guid.NewGuid();
                    var log = new MessageLog
                    {
                        Id = logId,
                        BusinessId = businessId,
                        CampaignId = campaign.Id,
                        ContactId = r.ContactId,
                        RecipientNumber = r.Contact.PhoneNumber,
                        MessageContent = templateName,                       // NOT NULL
                        Status = result.Success ? "Sent" : "Failed",
                        MessageId = result.MessageId,                        // join key (provider msg id)
                        ErrorMessage = result.ErrorMessage,                  // single source
                        RawResponse = result.RawResponse,
                        CreatedAt = DateTime.UtcNow,
                        SentAt = result.Success ? DateTime.UtcNow : (DateTime?)null, // only when sent
                        Source = "campaign",
                        CTAFlowConfigId = campaign.CTAFlowConfigId,
                        CTAFlowStepId = entryStepId,
                        ButtonBundleJson = buttonBundleJson,
                        RunId = runId                                        // ✅ journey key
                    };
                    _context.MessageLogs.Add(log);

                    await _context.CampaignSendLogs.AddAsync(new CampaignSendLog
                    {
                        Id = campaignSendLogId,
                        CampaignId = campaign.Id,
                        BusinessId = businessId,
                        ContactId = r.ContactId,
                        RecipientId = r.Id,
                        MessageBody = campaign.MessageBody ?? templateName,
                        TemplateId = templateName,
                        SendStatus = result.Success ? "Sent" : "Failed",
                        MessageLogId = log.Id,
                        MessageId = result.MessageId,                        // join key (provider msg id)
                        ErrorMessage = result.ErrorMessage,                  // ✅ same source as MessageLog
                        CreatedAt = DateTime.UtcNow,
                        SentAt = result.Success ? DateTime.UtcNow : (DateTime?)null, // ✅ guard SentAt
                        CreatedBy = campaign.CreatedBy,
                        CTAFlowConfigId = campaign.CTAFlowConfigId,
                        CTAFlowStepId = entryStepId,
                        ButtonBundleJson = buttonBundleJson,
                        RunId = runId                                        // ✅ journey key
                    });

                    if (result.Success) successCount++; else failureCount++;
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


        #region Text Component Builders
        private string BuildTokenParam(Guid campaignSendLogId, int buttonIndex, string? buttonTitle, string destinationUrlAbsolute)
        {
            var full = _urlBuilderService.BuildTrackedButtonUrl(campaignSendLogId, buttonIndex, buttonTitle, destinationUrlAbsolute);
            var pos = full.LastIndexOf("/r/", StringComparison.OrdinalIgnoreCase);
            return (pos >= 0) ? full.Substring(pos + 3) : full; // fallback: if not found, return full (rare)
        }

        //private static string CleanForUri(string s)
        //{
        //    if (s is null) return string.Empty;
        //    var t = s.Trim();
        //    return new string(Array.FindAll(t.ToCharArray(), c => !char.IsControl(c)));
        //}

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

        private static object[] BuildBodyParameters(List<string>? templateParams, int requiredCount)
        {
            if (requiredCount <= 0) return Array.Empty<object>();

            var src = templateParams ?? new List<string>();
            // Trim if more were provided than required
            if (src.Count > requiredCount) src = src.Take(requiredCount).ToList();
            // Pad with empty strings if fewer were provided
            while (src.Count < requiredCount) src.Add(string.Empty);

            // Return in the shape Meta/Pinnacle expect
            return src.Select(p => (object)new { type = "text", text = p ?? string.Empty }).ToArray();
        }
        private List<object> BuildTextTemplateComponents_Meta(
            List<string> templateParams,
            List<CampaignButton>? buttonList,
            TemplateMetadataDto templateMeta,
            Guid campaignSendLogId,
            Contact contact)
        {
            var components = new List<object>();

            // BODY: send exactly PlaceholderCount
            if (templateMeta.PlaceholderCount > 0)
            {
                var bodyParams = BuildBodyParameters(templateParams, templateMeta.PlaceholderCount);
                components.Add(new { type = "body", parameters = bodyParams });
            }

            // No buttons or template has no button params
            if (buttonList == null || buttonList.Count == 0 ||
                templateMeta.ButtonParams == null || templateMeta.ButtonParams.Count == 0)
                return components;

            // ✅ Ensure index alignment with the template by ordering by Position (then original index)
            var orderedButtons = buttonList
                .Select((b, idx) => new { Btn = b, idx })
                .OrderBy(x => (int?)x.Btn.Position ?? int.MaxValue)
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
                if (!string.Equals(subType, "url", StringComparison.OrdinalIgnoreCase))
                    continue;

                var isDynamic = !string.IsNullOrWhiteSpace(metaParam) && metaParam.Contains("{{");
                if (!isDynamic)
                    continue;

                var btn = orderedButtons[i];
                var btnType = (btn?.Type ?? "URL").ToUpperInvariant();
                if (!string.Equals(btnType, "URL", StringComparison.OrdinalIgnoreCase))
                {
                    // If template expects dynamic URL at this index and your campaign button isn't URL, skip to avoid 131008
                    continue;
                }

                var valueRaw = btn.Value?.Trim();
                if (string.IsNullOrWhiteSpace(valueRaw))
                {
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
        private List<object> BuildTextTemplateComponents_Pinnacle(
            List<string> templateParams,
            List<CampaignButton>? buttonList,
            TemplateMetadataDto templateMeta,
            Guid campaignSendLogId,
            Contact contact)
        {
            var components = new List<object>();

            // BODY: Pinnacle is strict → always send exactly PlaceholderCount
            if (templateMeta.PlaceholderCount > 0)
            {
                var bodyParams = BuildBodyParameters(templateParams, templateMeta.PlaceholderCount);
                components.Add(new { type = "body", parameters = bodyParams });
            }

            // No buttons to map → return body-only
            if (buttonList == null || buttonList.Count == 0 ||
                templateMeta.ButtonParams == null || templateMeta.ButtonParams.Count == 0)
                return components;

            // ✅ Ensure index alignment with the template by ordering by Position (then original index)
            var orderedButtons = buttonList
                .Select((b, idx) => new { Btn = b, idx })
                .OrderBy(x => (int?)x.Btn.Position ?? int.MaxValue)
                .ThenBy(x => x.idx)
                .Select(x => x.Btn)
                .ToList();

            var total = Math.Min(3, Math.Min(orderedButtons.Count, templateMeta.ButtonParams.Count));

            for (int i = 0; i < total; i++)
            {
                var meta = templateMeta.ButtonParams[i];
                var subType = (meta.SubType ?? "url").ToLowerInvariant();
                var metaParam = meta.ParameterValue?.Trim();

                // Pinnacle path currently supports dynamic URL params only
                if (!string.Equals(subType, "url", StringComparison.OrdinalIgnoreCase))
                    continue;

                var isDynamic = !string.IsNullOrWhiteSpace(metaParam) && metaParam.Contains("{{");
                if (!isDynamic)
                    continue;

                var btn = orderedButtons[i];
                var btnType = (btn?.Type ?? "URL").ToUpperInvariant();
                if (!string.Equals(btnType, "URL", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        $"Template expects a dynamic URL at button index {i}, but campaign button type is '{btn?.Type}'.");
                }

                var valueRaw = btn?.Value?.Trim();
                if (string.IsNullOrWhiteSpace(valueRaw))
                {
                    throw new InvalidOperationException(
                        $"Template requires a dynamic URL at button index {i}, but campaign button value is empty.");
                }

                // Optional phone substitution
                var phone = string.IsNullOrWhiteSpace(contact?.PhoneNumber)
                    ? ""
                    : (contact.PhoneNumber.StartsWith("+") ? contact.PhoneNumber : "+" + contact.PhoneNumber);
                var encodedPhone = Uri.EscapeDataString(phone);

                var resolvedDestination = valueRaw.Contains("{{1}}")
                    ? valueRaw.Replace("{{1}}", encodedPhone)
                    : valueRaw;

                // Validate + normalize absolute URL
                resolvedDestination = NormalizeAbsoluteUrlOrThrowForButton(resolvedDestination, btn!.Title, i);

                // Build both options: full tracked URL vs token param (for absolute-base placeholders)
                var fullTrackedUrl = _urlBuilderService.BuildTrackedButtonUrl(
                    campaignSendLogId, i, btn.Title, resolvedDestination);

                var tokenParam = BuildTokenParam(campaignSendLogId, i, btn.Title, resolvedDestination);

                var templateHasAbsoluteBase = LooksLikeAbsoluteBaseUrlWithPlaceholder(metaParam);
                var valueToSend = templateHasAbsoluteBase ? tokenParam : fullTrackedUrl;

                // Pinnacle payload shape (aligned with Meta)
                components.Add(new Dictionary<string, object>
                {
                    ["type"] = "button",
                    ["sub_type"] = "url",
                    ["index"] = i.ToString(),
                    ["parameters"] = new[] {
                new Dictionary<string, object> { ["type"] = "text", ["text"] = valueToSend }
            }
                });
            }

            return components;
        }

        #endregion
        #region SendImagetemplate

        public async Task<ResponseResult> SendImageTemplateCampaignAsync(Campaign campaign)
        {
            try
            {
                if (campaign == null || campaign.IsDeleted)
                    return ResponseResult.ErrorInfo("❌ Invalid campaign.");
                if (campaign.Recipients == null || !campaign.Recipients.Any())
                    return ResponseResult.ErrorInfo("❌ No recipients to send.");

                var businessId = campaign.BusinessId;

                // 🔑 Flow entry → template name
                var (_, entryTemplate) = await ResolveFlowEntryAsync(businessId, campaign.CTAFlowConfigId);
                var templateName = !string.IsNullOrWhiteSpace(entryTemplate)
                    ? entryTemplate!
                    : (campaign.TemplateId ?? campaign.MessageTemplate ?? "");

                var language = "en_US";
                var templateParams = JsonConvert.DeserializeObject<List<string>>(campaign.TemplateParameters ?? "[]");

                int success = 0, failed = 0;

                foreach (var r in campaign.Recipients)
                {
                    var dto = new ImageTemplateMessageDto
                    {
                        RecipientNumber = r.Contact.PhoneNumber,
                        TemplateName = templateName,
                        LanguageCode = language,
                        HeaderImageUrl = campaign.ImageUrl,
                        TemplateParameters = templateParams,
                        ButtonParameters = campaign.MultiButtons
                            .OrderBy(b => b.Position)
                            .Take(3)
                            .Select(b => new CampaignButtonDto
                            {
                                ButtonText = b.Title,
                                ButtonType = b.Type,
                                TargetUrl = b.Value
                            }).ToList()
                    };

                    var res = await _messageEngineService.SendImageTemplateMessageAsync(dto, businessId);
                    var ok = res.ToString().ToLower().Contains("messages");

                    _context.MessageLogs.Add(new MessageLog
                    {
                        Id = Guid.NewGuid(),
                        BusinessId = businessId,
                        CampaignId = campaign.Id,
                        ContactId = r.ContactId,
                        RecipientNumber = r.Contact.PhoneNumber,
                        MessageContent = templateName,
                        MediaUrl = campaign.ImageUrl,
                        Status = ok ? "Sent" : "Failed",
                        ErrorMessage = ok ? null : "API Failure",
                        RawResponse = JsonConvert.SerializeObject(res),
                        CreatedAt = DateTime.UtcNow,
                        SentAt = DateTime.UtcNow,
                        Source = "campaign"
                    });

                    if (ok) success++; else failed++;
                }

                await _context.SaveChangesAsync();
                return ResponseResult.SuccessInfo($"✅ Sent: {success}, ❌ Failed: {failed}");
            }
            catch (Exception ex)
            {
                return ResponseResult.ErrorInfo("❌ Unexpected error during campaign send.", ex.ToString());
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


        private static string NormalizePhoneForTel(string? raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return "";
            var p = raw.Trim();
            if (!p.StartsWith("+")) p = "+" + new string(p.Where(char.IsDigit).ToArray());
            return p;
        }
        #endregion

        #endregion

        public async Task<List<FlowListItemDto>> GetAvailableFlowsAsync(Guid businessId, bool onlyPublished = true)
        {
            return await _context.CTAFlowConfigs
                .AsNoTracking()
                .Where(f => f.BusinessId == businessId && f.IsActive && (!onlyPublished || f.IsPublished))
                .OrderByDescending(f => f.UpdatedAt)
                .Select(f => new FlowListItemDto
                {
                    Id = f.Id,
                    FlowName = f.FlowName,
                    IsPublished = f.IsPublished
                })
                .ToListAsync();
        }
    }


}


