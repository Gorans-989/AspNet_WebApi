using Sedc.WebApi.Class04.NotesApp.Helpers.Mappers;
using Sedc.WebApi.Class04.NotesApp.Models.DbModels;
using Sedc.WebApi.Class04.NotesApp.Models.DtoModels;
using Sedc.WebApi.Class04.NotesApp.Repository;
using Sedc.WebApi.Class04.NotesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.WebApi.Class04.NotesApp.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepo;
        public NoteService(IRepository<Note> noteRepo)
        {
            _noteRepo = noteRepo;
        }

        public string AddNewNote(NoteDto note)
        {
            Note noteDto = NoteMapper.MapToNote(note);
            _noteRepo.Add(noteDto);
            return "Succesfully created note";
        }

        public List<NoteDto> GetAllNotes()
        {
            return _noteRepo.GetAll().Select(note => NoteMapper.MapToDboNote(note)).ToList();
        }

        public List<NoteDto> GetAllUserNotes(int userId)
        {
            return _noteRepo.GetAll()
                .Where(note => note.UserId == userId)
                .Select(x => NoteMapper.MapToDboNote(x)).ToList();
        }

        public string RemoveNote(int noteId)
        {
            Note note = _noteRepo.GetById(noteId);
            if(note == null) 
            {
                throw new Exception("No such Note to remove. From noteService");
            
            }
            _noteRepo.Remove(note.Id);
            return "Note Removed. NoteService";
        }

        public string UpdateNote(NoteDto note)
        {
            Note smt = _noteRepo.GetById(note.Id);
            if (smt == null) 
            {
                throw new Exception("No such Note for update. From noteService");
            }
            Note MappedNote = NoteMapper.MapToNote(note);
            _noteRepo.Update(MappedNote);


            return "Note updated. from NoteService";
        }
    }
}
