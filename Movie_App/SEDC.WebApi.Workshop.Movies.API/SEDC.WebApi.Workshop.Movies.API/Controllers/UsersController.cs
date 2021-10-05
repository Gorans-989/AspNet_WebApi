using Domain.Models;
using DtoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Workshop.Movies.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet] //api/users
        public ActionResult<List<UserDto>> GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok(new { Id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]

        public ActionResult Authenticate ([FromBody]LogIn model)
        {
            try
            {
                return Ok(_service.Authenticate(model.UserName, model.Password));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(RegisterModel entity)
        {
            try
            {
                _service.Create(entity);
                return Ok( );
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public ActionResult Update(UserDto entity)
        {
            try
            {
                _service.Update(entity);
                return Ok(new { entity.Id });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //[HttpPost("watch")] 
        //public ActionResult RentMovie([FromBody] RentAMovieDto dto)
        //{
        //    // after authentication/ authorization get the ID from current user somehwo and refactor this
        //    try
        //    {
        //        _service.WatchMovie(dto);
        //        return Ok(new { Message = 2 });
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
