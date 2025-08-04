using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using xbytechat.api.Features.FeatureAccess.DTOs;
using xbytechat.api.Features.FeatureAccessModule.DTOs;
using xbytechat.api.Features.FeatureAccessModule.Services;
using xbytechat.api.Shared;
using System;

namespace xbytechat.api.Features.FeatureAccessModule.Controllers
{
    [ApiController]
    [Route("api/feature-access")]
    public class FeatureAccessController : ControllerBase
    {
        private readonly IFeatureAccessService _featureAccessService;
        private readonly IFeatureAccessEvaluator _accessEvaluator;
        private readonly ILogger<FeatureAccessController> _logger;

        public FeatureAccessController(
            IFeatureAccessService featureAccessService,
            IFeatureAccessEvaluator accessEvaluator,
            ILogger<FeatureAccessController> logger)
        {
            _featureAccessService = featureAccessService;
            _accessEvaluator = accessEvaluator;
            _logger = logger;
        }

        [Authorize(Roles = "superadmin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeatureAccessDto>>> GetAll()
        {
            var result = await _featureAccessService.GetAllAsync();
            return Ok(result);
        }

        [Authorize(Roles = "superadmin")]
        [HttpGet("business/{businessId}")]
        public async Task<ActionResult<IEnumerable<FeatureAccessDto>>> GetByBusinessId(Guid businessId)
        {
            var result = await _featureAccessService.GetByBusinessIdAsync(businessId);
            return Ok(result);
        }

        [Authorize(Roles = "superadmin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<FeatureAccessDto>> Get(Guid id)
        {
            var item = await _featureAccessService.GetAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<ActionResult<FeatureAccessDto>> Create(FeatureAccessDto dto)
        {
            var created = await _featureAccessService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [Authorize(Roles = "superadmin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<FeatureAccessDto>> Update(Guid id, FeatureAccessDto dto)
        {
            var updated = await _featureAccessService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [Authorize(Roles = "superadmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _featureAccessService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }

        // ✅ Unified endpoint for both SuperAdmin and Business users
        // Accepts businessId as optional (route or query)
        [Authorize]
        [HttpGet("available/{businessId?}")]
        public async Task<ActionResult<Dictionary<string, bool>>> GetAvailableFeatures(string businessId = null)
        {
            try
            {
                var role = User.FindFirst("role")?.Value?.ToLowerInvariant() ?? "";
                var result = new Dictionary<string, bool>();
                var allFeatures = new[] { "CRM", "Campaigns", "Catalog", "CatalogInsights", "AdminPanel", "FlowBuilder", "Messaging", "FlowInsights", "CTAFlow", "CRMInsights" };

                _logger.LogInformation("🔍 Feature access check - Role: {Role}, BusinessId: {BusinessId}", role, businessId);

                // ✅ Superadmin: Full access to all features
                if (role == "superadmin")
                {
                    foreach (var feature in allFeatures)
                        result[feature] = true;

                    _logger.LogInformation("Superadmin detected. All features enabled.");
                    return Ok(result);
                }

                // ✅ Business: Must have valid businessId, else 400
                if (role == "business")
                {
                    if (string.IsNullOrWhiteSpace(businessId) || !Guid.TryParse(businessId, out var parsedBusinessId))
                    {
                        _logger.LogWarning("Feature access attempted with missing or invalid businessId by business user.");
                        return BadRequest("Valid businessId is required for business users.");
                    }

                    foreach (var feature in allFeatures)
                    {
                        bool isAllowed = await _accessEvaluator.CanUseAsync(parsedBusinessId, feature);
                        result[feature] = isAllowed;
                    }

                    _logger.LogInformation("Feature set calculated for businessId={BusinessId}", businessId);
                    return Ok(result);
                }

                // ❌ Unknown/unsupported role
                _logger.LogWarning("Access attempt with unsupported role: {Role}", role);
                return Forbid("Role not permitted.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "🔥 Error in GetAvailableFeatures for businessId={BusinessId}", businessId);
                return StatusCode(500, "Feature access calculation failed.");
            }
        }

        [Authorize]
        [HttpGet("feature-toggle-view")]
        public async Task<IActionResult> GetToggleView()
        {
            try
            {
                Guid businessId;
                try
                {
                    businessId = User.GetBusinessId();
                }
                catch (UnauthorizedAccessException ex)
                {
                    return Unauthorized(ex.Message);
                }

                var plan = User.FindFirst("plan")?.Value ?? "";
                var features = await _featureAccessService.GetToggleViewAsync(businessId, plan);

                return Ok(new
                {
                    success = true,
                    data = features
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "🔥 Error in GetToggleView");
                return StatusCode(500, "Failed to fetch feature toggle view.");
            }
        }

        [Authorize]
        [HttpPatch("{featureCode}")]
        public async Task<IActionResult> ToggleFeatureAccess(string featureCode, [FromBody] FeatureTogglePatchDto dto)
        {
            try
            {
                var businessId = User.GetBusinessId();
                await _featureAccessService.ToggleFeatureAsync(businessId, featureCode, dto.IsEnabled);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "🔥 Error toggling feature access for code={FeatureCode}", featureCode);
                return StatusCode(500, "Failed to toggle feature.");
            }
        }

        [Authorize]
        [HttpGet("user-permissions")]
        public async Task<IActionResult> GetAllUserPermissions()
        {
            try
            {
                var businessId = User.GetBusinessId();
                var users = await _featureAccessService.GetAllUserPermissionsAsync(businessId);
                return Ok(new { success = true, data = users });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "🔥 Error fetching user permissions");
                return StatusCode(500, "Failed to fetch user permissions.");
            }
        }

        // ✅ Used by frontend guards like <FeatureGuard>
        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<List<FeatureStatusDto>>> GetMyFeatures()
        {
            try
            {
                //var businessIdStr = User.FindFirst("BusinessId")?.Value;
                //if (!Guid.TryParse(businessIdStr, out var businessId))
                //    return Unauthorized("BusinessId not found");
                var businessIdStr = User.Claims.FirstOrDefault(c => c.Type.Equals("businessId", StringComparison.OrdinalIgnoreCase))?.Value;
                if (!Guid.TryParse(businessIdStr, out var businessId))
                {
                    return Unauthorized();
                }

                var features = await _featureAccessService.GetFeaturesForCurrentUserAsync(businessId);
                foreach (var claim in User.Claims)
                {
                    Console.WriteLine($"[{claim.Type}] = {claim.Value}");
                }

                return Ok(features);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "🔥 Error fetching current user's features");
                return StatusCode(500, "Failed to fetch features.");
            }
        }
    }
}
