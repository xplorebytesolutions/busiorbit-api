

//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using xbytechat.api.Features.MessagesEngine.DTOs;
//using xbytechat.api.Features.MessagesEngine.Services;
//using xbytechat.api.Features.ReportingModule.Services;
//using xbytechat.api.Helpers;
//using xbytechat.api.Shared;

//namespace xbytechat.api.Features.MessagesEngine.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    [Authorize]
//    public class MessageEngineController : ControllerBase
//    {
//        private readonly IMessageEngineService _messageEngineService;
//        private readonly IMessageAnalyticsService _messageAnalyticsService;

//        public MessageEngineController(
//            IMessageEngineService messageEngineService,
//            IMessageAnalyticsService messageAnalyticsService)
//        {
//            _messageEngineService = messageEngineService;
//            _messageAnalyticsService = messageAnalyticsService;
//        }

//        // POST: /api/messageengine/send-text
//        [HttpPost("send-text")]
//        public async Task<IActionResult> SendTextMessage([FromBody] TextMessageSendDto dto)
//        {
//            if (dto is null)
//                return BadRequest(ResponseResult.ErrorInfo("❌ Payload is required."));

//            if (string.IsNullOrWhiteSpace(dto.RecipientNumber))
//                return BadRequest(ResponseResult.ErrorInfo("❌ RecipientNumber is required."));

//            if (string.IsNullOrWhiteSpace(dto.TextContent))
//                return BadRequest(ResponseResult.ErrorInfo("❌ TextContent is required."));

//            try
//            {
//                // 🔒 Enforce BusinessId from token (ignore client-supplied BusinessId)
//                var businessId = User.GetBusinessId();
//                dto.BusinessId = businessId;

//                var result = await _messageEngineService.SendTextDirectAsync(dto);

//                return result.Success
//                    ? Ok(result)
//                    : BadRequest(ResponseResult.ErrorInfo(result.ErrorMessage ?? "❌ Failed to send text.", result.RawResponse));
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"❌ Exception while sending text message: {ex.Message}");
//                return StatusCode(500, ResponseResult.ErrorInfo("🚨 Server error while sending text message.", ex.ToString()));
//            }
//        }

//        // POST: /api/messageengine/send-template-simple
//        [HttpPost("send-template-simple")]
//        public async Task<IActionResult> SendTemplateMessageSimple([FromBody] SimpleTemplateMessageDto dto)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ResponseResult.ErrorInfo("❌ Invalid template message request."));

//            try
//            {
//                var businessId = User.GetBusinessId();

//                var result = await _messageEngineService.SendTemplateMessageSimpleAsync(businessId, dto);

//                return result.Success
//                    ? Ok(result)
//                    : BadRequest(ResponseResult.ErrorInfo(result.Message ?? "❌ Failed to send template.", result.RawResponse));
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"❌ Exception while sending template: {ex.Message}");
//                return StatusCode(500, ResponseResult.ErrorInfo("🚨 Server error while sending template.", ex.ToString()));
//            }
//        }

//        // POST: /api/messageengine/send-image-campaign/{campaignId}
//        [HttpPost("send-image-campaign/{campaignId}")]
//        public async Task<IActionResult> SendImageCampaign(Guid campaignId)
//        {
//            try
//            {
//                var businessId = User.GetBusinessId();
//                var userName = User.Identity?.Name ?? "Unknown";

//                var result = await _messageEngineService.SendImageCampaignAsync(campaignId, businessId, userName);

//                return result.Success ? Ok(result) : BadRequest(result);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("❌ Error while sending image campaign: " + ex.Message);
//                return StatusCode(500, ResponseResult.ErrorInfo("Server error while sending campaign.", ex.ToString()));
//            }
//        }

//        // POST: /api/messageengine/send-image-template
//        [HttpPost("send-image-template")]
//        public async Task<IActionResult> SendImageTemplateMessage([FromBody] ImageTemplateMessageDto dto)
//        {
//            Guid businessId;
//            try
//            {
//                businessId = User.GetBusinessId();
//            }
//            catch (UnauthorizedAccessException ex)
//            {
//                return Unauthorized(new { message = ex.Message });
//            }

//            var result = await _messageEngineService.SendImageTemplateMessageAsync(dto, businessId);

//            if (result.Success)
//                return Ok(new { message = result.Message, raw = result.RawResponse });

//            return BadRequest(new { message = result.Message, raw = result.RawResponse });
//        }

//        // GET: /api/messageengine/recent?limit=20
//        [HttpGet("recent")]
//        public async Task<IActionResult> GetRecentLogs([FromQuery] int limit = 20)
//        {
//            var businessId = User.GetBusinessId();
//            var logs = await _messageAnalyticsService.GetRecentLogsAsync(businessId, limit);
//            return Ok(new { success = true, data = logs });
//        }
//    }
//}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using xbytechat.api.DTOs.Messages;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat.api.Features.ReportingModule.Services;
using xbytechat.api.Helpers;
using xbytechat.api.Shared;

namespace xbytechat.api.Features.MessagesEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessageEngineController : ControllerBase
    {
        private readonly IMessageEngineService _messageEngineService;
        private readonly IMessageAnalyticsService _messageAnalyticsServiceervice;


        public MessageEngineController(IMessageEngineService messageService, IMessageAnalyticsService messageAnalyticsService)
        {
            _messageEngineService = messageService;
            _messageAnalyticsServiceervice = messageAnalyticsService;
        }
        [HttpPost("send-text")]
        public async Task<IActionResult> SendTextMessage([FromBody] TextMessageSendDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ResponseResult.ErrorInfo("❌ Invalid text message payload."));

            try
            {
                var result = await _messageEngineService.SendTextDirectAsync(dto); // 👈 New direct method

                return result.Success
                    ? Ok(result)
                    : BadRequest(ResponseResult.ErrorInfo(result.Message, result.RawResponse));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception while sending text message: {ex.Message}");
                return StatusCode(500, ResponseResult.ErrorInfo("🚨 Server error while sending text message.", ex.ToString()));
            }
        }


        [HttpPost("send-template-simple")]
        public async Task<IActionResult> SendTemplateMessageSimple([FromBody] SimpleTemplateMessageDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ResponseResult.ErrorInfo("❌ Invalid template message request."));

            try
            {
                var businessIdClaim = User.FindFirst("businessId")?.Value;
                if (!Guid.TryParse(businessIdClaim, out Guid businessId))
                    return Unauthorized(ResponseResult.ErrorInfo("❌ Business ID not found in token."));

                var result = await _messageEngineService.SendTemplateMessageSimpleAsync(businessId, dto);

                return result.Success
                    ? Ok(result)
                    : BadRequest(ResponseResult.ErrorInfo(result.Message ?? "❌ Failed to send template.", result.RawResponse));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception while sending template: {ex.Message}");
                return StatusCode(500, ResponseResult.ErrorInfo("🚨 Server error while sending template.", ex.ToString()));
            }
        }


        [HttpPost("send-image-campaign/{campaignId}")]
        public async Task<IActionResult> SendImageCampaign(Guid campaignId)
        {
            try
            {
                var businessId = UserClaimHelper.GetBusinessId(User); // ✅ from
                                                                      // claims
                var userName = UserClaimHelper.GetUserName(User);     // for logging (if needed)

                var result = await _messageEngineService.SendImageCampaignAsync(campaignId, businessId, userName);

                return result.Success
                    ? Ok(result)
                    : BadRequest(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error while sending image campaign: " + ex.Message);
                return StatusCode(500, ResponseResult.ErrorInfo("Server error while sending campaign.", ex.ToString()));
            }
        }
        public static class UserClaimHelper
        {
            public static Guid GetBusinessId(ClaimsPrincipal user)
            {
                var claim = user.Claims.FirstOrDefault(c => c.Type == "businessId");
                return claim != null ? Guid.Parse(claim.Value) : Guid.Empty;
            }

            public static string GetUserName(ClaimsPrincipal user)
            {
                return user?.Identity?.Name ?? "Unknown";
            }
        }

        //[HttpPost("send-image-template")]
        //public async Task<IActionResult> SendImageTemplateMessage([FromBody] ImageTemplateMessageDto dto)
        //{
        //    if (string.IsNullOrWhiteSpace(dto.RecipientNumber) || string.IsNullOrWhiteSpace(dto.TemplateName))
        //        return BadRequest(new { message = "RecipientNumber and TemplateName are required." });

        //    var result = await _messageEngineService.SendImageTemplateMessageAsync(dto);

        //    if (result.Success)
        //        return Ok(new { message = result.Message, raw = result.RawResponse });

        //    return BadRequest(new { message = result.Message, raw = result.RawResponse });
        //}
        //[HttpPost("send-image-template")]
        //public async Task<IActionResult> SendImageTemplateMessage([FromBody] ImageTemplateMessageDto dto)
        //{
        //    // Extract BusinessId from claims (assuming it's saved as "BusinessId" claim)
        //    var businessIdClaim = User.Claims.FirstOrDefault(c => c.Type == "BusinessId")?.Value;
        //    if (string.IsNullOrEmpty(businessIdClaim) || !Guid.TryParse(businessIdClaim, out var businessId))
        //        return Unauthorized(new { message = "BusinessId not found in user claims." });

        //    // Pass businessId explicitly to the service
        //    var result = await _messageEngineService.SendImageTemplateMessageAsync(dto, businessId);

        //    if (result.Success)
        //        return Ok(new { message = result.Message, raw = result.RawResponse });

        //    return BadRequest(new { message = result.Message, raw = result.RawResponse });
        //}
        [HttpPost("send-image-template")]
        public async Task<IActionResult> SendImageTemplateMessage([FromBody] ImageTemplateMessageDto dto)
        {
            Guid businessId;
            try
            {
                businessId = User.GetBusinessId(); // Uses your extension method!
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }

            var result = await _messageEngineService.SendImageTemplateMessageAsync(dto, businessId);

            if (result.Success)
                return Ok(new { message = result.Message, raw = result.RawResponse });

            return BadRequest(new { message = result.Message, raw = result.RawResponse });
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentLogs([FromQuery] int limit = 20)
        {
            var businessId = User.GetBusinessId();
            var logs = await _messageAnalyticsServiceervice.GetRecentLogsAsync(businessId, limit);
            return Ok(new { success = true, data = logs });
        }



    }
}