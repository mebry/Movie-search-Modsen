using Microsoft.Extensions.DependencyInjection;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Repositories.FilmRepositories;

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
            service.AddScoped<IRatingFilmRepository, RatingFilmRepository>();
        }
    }
}
