using SedcWebApiClass05MovieApp.DomainModels.DbModels;
using SedcWebApiClass05MovieApp.DomainModels.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SedcWebApiClass05MovieApp.Helpers.Mappers
{
    public static class MovieMapper
    {
        public static Movie MovieDtoToMovie (MovieDto entity) {

            return new Movie()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Year = entity.Year,
                Genre = entity.Genre

            };
        }
        public static MovieDto MovieToMovieDto(Movie entity)
        
        {
            return new MovieDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Year = entity.Year,
                Genre = entity.Genre
            };
        }

    }
}
