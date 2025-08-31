using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xbytechat.api.Features.CTAFlowBuilder.Models;
using xbytechat.api.Features.Tracking.DTOs; // Updated namespace
// Add other necessary using statements for your project

namespace xbytechat.api.Features.Tracking.Services
{
    public class ContactJourneyService : IContactJourneyService
    {
        private readonly AppDbContext _context;

        public ContactJourneyService(AppDbContext context)
        {
            _context = context;
        }



        //public async Task<JourneyResponseDto> GetJourneyEventsAsync(Guid initialCampaignSendLogId)
        //{
        //    var resp = new JourneyResponseDto();
        //    var events = new List<JourneyEventDto>();

        //    // 1) Initial send
        //    var sentLog = await _context.CampaignSendLogs
        //        .AsNoTracking()
        //        .Include(x => x.Campaign)
        //        .Include(x => x.Contact)
        //        .FirstOrDefaultAsync(x => x.Id == initialCampaignSendLogId);

        //    if (sentLog == null || sentLog.Campaign == null || sentLog.Contact == null)
        //    {
        //        resp.Events = events;
        //        return resp;
        //    }

        //    resp.CampaignId = sentLog.CampaignId;
        //    resp.ContactId = sentLog.ContactId;
        //    resp.ContactPhone = sentLog.Contact.PhoneNumber ?? "";
        //    resp.CampaignType = sentLog.CTAFlowConfigId.HasValue ? "flow" : "dynamic_url";
        //    resp.FlowId = sentLog.CTAFlowConfigId;

        //    events.Add(new JourneyEventDto
        //    {
        //        Timestamp = sentLog.SentAt ?? sentLog.CreatedAt,
        //        Source = "System",
        //        EventType = "MessageSent",
        //        Title = $"Campaign '{sentLog.Campaign.Name}' sent",
        //        Details = $"Template '{sentLog.TemplateId}' to {resp.ContactPhone}",
        //        TemplateName = sentLog.TemplateId
        //    });

        //    // 2) Delivered / Read (from CampaignSendLog)
        //    if (sentLog.DeliveredAt.HasValue)
        //    {
        //        events.Add(new JourneyEventDto
        //        {
        //            Timestamp = sentLog.DeliveredAt.Value,
        //            Source = "Provider",
        //            EventType = "Delivered",
        //            Title = "Message delivered",
        //            Details = $"Delivered to {resp.ContactPhone}",
        //            TemplateName = sentLog.TemplateId
        //        });
        //    }
        //    if (sentLog.ReadAt.HasValue)
        //    {
        //        events.Add(new JourneyEventDto
        //        {
        //            Timestamp = sentLog.ReadAt.Value,
        //            Source = "Provider",
        //            EventType = "Read",
        //            Title = "Message read",
        //            Details = $"Read by {resp.ContactPhone}",
        //            TemplateName = sentLog.TemplateId
        //        });
        //    }

        //    // 3A) URL-clicks for this initial send
        //    var urlClicksInitial = await _context.CampaignClickLogs
        //        .AsNoTracking()
        //        .Where(c => c.CampaignSendLogId == initialCampaignSendLogId)
        //        .OrderBy(c => c.ClickedAt)
        //        .ToListAsync();

        //    foreach (var c in urlClicksInitial)
        //    {
        //        events.Add(new JourneyEventDto
        //        {
        //            Timestamp = c.ClickedAt,
        //            Source = "User",
        //            EventType = "ButtonClicked",
        //            Title = $"Clicked URL Button: '{c.ButtonTitle}'",
        //            Details = $"User was directed to: {c.Destination}",
        //            ButtonIndex = c.ButtonIndex,
        //            ButtonTitle = c.ButtonTitle,
        //            Url = c.Destination
        //        });
        //    }

        //    // 3B) Flow journey (build entire chain)
        //    if (sentLog.CTAFlowConfigId.HasValue)
        //    {
        //        // Flow name
        //        resp.FlowName = await _context.CTAFlowConfigs
        //            .Where(f => f.Id == sentLog.CTAFlowConfigId.Value)
        //            .Select(f => f.FlowName)
        //            .FirstOrDefaultAsync();

        //        // All related CSL ids for same contact+flow from the initial send onward
        //        var flowCslIds = await _context.CampaignSendLogs
        //            .AsNoTracking()
        //            .Where(csl =>
        //                csl.BusinessId == sentLog.BusinessId &&
        //                csl.ContactId == sentLog.ContactId &&
        //                csl.CTAFlowConfigId == sentLog.CTAFlowConfigId &&
        //                csl.CreatedAt >= sentLog.CreatedAt)
        //            .OrderBy(csl => csl.CreatedAt)
        //            .Select(csl => csl.Id)
        //            .ToListAsync();

        //        // FlowExec: query by CSL ids
        //        var flowExecByCsl = await _context.FlowExecutionLogs
        //            .AsNoTracking()
        //            .Where(f => f.CampaignSendLogId.HasValue && flowCslIds.Contains(f.CampaignSendLogId.Value))
        //            .OrderBy(f => f.ExecutedAt)
        //            .ToListAsync();

        //        // Fallback by (biz + flow + phone) to be safe
        //        var phone = sentLog.Contact.PhoneNumber ?? "";
        //        var flowExecByPhone = await _context.FlowExecutionLogs
        //            .AsNoTracking()
        //            .Where(f => f.BusinessId == sentLog.BusinessId &&
        //                        f.FlowId == sentLog.CTAFlowConfigId &&
        //                        f.ContactPhone == phone &&
        //                        f.ExecutedAt >= sentLog.CreatedAt)
        //            .OrderBy(f => f.ExecutedAt)
        //            .ToListAsync();

        //        // Merge (dedupe by Id)
        //        var flowExec = flowExecByCsl.Concat(flowExecByPhone)
        //                                    .GroupBy(x => x.Id)
        //                                    .Select(g => g.First())
        //                                    .OrderBy(x => x.ExecutedAt)
        //                                    .ToList();

        //        foreach (var fe in flowExec)
        //        {
        //            if (!string.IsNullOrWhiteSpace(fe.TriggeredByButton))
        //            {
        //                events.Add(new JourneyEventDto
        //                {
        //                    Timestamp = fe.ExecutedAt,
        //                    Source = "User",
        //                    EventType = "ButtonClicked",
        //                    Title = $"Clicked Quick Reply: '{fe.TriggeredByButton}'",
        //                    Details = string.IsNullOrWhiteSpace(fe.TemplateName)
        //                                  ? $"Advanced in flow at step '{fe.StepName}'"
        //                                  : $"Triggered next template: '{fe.TemplateName}'",
        //                    StepId = fe.StepId,
        //                    StepName = fe.StepName,
        //                    ButtonIndex = fe.ButtonIndex.HasValue ? (int?)fe.ButtonIndex.Value : null,
        //                    ButtonTitle = fe.TriggeredByButton,
        //                    TemplateName = fe.TemplateName
        //                });
        //            }

        //            if (!string.IsNullOrWhiteSpace(fe.TemplateName))
        //            {
        //                events.Add(new JourneyEventDto
        //                {
        //                    Timestamp = fe.ExecutedAt,
        //                    Source = "System",
        //                    EventType = "FlowSend",
        //                    Title = $"Flow sent template '{fe.TemplateName}'",
        //                    Details = $"Step '{fe.StepName}'",
        //                    StepId = fe.StepId,
        //                    StepName = fe.StepName,
        //                    TemplateName = fe.TemplateName
        //                });
        //            }
        //        }

        //        // Include other flow-sent CSLs as events (beyond the initial)
        //        var flowSends = await _context.CampaignSendLogs
        //            .AsNoTracking()
        //            .Where(csl => flowCslIds.Contains(csl.Id) && csl.Id != sentLog.Id)
        //            .OrderBy(csl => csl.CreatedAt)
        //            .ToListAsync();

        //        foreach (var csl in flowSends)
        //        {
        //            events.Add(new JourneyEventDto
        //            {
        //                Timestamp = csl.SentAt ?? csl.CreatedAt,
        //                Source = "System",
        //                EventType = "FlowSend",
        //                Title = $"Flow sent template '{csl.TemplateId}'",
        //                Details = csl.CTAFlowStepId.HasValue ? $"Step: {csl.CTAFlowStepId}" : null,
        //                StepId = csl.CTAFlowStepId,
        //                TemplateName = csl.TemplateId
        //            });

        //            if (csl.DeliveredAt.HasValue)
        //            {
        //                events.Add(new JourneyEventDto
        //                {
        //                    Timestamp = csl.DeliveredAt.Value,
        //                    Source = "Provider",
        //                    EventType = "Delivered",
        //                    Title = "Message delivered",
        //                    Details = "",
        //                    TemplateName = csl.TemplateId,
        //                    StepId = csl.CTAFlowStepId
        //                });
        //            }
        //            if (csl.ReadAt.HasValue)
        //            {
        //                events.Add(new JourneyEventDto
        //                {
        //                    Timestamp = csl.ReadAt.Value,
        //                    Source = "Provider",
        //                    EventType = "Read",
        //                    Title = "Message read",
        //                    Details = "",
        //                    TemplateName = csl.TemplateId,
        //                    StepId = csl.CTAFlowStepId
        //                });
        //            }
        //        }

        //        // URL clicks that happen during the flow for any related CSLs
        //        var flowUrlClicks = await _context.CampaignClickLogs
        //            .AsNoTracking()
        //            .Where(c => flowCslIds.Contains(c.CampaignSendLogId))
        //            .OrderBy(c => c.ClickedAt)
        //            .ToListAsync();

        //        foreach (var c in flowUrlClicks)
        //        {
        //            events.Add(new JourneyEventDto
        //            {
        //                Timestamp = c.ClickedAt,
        //                Source = "User",
        //                EventType = "ButtonClicked",
        //                Title = $"Clicked URL: '{c.ButtonTitle}'",
        //                Details = $"Redirected to {c.Destination}",
        //                ButtonIndex = c.ButtonIndex,
        //                ButtonTitle = c.ButtonTitle,
        //                Url = c.Destination
        //            });
        //        }

        //        // Where user left off (last flow-relevant event)
        //        var lastFlowEvent = events
        //            .Where(e => e.EventType == "FlowSend" || e.EventType == "ButtonClicked")
        //            .OrderBy(e => e.Timestamp)
        //            .LastOrDefault();

        //        resp.LeftOffAt = lastFlowEvent?.StepName ?? lastFlowEvent?.Title;
        //    }

        //    resp.Events = events.OrderBy(e => e.Timestamp).ToList();
        //    return resp;
        //}

        public async Task<JourneyResponseDto> GetJourneyEventsAsync(Guid initialCampaignSendLogId)
        {
            var resp = new JourneyResponseDto();
            var events = new List<JourneyEventDto>();

            // 0) Load the selected send
            var sentLog = await _context.CampaignSendLogs
                .AsNoTracking()
                .Include(x => x.Campaign)
                .Include(x => x.Contact)
                .FirstOrDefaultAsync(x => x.Id == initialCampaignSendLogId);

            if (sentLog == null || sentLog.Campaign == null || sentLog.Contact == null)
            {
                resp.Events = events;
                return resp;
            }

            resp.CampaignId = sentLog.CampaignId;
            resp.ContactId = sentLog.ContactId;
            resp.ContactPhone = sentLog.Contact.PhoneNumber ?? "";
            resp.CampaignType = sentLog.CTAFlowConfigId.HasValue ? "flow" : "dynamic_url";
            resp.FlowId = sentLog.CTAFlowConfigId;

            // 1) Establish a "session window" for THIS run of the campaign to THIS contact
            var sessionStart = sentLog.SentAt ?? sentLog.CreatedAt;

            // next send to same contact for same campaign
            var nextSameCampaignAt = await _context.CampaignSendLogs.AsNoTracking()
                .Where(x => x.ContactId == sentLog.ContactId &&
                            x.CampaignId == sentLog.CampaignId &&
                            x.CreatedAt > sessionStart)
                .OrderBy(x => x.CreatedAt)
                .Select(x => (DateTime?)x.CreatedAt)
                .FirstOrDefaultAsync();

            // next send to same contact for same flow (if this is a flow)
            DateTime? nextSameFlowAt = null;
            if (sentLog.CTAFlowConfigId.HasValue)
            {
                nextSameFlowAt = await _context.CampaignSendLogs.AsNoTracking()
                    .Where(x => x.ContactId == sentLog.ContactId &&
                                x.CTAFlowConfigId == sentLog.CTAFlowConfigId &&
                                x.CreatedAt > sessionStart)
                    .OrderBy(x => x.CreatedAt)
                    .Select(x => (DateTime?)x.CreatedAt)
                    .FirstOrDefaultAsync();
            }

            // session end = earliest “next run” OR +24h cap
            var sessionEnd = new[] { nextSameCampaignAt, nextSameFlowAt }
                .Where(dt => dt.HasValue)
                .Select(dt => dt!.Value)
                .DefaultIfEmpty(sessionStart.AddHours(24))
                .Min();

            // 2) Initial "sent" + statuses from CSL
            events.Add(new JourneyEventDto
            {
                Timestamp = sessionStart,
                Source = "System",
                EventType = "MessageSent",
                Title = $"Campaign '{sentLog.Campaign.Name}' sent",
                Details = $"Template '{sentLog.TemplateId}' to {resp.ContactPhone}",
                TemplateName = sentLog.TemplateId
            });

            if (sentLog.DeliveredAt.HasValue && sentLog.DeliveredAt.Value >= sessionStart && sentLog.DeliveredAt.Value < sessionEnd)
                events.Add(new JourneyEventDto { Timestamp = sentLog.DeliveredAt.Value, Source = "Provider", EventType = "Delivered", Title = "Message delivered", Details = $"Delivered to {resp.ContactPhone}", TemplateName = sentLog.TemplateId });

            if (sentLog.ReadAt.HasValue && sentLog.ReadAt.Value >= sessionStart && sentLog.ReadAt.Value < sessionEnd)
                events.Add(new JourneyEventDto { Timestamp = sentLog.ReadAt.Value, Source = "Provider", EventType = "Read", Title = "Message read", Details = $"Read by {resp.ContactPhone}", TemplateName = sentLog.TemplateId });

            // 3) URL clicks for THIS send within the window
            var urlClicksInitial = await _context.CampaignClickLogs
                .AsNoTracking()
                .Where(c => c.CampaignSendLogId == sentLog.Id &&
                            c.ClickedAt >= sessionStart &&
                            c.ClickedAt < sessionEnd)
                .OrderBy(c => c.ClickedAt)
                .ToListAsync();

            foreach (var c in urlClicksInitial)
            {
                events.Add(new JourneyEventDto
                {
                    Timestamp = c.ClickedAt,
                    Source = "User",
                    EventType = "ButtonClicked",
                    Title = $"Clicked URL Button: '{c.ButtonTitle}'",
                    Details = $"Redirected to {c.Destination}",
                    ButtonIndex = c.ButtonIndex,
                    ButtonTitle = c.ButtonTitle,
                    Url = c.Destination
                });
            }

            // 4) FLOW chain (if any) scoped to THIS session window
            if (sentLog.CTAFlowConfigId.HasValue)
            {
                // Flow label
                resp.FlowName = await _context.CTAFlowConfigs
                    .Where(f => f.Id == sentLog.CTAFlowConfigId.Value)
                    .Select(f => f.FlowName)
                    .FirstOrDefaultAsync();

                // All flow sends (CSLs) for same contact+flow within the window
                var flowCslChain = await _context.CampaignSendLogs
                    .AsNoTracking()
                    .Where(csl => csl.BusinessId == sentLog.BusinessId &&
                                  csl.ContactId == sentLog.ContactId &&
                                  csl.CTAFlowConfigId == sentLog.CTAFlowConfigId &&
                                  csl.CreatedAt >= sessionStart &&
                                  csl.CreatedAt < sessionEnd)
                    .OrderBy(csl => csl.CreatedAt)
                    .Select(csl => new { csl.Id, csl.MessageLogId, csl.SentAt, csl.CreatedAt, csl.TemplateId, csl.CTAFlowStepId, csl.DeliveredAt, csl.ReadAt })
                    .ToListAsync();

                var chainCslIds = flowCslChain.Select(x => x.Id).ToList();
                var chainMsgLogIds = flowCslChain.Where(x => x.MessageLogId.HasValue).Select(x => x.MessageLogId!.Value).ToList();

                // FlowExecutionLogs joined by CSL id
                var execByCsl = await _context.FlowExecutionLogs
                    .AsNoTracking()
                    .Where(f => f.CampaignSendLogId.HasValue &&
                                chainCslIds.Contains(f.CampaignSendLogId.Value) &&
                                f.ExecutedAt >= sessionStart &&
                                f.ExecutedAt < sessionEnd)
                    .OrderBy(f => f.ExecutedAt)
                    .ToListAsync();

                // Or by message log id
                var execByMsg = chainMsgLogIds.Count == 0 ? new List<FlowExecutionLog>()
                    : await _context.FlowExecutionLogs
                        .AsNoTracking()
                        .Where(f => f.MessageLogId.HasValue &&
                                    chainMsgLogIds.Contains(f.MessageLogId.Value) &&
                                    f.ExecutedAt >= sessionStart &&
                                    f.ExecutedAt < sessionEnd)
                        .OrderBy(f => f.ExecutedAt)
                        .ToListAsync();

                // Phone fallback (strictly within the session window; accept + or digits-only)
                var phoneA = resp.ContactPhone ?? "";
                var phoneB = phoneA.StartsWith("+") ? phoneA.Substring(1) : "+" + phoneA;
                var execByPhone = await _context.FlowExecutionLogs
                    .AsNoTracking()
                    .Where(f => f.BusinessId == sentLog.BusinessId &&
                                f.FlowId == sentLog.CTAFlowConfigId &&
                                (f.ContactPhone == phoneA || f.ContactPhone == phoneB) &&
                                f.ExecutedAt >= sessionStart &&
                                f.ExecutedAt < sessionEnd)
                    .OrderBy(f => f.ExecutedAt)
                    .ToListAsync();

                var flowExec = execByCsl.Concat(execByMsg).Concat(execByPhone)
                    .GroupBy(x => x.Id).Select(g => g.First())
                    .OrderBy(x => x.ExecutedAt).ToList();

                foreach (var fe in flowExec)
                {
                    if (!string.IsNullOrWhiteSpace(fe.TriggeredByButton))
                    {
                        events.Add(new JourneyEventDto
                        {
                            Timestamp = fe.ExecutedAt,
                            Source = "User",
                            EventType = "ButtonClicked",
                            Title = $"Clicked Quick Reply: '{fe.TriggeredByButton}'",
                            Details = string.IsNullOrWhiteSpace(fe.TemplateName) ? $"Advanced in flow at step '{fe.StepName}'" : $"Triggered next template: '{fe.TemplateName}'",
                            StepId = fe.StepId,
                            StepName = fe.StepName,
                            ButtonIndex = fe.ButtonIndex.HasValue ? (int?)fe.ButtonIndex.Value : null,
                            ButtonTitle = fe.TriggeredByButton,
                            TemplateName = fe.TemplateName
                        });
                    }

                    if (!string.IsNullOrWhiteSpace(fe.TemplateName))
                    {
                        events.Add(new JourneyEventDto
                        {
                            Timestamp = fe.ExecutedAt,
                            Source = "System",
                            EventType = "FlowSend",
                            Title = $"Flow sent template '{fe.TemplateName}'",
                            Details = $"Step '{fe.StepName}'",
                            StepId = fe.StepId,
                            StepName = fe.StepName,
                            TemplateName = fe.TemplateName
                        });
                    }
                }

                // Include the flow CSLs themselves + statuses (within window)
                foreach (var csl in flowCslChain.Where(x => x.Id != sentLog.Id))
                {
                    var ts = csl.SentAt ?? csl.CreatedAt;
                    events.Add(new JourneyEventDto
                    {
                        Timestamp = ts,
                        Source = "System",
                        EventType = "FlowSend",
                        Title = $"Flow sent template '{csl.TemplateId}'",
                        Details = csl.CTAFlowStepId.HasValue ? $"Step: {csl.CTAFlowStepId}" : null,
                        StepId = csl.CTAFlowStepId,
                        TemplateName = csl.TemplateId
                    });

                    if (csl.DeliveredAt.HasValue && csl.DeliveredAt.Value >= sessionStart && csl.DeliveredAt.Value < sessionEnd)
                        events.Add(new JourneyEventDto { Timestamp = csl.DeliveredAt.Value, Source = "Provider", EventType = "Delivered", Title = "Message delivered", Details = "", TemplateName = csl.TemplateId, StepId = csl.CTAFlowStepId });

                    if (csl.ReadAt.HasValue && csl.ReadAt.Value >= sessionStart && csl.ReadAt.Value < sessionEnd)
                        events.Add(new JourneyEventDto { Timestamp = csl.ReadAt.Value, Source = "Provider", EventType = "Read", Title = "Message read", Details = "", TemplateName = csl.TemplateId, StepId = csl.CTAFlowStepId });
                }

                // URL clicks during the flow (within window)
                if (chainCslIds.Count > 0)
                {
                    var flowClicks = await _context.CampaignClickLogs
                        .AsNoTracking()
                        .Where(c => chainCslIds.Contains(c.CampaignSendLogId) &&
                                    c.ClickedAt >= sessionStart &&
                                    c.ClickedAt < sessionEnd)
                        .OrderBy(c => c.ClickedAt)
                        .ToListAsync();

                    foreach (var c in flowClicks)
                    {
                        events.Add(new JourneyEventDto
                        {
                            Timestamp = c.ClickedAt,
                            Source = "User",
                            EventType = "ButtonClicked",
                            Title = $"Clicked URL: '{c.ButtonTitle}'",
                            Details = $"Redirected to {c.Destination}",
                            ButtonIndex = c.ButtonIndex,
                            ButtonTitle = c.ButtonTitle,
                            Url = c.Destination
                        });
                    }
                }

                // Where the user left off in this session
                var lastFlowEvent = events
                    .Where(e => e.EventType == "FlowSend" || e.EventType == "ButtonClicked")
                    .OrderBy(e => e.Timestamp)
                    .LastOrDefault();

                resp.LeftOffAt = lastFlowEvent?.StepName ?? lastFlowEvent?.Title;
            }

            resp.Events = events.OrderBy(e => e.Timestamp).ToList();
            return resp;
        }
    }

}
