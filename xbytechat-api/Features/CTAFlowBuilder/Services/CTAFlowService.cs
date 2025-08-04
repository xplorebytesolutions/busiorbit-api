// 📄 File: Features/CTAFlowBuilder/Services/CTAFlowService.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using xbytechat.api.AuthModule.Models;
using xbytechat.api.CRM.Models;
using xbytechat.api.Features.CTAFlowBuilder.DTOs;
using xbytechat.api.Features.CTAFlowBuilder.Models;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat.api.Features.Tracking.Models;
using xbytechat.api.Helpers;
using xbytechat.api.WhatsAppSettings.DTOs;
using xbytechat_api.WhatsAppSettings.Services;

namespace xbytechat.api.Features.CTAFlowBuilder.Services
{
    public class CTAFlowService : ICTAFlowService
    {
        private readonly AppDbContext _context;
        private readonly IMessageEngineService _messageEngineService;
        private readonly IWhatsAppTemplateFetcherService _templateFetcherService;

        public CTAFlowService(AppDbContext context, IMessageEngineService messageEngineService,
            IWhatsAppTemplateFetcherService templateFetcherService
            )
        {
            _context = context;
            _messageEngineService = messageEngineService;
            _templateFetcherService = templateFetcherService;
        }

        public async Task<Guid> CreateFlowWithStepsAsync(CreateFlowDto dto, Guid businessId, string createdBy)
        {
            var flow = new CTAFlowConfig
            {
                Id = Guid.NewGuid(),
                FlowName = dto.FlowName,
                BusinessId = businessId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = createdBy,
                IsPublished = dto.IsPublished
            };

            foreach (var stepDto in dto.Steps)
            {
                var step = new CTAFlowStep
                {
                    Id = Guid.NewGuid(),
                    CTAFlowConfigId = flow.Id,
                    TriggerButtonText = stepDto.TriggerButtonText,
                    TriggerButtonType = stepDto.TriggerButtonType,
                    TemplateToSend = stepDto.TemplateToSend,
                    StepOrder = stepDto.StepOrder,
                    ButtonLinks = stepDto.ButtonLinks?.Select(link => new FlowButtonLink
                    {
                        ButtonText = link.ButtonText,
                        NextStepId = link.NextStepId
                    }).ToList() ?? new List<FlowButtonLink>()
                };

                flow.Steps.Add(step);
            }

            _context.CTAFlowConfigs.Add(flow);
            await _context.SaveChangesAsync();

            return flow.Id;
        }

        public async Task<CTAFlowConfig?> GetFlowByBusinessAsync(Guid businessId)
        {
            return await _context.CTAFlowConfigs
                .Include(f => f.Steps.OrderBy(s => s.StepOrder))
                .Where(f => f.BusinessId == businessId && f.IsActive && f.IsPublished)
                .FirstOrDefaultAsync();
        }

        public async Task<CTAFlowConfig?> GetDraftFlowByBusinessAsync(Guid businessId)
        {
            return await _context.CTAFlowConfigs
                .Include(f => f.Steps)
                    .ThenInclude(s => s.ButtonLinks)
                .Where(f => f.BusinessId == businessId && f.IsPublished == false)
                .OrderByDescending(f => f.CreatedAt)
                .FirstOrDefaultAsync();
        }



        public async Task<List<CTAFlowStep>> GetStepsForFlowAsync(Guid flowId)
        {
            return await _context.CTAFlowSteps
                .Where(s => s.CTAFlowConfigId == flowId)
                .OrderBy(s => s.StepOrder)
                .ToListAsync();
        }

        public async Task<CTAFlowStep?> MatchStepByButtonAsync(
            Guid businessId,
            string buttonText,
            string buttonType,
            string TemplateName,
            Guid? campaignId = null)
        {
            var normalizedButtonText = buttonText?.Trim().ToLower() ?? "";
            var normalizedButtonType = buttonType?.Trim().ToLower() ?? "";
            var normalizedTemplateName = TemplateName?.Trim().ToLower() ?? "";

            // 1️⃣ Try campaign-specific override
            if (campaignId.HasValue)
            {
                var overrideStep = await _context.CampaignFlowOverrides
                    .Where(o =>
                        o.CampaignId == campaignId &&
                        o.ButtonText.ToLower() == normalizedButtonText &&
                        o.TemplateName.ToLower() == normalizedTemplateName)
                    .FirstOrDefaultAsync();

                if (overrideStep != null)
                {
                    var overrideTemplate = overrideStep.OverrideNextTemplate?.ToLower();

                    var matched = await _context.CTAFlowSteps
                        .Include(s => s.Flow)
                        .FirstOrDefaultAsync(s => s.TemplateToSend.ToLower() == overrideTemplate);

                    if (matched != null)
                    {
                        Log.Information("🔁 Override matched: Template '{Template}' → Step '{StepId}'", overrideStep.OverrideNextTemplate, matched.Id);
                        return matched;
                    }

                    Log.Warning("⚠️ Override found for button '{Button}' but no matching step for template '{Template}'", normalizedButtonText, overrideStep.OverrideNextTemplate);
                }

                else
                {
                    Log.Information("🟡 No campaign override found for button '{Button}' on template '{Template}'", normalizedButtonText, normalizedTemplateName);
                }
            }

            // 2️⃣ Fallback to standard flow logic
            var fallbackStep = await _context.CTAFlowSteps
                .Include(s => s.Flow)
                .Where(s =>
                    s.Flow.BusinessId == businessId &&
                    s.Flow.IsActive &&
                    s.Flow.IsPublished &&
                    s.TriggerButtonText.ToLower() == normalizedButtonText &&
                    s.TriggerButtonType.ToLower() == normalizedButtonType)
                .FirstOrDefaultAsync();

            if (fallbackStep != null)
            {
                Log.Information("✅ Fallback flow step matched: StepId = {StepId}, Flow = {FlowName}", fallbackStep.Id, fallbackStep.Flow?.FlowName);
            }
            else
            {
                Log.Warning("❌ No fallback step matched for button '{ButtonText}' of type '{ButtonType}' in BusinessId: {BusinessId}", normalizedButtonText, normalizedButtonType, businessId);
            }

            return fallbackStep;
        }



        public async Task<ResponseResult> PublishFlowAsync(Guid businessId, List<FlowStepDto> steps, string createdBy)
        {
            try
            {
                // 🔥 1. Remove existing published flow for this business
                var existingFlows = await _context.CTAFlowConfigs
                    .Where(f => f.BusinessId == businessId && f.IsPublished)
                    .ToListAsync();

                if (existingFlows.Any())
                {
                    _context.CTAFlowConfigs.RemoveRange(existingFlows);
                }

                // 🌱 2. Create new flow config
                var flowConfig = new CTAFlowConfig
                {
                    Id = Guid.NewGuid(),
                    BusinessId = businessId,
                    FlowName = "Published Flow - " + DateTime.UtcNow.ToString("yyyyMMdd-HHmm"),
                    IsPublished = true,
                    IsActive = true,
                    CreatedBy = createdBy,
                    CreatedAt = DateTime.UtcNow,
                    Steps = new List<CTAFlowStep>()
                };

                // 🔁 3. Convert each step DTO to model
                foreach (var stepDto in steps)
                {
                    var step = new CTAFlowStep
                    {
                        Id = Guid.NewGuid(),
                        CTAFlowConfigId = flowConfig.Id,
                        TriggerButtonText = stepDto.TriggerButtonText,
                        TriggerButtonType = stepDto.TriggerButtonType,
                        TemplateToSend = stepDto.TemplateToSend,
                        StepOrder = stepDto.StepOrder,
                        ButtonLinks = stepDto.ButtonLinks.Select(bl => new FlowButtonLink
                        {
                            Id = Guid.NewGuid(),
                            ButtonText = bl.ButtonText,
                            NextStepId = bl.NextStepId,
                        }).ToList()
                    };

                    flowConfig.Steps.Add(step);
                }

                // 💾 4. Save to DB
                await _context.CTAFlowConfigs.AddAsync(flowConfig);
                await _context.SaveChangesAsync();

                return ResponseResult.SuccessInfo("✅ Flow published successfully.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "❌ Error while publishing CTA flow.");
                return ResponseResult.ErrorInfo("❌ Could not publish flow.");
            }
        }
        public async Task<ResponseResult> SaveVisualFlowAsync(SaveVisualFlowDto dto, Guid businessId, string createdBy)
        {
            try
            {
                Log.Information("🧠 SaveVisualFlow started | FlowName: {FlowName} | BusinessId: {BusinessId}", dto.FlowName, businessId);

                if (dto.Nodes == null || !dto.Nodes.Any())
                {
                    Log.Warning("❌ No nodes found in flow. Aborting save.");
                    return ResponseResult.ErrorInfo("❌ Cannot save an empty flow. Please add at least one step.");
                }

                var existing = await _context.CTAFlowConfigs
                    .FirstOrDefaultAsync(f => f.FlowName == dto.FlowName && f.BusinessId == businessId);

                if (existing == null)
                {
                    existing = new CTAFlowConfig
                    {
                        Id = Guid.NewGuid(),
                        BusinessId = businessId,
                        FlowName = dto.FlowName,
                        CreatedBy = createdBy,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        IsActive = true,
                        IsPublished = dto.IsPublished
                    };
                    _context.CTAFlowConfigs.Add(existing);
                    Log.Information("✅ New FlowConfig created with ID: {Id}", existing.Id);
                }
                else
                {
                    var oldSteps = await _context.CTAFlowSteps
                        .Where(s => s.CTAFlowConfigId == existing.Id)
                        .Include(s => s.ButtonLinks)
                        .ToListAsync();

                    foreach (var step in oldSteps)
                        _context.FlowButtonLinks.RemoveRange(step.ButtonLinks);

                    _context.CTAFlowSteps.RemoveRange(oldSteps);
                    existing.IsPublished = dto.IsPublished;
                    existing.UpdatedAt = DateTime.UtcNow;
                }

                var stepMap = new Dictionary<string, CTAFlowStep>();

                foreach (var (node, index) in dto.Nodes.Select((n, i) => (n, i)))
                {
                    if (string.IsNullOrWhiteSpace(node.Id))
                        continue;

                    var step = new CTAFlowStep
                    {
                        Id = Guid.NewGuid(),
                        CTAFlowConfigId = existing.Id,
                        StepOrder = index,
                        TemplateToSend = node.TemplateName,
                        TemplateType = node.TemplateType ?? "UNKNOWN",
                        TriggerButtonText = node.TriggerButtonText ?? "",
                        TriggerButtonType = node.TriggerButtonType ?? "cta",
                        PositionX = node.PositionX == 0 ? Random.Shared.Next(100, 600) : node.PositionX,
                        PositionY = node.PositionY == 0 ? Random.Shared.Next(100, 400) : node.PositionY,
                        ButtonLinks = new List<FlowButtonLink>()
                    };

                    stepMap[node.Id] = step;
                    _context.CTAFlowSteps.Add(step);
                }

                foreach (var edge in dto.Edges)
                {
                    if (!stepMap.TryGetValue(edge.FromNodeId, out var fromStep) ||
                        !stepMap.TryGetValue(edge.ToNodeId, out var toStep))
                        continue;

                    var sourceNode = dto.Nodes.FirstOrDefault(n => n.Id == edge.FromNodeId);
                    var button = sourceNode?.Buttons?.FirstOrDefault(b => b.Text == edge.SourceHandle);
                    var fallbackText = edge.SourceHandle ?? "[unnamed]";

                    var link = new FlowButtonLink
                    {
                        Id = Guid.NewGuid(),
                        CTAFlowStepId = fromStep.Id,
                        ButtonText = fallbackText,
                        ButtonType = button?.Type ?? "QUICK_REPLY",
                        ButtonSubType = button?.SubType ?? "",
                        ButtonValue = button?.Value ?? "",
                        NextStepId = toStep.Id
                    };

                    _context.FlowButtonLinks.Add(link); // ✅ Force EF to track this link properly
                    fromStep.ButtonLinks.Add(link);     // ✅ Optional if navigation is used

                    toStep.TriggerButtonText = fallbackText;
                    toStep.TriggerButtonType = button?.Type ?? "quick_reply";
                }

                await _context.SaveChangesAsync();

                Log.Information("✅ Flow '{Flow}' saved | Steps: {StepCount} | Links: {LinkCount}",
                    dto.FlowName, stepMap.Count, stepMap.Values.Sum(s => s.ButtonLinks.Count));

                return ResponseResult.SuccessInfo("✅ Flow saved successfully.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "❌ Exception while saving flow");
                return ResponseResult.ErrorInfo("❌ Internal error while saving flow.");
            }
        }

        public async Task<SaveVisualFlowDto?> GetVisualFlowByIdAsync(Guid flowId)
        {
            var flow = await _context.CTAFlowConfigs
                .Include(c => c.Steps)
                    .ThenInclude(s => s.ButtonLinks)
                .FirstOrDefaultAsync(c => c.Id == flowId && c.IsActive);

            if (flow == null) return null;

            var businessId = flow.BusinessId;

            // ✅ Pre-fetch templates from Meta
            var templateMap = new Dictionary<string, TemplateMetadataDto>();

            foreach (var step in flow.Steps)
            {
                if (!string.IsNullOrWhiteSpace(step.TemplateToSend) && !templateMap.ContainsKey(step.TemplateToSend))
                {
                    try
                    {
                        var template = await _templateFetcherService.GetTemplateByNameAsync(
                            businessId,
                            step.TemplateToSend,
                            includeButtons: true
                        );

                        if (template != null)
                            templateMap[step.TemplateToSend] = template;
                    }
                    catch (Exception ex)
                    {
                        Log.Warning(ex, "⚠️ Failed to fetch template from Meta for {Template}", step.TemplateToSend);
                    }
                }
            }

            // ✅ Map into ReactFlow-compatible structure
            var nodes = flow.Steps.Select(step =>
            {
                var template = templateMap.GetValueOrDefault(step.TemplateToSend);

                return new FlowNodeDto
                {
                    Id = step.Id.ToString(),
                    TemplateName = step.TemplateToSend,
                    MessageBody = template?.Body ?? "Message body preview...",
                    TriggerButtonText = step.TriggerButtonText,
                    TriggerButtonType = step.TriggerButtonType,
                    PositionX = step.PositionX ?? 100,
                    PositionY = step.PositionY ?? 100,

                    // ✅ NEW: Include conditional logic
                    RequiredTag = step.RequiredTag,
                    RequiredSource = step.RequiredSource,

                    Buttons = step.ButtonLinks.Select(link => new LinkButtonDto
                    {
                        Text = link.ButtonText,
                        TargetNodeId = link.NextStepId.ToString()
                    }).ToList()
                             .Concat((template?.ButtonParams ?? new List<ButtonMetadataDto>())
                                 .Where(btn => !step.ButtonLinks.Any(bl => bl.ButtonText == btn.Text))
                                 .Select(btn => new LinkButtonDto
                                 {
                                     Text = btn.Text,
                                     TargetNodeId = null
                                 })).ToList()
                };

            }).ToList();

            return new SaveVisualFlowDto
            {
                FlowName = flow.FlowName,
                IsPublished = flow.IsPublished,
                Nodes = nodes,
                Edges = flow.Steps
                        .SelectMany(step =>
                            step.ButtonLinks.Select(link => new FlowEdgeDto
                            {
                                FromNodeId = step.Id.ToString(),
                                ToNodeId = link.NextStepId.ToString(),
                                SourceHandle = link.ButtonText // ✅ important
                            })
                        ).ToList()

            };
        }


        public async Task<ResponseResult> DeleteFlowAsync(Guid id, Guid businessId)
        {
            var flow = await _context.CTAFlowConfigs
                .Where(f => f.Id == id && f.BusinessId == businessId)
                .FirstOrDefaultAsync();

            if (flow == null)
                return ResponseResult.ErrorInfo("❌ Flow not found or does not belong to you.");

            _context.CTAFlowConfigs.Remove(flow);
            await _context.SaveChangesAsync();

            return ResponseResult.SuccessInfo("✅ Flow deleted successfully.");
        }
        public async Task<List<VisualFlowSummaryDto>> GetAllPublishedFlowsAsync(Guid businessId)
        {
            return await _context.CTAFlowConfigs
                .Where(f => f.BusinessId == businessId && f.IsPublished)
                .OrderByDescending(f => f.CreatedAt)
                .Select(f => new VisualFlowSummaryDto
                {
                    Id = f.Id,
                    FlowName = f.FlowName,
                    IsPublished = f.IsPublished,
                    CreatedAt = f.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<List<VisualFlowSummaryDto>> GetAllDraftFlowsAsync(Guid businessId)
        {
            return await _context.CTAFlowConfigs
                .Where(f => f.BusinessId == businessId && !f.IsPublished && f.IsActive)
                .OrderByDescending(f => f.CreatedAt)
                .Select(f => new VisualFlowSummaryDto
                {
                    Id = f.Id,
                    FlowName = f.FlowName,
                    CreatedAt = f.CreatedAt,
                    IsPublished = f.IsPublished
                })
                .ToListAsync();
        }

        public async Task<ResponseResult> ExecuteFollowUpStepAsync(Guid businessId, CTAFlowStep? currentStep, string recipientNumber)
        {
            // Log.Information("🚀 Executing follow-up for BusinessId: {BusinessId}, CurrentStepId: {StepId}", businessId);
            if (currentStep == null)
            {
                Log.Warning("⚠️ Cannot execute follow-up. Current step is null.");
                return ResponseResult.ErrorInfo("Current step not found.");
            }

            // 🧠 Step: Look through all button links for a valid NextStepId
            var nextLink = currentStep.ButtonLinks.FirstOrDefault(link => link.NextStepId != null);

            if (nextLink == null)
            {
                Log.Information("ℹ️ No NextStepId defined in any ButtonLinks for StepId: {StepId}", currentStep.Id);
                return ResponseResult.SuccessInfo("No follow-up step to execute.");
            }

            // 🔍 Fetch the next step using new logic (via CTAFlowConfig + Steps)
            // 1️⃣ Try to resolve with smart condition check
            var followUpStep = await GetChainedStepAsync(businessId, nextLink.NextStepId, null, null);

            if (followUpStep == null)
            {
                Log.Warning("❌ Follow-up step skipped due to condition mismatch → StepId: {StepId}", nextLink.NextStepId);

                // 2️⃣ Optional fallback: Try same flow → Any step without conditions
                var flow = await _context.CTAFlowConfigs
                    .Include(f => f.Steps)
                    .FirstOrDefaultAsync(f => f.BusinessId == businessId && f.IsPublished);

                followUpStep = flow?.Steps
                    .Where(s => string.IsNullOrEmpty(s.RequiredTag) && string.IsNullOrEmpty(s.RequiredSource))
                    .OrderBy(s => s.StepOrder)
                    .FirstOrDefault();

                if (followUpStep != null)
                {
                    Log.Information("🔁 Fallback step selected → StepId: {StepId}, Template: {Template}",
                        followUpStep.Id, followUpStep.TemplateToSend);
                }
                else
                {
                    Log.Warning("🚫 No suitable fallback found in flow. Skipping follow-up.");
                    return ResponseResult.SuccessInfo("No matching follow-up step based on user context.");
                }
            }


            // 📨 Send the follow-up message using the TemplateToSend field
            try
            {
                var template = followUpStep.TemplateToSend;

                Log.Information("📤 Sending follow-up message → Template: {Template}, To: {Recipient}", template, recipientNumber);

                // 🧪 Replace this with actual message engine call
                var sendDto = new SimpleTemplateMessageDto
                {
                    RecipientNumber = recipientNumber,
                    TemplateName = template,
                    TemplateParameters = new List<string>() // Add dynamic params later if needed
                };

                var sendResult = await _messageEngineService
     .SendTemplateMessageSimpleAsync(businessId, sendDto);

                if (!sendResult.Success)
                {
                    Log.Warning("❌ Follow-up message send failed → {Template}", template);
                    return ResponseResult.ErrorInfo("Follow-up send failed.", sendResult.ErrorMessage);
                }


                return ResponseResult.SuccessInfo($"Follow-up message sent using template: {template}", null, sendResult.RawResponse);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "❌ Error sending follow-up message for StepId: {StepId}", followUpStep.Id);
                return ResponseResult.ErrorInfo("Failed to send follow-up.");
            }
        }
        //public async Task<CTAFlowStep?> GetChainedStepAsync(Guid businessId, Guid? nextStepId)
        //{
        //    // 🧠 If there's no next step to look up, just return null
        //    if (nextStepId == null)
        //    {
        //        Log.Information("ℹ️ No NextStepId provided — skipping follow-up.");
        //        return null;
        //    }

        //    try
        //    {
        //        // 🧲 Step 1: Find the flow that contains the step and belongs to the business
        //        var flow = await _context.CTAFlowConfigs
        //            .Include(f => f.Steps)
        //            .FirstOrDefaultAsync(f =>
        //                f.BusinessId == businessId &&
        //                f.Steps.Any(s => s.Id == nextStepId));

        //        if (flow == null)
        //        {
        //            Log.Warning("⚠️ No flow found containing NextStepId: {NextStepId} for business: {BusinessId}", nextStepId, businessId);
        //            return null;
        //        }

        //        // 🔁 Step 2: Extract the matching step from the flow's step list
        //        var followUpStep = flow.Steps.FirstOrDefault(s => s.Id == nextStepId);

        //        if (followUpStep == null)
        //        {
        //            Log.Warning("❌ NextStepId matched in flow but not found in step list: {NextStepId}", nextStepId);
        //            return null;
        //        }

        //        Log.Information("✅ Follow-up step found → StepId: {StepId}, Template: {Template}", followUpStep.Id, followUpStep.TemplateToSend);
        //        return followUpStep;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex, "❌ Exception while fetching chained step for NextStepId: {NextStepId}", nextStepId);
        //        throw;
        //    }
        //}
        // ✅ Interface-compatible method (required by ICTAFlowService)
        public Task<CTAFlowStep?> GetChainedStepAsync(Guid businessId, Guid? nextStepId)
        {
            return GetChainedStepAsync(businessId, nextStepId, null, null); // Forward to full logic
        }

        // ✅ Extended logic with condition check (Tag + Source)
        public async Task<CTAFlowStep?> GetChainedStepAsync(
            Guid businessId,
            Guid? nextStepId,
            TrackingLog? trackingLog = null,
            Contact? contact = null)
        {
            if (nextStepId == null)
            {
                Log.Information("ℹ️ No NextStepId provided — skipping follow-up.");
                return null;
            }

            try
            {
                var flow = await _context.CTAFlowConfigs
                    .Include(f => f.Steps)
                    .FirstOrDefaultAsync(f =>
                        f.BusinessId == businessId &&
                        f.Steps.Any(s => s.Id == nextStepId));

                if (flow == null)
                {
                    Log.Warning("⚠️ No flow found containing NextStepId: {NextStepId} for business: {BusinessId}", nextStepId, businessId);
                    return null;
                }

                var followUpStep = flow.Steps.FirstOrDefault(s => s.Id == nextStepId);

                if (followUpStep == null)
                {
                    Log.Warning("❌ Step matched in flow but not found in step list: {NextStepId}", nextStepId);
                    return null;
                }

                // ✅ Check RequiredTag / Source match
                if (trackingLog != null)
                {
                    var isMatch = StepMatchingHelper.IsStepMatched(followUpStep, trackingLog, contact);

                    if (!isMatch)
                    {
                        Log.Information("🚫 Step {StepId} skipped due to condition mismatch [Tag: {Tag}, Source: {Source}]",
                            followUpStep.Id, followUpStep.RequiredTag, followUpStep.RequiredSource);
                        return null;
                    }
                }

                Log.Information("✅ Follow-up step found and matched → StepId: {StepId}, Template: {Template}",
                    followUpStep.Id, followUpStep.TemplateToSend);

                return followUpStep;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "❌ Exception while fetching chained step for NextStepId: {NextStepId}", nextStepId);
                throw;
            }
        }

        // ✅ Optional helper for resolving from TrackingLogId
        public async Task<CTAFlowStep?> GetChainedStepWithContextAsync(
            Guid businessId,
            Guid? nextStepId,
            Guid? trackingLogId)
        {
            var log = await _context.TrackingLogs
                .Include(l => l.Contact)
                    .ThenInclude(c => c.ContactTags)
                        .ThenInclude(ct => ct.Tag)
                .FirstOrDefaultAsync(l => l.Id == trackingLogId);

            return await GetChainedStepAsync(businessId, nextStepId, log, log?.Contact);
        }

        public async Task<ResponseResult> ExecuteVisualFlowAsync(Guid businessId, Guid startStepId, Guid trackingLogId)
        {
            try
            {
                Log.Information("🚦 Executing Visual Flow → StepId: {StepId} | TrackingLogId: {TrackingLogId}", startStepId, trackingLogId);

                var log = await _context.TrackingLogs
                    .Include(l => l.Contact)
                        .ThenInclude(c => c.ContactTags)
                            .ThenInclude(ct => ct.Tag)
                    .FirstOrDefaultAsync(l => l.Id == trackingLogId);

                if (log == null)
                {
                    Log.Warning("❌ TrackingLog not found for ID: {TrackingLogId}", trackingLogId);
                    return ResponseResult.ErrorInfo("Tracking log not found.");
                }

                var step = await GetChainedStepAsync(businessId, startStepId, log, log?.Contact);

                if (step == null)
                {
                    Log.Warning("❌ No flow step matched or conditions failed → StepId: {StepId}", startStepId);
                    return ResponseResult.ErrorInfo("Step conditions not satisfied.");
                }

                ResponseResult sendResult;

                switch (step.TemplateType?.ToLower())
                {
                    case "image_template":
                        var imageDto = new ImageTemplateMessageDto
                        {
                            BusinessId = businessId,
                            RecipientNumber = log.ContactPhone ?? "",
                            TemplateName = step.TemplateToSend,
                            LanguageCode = "en_US"
                        };
                        sendResult = await _messageEngineService.SendImageTemplateMessageAsync(imageDto, businessId);
                        break;

                    case "text_template":
                    default:
                        var textDto = new SimpleTemplateMessageDto
                        {
                            RecipientNumber = log.ContactPhone ?? "",
                            TemplateName = step.TemplateToSend,
                            TemplateParameters = new()
                        };
                        sendResult = await _messageEngineService.SendTemplateMessageSimpleAsync(businessId, textDto);
                        break;

                }

                // ✅ Save FlowExecutionLog
                var executionLog = new FlowExecutionLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = businessId,
                    StepId = step.Id,
                    FlowId = step.CTAFlowConfigId,
                    TrackingLogId = trackingLogId,
                    ContactPhone = log.ContactPhone,
                    TriggeredByButton = step.TriggerButtonText,
                    TemplateName = step.TemplateToSend,
                    TemplateType = step.TemplateType,
                    Success = sendResult.Success,
                    ErrorMessage = sendResult.ErrorMessage,
                    RawResponse = sendResult.RawResponse,
                    ExecutedAt = DateTime.UtcNow
                };

                _context.FlowExecutionLogs.Add(executionLog);
                await _context.SaveChangesAsync();

                if (sendResult.Success)
                {
                    Log.Information("✅ Flow step executed → Template: {Template} sent to {To}", step.TemplateToSend, log.ContactPhone);
                }
                else
                {
                    Log.Warning("❌ Failed to send template from flow → {Reason}", sendResult.ErrorMessage);
                }

                return ResponseResult.SuccessInfo($"Flow step executed. Sent: {sendResult.Success}", null, sendResult.RawResponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "❌ Exception during ExecuteVisualFlowAsync()");
                return ResponseResult.ErrorInfo("Internal error during flow execution.");
            }
        }


    }
}
