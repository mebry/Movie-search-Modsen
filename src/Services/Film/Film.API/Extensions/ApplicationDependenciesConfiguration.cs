using Film.BusinessLogic.Extensions;
using Film.BusinessLogic.MassTransit.Consumers;
using Film.DataAccess.Contexts;
using Film.DataAccess.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Messages;
using System.Reflection;

namespace Film.API.Extensions
{
    public static class ApplicationDependenciesConfiguration
    {
        /// <summary>
        /// Configures the services required by the application, including database, repositories, 
        /// validators, business logic services, and API versioning.
        /// </summary>
        /// <param name="builder">The WebApplicationBuilder instance.</param>
        /// <returns>The updated WebApplicationBuilder instance.</returns>
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<FilmContext>()
            .AddRepositories()
            .ConfigureValidators()
            .ConfigureMappers()
            .ConfigureBusinessLogicServices()
            .Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddMassTransit(builder.Configuration);

            return builder;
        }

        /// <summary>
        /// Configures Cross-Origin Resource Sharing policy to allow requests from any origin, method, and header.
        /// </summary>
        /// <param name="services">The IServiceCollection instance.</param>
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration config)
        {
            return services.AddMassTransit(x =>
            {
                var assembly = Assembly.GetAssembly(typeof(UpdateAverageRatingMessageConsumer));
                var host = config["RabbitMQ:Host"];
                var virtualHost = config["RabbitMQ:VirtualHost"];
                var username = config["RabbitMQ:Username"];
                var password = config["RabbitMQ:Password"];

                x.AddEntityFrameworkOutbox<FilmContext>(o =>
                {
                    o.UseSqlServer();

                    o.QueryDelay = TimeSpan.FromSeconds(1);

                    o.UseBusOutbox();
                });

                x.AddConsumers(assembly);

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(host, virtualHost, h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });

                    cfg.ReceiveEndpoint(config["RabbitMQ:ReceiveEndpoints:AverageRatingUpdate"]!, x =>
                    {
                        x.Bind<UpdateAverageRatingMessage>();
                        x.ConfigureConsumer<UpdateAverageRatingMessageConsumer>(context);
                    });

                });

            });
        }
    }
}
