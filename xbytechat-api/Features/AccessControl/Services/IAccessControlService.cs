using System.Security.Claims;

namespace xbytechat.api.Features.AccessControl.Services
{
    public interface IAccessControlService
    {
        Task<List<string>> GetPermissionsAsync(Guid userId);
        bool HasPermission(ClaimsPrincipal user, string permission);
    }
}
