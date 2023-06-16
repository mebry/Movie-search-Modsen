using FilmCollection.DataAccess.Contexts;
using FilmCollection.DataAccess.Repositories.Implementations;
using FilmCollection.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Extensions
{
    public static class DataAccessDependencyInjection
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSqlContext(configuration);
            services.ConfigureRepositories();
        }

        private static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FilmCollectionContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        private static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseFilmInfoRepository, BaseFilmInfoRepository>();
            services.AddScoped<ICollectionRepository, CollectionRepository>();
            services.AddScoped<IFilmCollectionRepository, FilmCollectionRepository>();
            services.AddScoped<IFilmCountryRepository, FilmCountryRepository>();
            services.AddScoped<IFilmGenreRepository, FilmGenreRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }
    }
}
