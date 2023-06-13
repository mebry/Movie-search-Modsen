using Authentication.BusinessLogic.Services.Interfaces;
using Authentication.BusinessLogic.Services.Implementations;
using Authentication.API.IdentityServerConfig;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.API.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureAPI(this IServiceCollection services) 
        {
            services.ConfigureCors();
            services.ConfigureLoggerService();
            services.ConfigureIdentityServer();
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
        
        private static void ConfigureIdentityServer(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryApiResources(Configuration.GetApis())
                .AddInMemoryClients(Configuration.GetClients())
                .AddDeveloperSigningCredential();
                
        }


        private static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerService, LoggerService>();
    }
}
