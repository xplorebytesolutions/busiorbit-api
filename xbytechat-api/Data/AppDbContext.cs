using Microsoft.EntityFrameworkCore;
using System.Globalization;
using xbytechat.api.CRM.Models;
using xbytechat.api.Features.Catalog.Models;
using xbytechat.api.Models.BusinessModel;
using xbytechat.api.Features.CampaignModule.Models;
using xbytechat.api.Features.CampaignTracking.Models;
using xbytechat.api.AuthModule.Models;
using xbytechat.api.Features.AccessControl.Models;
using xbytechat.api.Features.AccessControl.Seeder;
using xbytechat.api.Features.AuditTrail.Models;
using xbytechat.api.Features.xbTimelines.Models;
using xbytechat_api.WhatsAppSettings.Models;
using xbytechat.api.Features.CTAManagement.Models;
using xbytechat.api.Features.Tracking.Models;
using xbytechat.api.Features.MessageManagement.DTOs;
using xbytechat.api.Features.Webhooks.Models;
using xbytechat.api.Features.CTAFlowBuilder.Models;
using xbytechat.api.Features.Inbox.Models;
using xbytechat.api.Features.AutoReplyBuilder.Models;
using xbytechat.api.Features.AutoReplyBuilder.Flows.Models;
using xbytechat.api.Features.BusinessModule.Models;
using xbytechat.api.Features.FeatureAccessModule.Models;
using xbytechat.api.Features.PlanManagement.Models;
using xbytechat.api.Features.Automation.Models;
using xbytechat.api.Features.CampaignTracking.Worker;

namespace xbytechat.api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // ✅ Table Registrations
        public DbSet<Business> Businesses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MessageLog> MessageLogs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CatalogClickLog> CatalogClickLogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<LeadTimeline> LeadTimelines { get; set; }
        public DbSet<ContactTag> ContactTags { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignRecipient> CampaignRecipients { get; set; }
        public DbSet<CampaignSendLog> CampaignSendLogs { get; set; }
        public DbSet<MessageStatusLog> MessageStatusLogs { get; set; }

        // 🧩 Access Control
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<WhatsAppSettingEntity> WhatsAppSettings { get; set; }
        public DbSet<BusinessPlanInfo> BusinessPlanInfos { get; set; }

        public DbSet<TrackingLog> TrackingLogs { get; set; }
        public DbSet<CTADefinition> CTADefinitions { get; set; }
        public DbSet<CampaignButton> CampaignButtons { get; set; }
        public DbSet<FailedWebhookLog> FailedWebhookLogs { get; set; }
        public DbSet<WebhookSettings> WebhookSettings { get; set; }

        public DbSet<CTAFlowConfig> CTAFlowConfigs { get; set; }
        public DbSet<CTAFlowStep> CTAFlowSteps { get; set; }
        public DbSet<FlowButtonLink> FlowButtonLinks { get; set; }

        public DbSet<CampaignFlowOverride> CampaignFlowOverrides { get; set; }
        public DbSet<FlowExecutionLog> FlowExecutionLogs { get; set; }
        public DbSet<ContactRead> ContactReads { get; set; }

        public DbSet<AutoReplyRule> AutoReplyRules { get; set; }
        public DbSet<AutoReplyFlow> AutoReplyFlows { get; set; }
        public DbSet<AutoReplyFlowNode> AutoReplyFlowNodes { get; set; }
        public DbSet<AutoReplyFlowEdge> AutoReplyFlowEdges { get; set; }
        public DbSet<AutoReplyLog> AutoReplyLogs { get; set; }
        public DbSet<ChatSessionState> ChatSessionStates { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanPermission> PlanPermissions { get; set; }
        public DbSet<FeatureAccess> FeatureAccess { get; set; }
        public DbSet<PlanFeatureMatrix> PlanFeatureMatrix { get; set; }
        public DbSet<UserFeatureAccess> UserFeatureAccess { get; set; }
        public DbSet<FeatureMaster> FeatureMasters { get; set; }
        public DbSet<AutomationFlow> AutomationFlows { get; set; }
        public DbSet<WhatsAppTemplate> WhatsAppTemplates { get; set; }

        public DbSet<CampaignClickLog> CampaignClickLogs => Set<CampaignClickLog>();
        public DbSet<CampaignClickDailyAgg> CampaignClickDailyAgg => Set<CampaignClickDailyAgg>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Seed Role IDs (keep them consistent)
            var superadminRoleId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var partnerRoleId = Guid.Parse("00000000-0000-0000-0000-000000000002");
            var resellerRoleId = Guid.Parse("00000000-0000-0000-0000-000000000003");
            var businessRoleId = Guid.Parse("00000000-0000-0000-0000-000000000004");
            var agentRoleId = Guid.Parse("00000000-0000-0000-0000-000000000005");

            // ✅ Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = superadminRoleId, Name = "admin", Description = "Super Admin", CreatedAt = DateTime.UtcNow },
                new Role { Id = partnerRoleId, Name = "partner", Description = "Business Partner", CreatedAt = DateTime.UtcNow },
                new Role { Id = resellerRoleId, Name = "reseller", Description = "Reseller Partner", CreatedAt = DateTime.UtcNow },
                new Role { Id = businessRoleId, Name = "business", Description = "Business Owner", CreatedAt = DateTime.UtcNow },
                new Role { Id = agentRoleId, Name = "staff", Description = "Staff", CreatedAt = DateTime.UtcNow }
            );

            // ✅ Permissions from RolePermissionMapping
            var allPermissions = RolePermissionMapping.RolePermissions
                .SelectMany(p => p.Value)
                .Distinct()
                .ToList();

            var permissionEntities = allPermissions.Select((perm, index) => new Permission
            {
                Id = Guid.Parse($"30000000-0000-0000-0000-{index.ToString("D12", CultureInfo.InvariantCulture)}"),
                Name = perm,
                Code = perm,
                Description = $"Permission for {perm}",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();
            modelBuilder.Entity<Permission>().HasData(permissionEntities);

            // ✅ RolePermission mappings
            var permissionMap = permissionEntities.ToDictionary(p => p.Name, p => p.Id);
            var roleMap = new Dictionary<string, Guid>
            {
                ["admin"] = superadminRoleId,
                ["partner"] = partnerRoleId,
                ["reseller"] = resellerRoleId,
                ["business"] = businessRoleId,
                ["staff"] = agentRoleId
            };

            var rolePermissions = RolePermissionMapping.RolePermissions
                .SelectMany(rp => rp.Value.Select(permissionName => new RolePermission
                {
                    Id = Guid.NewGuid(),
                    RoleId = roleMap[rp.Key],
                    PermissionId = permissionMap[permissionName],
                    IsActive = true,
                    AssignedAt = DateTime.UtcNow
                }))
                .ToList();

            modelBuilder.Entity<RolePermission>().HasData(rolePermissions);

            // ========== 🧩 CORRECT RELATIONSHIPS ==========

            // Role ↔️ RolePermission (One-to-Many)
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Permission ↔️ RolePermission (One-to-Many)
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // User ↔️ UserPermission (One-to-Many)
            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPermissions)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Permission ↔️ UserPermission (One-to-Many)
            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.Permission)
                .WithMany(p => p.UserPermissions)
                .HasForeignKey(up => up.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // ========== (Rest of your model mappings below remain the same) ==========

            modelBuilder.Entity<CampaignSendLog>()
                .HasOne(s => s.MessageLog)
                .WithMany()
                .HasForeignKey(s => s.MessageLogId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeadTimeline>()
                .HasOne(t => t.Contact)
                .WithMany()
                .HasForeignKey(t => t.ContactId);

            modelBuilder.Entity<Campaign>()
                .HasOne(c => c.Business)
                .WithMany(b => b.Campaigns)
                .HasForeignKey(c => c.BusinessId)
                .IsRequired();

            modelBuilder.Entity<CampaignRecipient>()
                .HasOne(r => r.Campaign)
                .WithMany(c => c.Recipients)
                .HasForeignKey(r => r.CampaignId);

            modelBuilder.Entity<CampaignRecipient>()
                .HasOne(r => r.Contact)
                .WithMany()
                .HasForeignKey(r => r.ContactId);

            modelBuilder.Entity<CampaignRecipient>()
                .HasOne(r => r.Business)
                .WithMany()
                .HasForeignKey(r => r.BusinessId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CampaignSendLog>()
                .HasOne(s => s.Recipient)
                .WithMany(r => r.SendLogs)
                .HasForeignKey(s => s.RecipientId);

            modelBuilder.Entity<CampaignSendLog>()
                .HasOne(s => s.Contact)
                .WithMany()
                .HasForeignKey(s => s.ContactId);

            modelBuilder.Entity<CampaignSendLog>()
                .HasOne(s => s.Campaign)
                .WithMany(c => c.SendLogs)
                .HasForeignKey(s => s.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ContactTag>()
                .HasOne(ct => ct.Contact)
                .WithMany(c => c.ContactTags)
                .HasForeignKey(ct => ct.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ContactTag>()
                .HasOne(ct => ct.Tag)
                .WithMany(t => t.ContactTags)
                .HasForeignKey(ct => ct.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Campaign>()
                .HasMany(c => c.MultiButtons)
                .WithOne(b => b.Campaign)
                .HasForeignKey(b => b.CampaignId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MessageLog>()
                .HasOne(m => m.SourceCampaign)
                .WithMany(c => c.MessageLogs)
                .HasForeignKey(m => m.CampaignId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CampaignSendLog>()
                .Property(s => s.BusinessId)
                .IsRequired();

            modelBuilder.Entity<FlowButtonLink>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Business>()
                .HasOne(b => b.WhatsAppSettings)
                .WithOne()
                .HasForeignKey<WhatsAppSettingEntity>(s => s.BusinessId);

            modelBuilder.Entity<ContactRead>()
                .HasIndex(cr => new { cr.ContactId, cr.UserId })
                .IsUnique();

            modelBuilder.Entity<AutoReplyFlowNode>()
                .OwnsOne(n => n.Position);

            modelBuilder.Entity<FeatureAccess>()
            .HasIndex(f => new { f.BusinessId, f.FeatureName })
            .IsUnique();

            modelBuilder.Entity<WhatsAppTemplate>(e =>
            {
                e.Property(x => x.Body).HasColumnType("text");
                e.Property(x => x.ButtonsJson).HasColumnType("text");
                e.Property(x => x.RawJson).HasColumnType("text");
            });
            modelBuilder.Entity<CampaignClickLog>(e =>
            {
                e.HasIndex(x => new { x.CampaignId, x.ClickType, x.ClickedAt });
                e.HasIndex(x => new { x.CampaignId, x.ButtonIndex });
                e.HasIndex(x => new { x.CampaignId, x.ContactId });
            });

            modelBuilder.Entity<CampaignClickDailyAgg>(e =>
            {
                e.HasIndex(x => new { x.CampaignId, x.Day, x.ButtonIndex }).IsUnique();
                e.Property(x => x.Day).HasColumnType("date");
            });

            modelBuilder.Entity<MessageLog>()
            .HasIndex(x => x.MessageId);
            modelBuilder.Entity<MessageLog>()
                .HasIndex(x => x.RunId);

            modelBuilder.Entity<CampaignSendLog>()
                .HasIndex(x => x.MessageId);
            modelBuilder.Entity<CampaignSendLog>()
                .HasIndex(x => x.RunId);

            // ---------- WhatsAppSettingEntity indexes (for webhook → BusinessId resolution) ----------
            modelBuilder.Entity<WhatsAppSettingEntity>(b =>
            {
                b.HasIndex(x => new { x.Provider, x.PhoneNumberId })
                 .HasDatabaseName("IX_WhatsAppSettings_Provider_PhoneNumberId");

                b.HasIndex(x => new { x.Provider, x.WhatsAppBusinessNumber })
                 .HasDatabaseName("IX_WhatsAppSettings_Provider_BusinessNumber");

                b.HasIndex(x => new { x.Provider, x.WabaId })
                 .HasDatabaseName("IX_WhatsAppSettings_Provider_WabaId");

                // Handy for admin views / quick filters
                b.HasIndex(x => new { x.BusinessId, x.Provider, x.IsActive })
                 .HasDatabaseName("IX_WhatsAppSettings_Business_Provider_IsActive");

                b.HasIndex(x => new { x.Provider, x.WebhookCallbackUrl })
                 .HasDatabaseName("IX_WhatsAppSettings_Provider_CallbackUrl");

              
            });

            // ---------- CampaignSendLog composite index (fast status reconciliation) ----------
            modelBuilder.Entity<CampaignSendLog>(b =>
            {
                b.HasIndex(x => new { x.BusinessId, x.MessageId })
                 .HasDatabaseName("IX_CampaignSendLogs_Business_MessageId");
            });

            // ---------- MessageLog composite indexes (fast joins & inbound lookups) ----------
            modelBuilder.Entity<MessageLog>(b =>
            {
                b.HasIndex(x => new { x.BusinessId, x.MessageId })
                 .HasDatabaseName("IX_MessageLogs_Business_MessageId");

                b.HasIndex(x => new { x.BusinessId, x.RecipientNumber })
                 .HasDatabaseName("IX_MessageLogs_Business_Recipient");
            });

            modelBuilder.Entity<Contact>()
                .HasIndex(c => new { c.BusinessId, c.PhoneNumber })
                .IsUnique();

        }
    }
}
