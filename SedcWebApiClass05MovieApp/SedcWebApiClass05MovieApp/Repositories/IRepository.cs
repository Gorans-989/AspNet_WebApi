using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SedcWebApiClass05MovieApp.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        //T GetByGenre(T entity);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);

    }

//    
//create new movie
//get movie by id
//get all movies
//get movie by genre
}
