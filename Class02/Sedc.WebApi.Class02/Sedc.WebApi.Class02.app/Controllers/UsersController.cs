using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.WebApi.Class02.app.Controllers
{
    [Route("api/[controller]")] // api/users = [controller] go dobiva imeto od controllerot ( vo ovoj slucaj USER )
    [ApiController]
    public class UsersController : ControllerBase //koga nasleduva od ControllerBase znaci deka e API controller.
                                                  // obicen kontroler nasleduva od Controller ( bidejki vrakja view )
    {
        private readonly List<User> Users = new List<User>()
            {
                new User()
                {
                    UserName = "Bob",
                    Id = 1,
                    Age = 23
                },
                new User()
                {
                    UserName = "Pero",
                    Id = 2,
                    Age = 29
                },
                new User()
                {
                    UserName = "Ana",
                    Id = 3,
                    Age = 18
                }
            };

        [HttpGet]
        [Route("all")]//one way
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(Users);
        }


        [HttpGet("{id}")]
        //[Route("{id}")]// second way
        public ActionResult<User> GetUserById(int id)
        {
            if(id == 0)
            {
                //one way to return status code 
                //return NotFound( new { 
                //    msg = "no such user with id = 0",
                //    sugestion = 1
                //});

                //second way to return status code
                //return StatusCode(StatusCodes.Status404NotFound, new{
                //    msg = "no such user with id = 0",
                //    sugestion = 1
                //});

                return StatusCode(StatusCodes.Status400BadRequest, "ne e vo red");
            };
            
            User someUser = Users.FirstOrDefault(user => user.Id == id);
            if(someUser == null) 
            {
                return NotFound();
            }
            return Ok(someUser);



        }

        [HttpGet("{userId}/class/{classId}")]
        public string GetSomething(int userId, int classId)
        {
            return $"User: {userId}, class:{classId}";
        }

        //[HttpPost]
        //public ActionResult<string> PostSomething()
        //{
        //    using StreamReader reader = new StreamReader(Request.Body);
        //    string bodyReaquest = reader.ReadToEnd();
        //    return bodyReaquest;
        //}

        [HttpPost]
        public ActionResult<int> PostSmt2([FromBody] User pero)
        {
            int id = Users.Count + 1;
            pero.Id = id;
            return StatusCode(StatusCodes.Status201Created, id);
        }


    }
}
