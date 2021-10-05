using DataAccess;
using DataAccess.Interfaces;
using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddDbContext<MoviesDbContext>(x => x.UseSqlServer(connectionString));

            return services;
        }
    }
}
