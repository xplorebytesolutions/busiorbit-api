// 📄 File: WhatsAppSettings/Controllers/WhatsAppSettingsController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using xbytechat.api.Shared; // for User.GetBusinessId()
using xbytechat_api.WhatsAppSettings.DTOs;
using xbytechat_api.WhatsAppSettings.Services;

namespace xbytechat_api.WhatsAppSettings.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WhatsAppSettingsController : ControllerBase
    {
        private readonly IWhatsAppSettingsService _svc;
        private readonly ILogger<WhatsAppSettingsController> _logger;

        public WhatsAppSettingsController(
            IWhatsAppSettingsService svc,
            ILogger<WhatsAppSettingsController> logger)
        {
            _svc = svc;
            _logger = logger;
        }

        // ----------------------------
        // Save/Update settings
        // ----------------------------
        [HttpPut("update")]
        public async Task<IActionResult> UpdateSetting([FromBody] SaveWhatsAppSettingDto dto)
        {
            _logger.LogInformation("🔧 [UpdateSetting] Incoming payload for provider={Provider}", dto?.Provider);

            if (!ModelState.IsValid)
            {
                var errs = ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new { Field = e.Key, Errors = e.Value.Errors.Select(x => x.ErrorMessage) });

                _logger.LogWarning("❌ [UpdateSetting] Validation failed: {@Errors}", errs);
                return BadRequest(new { message = "❌ Invalid input.", errors = errs });
            }

            Guid businessId;
            try
            {
                businessId = User.GetBusinessId();
                dto.BusinessId = businessId;
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning("❌ [UpdateSetting] BusinessId claim missing/invalid: {Msg}", ex.Message);
                return Unauthorized(new { message = "❌ BusinessId missing or invalid in token." });
            }

            try
            {
                // Normalize provider to our canonical set
                dto.Provider = NormalizeProvider(dto.Provider);

                await _svc.SaveOrUpdateSettingAsync(dto);
                return Ok(new { message = "✅ WhatsApp settings saved/updated successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ [UpdateSetting] Exception while saving settings.");
                return StatusCode(500, new { message = "❌ Error while saving settings.", details = ex.Message });
            }
        }

        // ----------------------------
        // Get the current user's saved settings
        // ----------------------------
        [HttpGet("me")]
        public async Task<IActionResult> GetMySettings()
        {
            var businessId = User.GetBusinessId();
            var setting = await _svc.GetSettingsByBusinessIdAsync(businessId);
            if (setting == null)
                return NotFound(new { message = "❌ WhatsApp settings not found." });

            return Ok(setting);
        }

        // ----------------------------
        // Test connection using values sent in the body (not necessarily saved)
        // Accepts Provider = "Pinnacle" or "Meta_cloud"
        // ----------------------------
        [HttpPost("test-connection")]
        public async Task<IActionResult> TestConnection([FromBody] SaveWhatsAppSettingDto dto)
        {
            if (dto is null)
                return BadRequest(new { message = "❌ Missing request body." });

            var provider = NormalizeProvider(dto.Provider);
            if (provider is null)
                return BadRequest(new { message = "❌ Provider is required (Pinnacle | Meta_cloud)." });

            dto.Provider = provider; // use canonical

            // Minimal provider-specific validation (service will validate again)
            if (provider == "Meta_cloud")
            {
                if (string.IsNullOrWhiteSpace(dto.ApiUrl) ||
                    string.IsNullOrWhiteSpace(dto.ApiToken) ||
                    string.IsNullOrWhiteSpace(dto.PhoneNumberId))
                {
                    return BadRequest(new { message = "❌ API URL, Token and Phone Number ID are required for Meta Cloud test." });
                }
            }
            else if (provider == "Pinnacle")
            {
                if (string.IsNullOrWhiteSpace(dto.ApiUrl) ||
                    string.IsNullOrWhiteSpace(dto.ApiKey) ||
                    (string.IsNullOrWhiteSpace(dto.WabaId) && string.IsNullOrWhiteSpace(dto.PhoneNumberId)) ||
                    string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber))
                {
                    return BadRequest(new
                    {
                        message = "❌ API URL, API Key, (WABA ID or Phone Number ID), and Business Number are required for Pinnacle test."
                    });
                }
            }

            try
            {
                var message = await _svc.TestConnectionAsync(dto);

                // Convention: service returns a human string; we 200 on success (starts with ✅), 400 otherwise
                if (!string.IsNullOrEmpty(message) && message.StartsWith("✅"))
                    return Ok(new { message });

                return BadRequest(new { message = string.IsNullOrEmpty(message) ? "❌ Test failed." : message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ [TestConnection] Failed");
                return StatusCode(500, new { message = "❌ Test connection failed.", details = ex.Message });
            }
        }

        // ----------------------------
        // Test connection against the SAVED settings for this business
        // ----------------------------
        [HttpPost("test-connection/current")]
        public async Task<IActionResult> TestConnectionCurrent()
        {
            var businessId = User.GetBusinessId();
            var saved = await _svc.GetSettingsByBusinessIdAsync(businessId);
            if (saved is null)
                return NotFound(new { message = "❌ No saved WhatsApp settings found." });

            var dto = new SaveWhatsAppSettingDto
            {
                BusinessId = businessId,
                Provider = NormalizeProvider(saved.Provider) ?? saved.Provider,
                ApiUrl = saved.ApiUrl,
                ApiKey = saved.ApiKey,
                ApiToken = saved.ApiToken,
                PhoneNumberId = saved.PhoneNumberId,
                WabaId = saved.WabaId,
                WhatsAppBusinessNumber = saved.WhatsAppBusinessNumber,
                SenderDisplayName = saved.SenderDisplayName,
                WebhookSecret = saved.WebhookSecret,
                WebhookVerifyToken = saved.WebhookVerifyToken,
                IsActive = saved.IsActive
            };

            try
            {
                var message = await _svc.TestConnectionAsync(dto);
                if (!string.IsNullOrEmpty(message) && message.StartsWith("✅"))
                    return Ok(new { message });

                return BadRequest(new { message = string.IsNullOrEmpty(message) ? "❌ Test failed." : message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ [TestConnectionCurrent] Failed");
                return StatusCode(500, new { message = "❌ Test connection failed.", details = ex.Message });
            }
        }

        // ----------------------------
        // Delete current user's settings
        // ----------------------------
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSetting()
        {
            var businessId = User.GetBusinessId();
            var deleted = await _svc.DeleteSettingsAsync(businessId);
            if (!deleted) return NotFound(new { message = "❌ No WhatsApp settings found to delete." });
            return Ok(new { message = "🗑️ WhatsApp settings deleted successfully." });
        }

        // Optional alias for FE routes that call /delete-current
        [HttpDelete("delete-current")]
        public Task<IActionResult> DeleteSettingAlias() => DeleteSetting();

        /// <summary>
        /// Maps any incoming text to the canonical provider values we support.
        /// Returns null if unrecognized.
        /// </summary>
        private static string? NormalizeProvider(string? providerRaw)
        {
            if (string.IsNullOrWhiteSpace(providerRaw)) return null;

            var p = providerRaw.Trim();

            // Accept canonical values exactly and a few common variants
            if (string.Equals(p, "Pinnacle", StringComparison.Ordinal)) return "Pinnacle";
            if (string.Equals(p, "Meta_cloud", StringComparison.Ordinal)) return "Meta_cloud";

            // tolerate some user/legacy variants from older UIs
            var lower = p.ToLowerInvariant();
            if (lower is "pinbot" or "pinnacle (official)" or "pinnacle (pinnacle)" or "pinnacle official")
                return "Pinnacle";
            if (lower is "meta cloud" or "meta" or "meta-cloud")
                return "Meta_cloud";

            return null;
        }
    }
}


//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using xbytechat.api.Shared;
//using xbytechat_api.WhatsAppSettings.DTOs;
//using xbytechat_api.WhatsAppSettings.Services;

//namespace xbytechat_api.WhatsAppSettings.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    [Authorize]
//    public class WhatsAppSettingsController : ControllerBase
//    {
//        private readonly IWhatsAppSettingsService _whatsAppSettingsService;
//        private readonly ILogger<WhatsAppSettingsController> _logger;

//        public WhatsAppSettingsController(
//            IWhatsAppSettingsService whatsAppSettingsService,
//            ILogger<WhatsAppSettingsController> logger)
//        {
//            _whatsAppSettingsService = whatsAppSettingsService;
//            _logger = logger;
//        }

//        [HttpPut("update")]
//        public async Task<IActionResult> UpdateSetting([FromBody] SaveWhatsAppSettingDto dto)
//        {
//            _logger.LogInformation("🔧 [UpdateSetting] Request received for WhatsApp settings update.");

//            if (!ModelState.IsValid)
//            {
//                var validationErrors = ModelState
//                    .Where(e => e.Value.Errors.Count > 0)
//                    .Select(e => new
//                    {
//                        Field = e.Key,
//                        Errors = e.Value.Errors.Select(x => x.ErrorMessage)
//                    });

//                _logger.LogWarning("❌ [UpdateSetting] Validation failed: {@Errors}", validationErrors);
//                return BadRequest(new { message = "❌ Invalid input.", errors = validationErrors });
//            }

//            Guid businessId;
//            try
//            {
//                businessId = User.GetBusinessId(); // ✅ Cleaner using your helper
//                dto.BusinessId = businessId;
//            }
//            catch (UnauthorizedAccessException ex)
//            {
//                _logger.LogWarning("❌ [UpdateSetting] BusinessId claim missing or invalid: {Message}", ex.Message);
//                return Unauthorized(new { message = "❌ BusinessId missing or invalid in token." });
//            }

//            if (string.IsNullOrWhiteSpace(dto.ApiToken) || string.IsNullOrWhiteSpace(dto.PhoneNumberId))
//            {
//                _logger.LogWarning("❌ [UpdateSetting] Missing ApiToken or PhoneNumberId.");
//                return BadRequest(new { message = "❌ API Token and Phone Number ID are required." });
//            }

//            try
//            {
//                _logger.LogInformation("💾 [UpdateSetting] Saving/updating WhatsApp settings for businessId={BusinessId}.", businessId);
//                await _whatsAppSettingsService.SaveOrUpdateSettingAsync(dto);
//                _logger.LogInformation("✅ [UpdateSetting] WhatsApp settings updated successfully.");
//                return Ok(new { message = "✅ WhatsApp settings saved/updated successfully." });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "❌ [UpdateSetting] Exception occurred while saving settings.");
//                return StatusCode(500, new { message = "❌ Error while saving settings.", details = ex.Message });
//            }
//        }

//        [HttpGet("me")]
//        public async Task<IActionResult> GetMySettings()
//        {

//            var businessId = User.GetBusinessId();
//            var setting = await _whatsAppSettingsService.GetSettingsByBusinessIdAsync(businessId);
//            if (setting == null)
//                return NotFound(new { message = "❌ WhatsApp settings not found." });

//            return Ok(setting);
//        }

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
//        //[HttpPost("test-connection")]
//        //public async Task<IActionResult> TestConnection([FromBody] SaveWhatsAppSettingDto dto)
//        //{
//        //    if (string.IsNullOrWhiteSpace(dto.ApiToken) || string.IsNullOrWhiteSpace(dto.ApiUrl))
//        //        return BadRequest(new { message = "❌ API Token and API URL are required for testing connection." });

//        //    try
//        //    {
//        //        var result = await _whatsAppSettingsService.TestConnectionAsync(dto);
//        //        return Ok(new { message = result });
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(500, new { message = "❌ Test connection failed.", details = ex.Message });
//        //    }
//        //}
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

//        [HttpDelete("delete")]
//        public async Task<IActionResult> DeleteSetting()
//        {
//            var businessIdStr = User.FindFirst("BusinessId")?.Value;
//            if (!Guid.TryParse(businessIdStr, out var businessId))
//                return Unauthorized(new { message = "❌ BusinessId missing or invalid in token." });

//            var result = await _whatsAppSettingsService.DeleteSettingsAsync(businessId);
//            if (!result)
//                return NotFound(new { message = "❌ No WhatsApp settings found to delete." });

//            return Ok(new { message = "🗑️ WhatsApp settings deleted successfully." });
//        }
//    }
//}


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
