using SEDC.NotesApp.DtoModels;
using SEDC.NotesApp.Models.DbModels;
using SEDC.NotesApp.Repositories;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NotesApp.Services
{
    public class UserServices : IUserService
    {
        private readonly IRepository<User> _userRepo;
        public UserServices(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public void Create(UserDto user)
        {
            User newUser = user.ToUser();
            _userRepo.Add(newUser);
        }

        public void Delete(int id)
        {
            _userRepo.Remove(id);
        }

        public List<UserDto> GetAll()
        {
            return _userRepo.GetAll().Select(x => x.ToUserDto()).ToList();
        }

        public UserDto GetById(int id)
        {
            return _userRepo.GetById(id).ToUserDto();


        }

        public void Update(UserDto user)
        {
            _userRepo.Update(user.ToUser());


        }
    }
}
