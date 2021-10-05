using Domain.Models;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.Title).IsRequired();
                x.HasData(
                    new Movie
                    {
                        Id = 1,
                        Title = "The Avengers",
                        Genre = MovieGenre.Action,
                        Year = 2020,
                        UserId = 1
                    },
                    new Movie
                    {
                        Id = 2,
                        Title = "Superbad",
                        Genre = MovieGenre.Comedy,
                        Year = 2018,
                        UserId = 1
                    },
                    new Movie
                    {
                        Id = 3,
                        Title = "Gone Girl",
                        Genre = MovieGenre.Thriller,
                        Year = 2014,
                        UserId = 1
                    });
            });

            builder.Entity<User>(x =>
            {
                x.HasKey(x => x.Id);
                x.Property(x => x.UserName).IsRequired().HasMaxLength(50);
                x.Property(x => x.FullName).IsRequired().HasMaxLength(50);
                x.Property(x => x.Password).IsRequired();
                x.HasMany(x => x.Movies)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

                x.HasData(
                    new User()
                    {
                        Id = 1,
                        FullName = "Goce Kabov",
                        Password = "123asd",
                        Subscription = Subscription.Default,
                        UserName = "goka"
                    });
            });

           

           

            //builder.Entity<RentedMovie>().HasKey(x => new { x.UserId, x.MovieId });

            //builder.Entity<RentedMovie>()
            //    .HasOne<User>(x => x.User)
            //    .WithMany(x => x.RentedMovies)
            //    .HasForeignKey(x => x.UserId);


            //builder.Entity<RentedMovie>(x =>
            //{
            //    x.HasOne<Movie>(x => x.Movie)
            //    .WithMany(x => x.RentedMovies)
            //    .HasForeignKey(x => x.MovieId);
            //});
        }
    }
}
