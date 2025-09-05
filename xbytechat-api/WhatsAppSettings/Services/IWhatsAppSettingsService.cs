﻿using System;
using System.Threading.Tasks;
using xbytechat_api.WhatsAppSettings.DTOs;
using xbytechat_api.WhatsAppSettings.Models;

namespace xbytechat_api.WhatsAppSettings.Services
{
    public interface IWhatsAppSettingsService
    {
        Task SaveOrUpdateSettingAsync(SaveWhatsAppSettingDto dto);
        Task<WhatsAppSettingEntity?> GetSettingsByBusinessIdAsync(Guid businessId);
        Task<bool> DeleteSettingsAsync(Guid businessId);
        Task<string> TestConnectionAsync(SaveWhatsAppSettingDto dto);
        Task<string?> GetSenderNumberAsync(Guid businessId);
        Task<string> GetCallbackUrlAsync(Guid businessId, string appBaseUrl);
    }
}
