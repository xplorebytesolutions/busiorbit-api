using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using xbytechat.api.AuthModule.DTOs;
using xbytechat.api.AuthModule.Services;
using xbytechat.api.Features.BusinessModule.DTOs;

namespace xbytechat.api.AuthModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // ✅ Login → return { token } (NO cookies)
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (!result.Success || string.IsNullOrWhiteSpace(result.Token))
                return Unauthorized(new { success = false, message = result.Message });

            return Ok(new { token = result.Token });
        }

        // (Optional) Refresh token endpoint if you still issue refresh tokens.
        // Returns tokens in body (NO cookies).
        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var result = await _authService.RefreshTokenAsync(request.RefreshToken);
            if (!result.Success) return Unauthorized(new { success = false, message = result.Message });

            dynamic data = result.Data!;
            return Ok(new
            {
                accessToken = data.accessToken,
                refreshToken = data.refreshToken
            });
        }
        // ✅ Signup
        [HttpPost("business-user-signup")]
        public async Task<IActionResult> Signup([FromBody] SignupBusinessDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new
                {
                    success = false,
                    message = "❌ Validation failed.",
                    errors
                });
            }

            var result = await _authService.SignupAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        // ✅ Logout (stateless JWT): nothing server-side to do
        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout() => Ok(new { success = true, message = "Logged out" });

        // ✅ (Optional) lightweight session echo from claims (works with Bearer)
        [Authorize]
        [HttpGet("session")]
        public IActionResult GetSession()
        {
            var user = HttpContext.User;
            if (user?.Identity is not { IsAuthenticated: true }) return BadRequest("Invalid session");

            var email = user.FindFirst(ClaimTypes.Email)?.Value ?? "unknown";
            var role = user.FindFirst(ClaimTypes.Role)?.Value
                       ?? user.FindFirst("role")?.Value
                       ?? "unknown";
            var plan = user.FindFirst("plan")?.Value ?? "basic";
            var biz = user.FindFirst("businessId")?.Value;

            return Ok(new { isAuthenticated = true, role, email, plan, businessId = biz });
        }
    }
}


//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using xbytechat.api.AuthModule.DTOs;
//using xbytechat.api.AuthModule.Services;
//using xbytechat.api.Features.BusinessModule.DTOs;
//using System.Security.Claims;
//using xbytechat.api.Helpers;
//using xbytechat.api.Features.FeatureAccessModule.Services;
//using xbytechat.api.Features.FeatureAccess;
//namespace xbytechat.api.AuthModule.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly IAuthService _authService;
//        private readonly IFeatureAccessService _featureAccessService;
//        public AuthController(IAuthService authService, IFeatureAccessService featureAccessService)
//        {
//            _authService = authService;
//            _featureAccessService = featureAccessService;
//        }

//        // ✅ Login
//        [AllowAnonymous]
//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
//        {
//            var result = await _authService.LoginAsync(dto);

//            if (!result.Success || string.IsNullOrWhiteSpace(result.Token))
//                return Unauthorized(result);

//            JwtCookieHelper.SetJwtCookie(HttpContext, "xbyte_token", result.Token);

//            if (!string.IsNullOrEmpty(result.RefreshToken))
//            {
//                JwtCookieHelper.SetRefreshTokenCookie(HttpContext, "xbyte_refresh", result.RefreshToken);
//            }

//            return Ok(new
//            {
//                success = true,
//                message = result.Message,
//                data = result.Data
//            });
//        }

//        // ✅ Refresh Token
//        // ✅ Refresh Token with cookie update
//        [AllowAnonymous]
//        [HttpPost("refresh-token")]
//        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
//        {
//            var result = await _authService.RefreshTokenAsync(request.RefreshToken);

//            if (!result.Success)
//                return Unauthorized(result);

//            dynamic data = result.Data;
//            var newAccessToken = data?.accessToken?.ToString();
//            var newRefreshToken = data?.refreshToken?.ToString();

//            // ✅ Set new JWT token in cookie
//            if (!string.IsNullOrEmpty(newAccessToken))
//                JwtCookieHelper.SetJwtCookie(HttpContext, "xbyte_token", newAccessToken);

//            // ✅ Set new refresh token in cookie (rotated)
//            if (!string.IsNullOrEmpty(newRefreshToken))
//                JwtCookieHelper.SetRefreshTokenCookie(HttpContext, "xbyte_refresh", newRefreshToken);

//            return Ok(new
//            {
//                success = true,
//                message = result.Message
//            });
//        }

//        // ✅ Logout
//        [HttpPost("logout")]
//        public IActionResult Logout()
//        {
//            JwtCookieHelper.ClearJwtCookie(HttpContext, "xbyte_token");
//            return Ok(new
//            {
//                success = true,
//                message = "🚪 Logged out successfully"
//            });
//        }

//        // ✅ Signup
//        [HttpPost("business-user-signup")]
//        public async Task<IActionResult> Signup([FromBody] SignupBusinessDto dto)
//        {
//            if (!ModelState.IsValid)
//            {
//                var errors = ModelState.Values
//                    .SelectMany(v => v.Errors)
//                    .Select(e => e.ErrorMessage)
//                    .ToList();

//                return BadRequest(new
//                {
//                    success = false,
//                    message = "❌ Validation failed.",
//                    errors
//                });
//            }

//            var result = await _authService.SignupAsync(dto);
//            return result.Success ? Ok(result) : BadRequest(result);
//        }

//        // 🔁 Resend confirmation
//        [HttpPost("resend-confirmation")]
//        public async Task<IActionResult> ResendConfirmation([FromBody] ResendConfirmationDto dto)
//        {
//            var result = await _authService.ResendConfirmationAsync(dto);
//            return result.Success ? Ok(result) : BadRequest(result);
//        }

//        // 🔐 Reset password
//        [HttpPost("reset-password")]
//        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
//        {
//            var result = await _authService.ResetPasswordAsync(dto);
//            return result.Success ? Ok(result) : BadRequest(result);
//        }
//        [Authorize]
//        [HttpGet("features")]
//        public async Task<IActionResult> GetFeatureAccess()
//        {
//            var result = await _authService.GetFeatureAccessForUserAsync(User);
//            return Ok(result.Features);
//        }
//        // ✅ Session Info
//        [Authorize]
//        [HttpGet("session")]
//        public IActionResult GetSession()
//        {
//            var identity = HttpContext.User.Identity as ClaimsIdentity;
//            if (identity == null || !identity.IsAuthenticated)
//                return BadRequest("Invalid session");

//            var email = identity.FindFirst(ClaimTypes.Email)?.Value ?? "unknown";
//            var role = identity.FindFirst(ClaimTypes.Role)?.Value ?? "unknown";
//            var plan = identity.FindFirst("Plan")?.Value ?? "basic";

//            return Ok(new
//            {
//                isAuthenticated = true,
//                role = role,
//                email = email,
//                plan = plan
//            });
//        }


//    }
//    public static class ClaimsPrincipalExtensions
//    {
//        public static string FindFirstValue(this ClaimsPrincipal user, string claimType)
//        {
//            return user?.FindFirst(claimType)?.Value ?? "";
//        }
//    }
//}
