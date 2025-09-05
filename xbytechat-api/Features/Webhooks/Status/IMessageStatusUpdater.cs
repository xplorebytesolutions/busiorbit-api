using System;
using System.Threading;
using System.Threading.Tasks;

namespace xbytechat.api.Features.Webhooks.Status
{
    /// <summary>
    /// Provider-agnostic updater for delivery/read/fail transitions.
    /// Must be idempotent (safe under retries / duplicates).
    /// </summary>
    public interface IMessageStatusUpdater
    {
        Task UpdateAsync(StatusEvent ev, CancellationToken ct = default);
    }

    /// <summary>
    /// Normalized status event parsed from any provider payload.
    /// </summary>
    public sealed class StatusEvent
    {
        public Guid BusinessId { get; init; }
        public string Provider { get; init; } = "";          // "meta" | "pinnacle"

        // Provider message id (Meta "id", Pinnacle equivalent) → maps to MessageId in your DB
        public string ProviderMessageId { get; init; } = "";

        // Optional hints (not required in your current lookups)
        public Guid? CampaignSendLogId { get; init; }
        public string? RecipientWaId { get; init; }

        public MessageDeliveryState State { get; init; }     // Sent/Delivered/Read/Failed/Deleted
        public DateTimeOffset OccurredAt { get; init; }      // from provider timestamp when available

        public string? ErrorCode { get; init; }
        public string? ErrorMessage { get; init; }
        public string? ConversationId { get; init; }
    }

    public enum MessageDeliveryState
    {
        Sent,
        Delivered,
        Read,
        Failed,
        Deleted
    }
}
