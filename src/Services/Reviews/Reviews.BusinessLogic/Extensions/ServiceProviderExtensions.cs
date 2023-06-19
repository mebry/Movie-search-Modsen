using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reviews.BusinessLogic.Services.Implementations;
using Reviews.BusinessLogic.Services.Interfaces;
using Reviews.DataAccess.Extensions;

namespace Reviews.BusinessLogic.Extensions
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
            services.AddScoped<ICriticService, CriticService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ITypeOfReviewService, TypeOfReviewService>();
        }
    }
}
