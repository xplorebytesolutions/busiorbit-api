using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xbytechat.api.Features.AccessControl.Models;
using xbytechat.api.Features.AccessControl.Services;
using xbytechat.api.Features.Inbox.Services;

namespace xbytechat.api.Features.AccessControl.Controllers
{
    [ApiController]
    [Route("api/admin/plans")]
    [Authorize(Roles = "SuperAdmin")] // Only SuperAdmin can access
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;
        
        private readonly ILogger<PlanController> _logger;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePlan([FromBody] CreatePlanRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest("Plan name is required.");

            var plan = await _planService.CreatePlanAsync(request.Name, request.Description);
            return Ok(plan);
        }

        [HttpPost("{planId}/assign-permissions")]
        public async Task<IActionResult> AssignPermissions(Guid planId, [FromBody] AssignPermissionsRequest request)
        {
            await _planService.AssignPermissionsAsync(planId, request.PermissionIds);
            return Ok(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlans()
        {
            var plans = await _planService.GetAllPlansAsync();
            return Ok(plans);
        }

        [HttpGet("{planId}")]
        public async Task<IActionResult> GetPlanDetails(Guid planId)
        {
            var plan = await _planService.GetPlanByIdAsync(planId);
            if (plan == null) return NotFound();

            return Ok(plan);
        }

        [HttpGet("{planId}/permissions")]
        public async Task<IActionResult> GetPermissionsForPlan(Guid planId)
        {
            var permissions = await _planService.GetPermissionsByPlanAsync(planId);
            return Ok(permissions);
        }
    }

    // ✅ DTOs

    public class CreatePlanRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class AssignPermissionsRequest
    {
        public List<Guid> PermissionIds { get; set; }
    }
}
