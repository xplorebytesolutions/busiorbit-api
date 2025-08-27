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

        public async Task<List<JourneyEventDto>> GetJourneyEventsAsync(Guid initialCampaignSendLogId)
        {
            var journeyEvents = new List<JourneyEventDto>();
            var currentLog = await _context.CampaignSendLogs.AsNoTracking().FirstOrDefaultAsync(log => log.Id == initialCampaignSendLogId);

            if (currentLog == null) return journeyEvents;

            journeyEvents.Add(new JourneyEventDto
            {
                EventType = "MessageSent",
                Source = "System",
                Title = "Initial Campaign Message Sent",
                Details = $"Template: {currentLog.TemplateId}",
                Timestamp = currentLog.SentAt ?? currentLog.CreatedAt
            });

            var currentMessageId = currentLog.MessageId;

            for (int i = 0; i < 10; i++) // Safety break
            {
                if (string.IsNullOrEmpty(currentMessageId)) break;

                var clickEvent = await _context.TrackingLogs.AsNoTracking().FirstOrDefaultAsync(t => t.MessageId == currentMessageId);
                if (clickEvent != null)
                {
                    journeyEvents.Add(new JourneyEventDto
                    {
                        EventType = "ButtonClicked",
                        Source = "User",
                        Title = "User Clicked Button:",
                        Details = clickEvent.ButtonText ?? "N/A",
                        Timestamp = clickEvent.ClickedAt
                    });
                }

                var nextMessage = await _context.MessageLogs.AsNoTracking().FirstOrDefaultAsync(m => m.RefMessageId.ToString() == currentMessageId);
                if (nextMessage != null)
                {
                    journeyEvents.Add(new JourneyEventDto
                    {
                        EventType = "MessageSent",
                        Source = "System",
                        Title = "System Sent Follow-up:",
                        Details = $"Template: {nextMessage.MessageContent}",
                        Timestamp = nextMessage.SentAt ?? nextMessage.CreatedAt
                    });
                    currentMessageId = nextMessage.MessageId;
                }
                else
                {
                    break;
                }
            }

            return journeyEvents;
        }
    }
}