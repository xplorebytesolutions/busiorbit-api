using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using xbytechat.api.AuthModule.Models;
using xbytechat.api.Features.AccessControl.Models;
using xbytechat.api.Repositories.Interfaces;
using System.Linq.Expressions;


namespace xbytechat.api.Features.AccessControl.Services
{
    public class AccessControlService : IAccessControlService
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<RolePermission> _rolePermissionRepo;
        private readonly IGenericRepository<UserPermission> _userPermissionRepo;
        private readonly IGenericRepository<Permission> _permissionRepo;

        public AccessControlService(
            IGenericRepository<User> userRepo,
            IGenericRepository<RolePermission> rolePermissionRepo,
            IGenericRepository<UserPermission> userPermissionRepo,
            IGenericRepository<Permission> permissionRepo
        )
        {
            _userRepo = userRepo;
            _rolePermissionRepo = rolePermissionRepo;
            _userPermissionRepo = userPermissionRepo;
            _permissionRepo = permissionRepo;
        }

        /// <summary>
        /// ✅ Fetch all permissions (Role-based + User-specific) for a given user
        /// </summary>
        public async Task<List<string>> GetPermissionsAsync(Guid userId)
        {
            var user = await _userRepo.FindByIdAsync(userId);
            if (user == null || user.RoleId == null)
                return new List<string>();

            // 🔐 Get Role-based permissions
            var rolePerms = await _rolePermissionRepo
                .WhereAsync(rp => rp.RoleId == user.RoleId && !rp.IsRevoked);

            // 🔐 Get User-specific extra permissions
            var userPerms = await _userPermissionRepo
                .WhereAsync(up => up.UserId == userId && !up.IsRevoked);

            // 🧠 Merge permission IDs
            var permissionIds = rolePerms.Select(r => r.PermissionId)
                .Union(userPerms.Select(u => u.PermissionId))
                .Distinct()
                .ToList();

            // 🎯 Get full permission names from Permission table
            var allPerms = await _permissionRepo
                .WhereAsync(p => permissionIds.Contains(p.Id));

            return allPerms.Select(p => p.Code).Distinct().ToList(); // Use Code (standard)
        }

        /// <summary>
        /// ✅ Runtime permission checker (for controller/middleware)
        /// </summary>
        public bool HasPermission(ClaimsPrincipal user, string requiredPermission)
        {
            var perms = user.Claims
                .Where(c => c.Type == "permissions")
                .Select(c => c.Value)
                .ToList();

            return perms.Contains(requiredPermission);
        }
    }
}
