using Sedc.WebApi.Class04.NotesApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.WebApi.Class04.NotesApp.Repository
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User entity)
        {
            entity.Id = StaticDb.Users.Count + 1;
            StaticDb.Users.Add(entity);
        }

        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            return StaticDb.Users.FirstOrDefault(note => note.Id == id);
        }

        public void Remove(int id)
        {
            User user = GetById(id);
            if (user == null)
            {
                throw new Exception("no such user to remove");
            };
            StaticDb.Users.Remove(user);
        }

        public void Update(User entity)
        {
            User user = GetById(entity.Id);
            if (user == null)
            {
                throw new Exception("no such user for update");
            };
            int IndexOfCurrentUser = StaticDb.Users.IndexOf(user);
            StaticDb.Users[IndexOfCurrentUser] = entity;
        }
    }
}
