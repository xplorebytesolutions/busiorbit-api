using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using xbytechat_api.WhatsAppSettings.Models;

namespace xbytechat.api.Features.Webhooks.Directory
{
    /// <summary>
    /// EF-backed resolver for mapping provider identifiers to BusinessId, with a short cache.
    /// </summary>
    public class ProviderDirectory : IProviderDirectory
    {
        private readonly AppDbContext _db;
        private readonly ILogger<ProviderDirectory> _logger;
        private readonly IMemoryCache _cache;

        // reduce DB hits during webhook bursts
        private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(2);

        public ProviderDirectory(AppDbContext db, ILogger<ProviderDirectory> logger, IMemoryCache cache)
        {
            _db = db;
            _logger = logger;
            _cache = cache;
        }

        public async Task<Guid?> ResolveBusinessIdAsync(
            string? provider,
            string? phoneNumberId,
            string? displayPhoneNumber,
            string? wabaId,
            string? waId,
            CancellationToken ct = default)
        {
            provider = provider?.Trim().ToLowerInvariant();

            var cacheKey = $"provdir:{provider}:{phoneNumberId}:{Normalize(displayPhoneNumber)}:{wabaId}";
            if (_cache.TryGetValue<Guid?>(cacheKey, out var cached))
                return cached;

            try
            {
                // ⚓ 1) Strongest match: provider + phone_number_id
                if (!string.IsNullOrWhiteSpace(provider) && !string.IsNullOrWhiteSpace(phoneNumberId))
                {
                    var hit = await QueryByAsync(provider, phoneNumberId: phoneNumberId, ct: ct);
                    if (hit.HasValue) return CacheAndReturn(cacheKey, hit);
                }

                // ⚓ 2) Next: provider + display_phone_number (normalized)
                var normalizedDisplay = Normalize(displayPhoneNumber);
                if (!string.IsNullOrWhiteSpace(provider) && !string.IsNullOrWhiteSpace(normalizedDisplay))
                {
                    var hit = await QueryByAsync(provider, displayPhoneNumber: normalizedDisplay, ct: ct);
                    if (hit.HasValue) return CacheAndReturn(cacheKey, hit);
                }

                // ⚓ 3) Next: provider + wabaId (Meta)
                if (!string.IsNullOrWhiteSpace(provider) && !string.IsNullOrWhiteSpace(wabaId))
                {
                    var hit = await QueryByAsync(provider, wabaId: wabaId, ct: ct);
                    if (hit.HasValue) return CacheAndReturn(cacheKey, hit);
                }

                _logger.LogWarning(
                    "ProviderDirectory: No match for provider={Provider}, pnid={PhoneId}, disp={Display}, waba={Waba}",
                    provider, phoneNumberId, normalizedDisplay, wabaId
                );
                return CacheAndReturn(cacheKey, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProviderDirectory lookup failed.");
                return null;
            }
        }

        private Guid? CacheAndReturn(string key, Guid? value)
        {
            _cache.Set(key, value, CacheTtl);
            return value;
        }

        /// <summary>
        /// Centralized query; now materializes candidates so Normalize() runs in-memory.
        /// </summary>
        private async Task<Guid?> QueryByAsync(
            string provider,
            string? phoneNumberId = null,
            string? displayPhoneNumber = null,
            string? wabaId = null,
            CancellationToken ct = default)
        {
            // Only bring back what we need
            var candidates = await _db.Set<WhatsAppSettingEntity>()
                .AsNoTracking()
                .Where(s => s.IsActive && s.Provider.ToLower() == provider)
                .Select(s => new
                {
                    s.BusinessId,
                    s.PhoneNumberId,
                    s.WhatsAppBusinessNumber,
                    s.WabaId
                })
                .ToListAsync(ct);

            var normDisp = Normalize(displayPhoneNumber);

            var hit = candidates.FirstOrDefault(s =>
                (!string.IsNullOrEmpty(phoneNumberId) && s.PhoneNumberId == phoneNumberId) ||
                (!string.IsNullOrEmpty(normDisp) && Normalize(s.WhatsAppBusinessNumber) == normDisp) ||
                (!string.IsNullOrEmpty(wabaId) && s.WabaId == wabaId)
            );

            return hit?.BusinessId;
        }

        /// <summary>
        /// Normalize phone formatting for robust comparisons.
        /// </summary>
        private static string? Normalize(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return null;
            var trimmed = phone.Trim();
            var hasPlus = trimmed.StartsWith("+");
            var digits = new string(trimmed.Where(char.IsDigit).ToArray());
            return hasPlus ? "+" + digits : digits;
        }
    }
}


//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Caching.Memory;
//using Microsoft.Extensions.Logging;
//using xbytechat_api.WhatsAppSettings.Models;

//namespace xbytechat.api.Features.Webhooks.Directory
//{
//    /// <summary>
//    /// EF-backed resolver for mapping provider identifiers to BusinessId, with a short cache.
//    /// </summary>
//    public class ProviderDirectory : IProviderDirectory
//    {
//        private readonly AppDbContext _db;
//        private readonly ILogger<ProviderDirectory> _logger;
//        private readonly IMemoryCache _cache;

//        // reduce DB hits during webhook bursts
//        private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(2);

//        public ProviderDirectory(AppDbContext db, ILogger<ProviderDirectory> logger, IMemoryCache cache)
//        {
//            _db = db;
//            _logger = logger;
//            _cache = cache;
//        }

//        public async Task<Guid?> ResolveBusinessIdAsync(
//            string? provider,
//            string? phoneNumberId,
//            string? displayPhoneNumber,
//            string? wabaId,
//            string? waId,
//            CancellationToken ct = default)
//        {
//            provider = provider?.Trim().ToLowerInvariant();

//            var cacheKey = $"provdir:{provider}:{phoneNumberId}:{Normalize(displayPhoneNumber)}:{wabaId}";
//            if (_cache.TryGetValue<Guid?>(cacheKey, out var cached))
//                return cached;

//            try
//            {
//                // ⚓ 1) Strongest match: provider + phone_number_id
//                if (!string.IsNullOrWhiteSpace(provider) && !string.IsNullOrWhiteSpace(phoneNumberId))
//                {
//                    var hit = await QueryByAsync(provider, phoneNumberId: phoneNumberId, ct: ct);
//                    if (hit.HasValue) return CacheAndReturn(cacheKey, hit);
//                }

//                // ⚓ 2) Next: provider + display_phone_number (normalized)
//                var normalizedDisplay = Normalize(displayPhoneNumber);
//                if (!string.IsNullOrWhiteSpace(provider) && !string.IsNullOrWhiteSpace(normalizedDisplay))
//                {
//                    var hit = await QueryByAsync(provider, displayPhoneNumber: normalizedDisplay, ct: ct);
//                    if (hit.HasValue) return CacheAndReturn(cacheKey, hit);
//                }

//                // ⚓ 3) Next: provider + wabaId (Meta)
//                if (!string.IsNullOrWhiteSpace(provider) && !string.IsNullOrWhiteSpace(wabaId))
//                {
//                    var hit = await QueryByAsync(provider, wabaId: wabaId, ct: ct);
//                    if (hit.HasValue) return CacheAndReturn(cacheKey, hit);
//                }

//                // (Optional) 4) Heuristic: waId → very weak; only if you store it
//                // If you keep sender WA IDs in settings, you could add another query here.

//                _logger.LogWarning("ProviderDirectory: No match for provider={Provider}, pnid={PhoneId}, disp={Display}, waba={Waba}",
//                    provider, phoneNumberId, normalizedDisplay, wabaId);
//                return CacheAndReturn(cacheKey, null);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "ProviderDirectory lookup failed.");
//                return null;
//            }
//        }

//        private Guid? CacheAndReturn(string key, Guid? value)
//        {
//            _cache.Set(key, value, CacheTtl);
//            return value;
//        }

//        /// <summary>
//        /// Centralized query; tweak entity/property names here if your model differs.
//        /// </summary>
//        private async Task<Guid?> QueryByAsync(
//                                string provider,
//                                string? phoneNumberId = null,
//                                string? displayPhoneNumber = null,
//                                string? wabaId = null,
//                                CancellationToken ct = default)
//        {
//            return await _db.Set<WhatsAppSettingEntity>()   // 👈 use your real entity
//                .AsNoTracking()
//                .Where(s => s.IsActive && s.Provider.ToLower() == provider)
//                .Where(s =>
//                    (phoneNumberId != null && s.PhoneNumberId == phoneNumberId) ||
//                    (displayPhoneNumber != null && Normalize(s.WhatsAppBusinessNumber) == displayPhoneNumber) ||
//                    (wabaId != null && s.WabaId == wabaId)
//                )
//                .Select(s => (Guid?)s.BusinessId)
//                .FirstOrDefaultAsync(ct);
//        }

//        /// <summary>
//        /// Normalize phone formatting for robust comparisons.
//        /// </summary>
//        private static string? Normalize(string? phone)
//        {
//            if (string.IsNullOrWhiteSpace(phone)) return null;
//            // keep leading '+' if present, strip spaces, dashes, parentheses
//            var trimmed = phone.Trim();
//            var hasPlus = trimmed.StartsWith("+");
//            var digits = new string(trimmed.Where(char.IsDigit).ToArray());
//            return hasPlus ? "+" + digits : digits;
//        }

//        // ⚠️ Replace with your actual settings entity if named differently

//    }
//}
