using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reviews.DataAccess.Contexts;
using Reviews.DataAccess.Repositories.Implementations;
using Reviews.DataAccess.Repositories.Interfaces;

namespace Reviews.DataAccess.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void AddDataAccessService(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddConfigurationMSSQLServer(configuration);
            service.AddRepositoriesService();
        }

        private static void AddConfigurationMSSQLServer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ReviewsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Reviews.DataAccess")));
        }

        private static void AddRepositoriesService(this IServiceCollection service)
        {
            service.AddScoped<ICriticRepository, CriticRepository>();
            service.AddScoped<IReviewRepository, ReviewRepository>();
            service.AddScoped<ITypeOfReviewRepository, TypeOfReviewRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
