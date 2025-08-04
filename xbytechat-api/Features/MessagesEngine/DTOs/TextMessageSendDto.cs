namespace xbytechat.api.Features.MessagesEngine.DTOs
{
    public class TextMessageSendDto
    {
        public Guid BusinessId { get; set; }

        public string RecipientNumber { get; set; }

        public string TextContent { get; set; }

        public Guid ContactId { get; set; }

        // ✅ NEW: Optional source indicator (e.g., "campaign", "auto-reply", etc.)
        public string? Source { get; set; }

        // ✅ NEW: Optional message ID for campaign tracing
        public string? MessageId { get; set; }


    }
}
