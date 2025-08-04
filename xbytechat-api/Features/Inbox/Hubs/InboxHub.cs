// 📄 xbytechat.api/Features/Inbox/InboxHub.cs

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using xbytechat.api.Features.Inbox.DTOs;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat.api.Shared;
using xbytechat.api.Models;
using Microsoft.EntityFrameworkCore;
using xbytechat.api.Features.Inbox.Models;

namespace xbytechat.api.Features.Inbox.Hubs
{
    [Authorize]
    public class InboxHub : Hub
    {
        private readonly AppDbContext _db;
        private readonly IMessageEngineService _messageService;

        public InboxHub(AppDbContext db, IMessageEngineService messageService)
        {
            _db = db;
            _messageService = messageService;
        }

        public override async Task OnConnectedAsync()
        {
            var businessId = Context.User.GetBusinessId();
            var groupName = $"business_{businessId}";

            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            Console.WriteLine($"✅ Connected to group: {groupName}");

            await base.OnConnectedAsync();
        }

        public async Task SendMessageToContact(SendMessageInputDto dto)
        {
            Console.WriteLine("📩 Raw DTO payload:");
            Console.WriteLine($"ContactId: {dto.ContactId}, Message: {dto.Message}");

            if (dto.ContactId == null || string.IsNullOrWhiteSpace(dto.Message))
            {
                Console.WriteLine("❌ Invalid contact or empty message.");
                return;
            }

            var businessId = Context.User.GetBusinessId();
            var userId = Context.User.GetUserId();

            // ✅ Lookup recipient phone number from Contact table
            var contact = await _db.Contacts
                .Where(c => c.BusinessId == businessId && c.Id == dto.ContactId)
                .FirstOrDefaultAsync();

            if (contact == null || string.IsNullOrWhiteSpace(contact.PhoneNumber))
            {
                Console.WriteLine($"❌ Contact not found or missing phone number. ContactId: {dto.ContactId}");
                await Clients.Caller.SendAsync("ReceiveInboxMessage", new
                {
                    contactId = dto.ContactId,
                    message = dto.Message,
                    from = userId,
                    status = "Failed",
                    error = "Invalid contact"
                   
                });
                return;
            }

            // ✅ Prepare DTO for WhatsApp sending
            var sendDto = new TextMessageSendDto
            {
                BusinessId = businessId,
                ContactId = dto.ContactId,
                RecipientNumber = contact.PhoneNumber,
                TextContent = dto.Message
            };

            // 🚀 Send via WhatsApp API and save to MessageLogs
            var result = await _messageService.SendTextDirectAsync(sendDto);

            // ✅ Construct unified message payload
            var inboxMessage = new
            {
                contactId = dto.ContactId,
                message = dto.Message,
                from = userId,
                status = result.Success ? "Sent" : "Failed",
                sentAt = DateTime.UtcNow,
                logId = result.LogId,
                senderId = userId,
                isIncoming = false
            };

            // ✅ Notify sender only
            await Clients.Caller.SendAsync("ReceiveInboxMessage", inboxMessage);

            // ✅ Notify others in group (for unread update)
            var groupName = $"business_{businessId}";
            await Clients.GroupExcept(groupName, Context.ConnectionId)
                .SendAsync("ReceiveInboxMessage", inboxMessage);
        }

   
        public async Task MarkAsRead(Guid contactId)
        {
            Console.WriteLine($"🟢 MarkAsRead triggered for ContactId: {contactId}");
            var userId = Context.User?.GetUserId();
            var businessId = Context.User?.GetBusinessId();

            if (userId == null || businessId == null || businessId == Guid.Empty)
                return;

            var userGuid = userId.Value;
            var businessGuid = businessId.Value;
            var now = DateTime.UtcNow;

            // ✅ Insert or Update ContactRead
            var readEntry = await _db.ContactReads
                .FirstOrDefaultAsync(r => r.ContactId == contactId && r.UserId == userGuid);

            if (readEntry == null)
            {
                Console.WriteLine("📥 New ContactRead will be added.");
                _db.ContactReads.Add(new ContactRead
                {
                    Id = Guid.NewGuid(),
                    BusinessId = businessGuid,
                    ContactId = contactId,
                    UserId = userGuid,
                    LastReadAt = now
                });
            }
            else
            {
                Console.WriteLine($"🔄 Updating LastReadAt for contact {contactId}");
                readEntry.LastReadAt = now;
            }

            await _db.SaveChangesAsync();
            Console.WriteLine("💾 ContactReads saved successfully.");
            // ✅ Step 1: Get message logs (DB)
            var allMessages = await _db.MessageLogs
                .Where(m => m.BusinessId == businessGuid && m.IsIncoming && m.ContactId != null)
                .ToListAsync();

            // ✅ Step 2: Get contactReads (DB)
            var contactReads = await _db.ContactReads
                .Where(r => r.UserId == userGuid)
                .ToDictionaryAsync(r => r.ContactId, r => r.LastReadAt);

            // ✅ Step 3: Now calculate unread counts in-memory (C# LINQ)
            var unreadCounts = allMessages
                .GroupBy(m => m.ContactId!.Value)
                .ToDictionary(
                    g => g.Key,
                    g => g.Count(m =>
                        !contactReads.ContainsKey(g.Key) ||
                        (m.SentAt ?? m.CreatedAt) > contactReads[g.Key])
                );

            // ✅ Push real-time update to user
            await Clients.User(userGuid.ToString())
                .SendAsync("UnreadCountChanged", unreadCounts);
        }


    }
}

