﻿using Microsoft.AspNetCore.Mvc;
using xbytechat.api.CRM.Dtos;
using xbytechat.api.CRM.Interfaces;
using xbytechat.api.Helpers; // For ResponseResult
using xbytechat.api.Shared;  // For GetBusinessId extension

namespace xbytechat.api.CRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody] NoteDto dto)
        {
            try
            {
                var businessId = HttpContext.User.GetBusinessId();
                var result = await _noteService.AddNoteAsync(businessId, dto);
                return Ok(ResponseResult.SuccessInfo("Note created.", result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseResult.ErrorInfo("Error creating note", ex.Message));
            }
        }

        [HttpGet("contact/{contactId}")]
        public async Task<IActionResult> GetNotesByContact(Guid contactId)
        {
            try
            {
                var businessId = HttpContext.User.GetBusinessId();
                var result = await _noteService.GetNotesByContactAsync(businessId, contactId);
                return Ok(ResponseResult.SuccessInfo("Notes loaded.", result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseResult.ErrorInfo("Error fetching notes", ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNoteById(Guid id)
        {
            var businessId = HttpContext.User.GetBusinessId();
            var result = await _noteService.GetNoteByIdAsync(businessId, id);
            if (result == null)
                return NotFound(ResponseResult.ErrorInfo("Note not found."));
            return Ok(ResponseResult.SuccessInfo("Note loaded.", result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(Guid id, [FromBody] NoteDto dto)
        {
            var businessId = HttpContext.User.GetBusinessId();
            var success = await _noteService.UpdateNoteAsync(businessId, id, dto);
            if (!success)
                return NotFound(ResponseResult.ErrorInfo("Note not found."));
            return Ok(ResponseResult.SuccessInfo("Note updated."));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(Guid id)
        {
            var businessId = HttpContext.User.GetBusinessId();
            var success = await _noteService.DeleteNoteAsync(businessId, id);
            if (!success)
                return NotFound(ResponseResult.ErrorInfo("Note not found."));
            return Ok(ResponseResult.SuccessInfo("Note deleted."));
        }
    }
}
