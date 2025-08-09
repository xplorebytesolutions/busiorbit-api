﻿using System.Security.Cryptography;
using System.Text;
using xbytechat.api.AuthModule.DTOs;
using xbytechat.api.AuthModule.Models;
using xbytechat.api.Helpers;
using xbytechat.api.Repositories.Interfaces;
using xbytechat.api.Features.AccessControl.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using xbytechat.api.Features.BusinessModule.DTOs;
using xbytechat.api.Features.BusinessModule.Models;
using xbytechat.api.Features.BusinessModule.Services;
using xbytechat.api.Features.FeatureAccessModule.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Logging;

namespace xbytechat.api.AuthModule.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IBusinessService _businessService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IAccessControlService _accessControlService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AuthService> _logger;
        private readonly AppDbContext _dbContext;
        public AuthService(
            IGenericRepository<User> userRepo,
            IBusinessService businessService,
            IJwtTokenService jwtTokenService,
            IAccessControlService accessControlService,
            IHttpContextAccessor httpContextAccessor,
            ILogger<AuthService> logger,
            AppDbContext dbContext)
        {
            _userRepo = userRepo;
            _businessService = businessService;
            _jwtTokenService = jwtTokenService;
            _accessControlService = accessControlService;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _dbContext = dbContext;
        }

        // 🔑 Production-grade Login
        //public async Task<ResponseResult> LoginAsync(UserLoginDto dto)
        //{
        //    _logger.LogInformation("🔑 Login attempt for email: {Email}", dto.Email);
        //    var hashedPassword = HashPassword(dto.Password);

        //    var user = await _userRepo
        //        .AsQueryable()
        //        .Where(u => u.Email == dto.Email && u.PasswordHash == hashedPassword && !u.IsDeleted)
        //        .Include(u => u.Role)
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        _logger.LogWarning("❌ Login failed: Invalid email or password for {Email}", dto.Email);
        //        return ResponseResult.ErrorInfo("❌ Invalid email or password");
        //    }

        //    var roleName = user.Role?.Name?.Trim().ToLower() ?? "unknown";
        //    var isAdminType = roleName == "admin" || roleName == "superadmin" || roleName == "partner" || roleName == "reseller";
        //    _logger.LogInformation("User role detected: {Role} (AdminType: {IsAdminType})", roleName, isAdminType);

        //    if (user.BusinessId == null && !isAdminType)
        //    {
        //        _logger.LogWarning("❌ Login denied for {Email}: No BusinessId and not admin", dto.Email);
        //        return ResponseResult.ErrorInfo("❌ Your account approval is pending. Please contact your administrator or support.");
        //    }

        //    Business business = null;
        //    if (user.BusinessId != null)
        //    {
        //        business = await _businessService
        //            .Query()
        //            .Include(b => b.BusinessPlanInfo)
        //            .FirstOrDefaultAsync(b => b.Id == user.BusinessId.Value);

        //        if (business == null)
        //        {
        //            _logger.LogError("❌ Login error: Business not found for user {UserId}", user.Id);
        //            return ResponseResult.ErrorInfo("❌ Associated business not found.");
        //        }

        //        if (business.Status == Business.StatusType.Pending)
        //        {
        //            _logger.LogWarning("⏳ Login blocked: Business under review (BusinessId: {BusinessId})", business.Id);
        //            return ResponseResult.ErrorInfo("⏳ Your business is under review. Please wait for approval.");
        //        }
        //    }

        //    var permissions = await _accessControlService.GetPermissionsAsync(user.Id);

        //    string planName;
        //    string companyName;
        //    string businessId = user.BusinessId?.ToString() ?? "";

        //    if (isAdminType)
        //    {
        //        planName = roleName;
        //        companyName = "xByte Admin";
        //        businessId = "";
        //        _logger.LogInformation("Admin/superadmin login. Plan set as role: {Plan}", planName);
        //    }
        //    else
        //    {
        //        planName = business?.BusinessPlanInfo?.Plan.ToString() ?? "";
        //        companyName = business?.CompanyName ?? "";
        //        _logger.LogInformation("Business login. Plan: {Plan}, Company: {Company}", planName, companyName);
        //    }

        //    var claims = new List<Claim>
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        //        new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
        //        new Claim("name", user.Name ?? ""),
        //        new Claim(ClaimTypes.Role, roleName),
        //        new Claim("role", roleName),
        //        new Claim("status", user.Status ?? "unknown"),
        //        new Claim("plan", planName ?? ""),
        //        new Claim("businessId", businessId),
        //        new Claim("companyName", companyName ?? "")
        //    };

        //    if (permissions?.Any() == true)
        //    {
        //        claims.AddRange(permissions.Select(p => new Claim("perm", p)));
        //    }

        //    var token = _jwtTokenService.GenerateToken(claims);

        //    var userDto = new UserDto
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Email = user.Email,
        //        Role = roleName,
        //        Status = user.Status,
        //        CreatedAt = user.CreatedAt,
        //        BusinessId = string.IsNullOrEmpty(businessId) ? Guid.Empty : Guid.Parse(businessId),
        //        CompanyName = companyName,
        //        Plan = planName,
        //        AccessToken = null
        //    };

        //    _logger.LogInformation("✅ Login successful for {Email}, Role: {Role}, Plan: {Plan}", dto.Email, roleName, planName);

        //    return new ResponseResult
        //    {
        //        Success = true,
        //        Message = "✅ Login successful",
        //        Data = userDto,
        //        Token = token
        //    };
        //}

        // 🟢 Signup Business User

        //public async Task<ResponseResult> LoginAsync(UserLoginDto dto)
        //{
        //    _logger.LogInformation("🔑 Login attempt for email: {Email}", dto.Email);
        //    var hashedPassword = HashPassword(dto.Password);

        //    var user = await _userRepo
        //        .AsQueryable()
        //        .Where(u => u.Email == dto.Email && u.PasswordHash == hashedPassword && !u.IsDeleted)
        //        .Include(u => u.Role)
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        _logger.LogWarning("❌ Login failed: Invalid email or password for {Email}", dto.Email);
        //        return ResponseResult.ErrorInfo("❌ Invalid email or password");
        //    }

        //    var roleName = user.Role?.Name?.Trim().ToLower() ?? "unknown";
        //    var isAdminType = roleName == "admin" || roleName == "superadmin" || roleName == "partner" || roleName == "reseller";
        //    _logger.LogInformation("User role detected: {Role} (AdminType: {IsAdminType})", roleName, isAdminType);

        //    if (user.BusinessId == null && !isAdminType)
        //    {
        //        _logger.LogWarning("❌ Login denied for {Email}: No BusinessId and not admin", dto.Email);
        //        return ResponseResult.ErrorInfo("❌ Your account approval is pending. Please contact your administrator or support.");
        //    }

        //    Business business = null;
        //    if (user.BusinessId != null)
        //    {
        //        business = await _businessService
        //            .Query()
        //            .Include(b => b.BusinessPlanInfo)
        //            .FirstOrDefaultAsync(b => b.Id == user.BusinessId.Value);

        //        if (business == null)
        //        {
        //            _logger.LogError("❌ Login error: Business not found for user {UserId}", user.Id);
        //            return ResponseResult.ErrorInfo("❌ Associated business not found.");
        //        }

        //        if (business.Status == Business.StatusType.Pending)
        //        {
        //            _logger.LogWarning("⏳ Login blocked: Business under review (BusinessId: {BusinessId})", business.Id);
        //            return ResponseResult.ErrorInfo("⏳ Your business is under review. Please wait for approval.");
        //        }
        //    }

        //    var permissions = await _accessControlService.GetPermissionsAsync(user.Id);

        //    string planName;
        //    string companyName;
        //    string businessId = user.BusinessId?.ToString() ?? "";

        //    if (isAdminType)
        //    {
        //        planName = roleName; // 'superadmin', 'admin', etc.
        //        companyName = "xByte Admin";
        //        businessId = "";
        //        _logger.LogInformation("Admin/superadmin login. Plan set as role: {Plan}", planName);
        //    }
        //    else
        //    {
        //        planName = business?.BusinessPlanInfo?.Plan.ToString() ?? "";
        //        companyName = business?.CompanyName ?? "";
        //        _logger.LogInformation("Business login. Plan: {Plan}, Company: {Company}", planName, companyName);
        //    }

        //    // ✅ Generate token with full claims
        //    var token = _jwtTokenService.GenerateToken(
        //        user.Id.ToString(),
        //        roleName,
        //        user.Name ?? "",
        //        user.Email ?? "",
        //        user.Status ?? "unknown",
        //        businessId,
        //        companyName,
        //        planName,
        //        permissions ?? new List<string>()
        //    );

        //    // ✅ User info for frontend
        //    var userDto = new UserDto
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Email = user.Email,
        //        Role = roleName,
        //        Status = user.Status,
        //        CreatedAt = user.CreatedAt,
        //        BusinessId = string.IsNullOrEmpty(businessId) ? Guid.Empty : Guid.Parse(businessId),
        //        CompanyName = companyName,
        //        Plan = planName,
        //        AccessToken = null
        //    };

        //    _logger.LogInformation("✅ Login successful for {Email}, Role: {Role}, Plan: {Plan}", dto.Email, roleName, planName);

        //    return new ResponseResult
        //    {
        //        Success = true,
        //        Message = "✅ Login successful",
        //        Data = userDto,
        //        Token = token
        //    };
        //}
        //public async Task<ResponseResult> LoginAsync(UserLoginDto dto)
        //{
        //    _logger.LogInformation("🔑 Login attempt for email: {Email}", dto.Email);
        //    var hashedPassword = HashPassword(dto.Password);

        //    var user = await _userRepo
        //        .AsQueryable()
        //        .Where(u => u.Email == dto.Email && u.PasswordHash == hashedPassword && !u.IsDeleted)
        //        .Include(u => u.Role)
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        _logger.LogWarning("❌ Login failed: Invalid email or password for {Email}", dto.Email);
        //        return ResponseResult.ErrorInfo("❌ Invalid email or password");
        //    }

        //    var roleName = user.Role?.Name?.Trim().ToLower() ?? "unknown";
        //    var isAdminType = roleName == "admin" || roleName == "superadmin" || roleName == "partner" || roleName == "reseller";
        //    _logger.LogInformation("User role detected: {Role} (AdminType: {IsAdminType})", roleName, isAdminType);

        //    if (user.BusinessId == null && !isAdminType)
        //    {
        //        _logger.LogWarning("❌ Login denied for {Email}: No BusinessId and not admin", dto.Email);
        //        return ResponseResult.ErrorInfo("❌ Your account approval is pending. Please contact your administrator or support.");
        //    }

        //    Business business = null;
        //    if (user.BusinessId != null)
        //    {
        //        business = await _businessService
        //            .Query()
        //            .Include(b => b.BusinessPlanInfo)
        //            .FirstOrDefaultAsync(b => b.Id == user.BusinessId.Value);

        //        if (business == null)
        //        {
        //            _logger.LogError("❌ Login error: Business not found for user {UserId}", user.Id);
        //            return ResponseResult.ErrorInfo("❌ Associated business not found.");
        //        }

        //        if (business.Status == Business.StatusType.Pending)
        //        {
        //            _logger.LogWarning("⏳ Login blocked: Business under review (BusinessId: {BusinessId})", business.Id);
        //            return ResponseResult.ErrorInfo("⏳ Your business is under review. Please wait for approval.");
        //        }
        //    }

        //    var permissions = await _accessControlService.GetPermissionsAsync(user.Id);

        //    string planName;
        //    string companyName;
        //    string businessId = user.BusinessId?.ToString() ?? "";

        //    if (isAdminType)
        //    {
        //        planName = roleName; // 'superadmin', 'admin', etc.
        //        companyName = "xByte Admin";
        //        businessId = "";
        //        _logger.LogInformation("Admin/superadmin login. Plan set as role: {Plan}", planName);
        //    }
        //    else
        //    {
        //        planName = business?.BusinessPlanInfo?.Plan.ToString() ?? "";
        //        companyName = business?.CompanyName ?? "";
        //        _logger.LogInformation("Business login. Plan: {Plan}, Company: {Company}", planName, companyName);
        //    }

        //    // ✅ Generate token with full claims
        //    var token = _jwtTokenService.GenerateToken(
        //        user.Id.ToString(),
        //        roleName,
        //        user.Name ?? "",
        //        user.Email ?? "",
        //        user.Status ?? "unknown",
        //        businessId,
        //        companyName,
        //        planName,
        //        permissions ?? new List<string>()
        //    );

        //    // ✅ Store token in secure HttpOnly cookie
        //    _httpContextAccessor.HttpContext.Response.Cookies.Append("xbyte_token", token, new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Secure = true, // Set to false only for localhost if needed
        //        SameSite = SameSiteMode.Lax,
        //        Expires = DateTime.UtcNow.AddDays(7)
        //    });

        //    // ✅ User info for frontend
        //    var userDto = new UserDto
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Email = user.Email,
        //        Role = roleName,
        //        Status = user.Status,
        //        CreatedAt = user.CreatedAt,
        //        BusinessId = string.IsNullOrEmpty(businessId) ? Guid.Empty : Guid.Parse(businessId),
        //        CompanyName = companyName,
        //        Plan = planName,
        //        AccessToken = null
        //    };

        //    _logger.LogInformation("✅ Login successful for {Email}, Role: {Role}, Plan: {Plan}", dto.Email, roleName, planName);

        //    return new ResponseResult
        //    {
        //        Success = true,
        //        Message = "✅ Login successful",
        //        Data = userDto,
        //        Token = token
        //    };
        //}

        #region // Below Code comeneted to replace cokkies to bearer

        //public async Task<ResponseResult> LoginAsync(UserLoginDto dto)
        //{
        //    _logger.LogInformation("🔑 Login attempt for email: {Email}", dto.Email);
        //    var hashedPassword = HashPassword(dto.Password);

        //    var user = await _userRepo
        //        .AsQueryable()
        //        .Where(u => u.Email == dto.Email && u.PasswordHash == hashedPassword && !u.IsDeleted)
        //        .Include(u => u.Role)
        //        .FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        _logger.LogWarning("❌ Login failed: Invalid email or password for {Email}", dto.Email);
        //        return ResponseResult.ErrorInfo("❌ Invalid email or password");
        //    }

        //    var roleName = user.Role?.Name?.Trim().ToLower() ?? "unknown";
        //    var isAdminType = roleName == "admin" || roleName == "superadmin" || roleName == "partner" || roleName == "reseller";

        //    if (user.BusinessId == null && !isAdminType)
        //    {
        //        _logger.LogWarning("❌ Login denied for {Email}: No BusinessId and not admin", dto.Email);
        //        return ResponseResult.ErrorInfo("❌ Your account approval is pending. Please contact your administrator or support.");
        //    }

        //    Business business = null;
        //    if (user.BusinessId != null)
        //    {
        //        business = await _businessService.Query()
        //            .Include(b => b.BusinessPlanInfo)
        //            .FirstOrDefaultAsync(b => b.Id == user.BusinessId.Value);

        //        if (business == null)
        //        {
        //            _logger.LogError("❌ Login error: Business not found for user {UserId}", user.Id);
        //            return ResponseResult.ErrorInfo("❌ Associated business not found.");
        //        }

        //        if (business.Status == Business.StatusType.Pending)
        //        {
        //            _logger.LogWarning("⏳ Login blocked: Business under review (BusinessId: {BusinessId})", business.Id);
        //            return ResponseResult.ErrorInfo("⏳ Your business is under review. Please wait for approval.");
        //        }
        //    }

        //    var permissions = await _accessControlService.GetPermissionsAsync(user.Id);

        //    string planName;
        //    string companyName;
        //    string businessId = user.BusinessId?.ToString() ?? "";

        //    if (isAdminType)
        //    {
        //        planName = roleName; // e.g., 'superadmin'
        //        companyName = "xByte Admin";
        //        businessId = ""; // Admins are not tied to a business
        //    }
        //    else
        //    {
        //        planName = business?.BusinessPlanInfo?.Plan.ToString() ?? "";
        //        companyName = business?.CompanyName ?? "";
        //    }

        //    // ✅ Generate JWT with lowercase claim keys
        //    var token = _jwtTokenService.GenerateToken(
        //        user.Id.ToString(),
        //        roleName,
        //        user.Name ?? "",
        //        user.Email ?? "",
        //        user.Status ?? "unknown",
        //        businessId,
        //        companyName,
        //        planName,
        //        permissions ?? new List<string>()
        //    );

        //    // ✅ Store token securely as cookie (must match JwtBearer event)
        //    _httpContextAccessor.HttpContext.Response.Cookies.Append("xbyte_token", token, 

        //        new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Secure = true,
        //       // SameSite = SameSiteMode.Strict,
        //        SameSite = SameSiteMode.None,
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        Domain = "http://localhost:3000"
        //    });

        //    // ✅ Build user info for frontend
        //    var userDto = new UserDto
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Email = user.Email,
        //        Role = roleName,
        //        Status = user.Status,
        //        CreatedAt = user.CreatedAt,
        //        BusinessId = string.IsNullOrEmpty(businessId) ? Guid.Empty : Guid.Parse(businessId),
        //        CompanyName = companyName,
        //        Plan = planName,
        //        AccessToken = null // Not needed since we're using secure cookie
        //    };

        //    _logger.LogInformation("✅ Login successful for {Email}, Role: {Role}, Plan: {Plan}", dto.Email, roleName, planName);

        //    return new ResponseResult
        //    {
        //        Success = true,
        //        Message = "✅ Login successful",
        //        Data = userDto,
        //        Token = token
        //    };
        //}

        #endregion

        public async Task<ResponseResult> LoginAsync(UserLoginDto dto)
        {
            _logger.LogInformation("🔑 Login attempt for email: {Email}", dto.Email);
            var hashedPassword = HashPassword(dto.Password);

            var user = await _userRepo
                .AsQueryable()
                .Where(u => u.Email == dto.Email && u.PasswordHash == hashedPassword && !u.IsDeleted)
                .Include(u => u.Role)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                _logger.LogWarning("❌ Login failed: Invalid email or password for {Email}", dto.Email);
                return ResponseResult.ErrorInfo("❌ Invalid email or password");
            }

            var roleName = user.Role?.Name?.Trim().ToLower() ?? "unknown";
            var isAdminType = roleName is "admin" or "superadmin" or "partner" or "reseller";

            if (user.BusinessId == null && !isAdminType)
            {
                _logger.LogWarning("❌ Login denied for {Email}: No BusinessId and not admin", dto.Email);
                return ResponseResult.ErrorInfo("❌ Your account approval is pending. Please contact your administrator or support.");
            }

            Business? business = null;
            if (user.BusinessId != null)
            {
                business = await _businessService.Query()
                    .Include(b => b.BusinessPlanInfo)
                    .FirstOrDefaultAsync(b => b.Id == user.BusinessId.Value);

                if (business == null)
                    return ResponseResult.ErrorInfo("❌ Associated business not found.");

                if (business.Status == Business.StatusType.Pending)
                    return ResponseResult.ErrorInfo("⏳ Your business is under review. Please wait for approval.");
            }

            var permissions = await _accessControlService.GetPermissionsAsync(user.Id);

            string planName;
            string companyName;
            string businessId = user.BusinessId?.ToString() ?? "";

            if (isAdminType)
            {
                planName = roleName;        // admin types treated as plan in UI
                companyName = "xByte Admin";
                businessId = "";
            }
            else
            {
                planName = business?.BusinessPlanInfo?.Plan.ToString() ?? "basic";
                companyName = business?.CompanyName ?? "";
            }

            // ✅ Generate JWT (includes role/plan/biz + ClaimTypes.Role)
            var token = _jwtTokenService.GenerateToken(
                user.Id.ToString(),
                roleName,
                user.Name ?? "",
                user.Email ?? "",
                user.Status ?? "unknown",
                businessId,
                companyName,
                planName,
                permissions ?? new List<string>()
            );

            // ❌ NO cookie writes in Bearer mode

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = roleName,
                Status = user.Status,
                CreatedAt = user.CreatedAt,
                BusinessId = string.IsNullOrEmpty(businessId) ? Guid.Empty : Guid.Parse(businessId),
                CompanyName = companyName,
                Plan = planName,
                AccessToken = null
            };

            _logger.LogInformation("✅ Login successful for {Email}, Role: {Role}, Plan: {Plan}", dto.Email, roleName, planName);

            return new ResponseResult
            {
                Success = true,
                Message = "✅ Login successful",
                Data = userDto,
                Token = token
            };
        }

        public async Task<ResponseResult> SignupAsync(SignupBusinessDto dto)
        {
            _logger.LogInformation("🟢 Signup attempt: {Email}", dto.Email);
            var result = await _businessService.SignupBusinessAsync(dto);

            if (!result.Success)
            {
                _logger.LogWarning("❌ Signup failed for {Email}: {Msg}", dto.Email, result.Message);
                return ResponseResult.ErrorInfo(result.Message);
            }

            var business = await _businessService.GetBusinessByEmailAsync(dto.Email);

            if (business == null)
            {
                _logger.LogError("❌ Signup succeeded but business retrieval failed for {Email}", dto.Email);
                return ResponseResult.ErrorInfo("❌ Signup succeeded but business retrieval failed.");
            }

            try
            {
                // 🆕 Set BusinessAssignedTo if available
                if (dto.CreatedByPartnerId.HasValue && business.CreatedByPartnerId == null)
                {
                    business.CreatedByPartnerId = dto.CreatedByPartnerId;
                    await _businessService.UpdateBusinessAsync(business);
                    _logger.LogInformation("✅ Partner assigned during signup: {PartnerId} for Business: {BusinessId}", dto.CreatedByPartnerId, business.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Signup succeeded but assigning partner failed for {Email}", dto.Email);
                return ResponseResult.ErrorInfo("❌ Signup succeeded but assigning partner failed: " + ex.Message);
            }

            _logger.LogInformation("✅ Signup successful for {Email} (BusinessId: {BusinessId})", dto.Email, business.Id);
            return ResponseResult.SuccessInfo("✅ Signup successful. Pending approval.", new { BusinessId = business.Id });
        }

        // 🔄 Refresh JWT Token (and Rotate)
        public async Task<ResponseResult> RefreshTokenAsync(string refreshToken)
        {
            _logger.LogInformation("🔄 RefreshToken attempt");

            var user = await _userRepo
                .AsQueryable()
                .Include(u => u.Role)
                .Include(u => u.Business)
                    .ThenInclude(b => b.BusinessPlanInfo)
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && u.RefreshTokenExpiry > DateTime.UtcNow);

            if (user == null)
            {
                _logger.LogWarning("❌ Invalid or expired refresh token.");
                return ResponseResult.ErrorInfo("❌ Invalid or expired refresh token.");
            }

            var permissions = await _accessControlService.GetPermissionsAsync(user.Id);
            var roleName = user.Role?.Name?.Trim().ToLower() ?? "unknown";
            var isAdminType = roleName == "superadmin" || roleName == "partner" || roleName == "reseller";

            string planName;
            string companyName;
            string businessId = user.BusinessId?.ToString() ?? "";

            if (isAdminType)
            {
                planName = roleName;
                companyName = "xByte Admin";
                businessId = "";
            }
            else
            {
                planName = user.Business?.BusinessPlanInfo?.Plan.ToString() ?? "";
                companyName = user.Business?.CompanyName ?? "";
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new Claim("name", user.Name ?? ""),
                new Claim(ClaimTypes.Role, roleName),
                new Claim("role", roleName),
                new Claim("status", user.Status ?? "unknown"),
                new Claim("plan", planName ?? ""),
                new Claim("businessId", businessId),
                new Claim("companyName", companyName ?? "")
            };

            if (permissions?.Any() == true)
            {
                claims.AddRange(permissions.Select(p => new Claim("perm", p)));
            }

            var token = _jwtTokenService.GenerateToken(claims);

            // 🔁 Rotate refresh token
            var newRefreshToken = Guid.NewGuid().ToString("N");
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(30);
            _userRepo.Update(user);

            _logger.LogInformation("🔄 Token refreshed for user {UserId}, role {Role}", user.Id, roleName);

            return ResponseResult.SuccessInfo("🔄 Token refreshed", new
            {
                accessToken = token,
                refreshToken = newRefreshToken
            });
        }

        // 🔁 Resend confirmation
        public async Task<ResponseResult> ResendConfirmationAsync(ResendConfirmationDto dto)
        {
            _logger.LogInformation("🔁 Resend confirmation attempt for {Email}", dto.Email);
            var business = await _businessService.GetBusinessByEmailAsync(dto.Email);
            if (business == null)
            {
                _logger.LogWarning("❌ Resend confirmation failed: No business for {Email}", dto.Email);
                return ResponseResult.ErrorInfo("❌ No business registered with this email");
            }

            _logger.LogInformation("✅ Resend confirmation request processed for {Email}", dto.Email);
            return ResponseResult.SuccessInfo("📨 Confirmation request resent.");
        }
        public async Task<FeatureAccessDto> GetFeatureAccessForUserAsync(ClaimsPrincipal user)
        {
            var role = user.FindFirstValue("role")?.ToLower();
            var dto = new FeatureAccessDto();

            if (role == "superadmin")
            {
                // Grant all known frontend features
                dto.Features = await _dbContext.FeatureAccess
                    .Select(f => f.FeatureName)
                    .Distinct()
                    .ToDictionaryAsync(name => name, name => true);

                return dto;
            }

            var plan = user.FindFirstValue("plan")?.ToLower();
            var businessIdStr = user.FindFirstValue("businessId");

            if (!Guid.TryParse(businessIdStr, out var businessId))
                return dto;

            // Plan-level or per-business override
            var features = await _dbContext.FeatureAccess
                .Where(f => f.BusinessId == businessId || f.Plan.ToLower() == plan)
                .ToListAsync();

            foreach (var feature in features)
            {
                dto.Features[feature.FeatureName] = feature.IsEnabled;
            }

            return dto;
        }

        // 🔒 Reset password
        public async Task<ResponseResult> ResetPasswordAsync(ResetPasswordDto dto)
        {
            _logger.LogInformation("🔒 Reset password attempt for {Email}", dto.Email);
            var user = await _userRepo.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
            {
                _logger.LogWarning("❌ Reset password failed: No user for {Email}", dto.Email);
                return ResponseResult.ErrorInfo("❌ No user found with this email");
            }

            user.PasswordHash = HashPassword(dto.NewPassword);
            _userRepo.Update(user);

            _logger.LogInformation("✅ Password reset successfully for {Email}", dto.Email);
            return ResponseResult.SuccessInfo("✅ Password reset successfully");
        }

        // Utility: Hash password using SHA256
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
