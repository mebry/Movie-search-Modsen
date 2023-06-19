using Film.BusinessLogic.Services.Implementations;
using Film.BusinessLogic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
