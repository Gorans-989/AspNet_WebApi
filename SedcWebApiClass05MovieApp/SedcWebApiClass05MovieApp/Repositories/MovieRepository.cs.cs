using SedcWebApiClass05MovieApp.DomainModels.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SedcWebApiClass05MovieApp.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        public void Add(Movie entity)
        {

            entity.Id = StaticDb.id + 1;
            StaticDb.Movies.Add(entity);
            StaticDb.id++;
        }

        public void Delete(int id)
        {
            Movie movie = GetById(id);
            StaticDb.Movies.Remove(movie);
        }

        public List<Movie> GetAll()
        {
            return StaticDb.Movies;
        }

        public Movie GetById(int id)
        {
            return StaticDb.Movies.SingleOrDefault(movie => movie.Id == id);   
        }

        public void Update(Movie entity)
        {
            Movie movie = GetById(entity.Id);
           
            int indexOfMovie = StaticDb.Movies.IndexOf(movie);
            StaticDb.Movies[indexOfMovie] = entity;
        }
    }
}
