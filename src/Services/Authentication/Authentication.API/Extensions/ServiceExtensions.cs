using Authentication.BusinessLogic.Services.Interfaces;
using Authentication.BusinessLogic.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Authentication.API.IdentityServerConfig;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Models;

namespace Authentication.API.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureAPI(this IServiceCollection services) 
        {
            services.ConfigureCors();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddControllers();
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
                .AddAspNetIdentity<User>()
                .AddInMemoryApiResources(Configuration.GetApis())
                .AddInMemoryClients(Configuration.GetClients())
                .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                .AddDeveloperSigningCredential();
                
        }
    }
}
