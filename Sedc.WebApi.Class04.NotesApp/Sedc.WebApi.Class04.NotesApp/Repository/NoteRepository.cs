using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sedc.WebApi.Class04.NotesApp.Models.DbModels;
using Sedc.WebApi.Class04.NotesApp.Repository;

namespace Sedc.WebApi.Class04.NotesApp.Repository
{
    public class NoteRepository : IRepository<Note>
    {
        public void Add(Note entity)
        {
            entity.Id = StaticDb.Notes.Count + 1;
            StaticDb.Notes.Add(entity);
        }

        public List<Note> GetAll()
        {
            return StaticDb.Notes;
        }

        public Note GetById(int id)
        {
            return StaticDb.Notes.FirstOrDefault(note => note.Id == id);
        }

        public void Remove(int id)
        {
            Note note = GetById(id);
           
            StaticDb.Notes.Remove(note);
        }

        public void Update(Note entity)
        {
            Note note = GetById(entity.Id);
            
            int IndexOfCurrentNote = StaticDb.Notes.IndexOf(note);
            StaticDb.Notes[IndexOfCurrentNote] = entity;

        }
    }
}
