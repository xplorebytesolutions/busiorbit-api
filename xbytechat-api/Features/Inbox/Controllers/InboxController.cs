using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using xbytechat.api.Features.Inbox.DTOs;
using xbytechat.api.Features.Inbox.Services;
using xbytechat.api.Helpers;
using Microsoft.AspNetCore.Authorization;
using xbytechat.api.Shared;

namespace xbytechat.api.Features.Inbox.Controllers
{
    [ApiController]
    [Route("api/inbox")]
    public class InboxController : ControllerBase
    {
        private readonly IInboxService _inboxService;

        public InboxController(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        /// <summary>
        /// Send a new message from UI or system.
        /// </summary>
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] InboxMessageDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.MessageBody))
                return BadRequest("Message content is required.");

            var result = await _inboxService.SaveOutgoingMessageAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Receive a message from external source (e.g., WhatsApp webhook).
        /// </summary>
        [HttpPost("receive")]
        public async Task<IActionResult> ReceiveMessage([FromBody] InboxMessageDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.MessageBody))
                return BadRequest("Incoming message content is required.");

            var result = await _inboxService.SaveIncomingMessageAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Fetch message history between agent and customer using business token + contactId.
        /// </summary>
        [HttpGet("messages")]
        public async Task<IActionResult> GetMessagesByContact([FromQuery] Guid contactId)
        {
            if (contactId == Guid.Empty)
                return BadRequest("ContactId is required.");

            var businessId = User.GetBusinessId();
            var messages = await _inboxService.GetMessagesByContactAsync(businessId, contactId);
            return Ok(messages);
        }

        /// <summary>
        /// Fetch full conversation between agent (userPhone) and customer (contactPhone).
        /// </summary>
        [HttpGet("conversation")]
        public async Task<IActionResult> GetConversation(
            [FromQuery] Guid businessId,
            [FromQuery] string userPhone,
            [FromQuery] string contactPhone)
        {
            if (businessId == Guid.Empty || string.IsNullOrWhiteSpace(userPhone) || string.IsNullOrWhiteSpace(contactPhone))
                return BadRequest("Invalid input.");

            var messages = await _inboxService.GetConversationAsync(businessId, userPhone, contactPhone);
            return Ok(messages);
        }

        //[HttpGet("unread-counts")]
        //public async Task<IActionResult> GetUnreadCounts()
        //{
        //    var businessId = User.GetBusinessId();
        //    var counts = await _inboxService.GetUnreadMessageCountsAsync(businessId);
        //    return Ok(counts);
        //}

        [HttpPost("mark-read")]
        public async Task<IActionResult> MarkMessagesAsRead([FromQuery] Guid contactId)
        {
            if (contactId == Guid.Empty)
                return BadRequest("ContactId is required.");

            var businessId = User.GetBusinessId();
            await _inboxService.MarkMessagesAsReadAsync(businessId, contactId);
            return Ok();
        }
        [HttpGet("unread-counts")]
        public async Task<IActionResult> GetUnreadCounts()
        {
            var userId = User.GetUserId();
            var businessId = User.GetBusinessId();

            var counts = await _inboxService.GetUnreadCountsForUserAsync(businessId, userId);
            return Ok(counts);
        }

    }
}
