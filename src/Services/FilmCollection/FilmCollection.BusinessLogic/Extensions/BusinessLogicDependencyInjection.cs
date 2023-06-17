using FilmCollection.BusinessLogic.Services.Implementations;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FilmCollection.BusinessLogic.Validators.RequestValidators;
using FilmCollection.BusinessLogic.Validators.ServiceValidators.Implementations;
using FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces;
using FluentValidation;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Extensions
{
    public static class BusinessLogicDependencyInjection
    {
        public static void ConfigureBusinessLogic(this IServiceCollection services)
        {
            services.ConfigureServices();
            services.ConfigureServiceValidators();
            services.ConfigureFluentValidation();
            services.ConfigureMappings();
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseFilmInfoService, BaseFilmInfoService>();
            services.AddScoped<ICollectionService, CollectionService>();
            services.AddScoped<IFilmCollectionService, FilmCollectionService>();
            services.AddScoped<IFilmCountryService, FilmCountryService>();
            services.AddScoped<IFilmGenreService, FilmGenreService>();  
            services.AddScoped<IGenreService, GenreService>();
        }

        private static void ConfigureServiceValidators(this IServiceCollection services)
        {
            services.AddScoped<IBaseFilmInfoServiceValidator, BaseFilmInfoServiceValidator>();
            services.AddScoped<ICollectionServiceValidator, CollectionServiceValidator>();
            services.AddScoped<IFilmCollectionServiceValidator, FilmCollectionServiceValidator>();
            services.AddScoped<IFilmCountryServiceValidator, FilmCountryServiceValidator>();
            services.AddScoped<IFilmGenreServiceValidator, FilmGenreServiceValidator>();
            services.AddScoped<IGenreServiceValidator, GenreServiceValidator>();
        }

        private static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CollectionRequestDtoValidator>();
        }

        private static void ConfigureMappings(this IServiceCollection services)
        {
            services.AddScoped<IMapper, ServiceMapper>(); 
        }
    }
}
