using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xbytechat.api.Features.AccessControl.Models;

namespace xbytechat.api.Features.AccessControl.Services
{
    public class PlanService : IPlanService
    {
        private readonly AppDbContext _context;

        public PlanService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Plan> CreatePlanAsync(string name, string description)
        {
            var plan = new Plan
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                CreatedAt = DateTime.UtcNow
            };

            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();
            return plan;
        }

        public async Task AssignPermissionsAsync(Guid planId, List<Guid> permissionIds)
        {
            var existing = await _context.PlanPermissions
                .Where(pp => pp.PlanId == planId)
                .ToListAsync();

            _context.PlanPermissions.RemoveRange(existing);

            var newLinks = permissionIds.Select(pid => new PlanPermission
            {
                Id = Guid.NewGuid(),
                PlanId = planId,
                PermissionId = pid,
                AssignedAt = DateTime.UtcNow
            });

            await _context.PlanPermissions.AddRangeAsync(newLinks);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Permission>> GetPermissionsByPlanAsync(Guid planId)
        {
            return await _context.PlanPermissions
                .Where(pp => pp.PlanId == planId)
                .Include(pp => pp.Permission)
                .Select(pp => pp.Permission)
                .ToListAsync();
        }

        public async Task<List<Plan>> GetAllPlansAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task<Plan?> GetPlanByIdAsync(Guid planId)
        {
            return await _context.Plans
                .Include(p => p.PlanPermissions)
                .ThenInclude(pp => pp.Permission)
                .FirstOrDefaultAsync(p => p.Id == planId);
        }
    }
}
