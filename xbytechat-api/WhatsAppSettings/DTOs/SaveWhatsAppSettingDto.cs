using System;
using System.ComponentModel.DataAnnotations;

namespace xbytechat_api.WhatsAppSettings.DTOs
{
    public class SaveWhatsAppSettingDto
    {
       
        public Guid BusinessId { get; set; }

        [Required]
        [MaxLength(1000)]
        public string ApiToken { get; set; }

        [Required]
        [MaxLength(100)]
        public string PhoneNumberId { get; set; }  // ✅ NEW: Needed to send messages

        [MaxLength(100)]
        public string? WabaId { get; set; } // Optional

        [MaxLength(100)]
        public string? SenderDisplayName { get; set; }

        [Required]
        [MaxLength(500)]
        public string ApiUrl { get; set; } = "https://graph.facebook.com/v18.0/";

        [Required]
        [MaxLength(50)]
        public string WhatsAppBusinessNumber { get; set; }  // ✅ Still used for testing via `/me` or WABA ID

        public bool IsActive { get; set; } = true;
    }
}
