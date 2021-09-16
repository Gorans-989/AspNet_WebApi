using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SedcWebApiClass05MovieApp.DomainModels.DbModels;
using SedcWebApiClass05MovieApp.DomainModels.DtoModels;
using SedcWebApiClass05MovieApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SedcWebApiClass05MovieApp.Controllers
{
    [Route("api/[controller]")] //localhost/api/movies
    [ApiController]


    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public ActionResult<List<MovieDto>> GetAll([FromQuery] Genre genre)
        {
            try
            {
                if(genre == 0) 
                {
                    return Ok(_movieService.GetAllMovies());
                }
                return Ok(_movieService.GetByGenre(genre));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
            
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]  // /api/movies/ ?id=
        public ActionResult<MovieDto> GetByID(int id)
        {
            try
            {
              return Ok(_movieService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }


        // POST api/<MovieController>
        [HttpPost]  //add 
        public ActionResult Post([FromBody] MovieDto movieDto)
        {
            try
            {
                _movieService.Add(movieDto);
                return StatusCode(StatusCodes.Status201Created, new { Message = "Movie created successfully" });            

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MovieController>/5
        [HttpPut("update")] // api/movies/update
        public ActionResult Put([FromBody] MovieDto movieDto)
        {
            try
            {
                _movieService.Update(movieDto);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")] //api/movies/
        public ActionResult Delete(int id)
        {
            try
            {
                _movieService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}
