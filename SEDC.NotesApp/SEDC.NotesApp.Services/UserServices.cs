using SEDC.NotesApp.DtoModels;
using SEDC.NotesApp.Models.DbModels;
using SEDC.NotesApp.Repositories;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Exceptions;
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
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                throw new BadRequestException("User name or PAssword are required");
            }
            User newUser = user.ToUser();
            _userRepo.Add(newUser);
        }

        public void Delete(int id)
        {
            User user = _userRepo.GetById(id);
            if (user == null)
            {

                throw new UserException(id, "Bad Id, No such user found.");
            }
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
            User userDb = _userRepo.GetById(user.Id);
            if (userDb == null)
            {

                throw new UserException(user.Id, "Bad Id, No user found to update.");
            }
            _userRepo.Update(user.ToUser());


        }
    }
}
