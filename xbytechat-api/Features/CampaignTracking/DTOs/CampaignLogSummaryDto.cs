namespace xbytechat.api.Features.CampaignTracking.DTOs
{
    public class CampaignLogSummaryDto
    {
        public int TotalSent { get; set; }
        public int FailedCount { get; set; }
        public int ClickedCount { get; set; }
        public DateTime? LastSentAt { get; set; }
    }
}
