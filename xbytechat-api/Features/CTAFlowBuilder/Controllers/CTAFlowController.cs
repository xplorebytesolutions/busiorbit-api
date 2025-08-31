// 📄 File: Features/CTAFlowBuilder/Controllers/CTAFlowController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using xbytechat.api.Features.CTAFlowBuilder.DTOs;
using xbytechat.api.Features.CTAFlowBuilder.Models;
using xbytechat.api.Features.CTAFlowBuilder.Services;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat.api.Features.Tracking.Models;
using xbytechat.api.Features.Tracking.Services;
using xbytechat.api.Helpers;


namespace xbytechat.api.Features.CTAFlowBuilder.Controllers
{
    [ApiController]
    [Route("api/cta-flow")]
    public class CTAFlowController : ControllerBase
    {
        private readonly ICTAFlowService _flowService;
        private readonly IMessageEngineService _messageEngineService;
        private readonly ITrackingService _trackingService;
        public CTAFlowController(ICTAFlowService flowService, IMessageEngineService messageEngineService, ITrackingService trackingService)
        {
            _flowService = flowService;
            _messageEngineService = messageEngineService;
            _trackingService = trackingService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateFlow([FromBody] CreateFlowDto dto)
        {
            var businessIdClaim = User.FindFirst("businessId")?.Value;
            var createdBy = User.FindFirst("name")?.Value ?? "system";

            if (string.IsNullOrWhiteSpace(businessIdClaim) || !Guid.TryParse(businessIdClaim, out var businessId))
                return BadRequest("❌ Invalid or missing businessId claim.");

            var id = await _flowService.CreateFlowWithStepsAsync(dto, businessId, createdBy);
            return Ok(new { flowId = id });
        }

        [HttpPost("publish")]
        public async Task<IActionResult> PublishFlow([FromBody] List<FlowStepDto> steps)
        {
            var businessIdClaim = User.FindFirst("businessId")?.Value;
            var createdBy = User.FindFirst("name")?.Value ?? "system";

            if (string.IsNullOrWhiteSpace(businessIdClaim) || !Guid.TryParse(businessIdClaim, out var businessId))
                return BadRequest("❌ Invalid or missing businessId claim.");

            var result = await _flowService.PublishFlowAsync(businessId, steps, createdBy);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok("✅ Flow published successfully.");
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetFlow()
        {
            var businessIdHeader = User.FindFirst("businessId")?.Value;
            if (!Guid.TryParse(businessIdHeader, out var businessId))
                return BadRequest("❌ Invalid or missing BusinessId header.");

            var flow = await _flowService.GetFlowByBusinessAsync(businessId);

            // ✅ Always return 200 even if flow is null
            return Ok(flow);
        }

        [HttpGet("draft")]
        public async Task<IActionResult> GetDraftFlow()
        {
            var businessIdHeader = User.FindFirst("businessId")?.Value;
            if (!Guid.TryParse(businessIdHeader, out var businessId))
                return BadRequest("❌ Invalid or missing BusinessId header.");

            var draft = await _flowService.GetDraftFlowByBusinessAsync(businessId);
            if (draft == null)
                return NotFound("❌ No draft flow found.");

            return Ok(draft);
        }

        [HttpGet("by-id/{id}")]
        public async Task<IActionResult> GetFlowById(Guid id)
        {
            var flow = await _flowService.GetVisualFlowByIdAsync(id);
            if (flow == null) return NotFound("❌ Flow not found");
            return Ok(flow);
        }

        //[HttpGet("match")]
        //public async Task<IActionResult> MatchButton([FromQuery] string text, [FromQuery] string type)
        //{
        //    var businessId = Guid.Parse(User.FindFirst("businessId")?.Value);

        //    var step = await _flowService.MatchStepByButtonAsync(businessId, text, type, currentTemplateName,);
        //    if (step == null)
        //        return NotFound("❌ No matching step found.");

        //    return Ok(new
        //    {
        //        step.TemplateToSend,
        //        step.TriggerButtonText,
        //        step.TriggerButtonType
        //    });
        //}

        [HttpGet("match")]
        public async Task<IActionResult> MatchButton(
    [FromQuery] string text,
    [FromQuery] string type,
    [FromQuery] string currentTemplateName,
    [FromQuery] Guid? campaignId) // Optional
        {
            var businessId = Guid.Parse(User.FindFirst("businessId")?.Value!);

            var step = await _flowService.MatchStepByButtonAsync(
                businessId,
                text,
                type,
                currentTemplateName,
                campaignId
            );

            if (step == null)
                return NotFound("❌ No matching step found.");

            return Ok(new
            {
                step.TemplateToSend,
                step.TriggerButtonText,
                step.TriggerButtonType
            });
        }

        [HttpPost("save-visual")]
        public async Task<IActionResult> SaveVisualFlow([FromBody] SaveVisualFlowDto dto)
        {
            var businessIdClaim = User.FindFirst("businessId")?.Value;
            var createdBy = User.FindFirst("name")?.Value ?? "system";

            if (!Guid.TryParse(businessIdClaim, out var businessId))
                return BadRequest("❌ Invalid business ID");

            Log.Information("📦 Saving CTA Flow: {FlowName} by {User}", dto.FlowName, createdBy);

            var result = await _flowService.SaveVisualFlowAsync(dto, businessId, createdBy);
            if (!result.Success)
            {
                Log.Error("❌ Failed to save flow. Error: {Error}. DTO: {@Dto}", result.ErrorMessage, dto);
                return StatusCode(500, new
                {
                    message = "❌ Failed to save flow",
                    error = result.ErrorMessage,
                    // skipped = result.SkippedNodes ?? 0
                });
            }

            return Ok(new
            {
                message = "✅ Flow saved successfully"
            });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFlow(Guid id)
        {
            var businessIdClaim = User.FindFirst("businessId")?.Value;
            if (!Guid.TryParse(businessIdClaim, out var businessId))
                return BadRequest("❌ Invalid business ID");

            var result = await _flowService.DeleteFlowAsync(id, businessId);

            return result.Success
                ? Ok(new { message = result.Message })
                : BadRequest(new { message = result.Message });
        }
        [HttpGet("all-published")]
        public async Task<IActionResult> GetPublishedFlows()
        {
            var businessIdClaim = User.FindFirst("businessId")?.Value;
            if (!Guid.TryParse(businessIdClaim, out var businessId))
                return BadRequest("❌ Invalid business ID");

            var flows = await _flowService.GetAllPublishedFlowsAsync(businessId);
            return Ok(flows);
        }
        [HttpGet("all-draft")]
        public async Task<IActionResult> GetAllDraftFlows()
        {
            var businessIdClaim = User.FindFirst("businessId")?.Value;
            if (!Guid.TryParse(businessIdClaim, out var businessId))
                return BadRequest("❌ Invalid business ID");

            var flows = await _flowService.GetAllDraftFlowsAsync(businessId);
            return Ok(flows);
        }

        // 📄 File: D:\...\Features\CTAFlowBuilder\Controllers\CTAFlowController.cs

        [HttpPost("execute-visual")]
        public async Task<IActionResult> ExecuteVisualFlowAsync(
            [FromQuery] Guid nextStepId,
            [FromQuery] Guid trackingLogId,
            // ✅ 1. ADD the new optional parameter to the endpoint
            [FromQuery] Guid? campaignSendLogId = null)
        {
            var businessIdClaim = User.FindFirst("businessId")?.Value;
            if (!Guid.TryParse(businessIdClaim, out var businessId))
                return BadRequest("❌ Invalid business ID");

            // ✅ 2. PASS the new parameter to the service call
            var result = await _flowService.ExecuteVisualFlowAsync(businessId, nextStepId, trackingLogId, campaignSendLogId);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("create-config")]
        public async Task<IActionResult> CreateConfigFlow([FromBody] CreateFlowDto dto)
        {
            var businessIdClaim = User.FindFirst("businessId")?.Value;
            var createdBy = User.FindFirst("name")?.Value ?? "system";

            if (string.IsNullOrWhiteSpace(businessIdClaim) || !Guid.TryParse(businessIdClaim, out var businessId))
                return BadRequest("❌ Invalid or missing businessId claim.");

            try
            {
                var id = await _flowService.CreateFlowWithStepsAsync(dto, businessId, createdBy);

                return Ok(new
                {
                    flowId = id,
                    message = "✅ Flow config created successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    error = "❌ Failed to create flow config.",
                    details = ex.Message
                });
            }
        }

    }
}