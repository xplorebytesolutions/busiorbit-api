using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using xbytechat.api;
using xbytechat.api.Features.CampaignTracking.DTOs;
using xbytechat.api.Features.CampaignTracking.Models;
using xbytechat.api.Features.CampaignTracking.Services;

namespace xbytechat.api.Features.CampaignTracking.Services
{
    public class CampaignSendLogService : ICampaignSendLogService
    {
        private readonly AppDbContext _context;
        private readonly ICampaignSendLogEnricher _enricher;

        public CampaignSendLogService(AppDbContext context, ICampaignSendLogEnricher enricher)
        {
            _context = context;
            _enricher = enricher;
        }

        // 📊 Get all send logs for a given campaign
        public async Task<List<CampaignSendLogDto>> GetLogsByCampaignIdAsync(Guid campaignId)
        {
            return await _context.CampaignSendLogs
                .Where(log => log.CampaignId == campaignId)
                .Include(log => log.Contact)
                .Select(log => new CampaignSendLogDto
                {
                    Id = log.Id,
                    CampaignId = log.CampaignId,
                    ContactId = log.ContactId,
                    ContactName = log.Contact != null ? log.Contact.Name : "N/A",
                    ContactPhone = log.Contact != null ? log.Contact.PhoneNumber : "-",
                    MessageBody = log.MessageBody,
                    TemplateId = log.TemplateId,
                    SendStatus = log.SendStatus,
                    ErrorMessage = log.ErrorMessage,
                    CreatedAt = log.CreatedAt,
                    SentAt = log.SentAt,
                    DeliveredAt = log.DeliveredAt,
                    ReadAt = log.ReadAt,
                    IpAddress = log.IpAddress,
                    DeviceInfo = log.DeviceInfo,
                    MacAddress = log.MacAddress,
                    SourceChannel = log.SourceChannel,
                    IsClicked = log.IsClicked,
                    ClickedAt = log.ClickedAt,
                    ClickType = log.ClickType
                })
                .ToListAsync();
        }

        // 📍 Get logs for a specific contact in a campaign
        public async Task<List<CampaignSendLogDto>> GetLogsForContactAsync(Guid campaignId, Guid contactId)
        {
            return await _context.CampaignSendLogs
                .Where(log => log.CampaignId == campaignId && log.ContactId == contactId)
                .Select(log => new CampaignSendLogDto
                {
                    Id = log.Id,
                    CampaignId = log.CampaignId,
                    ContactId = log.ContactId,
                    MessageBody = log.MessageBody,
                    TemplateId = log.TemplateId,
                    SendStatus = log.SendStatus,
                    ErrorMessage = log.ErrorMessage,
                    CreatedAt = log.CreatedAt,
                    SentAt = log.SentAt,
                    DeliveredAt = log.DeliveredAt,
                    ReadAt = log.ReadAt,
                    IpAddress = log.IpAddress,
                    DeviceInfo = log.DeviceInfo,
                    MacAddress = log.MacAddress,
                    SourceChannel = log.SourceChannel,
                    IsClicked = log.IsClicked,
                    ClickedAt = log.ClickedAt,
                    ClickType = log.ClickType
                })
                .ToListAsync();
        }

        // 🆕 Create a new send log (with enrichment)
        public async Task<bool> AddSendLogAsync(CampaignSendLogDto dto, string ipAddress, string userAgent)
        {
            var log = new CampaignSendLog
            {
                Id = Guid.NewGuid(),
                CampaignId = dto.CampaignId,
                ContactId = dto.ContactId,
                MessageBody = dto.MessageBody,
                TemplateId = dto.TemplateId,
                SendStatus = dto.SendStatus,
                ErrorMessage = dto.ErrorMessage,
                CreatedAt = DateTime.UtcNow,
                SentAt = dto.SentAt,
                DeliveredAt = dto.DeliveredAt,
                ReadAt = dto.ReadAt,
                SourceChannel = dto.SourceChannel,
                IsClicked = dto.IsClicked,
                ClickedAt = dto.ClickedAt,
                ClickType = dto.ClickType,
                RecipientId = dto.RecipientId
            };

            // ✅ Use enrichment service
            await _enricher.EnrichAsync(log, userAgent, ipAddress);

            _context.CampaignSendLogs.Add(log);
            await _context.SaveChangesAsync();
            return true;
        }

        // 📨 Update delivery or read status
        public async Task<bool> UpdateDeliveryStatusAsync(Guid logId, string status, DateTime? deliveredAt, DateTime? readAt)
        {
            var log = await _context.CampaignSendLogs.FirstOrDefaultAsync(l => l.Id == logId);
            if (log == null) return false;

            log.SendStatus = status;
            log.DeliveredAt = deliveredAt ?? log.DeliveredAt;
            log.ReadAt = readAt ?? log.ReadAt;

            await _context.SaveChangesAsync();
            return true;
        }

        // 📈 Track click (CTA)
        public async Task<bool> TrackClickAsync(Guid logId, string clickType)
        {
            var log = await _context.CampaignSendLogs.FirstOrDefaultAsync(l => l.Id == logId);
            if (log == null) return false;

            log.IsClicked = true;
            log.ClickedAt = DateTime.UtcNow;
            log.ClickType = clickType;

            await _context.SaveChangesAsync();
            return true;
        }

        // 📊 Get summary of campaign logs
        public async Task<CampaignLogSummaryDto> GetCampaignSummaryAsync(Guid campaignId)
        {
            var logs = await _context.CampaignSendLogs
                .Where(l => l.CampaignId == campaignId)
                .ToListAsync();

            return new CampaignLogSummaryDto
            {
                TotalSent = logs.Count,
                FailedCount = logs.Count(l => l.SendStatus == "Failed"),
                ClickedCount = logs.Count(l => l.IsClicked),
                LastSentAt = logs.Max(l => l.SentAt)
            };
        }


    }
}
