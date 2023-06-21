using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.ModelValidators.RequestDTOs;
using Film.BusinessLogic.Services.Implementations;
using Film.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Film.BusinessLogic.Extensions
{
    public static class ApplicationDependenciesConfiguration
    {
        public static IServiceCollection ConfigureBusinessLogicServices(this IServiceCollection services)
        {
            return services.AddScoped<IAgeRestrictionService, AgeRestrictionService>()
                .AddScoped<IFilmCountryService, FilmCountryService>()
                .AddScoped<IFilmGenreService, FilmGenreService>()
                .AddScoped<IFilmService, FilmService>()
                .AddScoped<IFilmTagService, FilmTagService>()
                .AddScoped<IGenreService, GenreService>()
                .AddScoped<ITagService, TagService>();
        }

        public static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            return services.AddValidatorsFromAssemblyContaining<TagRequestDTOValidator>();
        }

        public static IServiceCollection ConfigureMappers(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);

            return services;
        }
    }
}
