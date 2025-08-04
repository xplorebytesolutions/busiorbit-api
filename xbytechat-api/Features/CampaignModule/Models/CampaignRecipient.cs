using System;
using System.Collections.Generic;
using xbytechat.api.CRM.Models;
using xbytechat.api.Features.BusinessModule.Models;
using xbytechat.api.Features.CampaignTracking.Models;

namespace xbytechat.api.Features.CampaignModule.Models
{
    public class CampaignRecipient
    {
        public Guid Id { get; set; }

        public Guid CampaignId { get; set; }
        public Campaign Campaign { get; set; }

        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Sent, Delivered, Failed, Replied
        public DateTime? SentAt { get; set; }

        public string? BotId { get; set; } // Multi-bot support
        public string? MessagePreview { get; set; } // Final message sent
        public string? ClickedCTA { get; set; } // Track CTA clicked like "BuyNow"
        public string? CategoryBrowsed { get; set; } // e.g., Ads
        public string? ProductBrowsed { get; set; } // e.g., Product name
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool IsAutoTagged { get; set; } = false; // Flag for automation-based tagging

        // ✅ NEW: One-to-many link to detailed logs (message attempts, delivery tracking)
        public ICollection<CampaignSendLog> SendLogs { get; set; }

        public Guid BusinessId { get; set; }  // ✅ Add this line
        public Business Business { get; set; } = null!; // if navigation is needed


    }
}
