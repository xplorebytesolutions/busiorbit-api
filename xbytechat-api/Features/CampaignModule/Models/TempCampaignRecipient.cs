// Features/CampaignModule/Models/TempCampaignRecipient.cs
using System;

namespace xbytechat.api.Features.CampaignModule.Models
{
    public class TempCampaignRecipient
    {
        public Guid Id { get; set; }

        public Guid CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;
        public string? Name { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Sent, Failed
        public DateTime? SentAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
