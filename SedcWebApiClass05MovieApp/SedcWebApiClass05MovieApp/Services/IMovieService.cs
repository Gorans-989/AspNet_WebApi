using SedcWebApiClass05MovieApp.DomainModels.DbModels;
using SedcWebApiClass05MovieApp.DomainModels.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SedcWebApiClass05MovieApp.Services
{
    public interface IMovieService
    {
        List<MovieDto> GetAllMovies();
        MovieDto GetById(int id);
        List<MovieDto> GetByGenre(Genre genre);
        void Add(MovieDto entity);
        void Delete(int id);
        void Update(MovieDto entity);



    }
}
