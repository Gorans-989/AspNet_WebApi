using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Shared.Exceptions
{
    public class UserException : Exception
    {
        public int? UserId { get; set; }
        //porakata ja predava na objekt od exception klasa. i kje go prikaze kako message :)
        public UserException() : base ("there was problem with user")
        {
            
        }

        public UserException(int? userId)
        {
            UserId = userId;
        }

        public UserException(int? userId, string message): base(message)
        {
            UserId = userId;
        }

    }
}
