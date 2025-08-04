using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using xbytechat.api;
using xbytechat.api.Features.Inbox.DTOs;
using xbytechat.api.CRM.Models;
using xbytechat.api.Features.Inbox.Hubs;
using Microsoft.Extensions.DependencyInjection;
using xbytechat.api.CRM.Interfaces;
using xbytechat.api.Features.AutoReplyBuilder.Services;
using xbytechat.api.Features.Inbox.Services;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat.api.CRM.Services;
using xbytechat.api.Features.Automation.Services;


namespace xbytechat.api.Features.Webhooks.Services.Processors
{
    public class InboundMessageProcessor : IInboundMessageProcessor
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<InboxHub> _hubContext;
        private readonly ILogger<InboundMessageProcessor> _logger;
        private readonly IInboxService _inboxService;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public InboundMessageProcessor(
            AppDbContext context,
            IHubContext<InboxHub> hubContext,
            ILogger<InboundMessageProcessor> logger,
            IInboxService inboxService,
            IServiceScopeFactory serviceScopeFactory)
        {
            _context = context;
            _hubContext = hubContext;
            _logger = logger;
            _inboxService = inboxService;
            _serviceScopeFactory = serviceScopeFactory;
        }



        
        public async Task ProcessChatAsync(JsonElement value)
        {
            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var contactService = scope.ServiceProvider.GetRequiredService<IContactService>();
                var chatSessionStateService = scope.ServiceProvider.GetRequiredService<IChatSessionStateService>();
                var automationService = scope.ServiceProvider.GetRequiredService<IAutomationService>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<InboundMessageProcessor>>();

                // ✅ 1. Extract WhatsApp metadata and message
                var msg = value.GetProperty("messages")[0];
                var contactPhone = msg.GetProperty("from").GetString()!;
                var content = msg.GetProperty("text").GetProperty("body").GetString();
                var businessNumber = value.GetProperty("metadata").GetProperty("display_phone_number").GetString()!;

                // ✅ 2. Resolve business by WhatsApp number
                var business = await db.Businesses
                    .Include(b => b.WhatsAppSettings)
                    .FirstOrDefaultAsync(b => b.WhatsAppSettings.WhatsAppBusinessNumber == businessNumber);

                if (business == null)
                {
                    logger.LogWarning("❌ Business not found for WhatsApp number: {Number}", businessNumber);
                    return;
                }

                var businessId = business.Id;

                // ✅ 3. Find or create contact
                var contact = await contactService.FindOrCreateAsync(businessId, contactPhone);
                if (contact == null)
                {
                    logger.LogWarning("❌ Could not resolve contact for phone: {Phone}", contactPhone);
                    return;
                }

                // ✅ 4. Check chat mode (skip inbox sync if not agent)
                var mode = await chatSessionStateService.GetChatModeAsync(businessId, contact.Id);
                var isAgentMode = mode == "agent";

                // ✅ 5. Log incoming message
                var messageLog = new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = businessId,
                    ContactId = contact.Id,
                    RecipientNumber = contactPhone,
                    MessageContent = content,
                    Status = "received",
                    CreatedAt = DateTime.UtcNow,
                    SentAt = DateTime.UtcNow,
                    IsIncoming = true
                };

                db.MessageLogs.Add(messageLog);
                await db.SaveChangesAsync();

                // ✅ 6. Try to trigger automation by keyword
                try
                {
                    var triggerKeyword = content.Trim().ToLower();
                    var handled = await automationService.TryRunFlowByKeywordAsync(
                        businessId,
                        triggerKeyword,
                        contact.PhoneNumber,
                        sourceChannel: "whatsapp",
                        industryTag: "default"
                    );

                    if (!handled)
                    {
                        logger.LogInformation("🕵️ No automation flow matched keyword: {Keyword}", triggerKeyword);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "❌ Automation flow execution failed.");
                }

                // ✅ 7. Only sync to inbox if chat mode is agent
                if (isAgentMode)
                {
                    var inboxService = scope.ServiceProvider.GetRequiredService<IInboxService>();
                    await inboxService.SaveIncomingMessageAsync(new InboxMessageDto
                    {
                        BusinessId = businessId,
                        ContactId = contact.Id,
                        RecipientPhone = contact.PhoneNumber,
                        MessageBody = messageLog.MessageContent,
                        IsIncoming = true,
                        Status = messageLog.Status,
                        SentAt = messageLog.CreatedAt
                    });

                    logger.LogInformation("📥 Message synced to inbox for contact {Phone}", contactPhone);
                }
                else
                {
                    logger.LogInformation("🚫 Skipping inbox sync: chat mode is not 'agent'");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Failed to process inbound WhatsApp chat.");
            }
        }


    }
}
