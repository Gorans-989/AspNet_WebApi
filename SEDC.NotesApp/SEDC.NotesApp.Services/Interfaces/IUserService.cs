using SEDC.NotesApp.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(int id);
        void Create(UserDto User);
        void Update(UserDto User);
        void Delete(int id);

    }
}
