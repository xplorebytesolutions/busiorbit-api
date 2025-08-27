﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using xbytechat.api.Features.AccessControl.DTOs;
using xbytechat.api.Features.AccessControl.Services;
using xbytechat.api.Helpers; // ✅ For ResponseResult

namespace xbytechat.api.Features.AccessControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;
        private readonly IPermissionCacheService _permissionCacheService;
        private readonly ILogger<PlanController> _logger;
        public PlanController(IPlanService planService, IPermissionCacheService permissionCacheService, ILogger<PlanController> logger)
        {
            _planService = planService;
            _permissionCacheService = permissionCacheService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            try
            {
                var plans = await _planService.GetAllPlansAsync();
                return Ok(plans); // Return plain array
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load plans");
                return BadRequest(new { message = "Failed to load plans", error = ex.Message });
            }
        }

        [HttpGet("{planId}/permissions")]
        public async Task<IActionResult> GetPlanPermissions(Guid planId)
        {
            try
            {
               // var permissions = await _planService.GetPermissionsForPlanAsync(planId);
                var permissions = await _permissionCacheService.GetPlanPermissionsAsync(planId);

                return Ok(permissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load permissions for plan {PlanId}", planId);
                return BadRequest(new { message = "Failed to load permissions", error = ex.Message });
            }
        }

        [HttpPost("{planId}/permissions")]
        [Authorize(Roles = "superadmin,partneradmin")]
        public async Task<IActionResult> UpdatePlanPermissions(Guid planId, [FromBody] Guid[] permissionIds)
        {
            try
            {
                await _planService.UpdatePlanPermissionsAsync(planId, permissionIds.ToList());
                // ✅ Clear cache after update
                _permissionCacheService.ClearPlanPermissionsCache(planId);
                return Ok(new { message = "Permissions updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update permissions for plan {PlanId}", planId);
                return BadRequest(new { message = "Failed to update permissions", error = ex.Message });
            }
        }

        [HttpPost("Create")]
        [Authorize(Roles = "superadmin,partneradmin,admin")]
        public async Task<IActionResult> CreatePlan([FromBody] CreatePlanDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Code) || string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest(new { message = "Code and Name are required" });

            try
            {
                var newPlanId = await _planService.CreatePlanAsync(dto);
                return Ok(new { id = newPlanId, message = "Plan created successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create plan {PlanName}", dto.Name);
                return BadRequest(new { message = "Failed to create plan", error = ex.Message });
            }
        }

        [HttpPut("{planId}")]
        [Authorize(Roles = "superadmin,partneradmin,admin")]
        public async Task<IActionResult> UpdatePlan(Guid planId, [FromBody] UpdatePlanDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Code) || string.IsNullOrWhiteSpace(dto.Name))
                return BadRequest(new { message = "Code and Name are required" });

            try
            {
                var updated = await _planService.UpdatePlanAsync(planId, dto);
                if (!updated)
                    return NotFound(new { message = "Plan not found" });

                return Ok(new { message = "Plan updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update plan {PlanId}", planId);
                return BadRequest(new { message = "Failed to update plan", error = ex.Message });
            }
        }

        [HttpDelete("{planId}")]
        [Authorize(Roles = "superadmin,partneradmin")]
        public async Task<IActionResult> DeletePlan(Guid planId)
        {
            try
            {
                var deleted = await _planService.DeletePlanAsync(planId);
                if (!deleted)
                    return NotFound(new { message = "Plan not found or already inactive" });
                // ✅ Clear cache when plan is deleted
                _permissionCacheService.ClearPlanPermissionsCache(planId);
                return Ok(new { message = "Plan deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete plan {PlanId}", planId);
                return BadRequest(new { message = "Failed to delete plan", error = ex.Message });
            }
        }
        //[HttpGet("me/permissions")]
        //public async Task<IActionResult> GetMyPlanPermissions(CancellationToken ct)
        //{
        //    var role = User.FindFirst("role")?.Value ?? string.Empty;

        //    // Optional admin bypass
        //    if (role is "superadmin" or "admin" or "partner" or "reseller")
        //        return Ok(new { planId = (Guid?)null, permissions = new[] { "*" } });

        //    var planIdStr = User.FindFirst("plan_id")?.Value;
        //    if (!Guid.TryParse(planIdStr, out var planId))
        //        return Ok(new { planId = (Guid?)null, permissions = Array.Empty<string>() });

        //    var permissionEntities = await _permissionCacheService.GetPlanPermissionsAsync(planId);
        //    var codes = permissionEntities
        //        .Where(p => p.IsActive)
        //        .Select(p => p.Code)
        //        .Distinct()
        //        .ToList();

        //    return Ok(new { planId, permissions = codes });
        //}
        [HttpGet("me/permissions")]
        public async Task<IActionResult> GetMyPlanPermissions(CancellationToken ct)
        {
            var role = User.FindFirst("role")?.Value ?? string.Empty;

            // Admin-like roles don't need a plan
            if (role is "superadmin" or "admin" or "partner" or "reseller")
                return Ok(new
                {
                    planId = (Guid?)null,
                    plan = (PlanDto?)null,
                    permissions = new[] { "*" }
                });

            var planIdStr = User.FindFirst("plan_id")?.Value;
            if (!Guid.TryParse(planIdStr, out var planId))
                return Ok(new
                {
                    planId = (Guid?)null,
                    plan = (PlanDto?)null,
                    permissions = Array.Empty<string>()
                });

            // permissions (cached)
            var permissionEntities = await _permissionCacheService.GetPlanPermissionsAsync(planId);
            var codes = permissionEntities
                .Where(p => p.IsActive)
                .Select(p => p.Code)
                .Distinct()
                .ToList();

            // ✅ Fetch the plan once and return it as PlanDto
            var planDto = await _planService.GetByIdAsync(planId, ct);

            return Ok(new
            {
                planId,
                plan = planDto,     // PlanDto or null
                permissions = codes
            });
        }

    }
}
