using Microsoft.Extensions.DependencyInjection;
using Rating.DataAccess.Contexts;
using Rating.DataAccess.Repositories.FilmRepositories;
using Rating.DataAccess.Repositories.RaitingRepositories;

namespace Rating.DataAccess.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddDataAccessService(this IServiceCollection service)
        {
            service.AddDbContext<ApplicationContext>();
            service.AddRepositoriesService();
        }

        private static void AddRepositoriesService(this IServiceCollection service)
        {
            service.AddScoped<IFilmRepository, FilmRepository>();
            service.AddScoped<IRatingFilmRepository, RatingFilmRepository>();
        }
    }
}
