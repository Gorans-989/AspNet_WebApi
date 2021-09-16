using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sedc.WebApi.Class03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public static List<Note> notes = new List<Note>()
        {
            new Note()
            {
                Text = "firstnote",
                Color = "red",
                Id = 1
            },
            new Note()
            {
                Text = "second note",
                Color = "blue",
                Id = 2
            },

            new Note()
            {
                Text = "third note",
                Color = "red",
                Id = 3
            }

        };

        // GET: api/<NotesController>
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return notes;
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
            try
            {
                if (id < 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                                        new { Message = "Id can't be lower than ZERO" });
                }
                if (id > notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { Message = $"Nothing found by that id: { id }" });
                }
                return StatusCode(StatusCodes.Status200OK, notes.FirstOrDefault(note => note.Id == id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        // POST api/<NotesController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] Note note)
        {
            try
            {
                if (note.Text.Length == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Text field is required" });
                }
                note.Id = notes.Count + 1;
                notes.Add(note);
                return StatusCode(StatusCodes.Status200OK, new { Id = note.Id });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        [HttpGet("text")]
        public ActionResult<List<Note>> GetNoteByText([FromQuery] string text)
        {
            try
            {
                if (text == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { Message = "text lenght is zero. not allowed" });

                }
                return notes.Where(note => note.Text == text).ToList();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        //[HttpPost]
        //public ActionResult<int> Post([FromQuery] Note note)
        //{
        //    try
        //    {
        //        if (note.Text.Length == 0)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Text field is required" });
        //        }
        //        note.Id = notes.Count + 1;
        //        notes.Add(note);
        //        return StatusCode(StatusCodes.Status200OK, new { Id = note.Id });
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        //    }
        //}

        [HttpGet("getsmt")]
        public ActionResult<string> GetSmt([FromHeader(Name ="User-Agent")] string agent,[FromHeader] string token) 
        {
            if (token == null) 
            {

                return StatusCode(StatusCodes.Status401Unauthorized, new { Message = "You are not authorized" });
            }

            return StatusCode(StatusCodes.Status200OK, 
                new { Agent = agent, Message = "succes" });
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
