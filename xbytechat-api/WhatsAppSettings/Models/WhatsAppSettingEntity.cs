using System;
using System.ComponentModel.DataAnnotations;

namespace xbytechat_api.WhatsAppSettings.Models
{
    public class WhatsAppSettingEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid BusinessId { get; set; }

        [Required]
        [MaxLength(500)]
        public string ApiUrl { get; set; }

        [Required]
        [MaxLength(1000)]
        public string ApiToken { get; set; }

        [Required]
        [MaxLength(20)]
        public string? WhatsAppBusinessNumber { get; set; }

        public string? PhoneNumberId { get; set; } //Meta Business phone number ID
        public string? WabaId { get; set; } = string.Empty; //WhatsApp Business Account ID

        [MaxLength(100)]
        public string? SenderDisplayName { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // string ApiVersion { get; set; } = "v18.0";

    }
}
