using Microsoft.EntityFrameworkCore;
using xbytechat.api.Features.CampaignTracking.DTOs;
using xbytechat.api.Features.CampaignTracking.Models;

namespace xbytechat.api.Features.CampaignTracking.Services
{
    

    public class CampaignAnalyticsService : ICampaignAnalyticsService
    {
        private readonly AppDbContext _context;

        public CampaignAnalyticsService(AppDbContext context)
        {
            _context = context;
            //_context = context;
        }

        public async Task<CampaignStatusDashboardDto?> GetCampaignStatsAsync(Guid campaignId)
        {
            var logs = await _context.CampaignSendLogs
                .Where(l => l.CampaignId == campaignId)
                .ToListAsync();

            if (!logs.Any()) return null;

            return new CampaignStatusDashboardDto
            {
                CampaignId = campaignId,
                TotalRecipients = logs.Count,
                SentCount = logs.Count(l => l.SendStatus == "Sent"),
                DeliveredCount = logs.Count(l => l.SendStatus == "Delivered"),
                ReadCount = logs.Count(l => l.SendStatus == "Read"),
                FailedCount = logs.Count(l => l.SendStatus == "Failed"),
                FirstSentAt = logs.Min(l => l.SentAt),
                LastSentAt = logs.Max(l => l.SentAt),
                FirstReadAt = logs.Min(l => l.ReadAt),
                LastReadAt = logs.Max(l => l.ReadAt)
            };
        }

        //public async Task<CampaignStatusDashboardDto> GetStatusDashboardAsync(Guid businessId)
        //{
        //    var stats = await _context.CampaignSendLogs
        //        .Where(log => log.BusinessId == businessId)
        //        .GroupBy(log => 1) // Group by a constant to aggregate all rows
        //        .Select(g => new
        //        {
        //            TotalSent = g.Count(),
        //            TotalDelivered = g.Count(l => l.DeliveredAt != null),
        //            TotalRead = g.Count(l => l.ReadAt != null),
        //            TotalClicked = g.Count(l => l.ClickedAt != null),
        //            TotalFailed = g.Count(l => l.Status == "failed")
        //        })
        //        .FirstOrDefaultAsync();

        //    if (stats == null)
        //    {
        //        return new CampaignStatusDashboardDto(); // Return empty DTO if no logs found
        //    }

        //    //return new CampaignStatusDashboardDto
        //    //{
        //    //    TotalSent = stats.TotalSent,
        //    //    TotalDelivered = stats.TotalDelivered,
        //    //    TotalRead = stats.TotalRead,
        //    //    TotalClicked = stats.TotalClicked,
        //    //    TotalFailed = stats.TotalFailed,
        //    //    DeliveryRate = stats.TotalSent > 0 ? Math.Round((double)stats.TotalDelivered / stats.TotalSent * 100, 2) : 0,
        //    //    ReadRate = stats.TotalDelivered > 0 ? Math.Round((double)stats.TotalRead / stats.TotalDelivered * 100, 2) : 0,
        //    //    ClickRate = stats.TotalDelivered > 0 ? Math.Round((double)stats.TotalClicked / stats.TotalDelivered * 100, 2) : 0
        //    //};
        //}

        public async Task<IEnumerable<TopCampaignDto>> GetTopCampaignsAsync(Guid businessId, int count = 5)
        {
            var campaignStats = await _context.CampaignSendLogs
                .Where(log => log.BusinessId == businessId)
                .GroupBy(log => log.CampaignId)
                .Select(group => new
                {
                    CampaignId = group.Key,
                    TotalSent = group.Count(),
                    TotalRead = group.Count(l => l.ReadAt != null),
                    TotalClicked = group.Count(l => l.ClickedAt != null)
                })
                .Where(s => s.TotalSent > 0)
                .OrderByDescending(s => (double)s.TotalClicked / s.TotalSent)
                .Take(count)
                .ToListAsync();

            if (!campaignStats.Any())
            {
                return new List<TopCampaignDto>();
            }

            var campaignIds = campaignStats.Select(s => s.CampaignId).ToList();
            var campaigns = await _context.Campaigns
                .Where(c => campaignIds.Contains(c.Id))
                .ToDictionaryAsync(c => c.Id, c => c.Name);

            return campaignStats.Select(s => new TopCampaignDto
            {
                CampaignId = s.CampaignId,
                CampaignName = campaigns.GetValueOrDefault(s.CampaignId, "Unnamed Campaign"),
                ReadRate = s.TotalSent > 0 ? Math.Round(((double)s.TotalRead / s.TotalSent) * 100, 2) : 0,
                ClickThroughRate = s.TotalSent > 0 ? Math.Round(((double)s.TotalClicked / s.TotalSent) * 100, 2) : 0
            });
        }
    }
}

