﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// 👇 make sure this is where your AppDbContext lives
using xbytechat.api;

using xbytechat.api.Features.CampaignTracking.Models; // CampaignSendLog
using xbytechat.api.Features.CampaignModule.Models;   // Campaign (nav)
using xbytechat.api.CRM.Models;                       // Contact (nav)
using xbytechat.api.Features.MessageManagement.DTOs;  // MessageLog

namespace xbytechat.api.Features.Webhooks.Status
{
    /// <summary>
    /// Idempotent updater touching CampaignSendLogs and MessageLogs using your actual schema.
    /// </summary>
    public class MessageStatusUpdater : IMessageStatusUpdater
    {
        private readonly AppDbContext _db;
        private readonly ILogger<MessageStatusUpdater> _log;

        public MessageStatusUpdater(AppDbContext db, ILogger<MessageStatusUpdater> log)
        {
            _db = db;
            _log = log;
        }

        public async Task UpdateAsync(StatusEvent ev, CancellationToken ct = default)
        {
            // 🔎 Guard: we need Business + ProviderMessageId (WAMID) to reconcile reliably
            if (ev.BusinessId == Guid.Empty || string.IsNullOrWhiteSpace(ev.ProviderMessageId))
            {
                _log.LogWarning("Status update missing key fields (BusinessId or ProviderMessageId). Skip.");
                return;
            }

            // 1) Pull candidates (scoped to business + WAMID)
            var sendLogQ = _db.Set<CampaignSendLog>()
                              .AsTracking()
                              .Where(s => s.BusinessId == ev.BusinessId && s.MessageId == ev.ProviderMessageId);

            var msgLogQ = _db.Set<MessageLog>()
                             .AsTracking()
                             .Where(m => m.BusinessId == ev.BusinessId && m.MessageId == ev.ProviderMessageId);

            // If caller passed a specific CampaignSendLogId, narrow further
            if (ev.CampaignSendLogId is Guid sid)
                sendLogQ = sendLogQ.Where(s => s.Id == sid);

            var sendLog = await sendLogQ.FirstOrDefaultAsync(ct);
            var msgLog = await msgLogQ.FirstOrDefaultAsync(ct);

            // 2) Apply transition (idempotent)
            var changed = ApplyTransition(sendLog, msgLog, ev);

            // 3) Persist only if something actually changed
            if (changed > 0)
                await _db.SaveChangesAsync(ct);
        }

        /// <summary>Returns number of entities modified.</summary>
        private int ApplyTransition(CampaignSendLog? sendLog, MessageLog? msgLog, StatusEvent ev)
        {
            int modified = 0;

            // --- CampaignSendLog updates ---
            if (sendLog != null)
            {
                if (!string.Equals(sendLog.MessageId, ev.ProviderMessageId, StringComparison.Ordinal))
                {
                    sendLog.MessageId = ev.ProviderMessageId;
                    modified++;
                }

                switch (ev.State)
                {
                    case MessageDeliveryState.Sent:
                        if (!EqualsIgnoreCase(sendLog.SendStatus, "Sent"))
                        {
                            sendLog.SendStatus = "Sent";
                            modified++;
                        }
                        if (sendLog.SentAt == null || sendLog.SentAt == default)
                            sendLog.SentAt = ev.OccurredAt.UtcDateTime;
                        break;

                    case MessageDeliveryState.Delivered:
                        if (!EqualsIgnoreCase(sendLog.SendStatus, "Read") &&
                            !EqualsIgnoreCase(sendLog.SendStatus, "Delivered"))
                        {
                            sendLog.SendStatus = "Delivered";
                            modified++;
                        }
                        if (sendLog.DeliveredAt == null || sendLog.DeliveredAt == default)
                            sendLog.DeliveredAt = ev.OccurredAt.UtcDateTime;
                        break;

                    case MessageDeliveryState.Read:
                        if (!EqualsIgnoreCase(sendLog.SendStatus, "Read"))
                        {
                            sendLog.SendStatus = "Read";
                            modified++;
                        }
                        if (sendLog.ReadAt == null || sendLog.ReadAt == default)
                            sendLog.ReadAt = ev.OccurredAt.UtcDateTime;
                        break;

                    case MessageDeliveryState.Failed:
                        if (!EqualsIgnoreCase(sendLog.SendStatus, "Failed"))
                        {
                            sendLog.SendStatus = "Failed";
                            modified++;
                        }
                        if (sendLog.ErrorMessage != ev.ErrorMessage)
                        {
                            sendLog.ErrorMessage = ev.ErrorMessage;
                            modified++;
                        }
                        break;

                    case MessageDeliveryState.Deleted:
                        if (!EqualsIgnoreCase(sendLog.SendStatus, "Deleted"))
                        {
                            sendLog.SendStatus = "Deleted";
                            modified++;
                        }
                        break;
                }
            }

            // --- MessageLog updates ---
            if (msgLog != null)
            {
                if (!string.Equals(msgLog.MessageId, ev.ProviderMessageId, StringComparison.Ordinal))
                {
                    msgLog.MessageId = ev.ProviderMessageId;
                    modified++;
                }

                switch (ev.State)
                {
                    case MessageDeliveryState.Sent:
                        if (!EqualsIgnoreCase(msgLog.Status, "Sent"))
                        {
                            msgLog.Status = "Sent";
                            modified++;
                        }
                        if (msgLog.SentAt == null || msgLog.SentAt == default)
                            msgLog.SentAt = ev.OccurredAt.UtcDateTime;
                        break;

                    case MessageDeliveryState.Delivered:
                        if (!EqualsIgnoreCase(msgLog.Status, "Read") &&
                            !EqualsIgnoreCase(msgLog.Status, "Delivered"))
                        {
                            msgLog.Status = "Delivered";
                            modified++;
                        }
                        break;

                    case MessageDeliveryState.Read:
                        if (!EqualsIgnoreCase(msgLog.Status, "Read"))
                        {
                            msgLog.Status = "Read";
                            modified++;
                        }
                        break;

                    case MessageDeliveryState.Failed:
                        if (!EqualsIgnoreCase(msgLog.Status, "Failed"))
                        {
                            msgLog.Status = "Failed";
                            modified++;
                        }
                        if (msgLog.ErrorMessage != ev.ErrorMessage)
                        {
                            msgLog.ErrorMessage = ev.ErrorMessage;
                            modified++;
                        }
                        break;

                    case MessageDeliveryState.Deleted:
                        if (!EqualsIgnoreCase(msgLog.Status, "Deleted"))
                        {
                            msgLog.Status = "Deleted";
                            modified++;
                        }
                        break;
                }
            }

            if (sendLog == null && msgLog == null)
            {
                _log.LogWarning("No matching rows for BusinessId={BusinessId}, MessageId={MessageId}, State={State}",
                    ev.BusinessId, ev.ProviderMessageId, ev.State);
            }

            return modified;
        }

        private static bool EqualsIgnoreCase(string? a, string? b) =>
            string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }
}
