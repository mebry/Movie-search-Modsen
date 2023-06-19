using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Staff.DataAccess.Contexts;
using Staff.DataAccess.Repositories.Implementations;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.DataAccess.Extensions
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
            service.AddDbContext<StaffsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Staff.DataAccess")));
        }
        public static void AddRepositoriesService(this IServiceCollection service)
        {
            service.AddScoped<IFilmRepository, FilmRepository>();
            service.AddScoped<IPositionRepository, PositionRepository>();
            service.AddScoped<IStaffPersonRepository, StaffPersonRepository>();
            service.AddScoped<IStaffPersonPositionRepository, StaffPersonPositionRepository>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
