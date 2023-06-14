using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rating.BusinessLogic.Services.FilmServices;
using Rating.BusinessLogic.Services.RatingServices;
using Rating.DataAccess.Extensions;

namespace Rating.BusinessLogic.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddBusinessLogicService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataAccessService(configuration);

            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IFilmService, FilmService>();
        }
    }
}
