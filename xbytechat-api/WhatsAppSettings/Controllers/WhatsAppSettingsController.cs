using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using xbytechat.api.Shared;
using xbytechat_api.WhatsAppSettings.DTOs;
using xbytechat_api.WhatsAppSettings.Services;

namespace xbytechat_api.WhatsAppSettings.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WhatsAppSettingsController : ControllerBase
    {
        private readonly IWhatsAppSettingsService _whatsAppSettingsService;
        private readonly ILogger<WhatsAppSettingsController> _logger;

        public WhatsAppSettingsController(
            IWhatsAppSettingsService whatsAppSettingsService,
            ILogger<WhatsAppSettingsController> logger)
        {
            _whatsAppSettingsService = whatsAppSettingsService;
            _logger = logger;
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSetting([FromBody] SaveWhatsAppSettingDto dto)
        {
            _logger.LogInformation("🔧 [UpdateSetting] Request received for WhatsApp settings update.");

            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new
                    {
                        Field = e.Key,
                        Errors = e.Value.Errors.Select(x => x.ErrorMessage)
                    });

                _logger.LogWarning("❌ [UpdateSetting] Validation failed: {@Errors}", validationErrors);
                return BadRequest(new { message = "❌ Invalid input.", errors = validationErrors });
            }

            Guid businessId;
            try
            {
                businessId = User.GetBusinessId(); // ✅ Cleaner using your helper
                dto.BusinessId = businessId;
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning("❌ [UpdateSetting] BusinessId claim missing or invalid: {Message}", ex.Message);
                return Unauthorized(new { message = "❌ BusinessId missing or invalid in token." });
            }

            if (string.IsNullOrWhiteSpace(dto.ApiToken) || string.IsNullOrWhiteSpace(dto.PhoneNumberId))
            {
                _logger.LogWarning("❌ [UpdateSetting] Missing ApiToken or PhoneNumberId.");
                return BadRequest(new { message = "❌ API Token and Phone Number ID are required." });
            }

            try
            {
                _logger.LogInformation("💾 [UpdateSetting] Saving/updating WhatsApp settings for businessId={BusinessId}.", businessId);
                await _whatsAppSettingsService.SaveOrUpdateSettingAsync(dto);
                _logger.LogInformation("✅ [UpdateSetting] WhatsApp settings updated successfully.");
                return Ok(new { message = "✅ WhatsApp settings saved/updated successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ [UpdateSetting] Exception occurred while saving settings.");
                return StatusCode(500, new { message = "❌ Error while saving settings.", details = ex.Message });
            }
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMySettings()
        {
  
            var businessId = User.GetBusinessId();
            var setting = await _whatsAppSettingsService.GetSettingsByBusinessIdAsync(businessId);
            if (setting == null)
                return NotFound(new { message = "❌ WhatsApp settings not found." });

            return Ok(setting);
        }

        [HttpGet("{businessId}")]
        public async Task<IActionResult> GetSetting(Guid businessId)
        {
            if (businessId == Guid.Empty)
                return BadRequest(new { message = "❌ Invalid businessId." });

            var setting = await _whatsAppSettingsService.GetSettingsByBusinessIdAsync(businessId);
            if (setting == null)
                return NotFound(new { message = "❌ WhatsApp settings not found." });

            return Ok(setting);
        }
        //[HttpPost("test-connection")]
        //public async Task<IActionResult> TestConnection([FromBody] SaveWhatsAppSettingDto dto)
        //{
        //    if (string.IsNullOrWhiteSpace(dto.ApiToken) || string.IsNullOrWhiteSpace(dto.ApiUrl))
        //        return BadRequest(new { message = "❌ API Token and API URL are required for testing connection." });

        //    try
        //    {
        //        var result = await _whatsAppSettingsService.TestConnectionAsync(dto);
        //        return Ok(new { message = result });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "❌ Test connection failed.", details = ex.Message });
        //    }
        //}
        [HttpPost("test-connection")]
        public async Task<IActionResult> TestConnection([FromBody] SaveWhatsAppSettingDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ApiToken) || string.IsNullOrWhiteSpace(dto.ApiUrl))
                return BadRequest(new { message = "❌ API Token and API URL are required for testing connection." });

            try
            {
                var result = await _whatsAppSettingsService.TestConnectionAsync(dto);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "❌ Test connection failed.", details = ex.Message });
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSetting()
        {
            var businessIdStr = User.FindFirst("BusinessId")?.Value;
            if (!Guid.TryParse(businessIdStr, out var businessId))
                return Unauthorized(new { message = "❌ BusinessId missing or invalid in token." });

            var result = await _whatsAppSettingsService.DeleteSettingsAsync(businessId);
            if (!result)
                return NotFound(new { message = "❌ No WhatsApp settings found to delete." });

            return Ok(new { message = "🗑️ WhatsApp settings deleted successfully." });
        }
    }
}


//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Threading.Tasks;
//using xbytechat_api.WhatsAppSettings.DTOs;
//using xbytechat_api.WhatsAppSettings.Services;

//namespace xbytechat_api.WhatsAppSettings.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class WhatsAppSettingsController : ControllerBase
//    {
//        private readonly IWhatsAppSettingsService _whatsAppSettingsService;

//        public WhatsAppSettingsController(IWhatsAppSettingsService whatsAppSettingsService)
//        {
//            _whatsAppSettingsService = whatsAppSettingsService;
//        }


//        [HttpPut("update")]
//        public async Task<IActionResult> UpdateSetting([FromBody] SaveWhatsAppSettingDto dto)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(new { message = "❌ Invalid input.", errors = ModelState });

//            if (string.IsNullOrWhiteSpace(dto.ApiToken) || string.IsNullOrWhiteSpace(dto.PhoneNumberId))
//                return BadRequest(new { message = "❌ API Token and Phone Number ID are required." });

//            try
//            {
//                await _whatsAppSettingsService.SaveOrUpdateSettingAsync(dto);
//                return Ok(new { message = "✅ WhatsApp settings saved/updated successfully." });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new { message = "❌ Error while saving settings.", details = ex.Message });
//            }
//        }

//        /// <summary>
//        /// Get WhatsApp Settings by BusinessId
//        /// </summary>
//        [HttpGet("{businessId}")]
//        public async Task<IActionResult> GetSetting(Guid businessId)
//        {
//            if (businessId == Guid.Empty)
//                return BadRequest(new { message = "❌ Invalid businessId." });

//            var setting = await _whatsAppSettingsService.GetSettingsByBusinessIdAsync(businessId);
//            if (setting == null)
//                return NotFound(new { message = "❌ WhatsApp settings not found." });

//            return Ok(setting);
//        }

//        /// <summary>
//        /// Test WhatsApp Connection (API URL + Token)
//        /// </summary>
//        [HttpPost("test-connection")]
//        public async Task<IActionResult> TestConnection([FromBody] SaveWhatsAppSettingDto dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.ApiToken) || string.IsNullOrWhiteSpace(dto.ApiUrl))
//                return BadRequest(new { message = "❌ API Token and API URL are required for testing connection." });

//            try
//            {
//                var result = await _whatsAppSettingsService.TestConnectionAsync(dto);
//                return Ok(new { message = result });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new { message = "❌ Test connection failed.", details = ex.Message });
//            }
//        }

//        /// <summary>
//        /// Delete WhatsApp Settings for a Business
//        /// </summary>
//        [HttpDelete("delete/{businessId}")]
//        public async Task<IActionResult> DeleteSetting(Guid businessId)
//        {
//            if (businessId == Guid.Empty)
//                return BadRequest(new { message = "❌ Invalid businessId." });

//            var result = await _whatsAppSettingsService.DeleteSettingsAsync(businessId);
//            if (!result)
//                return NotFound(new { message = "❌ No WhatsApp settings found to delete." });

//            return Ok(new { message = "🗑️ WhatsApp settings deleted successfully." });
//        }
//    }
//}
