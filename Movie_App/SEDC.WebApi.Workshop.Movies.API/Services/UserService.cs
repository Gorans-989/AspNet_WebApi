
using DataAccess.Interfaces;
using Domain.Enums;
using Domain.Models;
using DtoModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Helpers;
using Services.Interfaces;
using Shared.Mappers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IOptions<AppSettings> _options;
        public UserService(IUserRepository repo, IOptions<AppSettings> options)
        {
            _repo = repo;
            _options = options;
        }

        public void Create(RegisterModel entity)
        {
            if (string.IsNullOrEmpty(entity.UserName))
            {
                throw new Exception("name can't be null or empty");
            }
            _repo.Create(new User()
            {
                UserName = entity.UserName,
                Password = entity.Password,
                FullName = entity.FirstName + " " + entity.LastName,
                Subscription = Subscription.Default

            }); 
            
        }

        public void Delete(int id)
        {
            if(_repo.GetById(id) == null)
            {
                throw new Exception("user doesn't exist");
            }
            _repo.Delete(id);
        }

        public List<UserDto> GetAll()
        {
            var users = _repo.GetAll().Select(x => x.ToUserDto()).ToList();
            if(users == null)
            {
                throw new Exception("there are currently no users in the database");
            }
            return users;
        }

        public UserDto GetById(int id)
        {
            var user = _repo.GetById(id).ToUserDto();
            if(user == null)
            {
                throw new Exception($"There's no user with id {id}");
            }
            return user;
        }

        public void Update(UserDto entity)
        {
            _repo.Update(entity.ToUser());
        }
        //public void WatchMovie(RentAMovieDto dto)
        //{
        //    _repo.WatchMovie(dto.MovieId, dto.UserId);

        //}

        public UserDto Authenticate ( string userName, string password)
        {
            User user = _repo.GetAll().SingleOrDefault(u => u.UserName == userName && u.Password == password);
            if(user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{user.FullName}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userModel = new UserDto() 
            { 
                Id = user.Id,
                FullName = user.FullName,
                Subscription = user.Subscription,
                UserName = user.UserName,
                Token = tokenHandler.WriteToken(token)
            };
            return userModel;

        }
    }
}
