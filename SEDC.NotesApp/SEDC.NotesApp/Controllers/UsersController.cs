using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.DtoModels;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public ActionResult<List<UserDto>> Get()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   new { Message = ex.Message });
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            try
            {
                return Ok(_userService.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new { Message = ex.Message });
            }

        }

        // POST api/users
        [HttpPost]
        public ActionResult Post([FromBody] UserDto newUser)
        {
            try
            {
                _userService.Create(newUser);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (BadRequestException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = ex.Message });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new { Message = ex.Message });
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] UserDto user)
        {
            try
            {
                _userService.Update(user);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (UserException ex) 
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new 
                    { 
                        Message = ex.Message,           
                        UserId = ex.UserId 
                    });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new { Message = ex.Message });
            }

        }
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (UserException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new
                    {
                        Message = ex.Message,
                        UserId = ex.UserId
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                   new { Message = ex.Message });
            }
        }
    }
}
