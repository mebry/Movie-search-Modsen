using Microsoft.Extensions.DependencyInjection;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Repositories.FilmCountryRepositories;
using Reporting.DataAccess.Repositories.FilmGenreRepositories;
using Reporting.DataAccess.Repositories.FilmRepositories;
using Reporting.DataAccess.Repositories.GenreRepositories;
using Reporting.DataAccess.Repositories.PositionRepositories;
using Reporting.DataAccess.Repositories.RatingRepositories;
using Reporting.DataAccess.Repositories.StaffPersonPositironRepositories;
using Reporting.DataAccess.Repositories.StaffPersonRepositories;
using Reporting.DataAccess.Repositories.UserRepository;

namespace Reporting.DataAccess.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddDataAccessService(this IServiceCollection service)
        {
            service.AddDbContext<ReportingContext>();
            service.AddRepositoriesService();
        }

        private static void AddRepositoriesService(this IServiceCollection service)
        {
            service.AddScoped<IFilmRepository, FilmRepository>();
            service.AddScoped<IGenreRepository, GenreRepository>();
            service.AddScoped<IPositionRepository, PositionRepository>();
            service.AddScoped<IRatingRepository, RatingRepository>();
            service.AddScoped<IStaffPersonRepository, StaffPersonRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IFilmCountryRepository, FilmCountryRepository>();
            service.AddScoped<IFilmGenreRepository, FilmGenreRepository>();
            service.AddScoped<ISatffPersonPositionRepository, SatffPersonPositionRepository>();
        }
    }
}
