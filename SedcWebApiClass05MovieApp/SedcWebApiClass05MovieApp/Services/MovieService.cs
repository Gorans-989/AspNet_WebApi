using SedcWebApiClass05MovieApp.DomainModels.DbModels;
using SedcWebApiClass05MovieApp.DomainModels.DtoModels;
using SedcWebApiClass05MovieApp.Helpers.Mappers;
using SedcWebApiClass05MovieApp.Helpers.Validators;
using SedcWebApiClass05MovieApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SedcWebApiClass05MovieApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepo;

        public MovieService(IRepository<Movie> movieRepo)
        {
            _movieRepo = movieRepo;
        }


        public void Add(MovieDto entity)
        {
            Movie movie = MovieMapper.MovieDtoToMovie(entity);
            if(!MovieValidator.ValidateTitle(entity.Title)) 
            {
                throw new Exception("The Title can't be empty.");         
            }
            _movieRepo.Add(movie);
        }

        public void Delete(int id)
        {
            Movie movie = _movieRepo.GetById(id);
            if (movie == null)
            {
                throw new Exception($"No such movie with that ID = {id}");
            }
            _movieRepo.Delete(id);
        }

        public List<MovieDto> GetAllMovies()
        {
            List<Movie> movies = _movieRepo.GetAll();
            List<MovieDto> moviesDto = movies.Select(movie => MovieMapper.MovieToMovieDto(movie)).ToList(); 
            return moviesDto;
        }

        public List<MovieDto> GetByGenre(Genre genre)
        {
            List<Movie> movies = _movieRepo.GetAll();
            return movies.Where(movie => movie.Genre == genre)
                                             .Select(x => MovieMapper.MovieToMovieDto(x)).ToList();
        }

        public MovieDto GetById(int id)
        {
            Movie movie = _movieRepo.GetById(id);
            if(movie == null)
            {
                throw new Exception("No movie by that id");
            }

            return MovieMapper.MovieToMovieDto(movie);
        }

        public void Update(MovieDto entity)
        {
            Movie movie = _movieRepo.GetById(entity.Id);
            if (movie == null)
            {
                throw new Exception("No such movie with that ID ");
            }
            if (!MovieValidator.ValidateTitle(movie.Title))
            {

                throw new Exception("Title cant be empty.");
            }
            Movie smt = MovieMapper.MovieDtoToMovie(entity);
            _movieRepo.Update(smt);

        }
    }
}
