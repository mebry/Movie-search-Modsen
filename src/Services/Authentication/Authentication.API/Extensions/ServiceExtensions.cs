using Authentication.BusinessLogic.Services.Interfaces;
using Authentication.BusinessLogic.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Authentication.API.IdentityServerConfig;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Models;
using Microsoft.OpenApi.Models;
using MassTransit;
using DataAccess.Contexts;

namespace Authentication.API.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureAPI(this IServiceCollection services, IConfiguration configuration) 
        {
            services.ConfigureCors();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddControllers();
            services.ConfigureIdentityServer();
            services.ConfigureSwagger();
            services.ConfigureMassTransit(configuration);
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

        private static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMassTransit(x =>
            {
                var host = configuration["RabbitMq:Host"];
                var virtualHost = configuration["RabbitMq:VirtualHost"];
                var username = configuration["RabbitMq:Username"];
                var password = configuration["RabbitMq:Password"];

                x.AddEntityFrameworkOutbox<AuthContext>(o =>
                {
                    o.UseSqlServer();

                    o.QueryDelay = TimeSpan.FromSeconds(1);

                    o.UseBusOutbox();
                });

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(host, virtualHost, h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });
                });
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
