using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Staff.BusinessLogic.Services.Implementations;
using Staff.BusinessLogic.Services.Interfaces;
using Staff.DataAccess.Extensions;

namespace Staff.BusinessLogic.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddBusinessLogicService(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureServices();
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IStaffPersonService, StaffPersonService>();
            services.AddScoped<IStaffPersonPositionService, StaffPersonPositionService>();
        }
    }
}
