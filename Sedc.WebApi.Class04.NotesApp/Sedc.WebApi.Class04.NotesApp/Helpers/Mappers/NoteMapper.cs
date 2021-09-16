using Sedc.WebApi.Class04.NotesApp.Models.DbModels;
using Sedc.WebApi.Class04.NotesApp.Models.DtoModels;
using Sedc.WebApi.Class04.NotesApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.WebApi.Class04.NotesApp.Helpers.Mappers
{
    public static class NoteMapper
    {
        public static Note MapToNote(NoteDto noteDto) 
        {
            return new Note()
            {
                Color = noteDto.Color,
                Id = noteDto.Id,
                Text = noteDto.Text,
                UserId = noteDto.UserId,
                Tag = (int)noteDto.Tag
            };
            
        }

        public static NoteDto MapToDboNote (Note note)
        {
            return new NoteDto()
            {
                Color = note.Color,
                Id = note.Id,
                Text = note.Text,
                UserId = note.UserId,
                Tag = (Tag)note.Tag

            };


        }

    }
}
