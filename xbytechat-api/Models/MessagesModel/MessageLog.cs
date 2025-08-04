using System;
using System.Collections.Generic;
using xbytechat.api.CRM.Models;
using xbytechat.api.Features.BusinessModule.Models;
using xbytechat.api.Features.CampaignModule.Models;
using xbytechat.api.Features.MessageManagement.DTOs;

public class MessageLog
{
    public Guid Id { get; set; }

    public string? MessageId { get; set; } // WAMID from WhatsApp — alternate key
   // public ICollection<MessageStatusLog> StatusUpdates { get; set; } = new List<MessageStatusLog>();

    // 🔗 FK to Business
    public Guid BusinessId { get; set; }
    public Business Business { get; set; }

    // 📨 Message Info
    public string RecipientNumber { get; set; }
    public string MessageContent { get; set; }
    public string? MediaUrl { get; set; }

    // 🧾 Status Info
    public string Status { get; set; } = "Queued";
    public string? ErrorMessage { get; set; }
    public string? RawResponse { get; set; }

    // 🕒 Timestamps
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? SentAt { get; set; }

    // 🔗 Contact (optional)
    public Guid? ContactId { get; set; }
    public Contact? Contact { get; set; }

    // 🔗 Campaign (optional)
    public Guid? CampaignId { get; set; }

    // 🔗 CTA Flow Tracking
    public Guid? CTAFlowConfigId { get; set; }  // Which visual flow config this message belongs to
    public Guid? CTAFlowStepId { get; set; }    // Which flow step (template) this message originated from
    public Campaign? SourceCampaign { get; set; } // renamed from "Campaign" to avoid name conflict

    public bool IsIncoming { get; set; }

    public string? RenderedBody { get; set; } // actual resolved message with parameters

    public Guid? RefMessageId { get; set; }
    public string? Source { get; set; } // e.g., "campaign", "flow", "manual"
}
