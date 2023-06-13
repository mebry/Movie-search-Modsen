using Authentication.BusinessLogic.Services.Interfaces;
using Authentication.BusinessLogic.Services.Implementations;

namespace Authentication.API.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureAPI(this IServiceCollection services) 
        {
            services.ConfigureCors();
            services.ConfigureLoggerService();
        }

        private static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        private static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerService, LoggerService>();
    }
}
