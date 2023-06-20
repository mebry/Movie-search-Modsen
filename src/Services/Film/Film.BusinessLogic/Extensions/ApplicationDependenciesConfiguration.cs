using Film.BusinessLogic.DTOs.RequestDTOs;
using Film.BusinessLogic.ModelValidators.RequestDTOs;
using Film.BusinessLogic.Services.Implementations;
using Film.BusinessLogic.Services.Interfaces;
using FluentValidation;
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

        public static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            return services.AddScoped<IValidator<AgeRestrictionRequestDTO>, AgeRestrictionRequestDTOValidator>()
                .AddScoped<IValidator<FilmCountryRequestDTO>, FilmCountryRequestDTOValidator>()
                .AddScoped<IValidator<FilmGenreRequestDTO>, FilmGenreRequestDTOValidator>()
                .AddScoped<IValidator<FilmRequestDTO>, FilmRequestDTOValidator>()
                .AddScoped<IValidator<FilmTagRequestDTO>, FilmTagRequestDTOValidator>()
                .AddScoped<IValidator<GenreRequestDTO>, GenreRequestDTOValidator>()
                .AddScoped<IValidator<PositionRequestDTO>, PositionRequestDTOValidator>()
                .AddScoped<IValidator<StaffPersonPositionRequestDTO>, StaffPersonPositionRequestDTOValidator>()
                .AddScoped<IValidator<StaffPersonRequestDTO>, StaffPersonRequestDTOValidator>()
                .AddScoped<IValidator<TagRequestDTO>, TagRequestDTOValidator>();
        }
    }
}
