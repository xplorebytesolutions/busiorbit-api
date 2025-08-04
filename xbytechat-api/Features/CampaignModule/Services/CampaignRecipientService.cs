﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using xbytechat.api.Features.CampaignModule.DTOs;
using xbytechat.api.Features.CampaignModule.Models;

namespace xbytechat.api.Features.CampaignModule.Services
{
    public class CampaignRecipientService : ICampaignRecipientService
    {
        private readonly AppDbContext _context;

        public CampaignRecipientService(AppDbContext context)
        {
            _context = context;
        }

        // 🔍 Get a single recipient by ID
        public async Task<CampaignRecipientDto?> GetByIdAsync(Guid id)
        {
            return await _context.CampaignRecipients
                .Include(r => r.Contact)
                .Where(r => r.Id == id)
                .Select(r => new CampaignRecipientDto
                {
                    Id = r.Id,
                    ContactId = r.ContactId,
                    ContactName = r.Contact.Name,
                    ContactPhone = r.Contact.PhoneNumber,
                    Status = r.Status,
                    SentAt = r.SentAt
                })
                .FirstOrDefaultAsync();
        }

        // 📦 Get all recipients of a specific campaign
        public async Task<List<CampaignRecipientDto>> GetByCampaignIdAsync(Guid campaignId)
        {
            return await _context.CampaignRecipients
                .Include(r => r.Contact)
                .Where(r => r.CampaignId == campaignId)
                .Select(r => new CampaignRecipientDto
                {
                    Id = r.Id,
                    ContactId = r.ContactId,
                    ContactName = r.Contact.Name,
                    ContactPhone = r.Contact.PhoneNumber,
                    Status = r.Status,
                    SentAt = r.SentAt
                })
                .ToListAsync();
        }

        // ✏️ Update status of a specific recipient
        public async Task<bool> UpdateStatusAsync(Guid recipientId, string newStatus)
        {
            var recipient = await _context.CampaignRecipients.FindAsync(recipientId);
            if (recipient == null) return false;

            recipient.Status = newStatus;
            recipient.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        // 💬 Track customer reply or CTA
        // 🗣️ Track customer reply on a recipient
        public async Task<bool> TrackReplyAsync(Guid recipientId, string replyText)
        {
            var recipient = await _context.CampaignRecipients.FindAsync(recipientId);
            if (recipient == null) return false;

            recipient.ClickedCTA = replyText; // You may later rename this to something like `LastReply`
            recipient.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }


        // 🔎 Global recipient search across all campaigns
        // 🔍 Search recipients by optional status or keyword
        public async Task<List<CampaignRecipientDto>> SearchRecipientsAsync(string status = null, string keyword = null)
        {
            var query = _context.CampaignRecipients
                .Include(r => r.Contact)
                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(r => r.Status == status);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(r =>
                    r.Contact.Name.Contains(keyword) ||
                    r.Contact.PhoneNumber.Contains(keyword)
                );

            return await query
                .Select(r => new CampaignRecipientDto
                {
                    Id = r.Id,
                    ContactId = r.ContactId,
                    ContactName = r.Contact.Name,
                    ContactPhone = r.Contact.PhoneNumber,
                    Status = r.Status,
                    SentAt = r.SentAt
                })
                .ToListAsync();
        }

        //public async Task AssignContactsToCampaignAsync(Guid campaignId, List<Guid> contactIds)
        //{
        //    var existing = await _context.CampaignRecipients
        //        .Where(r => r.CampaignId == campaignId && contactIds.Contains(r.ContactId))
        //        .Select(r => r.ContactId)
        //        .ToListAsync();

        //    var newRecipients = contactIds
        //        .Where(id => !existing.Contains(id))
        //        .Select(contactId => new CampaignRecipient
        //        {
        //            Id = Guid.NewGuid(),
        //            CampaignId = campaignId,
        //            ContactId = contactId,
        //            Status = "Pending",
        //            SentAt = DateTime.UtcNow,
        //            UpdatedAt = DateTime.UtcNow,
        //            IsAutoTagged = false
        //        }).ToList();

        //    if (newRecipients.Any())
        //    {
        //        await _context.CampaignRecipients.AddRangeAsync(newRecipients);
        //        await _context.SaveChangesAsync();
        //    }
        //}
        public async Task AssignContactsToCampaignAsync(Guid campaignId, List<Guid> contactIds)
        {
            var campaign = await _context.Campaigns
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == campaignId);

            if (campaign == null)
                throw new Exception("Campaign not found.");

            var businessId = campaign.BusinessId;

            var existing = await _context.CampaignRecipients
                .Where(r => r.CampaignId == campaignId && contactIds.Contains(r.ContactId))
                .Select(r => r.ContactId)
                .ToListAsync();

            var newRecipients = contactIds
                .Where(id => !existing.Contains(id))
                .Select(contactId => new CampaignRecipient
                {
                    Id = Guid.NewGuid(),
                    CampaignId = campaignId,
                    ContactId = contactId,
                    BusinessId = businessId, // ✅ required
                    Status = "Pending",
                    SentAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsAutoTagged = false
                }).ToList();

            if (newRecipients.Any())
            {
                await _context.CampaignRecipients.AddRangeAsync(newRecipients);
                await _context.SaveChangesAsync();
            }
        }

    }
}
