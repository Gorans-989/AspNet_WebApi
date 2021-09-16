using Sedc.WebApi.Class04.NotesApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.WebApi.Class04.NotesApp
{
    public static class StaticDb
    {
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Id = 1,
                UserName = "pero",
                FirstName = "pero",
                Password = "abc",
                LastName = "Kamber"

            },
            new User()
            {
                Id = 2,
                UserName = "ana",
                FirstName = "Ana",
                Password = "123",
                LastName = "Pivo"
            }
        };
        public static List<Note> Notes = new List<Note>()
        {
            new Note ()
            {
                Id = 1,
                Color = "red",
                Text = "First Note",
                UserId = Users.First().Id,
                Tag = 1,
            },
            new Note ()
            {
                Id = 2,
                Color = "blue",
                Text = "Second Note",
                UserId = 2,
                Tag = 2,
            }



        }; 




    }
}
