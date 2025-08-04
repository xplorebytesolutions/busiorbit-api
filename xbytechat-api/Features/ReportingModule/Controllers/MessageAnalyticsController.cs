using Microsoft.AspNetCore.Mvc;
using xbytechat.api.Features.ReportingModule.Services;
using xbytechat.api.Shared;


namespace xbytechat.api.Features.ReportingModule.Controllers
{
    [ApiController]
    [Route("api/reporting/messages")]
    public class MessageAnalyticsController : ControllerBase
    {
        private readonly IMessageAnalyticsService _service;

        public MessageAnalyticsController(IMessageAnalyticsService service)
        {
            _service = service;
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentLogs([FromQuery] int limit = 20)
        {
            var businessId = User.GetBusinessId(); // 🔒 assumes claims extension
            var logs = await _service.GetRecentLogsAsync(businessId, limit);
            return Ok(new { success = true, data = logs });
        }
        [HttpGet("history")]
        public async Task<IActionResult> GetPaginatedLogs([FromQuery] PaginatedRequest request)
        {
            var businessId = User.GetBusinessId(); // 🔐 via claims
            var result = await _service.GetPaginatedLogsAsync(businessId, request);
            return Ok(new { success = true, data = result });
        }

    }
}