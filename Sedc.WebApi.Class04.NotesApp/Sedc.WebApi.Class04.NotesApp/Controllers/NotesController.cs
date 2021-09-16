using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sedc.WebApi.Class04.NotesApp.Models.DtoModels;
using Sedc.WebApi.Class04.NotesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.WebApi.Class04.NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet] //api/notes
        public ActionResult<List<NoteDto>> GetAllNotes() 
        {
            try
            {
                return Ok(_noteService.GetAllNotes());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message});
            }
        }

        [HttpGet("user/{id}")] // api.notes.user/?id=...
        public ActionResult<List<NoteDto>> GetAllUserNotes (int id)
        {
            try
            {
                List<NoteDto> UserNotes = _noteService.GetAllUserNotes(id);
                return Ok(UserNotes);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpPost("addNewNote")]
        public ActionResult<string> AddNewNote([FromBody] NoteDto newNote)
        {
            try
            {
                string result = _noteService.AddNewNote(newNote);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteNote/{id}")]
        public ActionResult<string> RemoveNote (int id) 
        {
            try
            {
                string result = _noteService.RemoveNote(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public ActionResult<string> UpdateNote([FromBody] NoteDto noteDto) 
        {
            try
            {
                string result = _noteService.UpdateNote(noteDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
