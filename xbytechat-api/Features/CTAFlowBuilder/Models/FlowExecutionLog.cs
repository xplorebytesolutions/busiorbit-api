using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xbytechat.api.Features.CTAFlowBuilder.Models
{
    /// <summary>
    /// Logs when a visual flow step is executed (useful for analytics, debugging, audit).
    /// </summary>
    public class FlowExecutionLog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid BusinessId { get; set; }

        [Required]
        public Guid StepId { get; set; }
        public string StepName { get; set; } = string.Empty;

        public Guid? FlowId { get; set; }

        public Guid? TrackingLogId { get; set; }

        public string? ContactPhone { get; set; }

        public string? TriggeredByButton { get; set; }

        public string? TemplateName { get; set; }

        public string? TemplateType { get; set; }

        public bool Success { get; set; }

        public string? ErrorMessage { get; set; }

        public string? RawResponse { get; set; }

        public DateTime ExecutedAt { get; set; } = DateTime.UtcNow;

       
    }
}
