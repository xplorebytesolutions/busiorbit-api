﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using xbytechat.api; // Your using for AppDbContext
using xbytechat.api.Features.Tracking.Services;
using xbytechat.api.Features.Tracking.DTOs; // Your using for DTOs

namespace xbytechat.api.Features.Tracking.Controllers
{
    [ApiController]
    [Route("api/tracking")]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingService _tracker;
        private readonly AppDbContext _context;
        private readonly IContactJourneyService _journeyService;
        public TrackingController(ITrackingService tracker, AppDbContext context, IContactJourneyService journeyService)
        {
            _tracker = tracker;
            _context = context;
            _journeyService = journeyService;
        }

        [HttpGet("journeys/{campaignSendLogId}")]
        public async Task<IActionResult> GetJourney(Guid campaignSendLogId)
        {
            var journeyEvents = await _journeyService.GetJourneyEventsAsync(campaignSendLogId);
            return Ok(journeyEvents);
        }

 
        [HttpGet("redirect/{campaignSendLogId}")]
        public async Task<IActionResult> TrackCampaignClick(
            Guid campaignSendLogId,
            [FromQuery] string type,
            [FromQuery] string to)
        {
            if (string.IsNullOrWhiteSpace(to))
            {
                return BadRequest("Missing redirect target URL.");
            }

            var log = await _context.CampaignSendLogs.FindAsync(campaignSendLogId);
            if (log != null)
            {
                log.IsClicked = true;
                log.ClickedAt = DateTime.UtcNow;
                log.ClickType = type;
                log.IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                await _context.SaveChangesAsync();
            }

            return Redirect(to);
        }

        /// <summary>
        /// Gets detailed information for a specific tracking log entry.
        /// </summary>
        [HttpGet("logs/{id}/details")]
        public async Task<IActionResult> GetLogDetails(Guid id)
        {
            var result = await _tracker.GetLogDetailsAsync(id);
            if (result == null)
                return NotFound("Tracking log not found");

            return Ok(result);
        }

        /// <summary>
        /// Retrieves click logs specifically related to automation flows.
        /// </summary>
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
