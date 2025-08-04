// 📄 File: xbytechat.api/Features/CTAFlowBuilder/Models/CTAFlowConfig.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace xbytechat.api.Features.CTAFlowBuilder.Models
{
    /// <summary>
    /// Represents a complete flow configuration for a business, such as "Interested Journey".
    /// </summary>
    public class CTAFlowConfig
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid BusinessId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FlowName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public bool IsPublished { get; set; } = false; // ✅ NEW: Support draft/published

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }  // ✅ Add this line

        // 🔁 Navigation to steps
        public ICollection<CTAFlowStep> Steps { get; set; } = new List<CTAFlowStep>();
    }
}
