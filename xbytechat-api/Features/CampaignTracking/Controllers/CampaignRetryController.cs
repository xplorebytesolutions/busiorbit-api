using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using xbytechat.api.Features.CampaignTracking.Services;

namespace xbytechat.api.Features.CampaignTracking.Controllers
{
    [ApiController]
    [Route("api/campaign-retry")]
    public class CampaignRetryController : ControllerBase
    {
        private readonly ICampaignRetryService _retryService;

        public CampaignRetryController(ICampaignRetryService retryService)
        {
            _retryService = retryService;
        }

        // 🔁 Retry a single failed log
        // Endpoint: POST /api/campaign-retry/{logId}/retry
        [HttpPost("{logId}/retry")]
        public async Task<IActionResult> RetrySingle(Guid logId)
        {
            var success = await _retryService.RetrySingleAsync(logId);
            if (!success)
                return BadRequest(new { message = "Retry failed or not allowed for this log." });

            return Ok(new { success = true, message = "Retry completed." });
        }

        // 🔁 Retry all failed logs in a campaign
        // Endpoint: POST /api/campaign-retry/campaign/{campaignId}/retry-all
        [HttpPost("campaign/{campaignId}/retry-all")]
        public async Task<IActionResult> RetryAllInCampaign(Guid campaignId)
        {
            var retriedCount = await _retryService.RetryFailedInCampaignAsync(campaignId);
            return Ok(new { success = true, retriedCount });
        }
    }
}
