// 📄 Features/TemplateCatalog/Services/TemplateSyncService.cs
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using xbytechat.api.AuthModule.Models;
using xbytechat.api;
using xbytechat.api.WhatsAppSettings.Abstractions;
using xbytechat.api.WhatsAppSettings.Providers;
using xbytechat_api.WhatsAppSettings.Models;

public record TemplateSyncResult(int Added, int Updated, int Skipped, DateTime SyncedAt);

public interface ITemplateSyncService
{
    Task<TemplateSyncResult> SyncBusinessTemplatesAsync(Guid businessId, bool force = false, CancellationToken ct = default);
}

public sealed class TemplateSyncService : ITemplateSyncService
{
    private readonly AppDbContext _db;
    private readonly MetaTemplateCatalogProvider _meta;
    private readonly PinnacleTemplateCatalogProvider _pinnacle;
    private readonly ILogger<TemplateSyncService> _log;

    private static readonly TimeSpan TTL = TimeSpan.FromHours(12);

    public TemplateSyncService(AppDbContext db,
        MetaTemplateCatalogProvider meta,
        PinnacleTemplateCatalogProvider pinnacle,
        ILogger<TemplateSyncService> log)
    { _db = db; _meta = meta; _pinnacle = pinnacle; _log = log; }

    public async Task<TemplateSyncResult> SyncBusinessTemplatesAsync(Guid businessId, bool force = false, CancellationToken ct = default)
    {
        var setting = await _db.WhatsAppSettings.FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive, ct)
                      ?? throw new InvalidOperationException("Active WhatsApp settings not found.");

        var now = DateTime.UtcNow;

        // TTL short-circuit
        if (!force)
        {
            var recent = await _db.WhatsAppTemplates
                .Where(t => t.BusinessId == businessId)
                .OrderByDescending(t => t.LastSyncedAt)
                .Select(t => t.LastSyncedAt)
                .FirstOrDefaultAsync(ct);

            if (recent != default && now - recent < TTL)
            {
                _log.LogInformation("⏭️ Skipping sync for {BusinessId}; TTL not expired.", businessId);
                return new TemplateSyncResult(0, 0, 0, recent);
            }
        }

        var providerKey = (setting.Provider ?? "meta_cloud").Trim().ToLowerInvariant();
        IReadOnlyList<TemplateCatalogItem> incoming = providerKey switch
        {
            "meta_cloud" => await _meta.ListAsync(setting, ct),
            "pinnacle" => await _pinnacle.ListAsync(setting, ct),
            _ => Array.Empty<TemplateCatalogItem>()
        };

        int added = 0, updated = 0, skipped = 0;

        foreach (var it in incoming)
        {
            var existing = await _db.WhatsAppTemplates.FirstOrDefaultAsync(t =>
                t.BusinessId == businessId &&
                t.Provider == providerKey &&
                t.Name == it.Name &&
                t.Language == it.Language, ct);

            var buttonsJson = JsonConvert.SerializeObject(it.Buttons);

            if (existing == null)
            {
                await _db.WhatsAppTemplates.AddAsync(new WhatsAppTemplate
                {
                    BusinessId = businessId,
                    Provider = providerKey,
                    ExternalId = it.ExternalId,
                    Name = it.Name,
                    Language = it.Language,
                    Status = string.IsNullOrWhiteSpace(it.Status) ? "APPROVED" : it.Status,
                    Category = it.Category,
                    Body = it.Body ?? "",
                    HasImageHeader = it.HasImageHeader,
                    PlaceholderCount = it.PlaceholderCount,
                    ButtonsJson = buttonsJson,
                    RawJson = it.RawJson,
                    LastSyncedAt = now,
                    CreatedAt = now,
                    UpdatedAt = now,
                    IsActive = true
                }, ct);
                added++;
            }
            else
            {
                existing.ExternalId = it.ExternalId ?? existing.ExternalId;
                existing.Status = string.IsNullOrWhiteSpace(it.Status) ? existing.Status : it.Status;
                existing.Category = it.Category ?? existing.Category;
                existing.Body = it.Body ?? existing.Body;
                existing.HasImageHeader = it.HasImageHeader;
                existing.PlaceholderCount = it.PlaceholderCount;
                existing.ButtonsJson = buttonsJson;
                existing.RawJson = it.RawJson ?? existing.RawJson;
                existing.LastSyncedAt = now;
                existing.UpdatedAt = now;
                existing.IsActive = true;
                updated++;
            }
        }

        await _db.SaveChangesAsync(ct);

        return new TemplateSyncResult(added, updated, skipped, now);
    }
}
