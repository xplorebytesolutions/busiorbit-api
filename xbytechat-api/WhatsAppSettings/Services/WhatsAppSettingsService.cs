using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using xbytechat.api;
using xbytechat_api.WhatsAppSettings.DTOs;
using xbytechat_api.WhatsAppSettings.Models;

namespace xbytechat_api.WhatsAppSettings.Services
{
    public class WhatsAppSettingsService : IWhatsAppSettingsService
    {
        private readonly AppDbContext _dbContext;

        public WhatsAppSettingsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveOrUpdateSettingAsync(SaveWhatsAppSettingDto dto)
        {
            if (dto.BusinessId == Guid.Empty)
                throw new ArgumentException("Invalid BusinessId provided.");

            var existingSetting = await _dbContext.WhatsAppSettings
                .FirstOrDefaultAsync(x => x.BusinessId == dto.BusinessId);

            if (existingSetting != null)
            {
                // 🔁 Update existing record with null-safety
                existingSetting.ApiUrl = dto.ApiUrl?.Trim() ?? existingSetting.ApiUrl;
                existingSetting.ApiToken = dto.ApiToken?.Trim() ?? existingSetting.ApiToken;

                if (!string.IsNullOrWhiteSpace(dto.PhoneNumberId))
                    existingSetting.PhoneNumberId = dto.PhoneNumberId.Trim();

                if (!string.IsNullOrWhiteSpace(dto.WhatsAppBusinessNumber))
                    existingSetting.WhatsAppBusinessNumber = dto.WhatsAppBusinessNumber.Trim();

                if (!string.IsNullOrWhiteSpace(dto.SenderDisplayName))
                    existingSetting.SenderDisplayName = dto.SenderDisplayName.Trim();

                if (!string.IsNullOrWhiteSpace(dto.WabaId))
                    existingSetting.WabaId = dto.WabaId.Trim();

                existingSetting.IsActive = dto.IsActive;
                existingSetting.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                // ➕ Insert new record
                var newSetting = new WhatsAppSettingEntity
                {
                    Id = Guid.NewGuid(),
                    BusinessId = dto.BusinessId,
                    ApiUrl = dto.ApiUrl.Trim(),
                    ApiToken = dto.ApiToken.Trim(),
                    PhoneNumberId = dto.PhoneNumberId?.Trim(),
                    WhatsAppBusinessNumber = dto.WhatsAppBusinessNumber?.Trim(),
                    SenderDisplayName = dto.SenderDisplayName?.Trim(),
                    WabaId = dto.WabaId?.Trim(),
                    IsActive = dto.IsActive,
                    CreatedAt = DateTime.UtcNow
                };

                await _dbContext.WhatsAppSettings.AddAsync(newSetting);
            }

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving WhatsApp settings: " + ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<WhatsAppSettingEntity?> GetSettingsByBusinessIdAsync(Guid businessId)
        {
            // 🔎 Find active WhatsApp setting for the business
            return await _dbContext.WhatsAppSettings
                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);
        }

        public async Task<bool> DeleteSettingsAsync(Guid businessId)
        {
            // 🗑 Delete settings based on businessId
            var setting = await _dbContext.WhatsAppSettings
                .FirstOrDefaultAsync(x => x.BusinessId == businessId);

            if (setting == null)
                return false;

            _dbContext.WhatsAppSettings.Remove(setting);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        //public async Task<string> TestConnectionAsync(SaveWhatsAppSettingDto dto)
        //{
        //    using var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", dto.ApiToken);

        //    var baseUrl = dto.ApiUrl.TrimEnd('/');
        //    var testUrl = $"{baseUrl}/me"; // 📡 Lightweight endpoint for connection test

        //    var response = await client.GetAsync(testUrl);
        //    var content = await response.Content.ReadAsStringAsync();

        //    if (!response.IsSuccessStatusCode)
        //        throw new Exception($"❌ WhatsApp API Error: {content}");

        //    return "WhatsApp API token is valid and connection was successful.";
        //}
        public async Task<string> TestConnectionAsync(SaveWhatsAppSettingDto dto)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", dto.ApiToken);

            var baseUrl = dto.ApiUrl.TrimEnd('/');
            if (string.IsNullOrWhiteSpace(dto.PhoneNumberId))
                throw new Exception("PhoneNumberId is required to test WhatsApp Cloud API connection.");

            // This is the official endpoint for checking the number
            var testUrl = $"{baseUrl}/{dto.PhoneNumberId}";

            var response = await client.GetAsync(testUrl);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"❌ WhatsApp API Error: {content}");

            return "WhatsApp API token is valid and connection was successful.";
        }

        public async Task<string?> GetSenderNumberAsync(Guid businessId)
        {
            var setting = await _dbContext.WhatsAppSettings
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);

            if (setting == null)
            {
                throw new Exception($"❌ WhatsApp settings not found for BusinessId: {businessId}");
            }

            return setting.WhatsAppBusinessNumber;
        }

    }
}
