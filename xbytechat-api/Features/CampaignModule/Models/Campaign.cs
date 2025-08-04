using System;
using System.Collections.Generic;
using xbytechat.api.CRM.Models;
using xbytechat.api.Features.CampaignTracking.Models;
using xbytechat.api.Features.CTAManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;
using xbytechat.api.Features.MessageManagement.DTOs;
using xbytechat.api.Features.BusinessModule.Models;

namespace xbytechat.api.Features.CampaignModule.Models
{
    public class Campaign
    {
        public Guid Id { get; set; }

        // 🔗 Business info
        public Guid BusinessId { get; set; }
        public Business Business { get; set; }
        public Guid? CampaignId { get; set; }
        public Campaign? SourceCampaign { get; set; }

        // 📋 Core campaign details
        public string Name { get; set; }
        public string MessageTemplate { get; set; }
        public string? TemplateId { get; set; } // ✅ Meta-approved template ID

        [Column(TypeName = "text")]
        public string? MessageBody { get; set; } // ✅ Final resolved WhatsApp message body


        public string? FollowUpTemplateId { get; set; } // 🔁 For auto-reply follow-up after interest
        public string? CampaignType { get; set; } // = "template"; // text, template, cta

        // 🔘 CTA tracking (optional)
        public Guid? CtaId { get; set; }
        public CTADefinition? Cta { get; set; }

       
        public DateTime? ScheduledAt { get; set; }
        public string Status { get; set; } = "Draft"; // Draft, Scheduled, Sent

        // 👤 Metadata
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // 🗑️ Soft delete support
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }

        // 👥 Recipient relationship
        public ICollection<CampaignRecipient> Recipients { get; set; }

        // 📊 Logs
        public ICollection<CampaignSendLog> SendLogs { get; set; } = new List<CampaignSendLog>();
        public ICollection<MessageStatusLog> MessageStatusLogs { get; set; }

        //public ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>();

        public string? ImageUrl { get; set; } // ✅ store image URL
        public string? ImageCaption { get; set; } // optional caption
        public string? TemplateParameters { get; set; } // ✅ stores ["value1", "value2", ...] as JSON string

        public ICollection<CampaignButton> MultiButtons { get; set; } = new List<CampaignButton>();

        public ICollection<MessageLog> MessageLogs { get; set; } = new List<MessageLog>();

    }
}
