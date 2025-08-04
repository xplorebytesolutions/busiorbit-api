using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xbytechat.api.Features.CampaignTracking.DTOs;

namespace xbytechat.api.Features.CampaignTracking.Services
{
    public interface ICampaignSendLogService
    {
        // 📊 Get all logs for a specific campaign
        Task<List<CampaignSendLogDto>> GetLogsByCampaignIdAsync(Guid campaignId);

        // 📍 Get logs for a specific contact in a campaign
        Task<List<CampaignSendLogDto>> GetLogsForContactAsync(Guid campaignId, Guid contactId);

        // 🆕 Add a new send log entry with enrichment (IP, User-Agent)
        Task<bool> AddSendLogAsync(CampaignSendLogDto dto, string ipAddress, string userAgent);

        // 📨 Update delivery or read status
        Task<bool> UpdateDeliveryStatusAsync(Guid logId, string status, DateTime? deliveredAt, DateTime? readAt);

        // 📈 Track CTA click (e.g., BuyNow, ViewDetails)
        Task<bool> TrackClickAsync(Guid logId, string clickType);
        // 📊 Get summary of campaign logs
        Task<CampaignLogSummaryDto> GetCampaignSummaryAsync(Guid campaignId);

    }
}
