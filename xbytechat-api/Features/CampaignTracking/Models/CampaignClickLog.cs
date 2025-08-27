using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using xbytechat.api.Features.CampaignModule.Models;
using xbytechat.api.CRM.Models;

namespace xbytechat.api.Features.CampaignTracking.Models
{
    public class CampaignClickLog
    {
        [Key] public Guid Id { get; set; }

        // Parent send (one-per-recipient-per-send)
        [Required] public Guid CampaignSendLogId { get; set; }
        public CampaignSendLog? CampaignSendLog { get; set; }

        // Handy denormalized fields (fast reporting)
        [Required] public Guid CampaignId { get; set; }
        [Required] public Guid ContactId { get; set; }

        // Which button
        public int ButtonIndex { get; set; }           // 0,1,2
        public string? ButtonTitle { get; set; }          // e.g. "Visit website"

        // Where they went
        public string DestinationUrl { get; set; } = "";

        // Click info
        public DateTime ClickedAt { get; set; } = DateTime.UtcNow;
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
    }
}
