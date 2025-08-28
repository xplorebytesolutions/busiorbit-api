using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        //public async Task<List<JourneyEventDto>> GetJourneyEventsAsync(Guid initialCampaignSendLogId)
        //{
        //    var journeyEvents = new List<JourneyEventDto>();
        //    var currentLog = await _context.CampaignSendLogs.AsNoTracking().FirstOrDefaultAsync(log => log.Id == initialCampaignSendLogId);

        //    if (currentLog == null) return journeyEvents;

        //    journeyEvents.Add(new JourneyEventDto
        //    {
        //        EventType = "MessageSent",
        //        Source = "System",
        //        Title = "Initial Campaign Message Sent",
        //        Details = $"Template: {currentLog.TemplateId}",
        //        Timestamp = currentLog.SentAt ?? currentLog.CreatedAt
        //    });

        //    var currentMessageId = currentLog.MessageId;

        //    for (int i = 0; i < 10; i++) // Safety break
        //    {
        //        if (string.IsNullOrEmpty(currentMessageId)) break;

        //        var clickEvent = await _context.TrackingLogs.AsNoTracking().FirstOrDefaultAsync(t => t.MessageId == currentMessageId);
        //        if (clickEvent != null)
        //        {
        //            journeyEvents.Add(new JourneyEventDto
        //            {
        //                EventType = "ButtonClicked",
        //                Source = "User",
        //                Title = "User Clicked Button:",
        //                Details = clickEvent.ButtonText ?? "N/A",
        //                Timestamp = clickEvent.ClickedAt
        //            });
        //        }

        //        var nextMessage = await _context.MessageLogs.AsNoTracking().FirstOrDefaultAsync(m => m.RefMessageId.ToString() == currentMessageId);
        //        if (nextMessage != null)
        //        {
        //            journeyEvents.Add(new JourneyEventDto
        //            {
        //                EventType = "MessageSent",
        //                Source = "System",
        //                Title = "System Sent Follow-up:",
        //                Details = $"Template: {nextMessage.MessageContent}",
        //                Timestamp = nextMessage.SentAt ?? nextMessage.CreatedAt
        //            });
        //            currentMessageId = nextMessage.MessageId;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }

        //    return journeyEvents;
        //}
        public async Task<List<JourneyEventDto>> GetJourneyEventsAsync(Guid initialCampaignSendLogId)
        {
            var journeyEvents = new List<JourneyEventDto>();

            // 1. Fetch the initial "Message Sent" event from the correct log
            var sentLog = await _context.CampaignSendLogs
                .AsNoTracking()
                .FirstOrDefaultAsync(log => log.Id == initialCampaignSendLogId);

            if (sentLog == null)
            {
                return journeyEvents; // Return empty if the initial log isn't found
            }

            journeyEvents.Add(new JourneyEventDto
            {
                EventType = "MessageSent",
                Title = "Initial Campaign Message Sent",
                Details = $"Template: {sentLog.TemplateId}",
                Timestamp = sentLog.SentAt ?? sentLog.CreatedAt
            });

            // 2. Fetch ALL "ButtonClicked" events from the correct table
            var clickLogs = await _context.CampaignClickLogs
                .AsNoTracking()
                .Where(click => click.CampaignSendLogId == initialCampaignSendLogId)
                .OrderBy(click => click.ClickedAt) // It's good practice to order them
                .ToListAsync();

            // 3. Add each click event to our journey list
            foreach (var click in clickLogs)
            {
                journeyEvents.Add(new JourneyEventDto
                {
                    EventType = "ButtonClicked",
                    Title = $"User clicked: {click.ButtonTitle}",
                    Details = $"Redirected to: {click.Destination}",
                    Timestamp = click.ClickedAt
                });
            }

            // (Optional) Add your logic for follow-up messages here if needed

            // 4. Return the final, sorted list of all events
            return journeyEvents.OrderBy(e => e.Timestamp).ToList();
        }

    }
}