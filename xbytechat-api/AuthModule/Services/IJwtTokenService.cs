using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;

namespace xbytechat.api.AuthModule.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(
            string userId,
            string role,
            string userName,
            string email,
            string status,
            string businessId,
            string companyName,
            string plan,
            List<string> permissions
        );
        string GenerateToken(IEnumerable<Claim> claims);
        TokenValidationParameters GetValidationParameters(); // ✅ For Middleware validation
    }
}

