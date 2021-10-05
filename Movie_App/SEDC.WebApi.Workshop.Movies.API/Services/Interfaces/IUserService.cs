using DtoModels;
using System.Collections.Generic;


namespace Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(int id);
        void Delete(int id);
        void Create(RegisterModel entity);
        void Update(UserDto entity);
        //void WatchMovie(RentAMovieDto dto);
        UserDto Authenticate(string userName, string password);
    }
}
