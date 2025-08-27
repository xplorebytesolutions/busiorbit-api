namespace xbytechat.api.Features.Tracking.DTOs
{
    public class JourneyEventDto
    {
        public string EventType { get; set; } // e.g., "MessageSent", "ButtonClicked"
        public string Source { get; set; } // "System" or "User"
        public string Title { get; set; } // e.g., "Sent Template:" or "Clicked Button:"
        public string Details { get; set; } // e.g., the template name or the button text
        public DateTime Timestamp { get; set; }
    }
}
