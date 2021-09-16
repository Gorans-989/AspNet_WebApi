using Sedc.WebApi.Class04.NotesApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.WebApi.Class04.NotesApp.Models.DtoModels
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public string Color { get; set; }
        public Tag Tag { get; set; }
    }
}
