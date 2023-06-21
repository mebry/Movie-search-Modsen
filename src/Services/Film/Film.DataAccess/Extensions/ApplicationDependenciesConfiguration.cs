﻿using Film.DataAccess.Contexts;
using Film.DataAccess.Repositories.Implementations;
using Film.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Film.DataAccess.Extensions
{
    public static class ApplicationDependenciesConfiguration
    {
        public static IServiceCollection AddFilmDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FilmContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(FilmContext).Assembly.FullName)));
            
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IAgeRestrictionRepository, AgeRestrictionRepository>()
                .AddScoped<IFilmCountryRepository, FilmCountryRepository>()
                .AddScoped<IFilmGenreRepository, FilmGenreRepository>()
                .AddScoped<IFilmRepository, FilmRepository>()
                .AddScoped<IFilmTagRepository, FilmTagRepository>()
                .AddScoped<IGenreRepository, GenreRepository>()
                .AddScoped<IPositionRepository, PositionRepository>()
                .AddScoped<IStaffPersonPositionRepository, StaffPersonPositionRepository>()
                .AddScoped<IStaffPersonRepository, StaffPersonRepository>()
                .AddScoped<ITagRepository, TagRepository>();
        }
    }
}
