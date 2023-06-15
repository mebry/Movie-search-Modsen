using Microsoft.Extensions.DependencyInjection;
using Staff.DataAccess.Repositories.Implementations;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.DataAccess.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureServices(this IServiceCollection service)
        {
            service.AddScoped<IFilmRepository, FilmRepository>();
            service.AddScoped<IPositionRepository, PositionRepository>();
            service.AddScoped<IStaffPersonRepository, StaffPersonRepository>();
            service.AddScoped<IStaffPersonPositionRepository, StaffPersonPositionRepository>();
        }

    }
}
