using System;
using System.Collections.Generic;

namespace xbytechat.api.Features.MessagesEngine.DTOs
{
    public class SimpleTemplateMessageDto
    {
        //public Guid BusinessId { get; set; }

        public string RecipientNumber { get; set; }

        public string TemplateName { get; set; }

        public List<string> TemplateParameters { get; set; } = new();
        public bool HasStaticButtons { get; set; } = false;

        // ✅ Add these two for flow tracking
        public Guid? CTAFlowConfigId { get; set; }
        public Guid? CTAFlowStepId { get; set; }
        public string? TemplateBody { get; set; }  // 🔥 Used to render actual message body from placeholders

    }
}

