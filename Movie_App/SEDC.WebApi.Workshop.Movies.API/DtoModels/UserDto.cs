using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DtoModels
{
    public class UserDto
    {
        public UserDto()
        {
            RentedMovies = new List<MovieDto>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Subscription Subscription { get; set; }
        public string Token { get; set; }
        public List<MovieDto> RentedMovies { get; set; }
    }
}
