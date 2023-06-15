using Authentication.BusinessLogic.Services.Interfaces;
using Authentication.BusinessLogic.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Authentication.API.IdentityServerConfig;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Models;
using Microsoft.OpenApi.Models;

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
            services.ConfigureSwagger();
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
        
        private static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity Service", Version = "v1" });
            });
        }

        private static void ConfigureIdentityServer(this IServiceCollection services)
        {

            services.AddIdentityServer()
                .AddAspNetIdentity<User>()
                .AddInMemoryApiScopes(Configuration.GetApiScopes())
                .AddInMemoryApiResources(Configuration.GetApis())
                .AddInMemoryClients(Configuration.GetClients())
                .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                .AddDeveloperSigningCredential()
                .AddProfileService<ProfileService>();
                
        }
    }
}
