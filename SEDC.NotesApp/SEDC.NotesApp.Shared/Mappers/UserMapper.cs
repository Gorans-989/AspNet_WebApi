using SEDC.NotesApp.DtoModels;
using SEDC.NotesApp.Helpers.Mappers;
using SEDC.NotesApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NotesApp.Shared.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this UserDto userDto)
        {

            return new User()
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Notes = userDto.Notes.Select(x => NoteMapper.MapNoteDtoToNoteModel(x)).ToList()
            };
        }
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto()
            {
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                Password = user.Password,
                UserName = user.UserName,
                Notes = user.Notes.Select(x => NoteMapper.MapNoteToNoteDtoModel(x)).ToList()
            };
        }
    }
}
