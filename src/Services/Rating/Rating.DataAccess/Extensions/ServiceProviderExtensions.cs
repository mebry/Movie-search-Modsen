using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rating.DataAccess.Contexts;
using Rating.DataAccess.Entities;
using Rating.DataAccess.Repositories.FilmRepositories;
using Rating.DataAccess.Repositories.RaitingRepositories;
using Rating.DataAccess.Validators;

namespace Rating.DataAccess.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddDataAccessService(this IServiceCollection service)
        {
            service.AddDbContext<ApplicationContext>();
            service.AddRepositoriesService();

            service.AddScoped<IValidator<Film>, FilmValidator>();
            service.AddScoped<IValidator<RatingFilm>, RatingFilmValidator>();
        }

        private static void AddRepositoriesService(this IServiceCollection service)
        {
            service.AddScoped<IFilmRepository, FilmRepository>();
            service.AddScoped<IRatingFilmRepository, RatingFilmRepository>();
        }
    }
}
