using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public MovieGenre Genre { get; set; }
        public int UserId { get; set; }//FK
        public virtual User User{ get; set; }
    }
}