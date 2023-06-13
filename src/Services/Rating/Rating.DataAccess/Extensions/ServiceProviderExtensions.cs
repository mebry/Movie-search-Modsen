using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rating.DataAccess.Contexts;
using Rating.DataAccess.Repositories.FilmRepositories;
using Rating.DataAccess.Repositories.RaitingRepositories;

namespace Rating.DataAccess.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddDataAccessService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddConfigurationMSSQLServer(configuration);

            service.AddRepositoriesService();
        }

        private static void AddConfigurationMSSQLServer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Raiting.DataAccess")));
        }

        private static void AddRepositoriesService(this IServiceCollection service)
        {
            service.AddScoped<IFilmRepository, FilmRepository>();
            service.AddScoped<IRatingFilmRepository, RatingFilmRepository>();
        }
    }
}
