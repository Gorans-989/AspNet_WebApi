using SEDC.NotesApp.Models.DbModels;
using SEDC.NotesApp.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SEDC.NotesApp.DataAccess.AdoNet
{
    public class AdoNetUserRepository : IRepository<User>
    {
        private readonly string _connectionString;
        
        public AdoNetUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(User entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"INSERT INTO [Users] (UserName, Password, FirstName, LastName,)" +
                        $"VALUES(@UserName, @Password,@FirstName, @LastName)";
                    command.Parameters.AddWithValue("@UserName", entity.UserName);
                    command.Parameters.AddWithValue("@Password", entity.Password);
                    command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                    command.Parameters.AddWithValue("@LastName", entity.LastName);
                    command.ExecuteNonQuery();
                }

//                  za multiquery samo prajs anonymous object i pisis UserId = id
//                  from Filip Belevski to everyone: 8:31 PM
//                  string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID; SELECT * FROM InvoiceItem WHERE InvoiceID = @InvoiceID;";
//                  using (var connection = My.ConnectionFactory())
//                  {
//                        connection.Open();
//                      using (var multi = connection.QueryMultiple(sql, new { InvoiceID = 1 }))
//                      {
//                          var invoice = multi.Read<Invoice>().First();
//                          var invoiceItems = multi.Read<InvoiceItem>().ToList();
//                      }
//                  }
            }


        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            List<Note> notes = new List<Note>();   
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [Users]";
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //// prv nacin
                        //User user = new User()
                        //{
                        //    Id = dataReader.GetInt32(0),
                        //    UserName = dataReader.GetString(1),
                        //    Password = dataReader.GetString(2),
                        //    FirstName = dataReader.GetString(3),
                        //    LastName = dataReader.GetString(4)
                        //};
                        //users.Add(user);

                        //Vtor Nacin
                        //User user = new User()
                        //{
                        //    Id = dataReader.GetFieldValue<int>(0),
                        //    UserName = dataReader.GetFieldValue<string>(1),
                        //    Password = dataReader.GetFieldValue<string>(2),
                        //    FirstName = dataReader.GetFieldValue<string>(3),
                        //    LastName = dataReader.GetFieldValue<string>(4)
                        //};
                        //users.Add(user);

                        //Tret nacin
                        User user = new User()
                        {
                            Id = (int)dataReader["Id"],
                            UserName = (string)dataReader["UserName"],
                            Password = (string)dataReader["Password"],
                            FirstName = (string)dataReader["FirstName"],
                            LastName = (string)dataReader["LastName"]
                        };

                        users.Add(user);
                        
                    }
                }

                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [Notes]";
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Note note = new Note()
                        {
                            Id = (int)dataReader["Id"],
                            Text = (string)dataReader["Text"],
                            Color = (string)dataReader["Color"],
                            UserId = (int)dataReader["UserId"],
                            Tag = (int)dataReader["Tag"]
                        };
                        notes.Add(note);
                    }
                }
            }
            foreach (var user in users)
            {
                foreach (var note in notes)
                {
                    if(user.Id == note.Id)
                    {
                        user.Notes.Add(note);
                    }
                }
            }
            return users;
        }

        public User GetById(int id)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                //User user = new User();
                connection.Open();
                
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [Users] WHERE Id = userId";
                    command.Parameters.AddWithValue("UserId", id);
                    
                    SqlDataReader dataReader = command.ExecuteReader();
                    
                    while (dataReader.Read())
                    {
                        user.Id = (int)dataReader["Id"];
                        user.UserName = (string)dataReader["UserName"];
                        user.FirstName = (string)dataReader["FirstName"];
                        user.Password = (string)dataReader["Password"];
                        user.LastName = (string)dataReader["LastName"];
                    };
                
                }
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [Notes] WHERE UserId = @UserId";
                    command.Parameters.AddWithValue("@UserId", user.Id);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Note note = new Note()
                        {
                            Id = (int)dataReader["Id"],
                            Text = (string)dataReader["Text"],
                            Color = (string)dataReader["Color"],
                            UserId = (int)dataReader["UserId"],
                            Tag = (int)dataReader["Tag"]
                        };
                        user.Notes.Add(note);
                    }
                
                }
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
