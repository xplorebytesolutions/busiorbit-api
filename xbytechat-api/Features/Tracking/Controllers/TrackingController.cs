using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using xbytechat.api.Features.Tracking.DTOs;
using xbytechat.api.Features.Tracking.Models;
using xbytechat.api.Features.Tracking.Services;
using xbytechat.api.Shared.TrackingUtils;

namespace xbytechat.api.Features.Tracking.Controllers
{
    [ApiController]
    [Route("api/tracking")]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingService _tracker;

        public TrackingController(ITrackingService tracker)
        {
            _tracker = tracker;
        }
        #region "Tracking Logs"
        //       [HttpGet("redirect")]
        //       public async Task<IActionResult> TrackAndRedirect(
        //                                        [FromQuery] string src,
        //                                        [FromQuery] Guid id,
        //                                        [FromQuery] string btn,
        //                                        [FromQuery] string? to = null,
        //                                        [FromQuery] string? type = null,
        //                                        [FromQuery] Guid? msg = null,
        //                                        [FromQuery] Guid? contact = null,
        //                                        [FromQuery] string? phone = null,
        //                                        [FromQuery] string? session = null,
        //                                        [FromQuery] string? thread = null
        //)
        //       {
        //           var userAgent = Request.Headers["User-Agent"].FirstOrDefault() ?? "unknown";
        //           var ipAddress = Request.Headers["X-Forwarded-For"].FirstOrDefault()
        //                        ?? HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        //           var country = await GeoHelper.GetCountryFromIP(ipAddress);
        //           var deviceType = DeviceHelper.GetDeviceType(userAgent);

        //           var businessIdClaim = User.FindFirst("businessId")?.Value;
        //           if (!Guid.TryParse(businessIdClaim, out var businessId))
        //               return Unauthorized("Invalid business context");

        //           var dto = new TrackingLogDto
        //           {
        //               BusinessId = businessId,// Guid.Empty, // TODO: Replace with actual business lookup if available
        //               ContactId = contact,
        //               ContactPhone = phone,
        //               SourceType = src,
        //               SourceId = id,
        //               ButtonText = btn,
        //               CTAType = type ?? btn,
        //               MessageId = msg?.ToString(),
        //               SessionId = session,
        //               ThreadId = thread,
        //               ClickedAt = DateTime.UtcNow,
        //               IPAddress = ipAddress,
        //               Browser = userAgent,
        //               DeviceType = deviceType,
        //               Country = country,
        //               ClickedVia = "web"
        //           };

        //           await _tracker.LogCTAClickAsync(dto);

        //           if (string.IsNullOrWhiteSpace(to))
        //               return BadRequest("Missing redirect target.");

        //           var decodedUrl = Uri.UnescapeDataString(to);
        //           return Redirect(decodedUrl);
        //       }

        #endregion

        //        [HttpGet("redirect")]
        //        public async Task<IActionResult> TrackAndRedirect(
        //            [FromQuery] string src,
        //            [FromQuery] Guid id,
        //            [FromQuery] string btn,
        //            [FromQuery] string? to = null,
        //            [FromQuery] string? type = null,
        //            [FromQuery] Guid? msg = null,
        //            [FromQuery] Guid? contact = null,
        //            [FromQuery] string? phone = null,
        //            [FromQuery] string? session = null,
        //            [FromQuery] string? thread = null
        //)
        //        {
        //            var userAgent = Request.Headers["User-Agent"].FirstOrDefault() ?? "unknown";
        //            var ipAddress = Request.Headers["X-Forwarded-For"].FirstOrDefault()
        //                         ?? HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        //            var country = await GeoHelper.GetCountryFromIP(ipAddress);
        //            var deviceType = DeviceHelper.GetDeviceType(userAgent);

        //            // 🔍 1. Attempt to extract businessId from claims
        //            var businessIdClaim = User.FindFirst("businessId")?.Value;
        //            var hasBusinessId = Guid.TryParse(businessIdClaim, out var businessId);

        //            // 🧠 2. Create base DTO
        //            var dto = new TrackingLogDto
        //            {
        //                BusinessId = hasBusinessId ? businessId : Guid.Empty, // fallback — will enrich later
        //                ContactId = contact,
        //                ContactPhone = phone,
        //                SourceType = src,
        //                SourceId = id,
        //                ButtonText = btn,
        //                CTAType = type ?? btn,
        //                MessageId = msg?.ToString(),
        //                SessionId = session,
        //                ThreadId = thread,
        //                ClickedAt = DateTime.UtcNow,
        //                IPAddress = ipAddress,
        //                Browser = userAgent,
        //                DeviceType = deviceType,
        //                Country = country,
        //                ClickedVia = "web"
        //            };

        //            // 🔁 3. Fallback enrichment from MessageLog
        //            if (msg.HasValue)
        //            {
        //                var messageLog = await _context.MessageLogs
        //                    .AsNoTracking()
        //                    .FirstOrDefaultAsync(m => m.Id == msg.Value || m.MessageId == msg.ToString());

        //                if (messageLog != null)
        //                {
        //                    // 🧩 Backfill missing fields if needed
        //                    dto.BusinessId = dto.BusinessId == Guid.Empty ? messageLog.BusinessId : dto.BusinessId;
        //                    dto.ContactId ??= messageLog.ContactId;
        //                    dto.CampaignId ??= messageLog.CampaignId;
        //                    dto.MessageLogId ??= messageLog.Id;
        //                }
        //            }

        //            // 🔁 4. Fallback from CampaignSendLog (if SourceType is "campaign")
        //            if (src == "campaign" && msg.HasValue && dto.CampaignId == null)
        //            {
        //                var sendLog = await _context.CampaignSendLogs
        //                    .AsNoTracking()
        //                    .FirstOrDefaultAsync(c => c.MessageId == msg.ToString());

        //                if (sendLog != null)
        //                {
        //                    dto.BusinessId = dto.BusinessId == Guid.Empty ? sendLog.BusinessId : dto.BusinessId;
        //                    dto.ContactId ??= sendLog.ContactId;
        //                    dto.CampaignId ??= sendLog.CampaignId;
        //                    dto.CampaignSendLogId ??= sendLog.Id;
        //                }
        //            }

        //            // ✅ 5. Final safety check
        //            if (dto.BusinessId == Guid.Empty)
        //            {
        //                Log.Warning("⚠️ TrackingLog DTO missing valid BusinessId. msg={@msg}", msg);
        //                return Unauthorized("Business context missing or invalid.");
        //            }

        //            // 💾 6. Save to database
        //            await _tracker.LogCTAClickAsync(dto);

        //            // 🌐 7. Redirect to final URL
        //            if (string.IsNullOrWhiteSpace(to))
        //                return BadRequest("Missing redirect target.");

        //            var decodedUrl = Uri.UnescapeDataString(to);
        //            return Redirect(decodedUrl);
        //        }
        [HttpGet("redirect")]
        public async Task<IActionResult> TrackAndRedirect([FromQuery] string src, [FromQuery] Guid id,
            [FromQuery] string btn, [FromQuery] string? to = null, [FromQuery] string? type = null,
            [FromQuery] Guid? msg = null, [FromQuery] Guid? contact = null, [FromQuery] string? phone = null,
            [FromQuery] string? session = null, [FromQuery] string? thread = null)
        {
            var userAgent = Request.Headers["User-Agent"].FirstOrDefault() ?? "unknown";
            var ipAddress = Request.Headers["X-Forwarded-For"].FirstOrDefault()
                         ?? HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            var country = await GeoHelper.GetCountryFromIP(ipAddress);
            var deviceType = DeviceHelper.GetDeviceType(userAgent);

            var businessIdClaim = User.FindFirst("businessId")?.Value;
            var hasBusinessId = Guid.TryParse(businessIdClaim, out var businessId);

            var dto = new TrackingLogDto
            {
                BusinessId = hasBusinessId ? businessId : Guid.Empty,
                ContactId = contact,
                ContactPhone = phone,
                SourceType = src,
                SourceId = id,
                ButtonText = btn,
                CTAType = type ?? btn,
                MessageId = msg?.ToString(),
                SessionId = session,
                ThreadId = thread,
                ClickedAt = DateTime.UtcNow,
                IPAddress = ipAddress,
                Browser = userAgent,
                DeviceType = deviceType,
                Country = country,
                ClickedVia = "web"
            };

            var result = await _tracker.LogCTAClickWithEnrichmentAsync(dto);
            if (!result.Success)
                return Unauthorized(result.Message);

            if (string.IsNullOrWhiteSpace(to))
                return BadRequest("Missing redirect target.");

            return Redirect(Uri.UnescapeDataString(to));
        }

        [HttpGet("logs/{id}/details")]
        public async Task<IActionResult> GetLogDetails(Guid id)
        {
            var result = await _tracker.GetLogDetailsAsync(id);
            if (result == null)
                return NotFound("Tracking log not found");

            return Ok(result);
        }
        [HttpGet("flow-clicks")]
       
        public async Task<IActionResult> GetFlowClickLogs()
        {
            var businessIdClaim = User.FindFirst("businessId")?.Value;
            if (!Guid.TryParse(businessIdClaim, out var businessId))
                return BadRequest("❌ Invalid or missing business ID");

            var logs = await _tracker.GetFlowClickLogsAsync(businessId);

            var dtoList = logs.Select(x => new
            {
                x.Id,
                x.StepId,
                x.ContactPhone,
                x.ButtonText,
                x.TemplateId,
                x.FollowUpSent,
                x.ClickedAt
            });

            return Ok(dtoList);
        }
    }
}