using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xbytechat.api.Features.AccessControl.Models;

namespace xbytechat.api.Features.AccessControl.Services
{
    public interface IPlanService
    {
        Task<Plan> CreatePlanAsync(string name, string description);
        Task AssignPermissionsAsync(Guid planId, List<Guid> permissionIds);
        Task<List<Permission>> GetPermissionsByPlanAsync(Guid planId);
        Task<List<Plan>> GetAllPlansAsync();
        Task<Plan?> GetPlanByIdAsync(Guid planId);
    }
}
