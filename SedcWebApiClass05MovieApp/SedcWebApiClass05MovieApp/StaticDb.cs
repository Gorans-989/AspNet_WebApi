using SedcWebApiClass05MovieApp.DomainModels.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SedcWebApiClass05MovieApp
{
    public static class StaticDb
    {
        public static int id = 4;

        public static List<Movie> Movies = new List<Movie>()
        {

            new Movie()
            {
                Id = 1,
                Title = "Titanik",
                Description = "Brodot se udri",
                Genre = Genre.Other,
                Year = 1996

            },

            new Movie()
            {
                Id = 2,
                Title = "Rambo",
                Description = "Site gi ubi",
                Genre = Genre.Action,
                Year = 1995

            },

            new Movie()
            {
                Id = 3,
                Title = "Lepi sela lepo gore",
                Description = "Srpski film",
                Genre = Genre.Comedy,
                Year = 1995

            },

            new Movie()
            {
                Id = 4,
                Title = "Interstellar",
                Description = "About Space",
                Genre = Genre.Other,
                Year = 2012

            }


        };


    }
}
