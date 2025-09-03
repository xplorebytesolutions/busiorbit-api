// 📄 xbytechat_api/WhatsAppSettings/Services/WhatsAppSettingsService.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using xbytechat.api;
using xbytechat_api.WhatsAppSettings.DTOs;
using xbytechat_api.WhatsAppSettings.Models;

namespace xbytechat_api.WhatsAppSettings.Services
{
    public class WhatsAppSettingsService : IWhatsAppSettingsService
    {
        private readonly AppDbContext _dbContext;
        private readonly HttpClient _http;                    // kept for any other callers you may have
        private readonly IHttpClientFactory _httpClientFactory;

        public WhatsAppSettingsService(
            AppDbContext dbContext,
            HttpClient http,
            IHttpClientFactory httpClientFactory)
        {
            _dbContext = dbContext;
            _http = http;
            _httpClientFactory = httpClientFactory;
        }

        //public async Task SaveOrUpdateSettingAsync(SaveWhatsAppSettingDto dto)
        //{
        //    if (dto.BusinessId == Guid.Empty)
        //        throw new ArgumentException("Invalid BusinessId provided.");

        //    var existing = await _dbContext.WhatsAppSettings
        //        .FirstOrDefaultAsync(x => x.BusinessId == dto.BusinessId);

        //    if (existing != null)
        //    {
        //        // keep provider if not passed; otherwise trim
        //        existing.Provider = dto.Provider?.Trim() ?? existing.Provider;

        //        if (!string.IsNullOrWhiteSpace(dto.ApiUrl)) existing.ApiUrl = dto.ApiUrl.Trim();
        //        if (!string.IsNullOrWhiteSpace(dto.ApiKey)) existing.ApiKey = dto.ApiKey.Trim();
        //        if (!string.IsNullOrWhiteSpace(dto.ApiToken)) existing.ApiToken = dto.ApiToken.Trim();
        //        if (!string.IsNullOrWhiteSpace(dto.PhoneNumberId)) existing.PhoneNumberId = dto.PhoneNumberId.Trim();
        //        if (!string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber)) existing.WhatsAppBusinessNumber = dto.WhatsAppBusinessNumber.Trim();
        //        if (!string.IsNullOrWhiteSpace(dto.SenderDisplayName)) existing.SenderDisplayName = dto.SenderDisplayName.Trim();
        //        if (!string.IsNullOrWhiteSpace(dto.WabaId)) existing.WabaId = dto.WabaId.Trim();

        //        existing.IsActive = dto.IsActive;
        //        existing.UpdatedAt = DateTime.UtcNow;
        //    }
        //    else
        //    {
        //        var newSetting = new WhatsAppSettingEntity
        //        {
        //            Id = Guid.NewGuid(),
        //            BusinessId = dto.BusinessId,
        //            // default to Pinnacle
        //            Provider = dto.Provider?.Trim() ?? "Pinnacle",
        //            ApiUrl = (dto.ApiUrl ?? string.Empty).Trim(),
        //            ApiKey = string.IsNullOrWhiteSpace(dto.ApiKey) ? null : dto.ApiKey.Trim(),
        //            ApiToken = string.IsNullOrWhiteSpace(dto.ApiToken) ? null : dto.ApiToken.Trim(),
        //            PhoneNumberId = string.IsNullOrWhiteSpace(dto.PhoneNumberId) ? null : dto.PhoneNumberId.Trim(),
        //            WhatsAppBusinessNumber = string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber) ? null : dto.WhatsAppBusinessNumber.Trim(),
        //            SenderDisplayName = string.IsNullOrWhiteSpace(dto.SenderDisplayName) ? null : dto.SenderDisplayName.Trim(),
        //            WabaId = string.IsNullOrWhiteSpace(dto.WabaId) ? null : dto.WabaId.Trim(),
        //            IsActive = dto.IsActive,
        //            CreatedAt = DateTime.UtcNow
        //        };

        //        await _dbContext.WhatsAppSettings.AddAsync(newSetting);
        //    }

        //    await _dbContext.SaveChangesAsync();
        //}


        public async Task SaveOrUpdateSettingAsync(SaveWhatsAppSettingDto dto)
        {
            if (dto.BusinessId == Guid.Empty)
                throw new ArgumentException("Invalid BusinessId provided.", nameof(dto.BusinessId));

            // Normalize provider (store lower-case for consistency)
            var provider = (dto.Provider ?? "pinnacle").Trim();
            if (string.IsNullOrWhiteSpace(provider))
                provider = "pinnacle";
            var providerNorm = provider.ToLowerInvariant();

            // Look up by BusinessId + Provider (case-insensitive)
            var existing = await _dbContext.WhatsAppSettings
                .FirstOrDefaultAsync(x => x.BusinessId == dto.BusinessId && x.Provider.ToLower() == providerNorm);

            if (existing != null)
            {
                // keep provider normalized
                existing.Provider = providerNorm;

                // Only overwrite when incoming value is non-empty (avoid wiping secrets/tokens accidentally)
                if (!string.IsNullOrWhiteSpace(dto.ApiUrl)) existing.ApiUrl = dto.ApiUrl.Trim();
                if (!string.IsNullOrWhiteSpace(dto.ApiKey)) existing.ApiKey = dto.ApiKey.Trim();
                if (!string.IsNullOrWhiteSpace(dto.ApiToken)) existing.ApiToken = dto.ApiToken!.Trim();

                if (!string.IsNullOrWhiteSpace(dto.PhoneNumberId)) existing.PhoneNumberId = dto.PhoneNumberId!.Trim();
                if (!string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber)) existing.WhatsAppBusinessNumber = dto.WhatsAppBusinessNumber!.Trim();
                if (!string.IsNullOrWhiteSpace(dto.SenderDisplayName)) existing.SenderDisplayName = dto.SenderDisplayName!.Trim();
                if (!string.IsNullOrWhiteSpace(dto.WabaId)) existing.WabaId = dto.WabaId!.Trim();

                // 🔐 Webhook auth fields (optional)
                if (!string.IsNullOrWhiteSpace(dto.WebhookSecret)) existing.WebhookSecret = dto.WebhookSecret!.Trim();
                if (!string.IsNullOrWhiteSpace(dto.WebhookVerifyToken)) existing.WebhookVerifyToken = dto.WebhookVerifyToken!.Trim();

                // 🌐 NEW: provider callback URL (optional)
                if (!string.IsNullOrWhiteSpace(dto.WebhookCallbackUrl)) existing.WebhookCallbackUrl = dto.WebhookCallbackUrl!.Trim();

                existing.IsActive = dto.IsActive;
                existing.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var newSetting = new WhatsAppSettingEntity
                {
                    Id = Guid.NewGuid(),
                    BusinessId = dto.BusinessId,
                    Provider = providerNorm,
                    ApiUrl = (dto.ApiUrl ?? string.Empty).Trim(),
                    ApiKey = string.IsNullOrWhiteSpace(dto.ApiKey) ? null : dto.ApiKey!.Trim(),
                    ApiToken = string.IsNullOrWhiteSpace(dto.ApiToken) ? null : dto.ApiToken!.Trim(),
                    PhoneNumberId = string.IsNullOrWhiteSpace(dto.PhoneNumberId) ? null : dto.PhoneNumberId!.Trim(),
                    WhatsAppBusinessNumber = string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber) ? null : dto.WhatsAppBusinessNumber!.Trim(),
                    SenderDisplayName = string.IsNullOrWhiteSpace(dto.SenderDisplayName) ? null : dto.SenderDisplayName!.Trim(),
                    WabaId = string.IsNullOrWhiteSpace(dto.WabaId) ? null : dto.WabaId!.Trim(),

                    // 🔐 Webhook auth fields (optional)
                    WebhookSecret = string.IsNullOrWhiteSpace(dto.WebhookSecret) ? null : dto.WebhookSecret!.Trim(),
                    WebhookVerifyToken = string.IsNullOrWhiteSpace(dto.WebhookVerifyToken) ? null : dto.WebhookVerifyToken!.Trim(),

                    // 🌐 NEW: provider callback URL (optional)
                    WebhookCallbackUrl = string.IsNullOrWhiteSpace(dto.WebhookCallbackUrl) ? null : dto.WebhookCallbackUrl!.Trim(),

                    IsActive = dto.IsActive,
                    CreatedAt = DateTime.UtcNow
                };

                await _dbContext.WhatsAppSettings.AddAsync(newSetting);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<WhatsAppSettingEntity?> GetSettingsByBusinessIdAsync(Guid businessId)
        {
            return await _dbContext.WhatsAppSettings
                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);
        }

        public async Task<bool> DeleteSettingsAsync(Guid businessId)
        {
            var setting = await _dbContext.WhatsAppSettings
                .FirstOrDefaultAsync(x => x.BusinessId == businessId);

            if (setting == null) return false;

            _dbContext.WhatsAppSettings.Remove(setting);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Provider-aware test connection. Returns a short message (✅/❌ …).
        /// The controller may convert non-✅ messages to 400, etc.
        /// </summary>
        public async Task<string> TestConnectionAsync(SaveWhatsAppSettingDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Provider))
                throw new ArgumentException("Provider is required.");

            // normalize provider and baseUrl
            var provider = dto.Provider.Trim();
            var lower = provider.ToLowerInvariant();
            var baseUrl = (dto.ApiUrl ?? string.Empty).Trim().TrimEnd('/');

            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentException("ApiUrl is required.");

            var http = _httpClientFactory.CreateClient();

            // ----- Meta Cloud -----
            if (lower == "meta_cloud")
            {
                if (string.IsNullOrWhiteSpace(dto.ApiToken))
                    throw new ArgumentException("ApiToken is required for Meta Cloud.");
                if (string.IsNullOrWhiteSpace(dto.PhoneNumberId))
                    throw new ArgumentException("PhoneNumberId is required for Meta Cloud.");

                http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", dto.ApiToken);

                var url = $"{baseUrl}/{dto.PhoneNumberId}";
                var res = await http.GetAsync(url);
                var body = await res.Content.ReadAsStringAsync();

                if (!res.IsSuccessStatusCode)
                    return $"❌ Meta Cloud test failed ({(int)res.StatusCode}). Body: {body}";

                return "✅ Meta Cloud token & phone number ID are valid.";
            }

            // ----- Pinnacle (formerly Pinbot) -----
            if (lower == "pinnacle")
            {
                if (string.IsNullOrWhiteSpace(dto.ApiKey))
                    return "❌ API Key is required for Pinnacle.";

                // Pinnacle requires either phone number id OR WABA id in the path
                var pathId =
                    !string.IsNullOrWhiteSpace(dto.PhoneNumberId) ? dto.PhoneNumberId!.Trim() :
                    !string.IsNullOrWhiteSpace(dto.WabaId) ? dto.WabaId!.Trim() :
                    null;

                if (string.IsNullOrWhiteSpace(pathId))
                    return "❌ Provide PhoneNumberId or WabaId for Pinnacle.";

                if (string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber))
                    return "❌ WhatsApp Business Number is required for Pinnacle test.";

                var url = $"{baseUrl}/{pathId}/messages";
                var payload = new
                {
                    to = dto.WhatsAppBusinessNumber,
                    type = "text",
                    text = new { body = "Test message" },
                    messaging_product = "whatsapp"
                };

                using var req = new HttpRequestMessage(HttpMethod.Post, url);
                req.Headers.TryAddWithoutValidation("apikey", dto.ApiKey);
                req.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                var res = await http.SendAsync(req);
                var body = await res.Content.ReadAsStringAsync();

                if (!res.IsSuccessStatusCode)
                {
                    if ((int)res.StatusCode == 401 || (int)res.StatusCode == 403)
                        return $"❌ Pinnacle rejected the API key for id '{pathId}'. Verify the key and id. Body: {body}";

                    return $"❌ Pinnacle test failed ({(int)res.StatusCode}). Body: {body}";
                }

                return "✅ Pinnacle API key and endpoint are reachable.";
            }

            return $"❌ Unsupported provider: {dto.Provider}";
        }

        public async Task<string?> GetSenderNumberAsync(Guid businessId)
        {
            var setting = await _dbContext.WhatsAppSettings
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);

            return setting?.WhatsAppBusinessNumber;
        }

        public async Task<string> GetCallbackUrlAsync(Guid businessId, string appBaseUrl)
        {
            var s = await _dbContext.WhatsAppSettings
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);

            if (!string.IsNullOrWhiteSpace(s?.WebhookCallbackUrl))
                return s!.WebhookCallbackUrl!;

            return $"{appBaseUrl.TrimEnd('/')}/api/webhookcallback";
        }

    }
}


//// 📄 xbytechat_api/WhatsAppSettings/Services/WhatsAppSettingsService.cs
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using xbytechat.api;
//using xbytechat_api.WhatsAppSettings.DTOs;
//using xbytechat_api.WhatsAppSettings.Models;

//namespace xbytechat_api.WhatsAppSettings.Services
//{
//    public class WhatsAppSettingsService : IWhatsAppSettingsService
//    {
//        private readonly AppDbContext _dbContext;
//        private readonly HttpClient _http;
//        private readonly IHttpClientFactory _httpClientFactory;
//        public WhatsAppSettingsService(AppDbContext dbContext, HttpClient http, IHttpClientFactory httpClientFactory)
//        {
//            _dbContext = dbContext;
//            _http = http;
//            _httpClientFactory = httpClientFactory;
//        }

//        public async Task SaveOrUpdateSettingAsync(SaveWhatsAppSettingDto dto)
//        {
//            if (dto.BusinessId == Guid.Empty)
//                throw new ArgumentException("Invalid BusinessId provided.");

//            var existing = await _dbContext.WhatsAppSettings
//                .FirstOrDefaultAsync(x => x.BusinessId == dto.BusinessId);

//            if (existing != null)
//            {
//                existing.Provider = dto.Provider?.Trim() ?? existing.Provider;

//                if (!string.IsNullOrWhiteSpace(dto.ApiUrl)) existing.ApiUrl = dto.ApiUrl.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.ApiKey)) existing.ApiKey = dto.ApiKey.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.ApiToken)) existing.ApiToken = dto.ApiToken.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.PhoneNumberId)) existing.PhoneNumberId = dto.PhoneNumberId.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber)) existing.WhatsAppBusinessNumber = dto.WhatsAppBusinessNumber.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.SenderDisplayName)) existing.SenderDisplayName = dto.SenderDisplayName.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.WabaId)) existing.WabaId = dto.WabaId.Trim();

//                existing.IsActive = dto.IsActive;
//                existing.UpdatedAt = DateTime.UtcNow;
//            }
//            else
//            {
//                var newSetting = new WhatsAppSettingEntity
//                {
//                    Id = Guid.NewGuid(),
//                    BusinessId = dto.BusinessId,
//                    Provider = dto.Provider?.Trim() ?? "pinbot",
//                    ApiUrl = dto.ApiUrl.Trim(),
//                    ApiKey = string.IsNullOrWhiteSpace(dto.ApiKey) ? null : dto.ApiKey.Trim(),
//                    ApiToken = string.IsNullOrWhiteSpace(dto.ApiToken) ? null : dto.ApiToken.Trim(),
//                    PhoneNumberId = string.IsNullOrWhiteSpace(dto.PhoneNumberId) ? null : dto.PhoneNumberId.Trim(),
//                    WhatsAppBusinessNumber = string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber) ? null : dto.WhatsAppBusinessNumber.Trim(),
//                    SenderDisplayName = string.IsNullOrWhiteSpace(dto.SenderDisplayName) ? null : dto.SenderDisplayName.Trim(),
//                    WabaId = string.IsNullOrWhiteSpace(dto.WabaId) ? null : dto.WabaId.Trim(),
//                    IsActive = dto.IsActive,
//                    CreatedAt = DateTime.UtcNow
//                };

//                await _dbContext.WhatsAppSettings.AddAsync(newSetting);
//            }

//            await _dbContext.SaveChangesAsync();
//        }

//        public async Task<WhatsAppSettingEntity?> GetSettingsByBusinessIdAsync(Guid businessId)
//        {
//            return await _dbContext.WhatsAppSettings
//                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);
//        }

//        public async Task<bool> DeleteSettingsAsync(Guid businessId)
//        {
//            var setting = await _dbContext.WhatsAppSettings
//                .FirstOrDefaultAsync(x => x.BusinessId == businessId);

//            if (setting == null) return false;

//            _dbContext.WhatsAppSettings.Remove(setting);
//            await _dbContext.SaveChangesAsync();
//            return true;
//        }

//        /// <summary>
//        /// Provider-aware test connection. Returns a short success message or throws an Exception with details.
//        /// Controller turns exceptions into 500 with message/details.
//        /// </summary>
//        //public async Task<string> TestConnectionAsync(SaveWhatsAppSettingDto dto)
//        //{
//        //    if (dto is null) throw new ArgumentException("Test payload cannot be null.");
//        //    var provider = (dto.Provider ?? "pinbot").Trim().ToLowerInvariant();
//        //    var baseUrl = (dto.ApiUrl ?? "").Trim().TrimEnd('/');

//        //    if (string.IsNullOrWhiteSpace(baseUrl))
//        //        throw new Exception("API URL is required.");

//        //    if (provider == "meta_cloud")
//        //    {
//        //        // Validate inputs
//        //        if (string.IsNullOrWhiteSpace(dto.ApiToken))
//        //            throw new Exception("ApiToken is required for Meta Cloud test.");
//        //        if (string.IsNullOrWhiteSpace(dto.PhoneNumberId))
//        //            throw new Exception("PhoneNumberId is required for Meta Cloud test.");

//        //        // GET {apiUrl}/{phoneNumberId}
//        //        using var req = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/{dto.PhoneNumberId}");
//        //        req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", dto.ApiToken);

//        //        var res = await _http.SendAsync(req);
//        //        var body = await res.Content.ReadAsStringAsync();

//        //        if (!res.IsSuccessStatusCode)
//        //            throw new Exception($"Meta Cloud test failed ({(int)res.StatusCode}). Body: {body}");

//        //        return "Meta Cloud token is valid and connection was successful.";
//        //    }

//        //    if (provider == "pinbot")
//        //    {
//        //        // Validate inputs (Pinbot needs an API key and either WABA ID or PhoneNumberId)
//        //        if (string.IsNullOrWhiteSpace(dto.ApiKey))
//        //            throw new Exception("ApiKey is required for Pinbot test.");
//        //        var pathId = !string.IsNullOrWhiteSpace(dto.PhoneNumberId) ? dto.PhoneNumberId!.Trim()
//        //                     : !string.IsNullOrWhiteSpace(dto.WabaId) ? dto.WabaId!.Trim()
//        //                     : null;
//        //        if (pathId == null)
//        //            throw new Exception("Either PhoneNumberId or WabaId is required for Pinbot test.");

//        //        if (string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber))
//        //            throw new Exception("WhatsAppBusinessNumber is required for Pinbot test.");

//        //        // We do a small POST (same shape as their curl) to verify key + route
//        //        var url = $"{baseUrl}/{pathId}/messages";
//        //        var payload = new
//        //        {
//        //            to = dto.WhatsAppBusinessNumber,
//        //            type = "text",
//        //            text = new { body = "Test message" },
//        //            messaging_product = "whatsapp"
//        //        };

//        //        using var req = new HttpRequestMessage(HttpMethod.Post, url);
//        //        req.Headers.TryAddWithoutValidation("apikey", dto.ApiKey);
//        //        req.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

//        //        var res = await _http.SendAsync(req);
//        //        var body = await res.Content.ReadAsStringAsync();

//        //        if (!res.IsSuccessStatusCode)
//        //            throw new Exception($"Pinbot test failed ({(int)res.StatusCode}). Body: {body}");

//        //        return "Pinbot API key is valid and endpoint accepted a test payload.";
//        //    }

//        //    throw new Exception($"Unsupported provider: {dto.Provider}");
//        //}
//        public async Task<string> TestConnectionAsync(SaveWhatsAppSettingDto dto)
//        {
//            if (string.IsNullOrWhiteSpace(dto.Provider))
//                throw new ArgumentException("Provider is required.");

//            var provider = dto.Provider.Trim().ToLowerInvariant();
//            var baseUrl = (dto.ApiUrl ?? "").TrimEnd('/');
//            if (string.IsNullOrWhiteSpace(baseUrl))
//                throw new ArgumentException("ApiUrl is required.");

//            var http = _httpClientFactory.CreateClient();

//            if (provider == "meta_cloud")
//            {
//                if (string.IsNullOrWhiteSpace(dto.ApiToken))
//                    throw new ArgumentException("ApiToken is required for Meta Cloud.");
//                if (string.IsNullOrWhiteSpace(dto.PhoneNumberId))
//                    throw new ArgumentException("PhoneNumberId is required for Meta Cloud.");

//                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", dto.ApiToken);
//                var url = $"{baseUrl}/{dto.PhoneNumberId}";
//                //var url = $"{baseUrl}/652856141236584";
//                var res = await http.GetAsync(url);
//                var body = await res.Content.ReadAsStringAsync();

//                if (!res.IsSuccessStatusCode)
//                {
//                    // Return a clear message instead of throwing (keeps controller at 200/400 level)
//                    return $"❌ Meta Cloud test failed ({(int)res.StatusCode}). Body: {body}";
//                }

//                return "✅ Meta Cloud token & phone number ID are valid.";
//            }

//            if (provider == "pinbot")
//            {
//                if (string.IsNullOrWhiteSpace(dto.ApiKey))
//                    return "❌ ApiKey is required for Pinbot.";

//                // Pinbot requires either phone number id OR WABA id in the path
//                var pathId = !string.IsNullOrWhiteSpace(dto.PhoneNumberId) ? dto.PhoneNumberId!.Trim()
//                           : !string.IsNullOrWhiteSpace(dto.WabaId)       ? dto.WabaId!.Trim()
//                           : null;

//                if (string.IsNullOrWhiteSpace(pathId))
//                    return "❌ Provide PhoneNumberId or WabaId for Pinbot.";

//                // Build POST /v3/{id}/messages
//                var url = $"{baseUrl}/{pathId}/messages";
//               // var url = $"{baseUrl}/652856141236584/messages";
//                var payload = new
//                {
//                    to = dto.WhatsAppBusinessNumber ?? "", // can be any verified test recipient
//                    type = "text",
//                    text = new { body = "Test message" },
//                    messaging_product = "whatsapp"
//                };

//                using var req = new HttpRequestMessage(HttpMethod.Post, url);
//                req.Headers.TryAddWithoutValidation("apikey", dto.ApiKey);
//                req.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

//                var res = await http.SendAsync(req);
//                var body = await res.Content.ReadAsStringAsync();

//                if (!res.IsSuccessStatusCode)
//                {
//                    // Map common auth failures to a friendly response
//                    if ((int)res.StatusCode == 401 || (int)res.StatusCode == 403)
//                    {
//                        return $"❌ Pinbot rejected the API key for this path id ({pathId}). " +
//                               $"Check that the apikey belongs to this account and the id is correct. Body: {body}";
//                    }

//                    return $"❌ Pinbot test failed ({(int)res.StatusCode}). Body: {body}";
//                }

//                return "✅ Pinbot API key and endpoint are reachable.";
//            }

//            return $"❌ Unsupported provider: {dto.Provider}";
//        }

//        public async Task<string?> GetSenderNumberAsync(Guid businessId)
//        {
//            var setting = await _dbContext.WhatsAppSettings
//                .AsNoTracking()
//                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);

//            return setting?.WhatsAppBusinessNumber;
//        }

//        //public async Task<string?> GetSenderNumberAsync(Guid businessId)
//        //{
//        //    var setting = await _dbContext.WhatsAppSettings
//        //        .AsNoTracking()
//        //        .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);

//        //    return setting?.WhatsAppBusinessNumber;
//        //}
//    }
//}


//// 📄 xbytechat_api/WhatsAppSettings/Services/WhatsAppSettingsService.cs
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using xbytechat.api;
//using xbytechat.api.Helpers;
//using xbytechat_api.WhatsAppSettings.DTOs;
//using xbytechat_api.WhatsAppSettings.Models;
//using static System.Net.WebRequestMethods;

//namespace xbytechat_api.WhatsAppSettings.Services
//{
//    public class WhatsAppSettingsService : IWhatsAppSettingsService
//    {
//        private readonly AppDbContext _dbContext;

//        public WhatsAppSettingsService(AppDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task SaveOrUpdateSettingAsync(SaveWhatsAppSettingDto dto)
//        {
//            if (dto.BusinessId == Guid.Empty)
//                throw new ArgumentException("Invalid BusinessId provided.");

//            var existing = await _dbContext.WhatsAppSettings
//                .FirstOrDefaultAsync(x => x.BusinessId == dto.BusinessId);

//            if (existing != null)
//            {
//                existing.Provider = dto.Provider?.Trim() ?? existing.Provider;
//                if (!string.IsNullOrWhiteSpace(dto.ApiUrl)) existing.ApiUrl = dto.ApiUrl.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.ApiKey)) existing.ApiKey = dto.ApiKey.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.ApiToken)) existing.ApiToken = dto.ApiToken.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.PhoneNumberId)) existing.PhoneNumberId = dto.PhoneNumberId.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber)) existing.WhatsAppBusinessNumber = dto.WhatsAppBusinessNumber.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.SenderDisplayName)) existing.SenderDisplayName = dto.SenderDisplayName.Trim();
//                if (!string.IsNullOrWhiteSpace(dto.WabaId)) existing.WabaId = dto.WabaId.Trim();
//                existing.IsActive = dto.IsActive;
//                existing.UpdatedAt = DateTime.UtcNow;
//            }
//            else
//            {
//                var newSetting = new WhatsAppSettingEntity
//                {
//                    Id = Guid.NewGuid(),
//                    BusinessId = dto.BusinessId,
//                    Provider = dto.Provider?.Trim() ?? "pinbot",
//                    ApiUrl = dto.ApiUrl.Trim(),
//                    ApiKey = dto.ApiKey?.Trim(),
//                    ApiToken = dto.ApiToken?.Trim(),
//                    PhoneNumberId = dto.PhoneNumberId?.Trim(),
//                    WhatsAppBusinessNumber = dto.WhatsAppBusinessNumber?.Trim(),
//                    SenderDisplayName = dto.SenderDisplayName?.Trim(),
//                    WabaId = dto.WabaId?.Trim(),
//                    IsActive = dto.IsActive,
//                    CreatedAt = DateTime.UtcNow
//                };
//                await _dbContext.WhatsAppSettings.AddAsync(newSetting);
//            }

//            await _dbContext.SaveChangesAsync();
//        }

//        public async Task<WhatsAppSettingEntity?> GetSettingsByBusinessIdAsync(Guid businessId)
//        {
//            return await _dbContext.WhatsAppSettings
//                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);
//        }

//        public async Task<bool> DeleteSettingsAsync(Guid businessId)
//        {
//            var setting = await _dbContext.WhatsAppSettings
//                .FirstOrDefaultAsync(x => x.BusinessId == businessId);

//            if (setting == null) return false;

//            _dbContext.WhatsAppSettings.Remove(setting);
//            await _dbContext.SaveChangesAsync();
//            return true;
//        }

//        //public async Task<string> TestConnectionAsync(SaveWhatsAppSettingDto dto)
//        //{
//        //    using var client = new HttpClient();
//        //    var baseUrl = dto.ApiUrl.TrimEnd('/');
//        //    var provider = dto.Provider?.Trim().ToLowerInvariant() ?? "pinbot";

//        //    if (provider == "pinbot")
//        //    {
//        //        if (string.IsNullOrWhiteSpace(dto.ApiKey))
//        //            throw new Exception("ApiKey is required for Pinbot test.");
//        //        if (string.IsNullOrWhiteSpace(dto.WabaId))
//        //            throw new Exception("WabaId is required for Pinbot test.");

//        //        var probe = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/{dto.WabaId}/messages");
//        //        probe.Headers.Add("apikey", dto.ApiKey);
//        //        var resp = await client.SendAsync(probe);

//        //        if ((int)resp.StatusCode == 401 || (int)resp.StatusCode == 403)
//        //            throw new Exception("Pinbot API key rejected (401/403).");

//        //        return "Pinbot API key appears valid and endpoint reachable.";
//        //    }

//        //    if (provider == "meta_cloud")
//        //    {
//        //        if (string.IsNullOrWhiteSpace(dto.ApiToken))
//        //            throw new Exception("ApiToken is required for Meta Cloud test.");
//        //        if (string.IsNullOrWhiteSpace(dto.PhoneNumberId))
//        //            throw new Exception("PhoneNumberId is required for Meta Cloud test.");

//        //        client.DefaultRequestHeaders.Authorization =
//        //            new AuthenticationHeaderValue("Bearer", dto.ApiToken);

//        //        var url = $"{baseUrl}/{dto.PhoneNumberId}";
//        //        var res = await client.GetAsync(url);
//        //        var content = await res.Content.ReadAsStringAsync();

//        //        if (!res.IsSuccessStatusCode)
//        //            throw new Exception($"❌ WhatsApp API Error: {content}");

//        //        return "Meta Cloud token is valid and connection was successful.";
//        //    }

//        //    throw new Exception($"Unsupported provider: {dto.Provider}");
//        //}
//        public async Task<ResponseResult> TestConnectionAsync(WhatsAppSettingEntity setting)
//        {
//            if (setting.Provider.Equals("meta_cloud", StringComparison.OrdinalIgnoreCase))
//            {
//                // existing Meta Cloud test
//                return await _metaTester.TestAsync(setting);
//            }
//            else if (setting.Provider.Equals("pinbot", StringComparison.OrdinalIgnoreCase))
//            {
//                try
//                {
//                    var url = $"{setting.ApiUrl?.TrimEnd('/')}/v3/{setting.WabaId}/messages";
//                    var payload = new
//                    {
//                        to = setting.WhatsAppBusinessNumber,
//                        type = "text",
//                        text = new { body = "Test message" },
//                        messaging_product = "whatsapp"
//                    };

//                    using var req = new HttpRequestMessage(HttpMethod.Post, url);
//                    req.Headers.TryAddWithoutValidation("apikey", setting.ApiKey);
//                    req.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

//                    var res = await _http.SendAsync(req);
//                    var body = await res.Content.ReadAsStringAsync();

//                    if (!res.IsSuccessStatusCode)
//                        return ResponseResult.ErrorInfo("❌ Pinbot connection failed", body);

//                    return ResponseResult.SuccessInfo("✅ Pinbot connection successful!", null, body);
//                }
//                catch (Exception ex)
//                {
//                    return ResponseResult.ErrorInfo("❌ Exception during Pinbot test", ex.Message);
//                }
//            }

//            return ResponseResult.ErrorInfo("❌ Unknown provider type.");
//        }

//        public async Task<string?> GetSenderNumberAsync(Guid businessId)
//        {
//            var setting = await _dbContext.WhatsAppSettings
//                .AsNoTracking()
//                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);

//            return setting?.WhatsAppBusinessNumber;
//        }
//    }
//}


//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using xbytechat.api;
//using xbytechat_api.WhatsAppSettings.DTOs;
//using xbytechat_api.WhatsAppSettings.Models;

//namespace xbytechat_api.WhatsAppSettings.Services
//{
//    public class WhatsAppSettingsService : IWhatsAppSettingsService
//    {
//        private readonly AppDbContext _dbContext;

//        public WhatsAppSettingsService(AppDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task SaveOrUpdateSettingAsync(SaveWhatsAppSettingDto dto)
//        {
//            if (dto.BusinessId == Guid.Empty)
//                throw new ArgumentException("Invalid BusinessId provided.");

//            var existingSetting = await _dbContext.WhatsAppSettings
//                .FirstOrDefaultAsync(x => x.BusinessId == dto.BusinessId);

//            if (existingSetting != null)
//            {
//                // 🔁 Update existing record with null-safety
//                existingSetting.ApiUrl = dto.ApiUrl?.Trim() ?? existingSetting.ApiUrl;
//                existingSetting.ApiToken = dto.ApiToken?.Trim() ?? existingSetting.ApiToken;

//                if (!string.IsNullOrWhiteSpace(dto.PhoneNumberId))
//                    existingSetting.PhoneNumberId = dto.PhoneNumberId.Trim();

//                if (!string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber))
//                    existingSetting.WhatsAppBusinessNumber = dto.WhatsAppBusinessNumber.Trim();

//                if (!string.IsNullOrWhiteSpace(dto.SenderDisplayName))
//                    existingSetting.SenderDisplayName = dto.SenderDisplayName.Trim();

//                if (!string.IsNullOrWhiteSpace(dto.WabaId))
//                    existingSetting.WabaId = dto.WabaId.Trim();

//                existingSetting.IsActive = dto.IsActive;
//                existingSetting.UpdatedAt = DateTime.UtcNow;
//            }
//            else
//            {
//                // ➕ Insert new record
//                var newSetting = new WhatsAppSettingEntity
//                {
//                    Id = Guid.NewGuid(),
//                    BusinessId = dto.BusinessId,
//                    ApiUrl = dto.ApiUrl.Trim(),
//                    ApiToken = dto.ApiToken.Trim(),
//                    PhoneNumberId = dto.PhoneNumberId?.Trim(),
//                    WhatsAppBusinessNumber = dto.WhatsAppBusinessNumber?.Trim(),
//                    SenderDisplayName = dto.SenderDisplayName?.Trim(),
//                    WabaId = dto.WabaId?.Trim(),
//                    IsActive = dto.IsActive,
//                    CreatedAt = DateTime.UtcNow
//                };

//                await _dbContext.WhatsAppSettings.AddAsync(newSetting);
//            }

//            try
//            {
//                await _dbContext.SaveChangesAsync();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error saving WhatsApp settings: " + ex.InnerException?.Message ?? ex.Message);
//            }
//        }

//        public async Task<WhatsAppSettingEntity?> GetSettingsByBusinessIdAsync(Guid businessId)
//        {
//            // 🔎 Find active WhatsApp setting for the business
//            return await _dbContext.WhatsAppSettings
//                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);
//        }

//        public async Task<bool> DeleteSettingsAsync(Guid businessId)
//        {
//            // 🗑 Delete settings based on businessId
//            var setting = await _dbContext.WhatsAppSettings
//                .FirstOrDefaultAsync(x => x.BusinessId == businessId);

//            if (setting == null)
//                return false;

//            _dbContext.WhatsAppSettings.Remove(setting);
//            await _dbContext.SaveChangesAsync();
//            return true;
//        }

//        //public async Task<string> TestConnectionAsync(SaveWhatsAppSettingDto dto)
//        //{
//        //    using var client = new HttpClient();
//        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", dto.ApiToken);

//        //    var baseUrl = dto.ApiUrl.TrimEnd('/');
//        //    var testUrl = $"{baseUrl}/me"; // 📡 Lightweight endpoint for connection test

//        //    var response = await client.GetAsync(testUrl);
//        //    var content = await response.Content.ReadAsStringAsync();

//        //    if (!response.IsSuccessStatusCode)
//        //        throw new Exception($"❌ WhatsApp API Error: {content}");

//        //    return "WhatsApp API token is valid and connection was successful.";
//        //}
//        public async Task<string> TestConnectionAsync(SaveWhatsAppSettingDto dto)
//        {
//            using var client = new HttpClient();
//            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", dto.ApiToken);

//            var baseUrl = dto.ApiUrl.TrimEnd('/');
//            if (string.IsNullOrWhiteSpace(dto.PhoneNumberId))
//                throw new Exception("PhoneNumberId is required to test WhatsApp Cloud API connection.");

//            // This is the official endpoint for checking the number
//            var testUrl = $"{baseUrl}/{dto.PhoneNumberId}";

//            var response = await client.GetAsync(testUrl);
//            var content = await response.Content.ReadAsStringAsync();

//            if (!response.IsSuccessStatusCode)
//                throw new Exception($"❌ WhatsApp API Error: {content}");

//            return "WhatsApp API token is valid and connection was successful.";
//        }

//        public async Task<string?> GetSenderNumberAsync(Guid businessId)
//        {
//            var setting = await _dbContext.WhatsAppSettings
//                .AsNoTracking()
//                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);

//            if (setting == null)
//            {
//                throw new Exception($"❌ WhatsApp settings not found for BusinessId: {businessId}");
//            }

//            return setting.WhatsAppBusinessNumber;
//        }

//    }
//}
