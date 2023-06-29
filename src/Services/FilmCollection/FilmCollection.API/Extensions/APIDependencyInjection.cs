using Microsoft.AspNetCore.Mvc;
using MassTransit;
using FilmCollection.DataAccess.Contexts;
using System.Reflection;
using FilmCollection.BusinessLogic.MassTransit.Consumers.RatingMessageConsumers;
using Shared.Extensions;

namespace FilmCollection.API.Extensions
{
    public static class APIDependencyInjection
    {
        public static void ConfigureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureCors();
            services.AddControllers();
            services.ConfigureMassTransit(configuration);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.ConfigureSwagger(configuration);
            services.ConfigureVersioning();
        }

        private static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"));
            });
        }

        private static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }
        
        private static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                var assembly = Assembly.GetAssembly(typeof(UpdateAverageRatingMessageConsumer));
                var host = configuration["RabbitMq:Host"];
                var virtualHost = configuration["RabbitMq:VirtualHost"];
                var username = configuration["RabbitMq:Username"];
                var password = configuration["RabbitMq:Password"];

                x.AddEntityFrameworkOutbox<FilmCollectionContext>(o =>
                {
                    o.UseSqlServer();

                    o.QueryDelay = TimeSpan.FromSeconds(1);

                    o.UseBusOutbox();
                });

                x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("FilmCollection", false));

                x.AddConsumers(assembly);

                x.UsingRabbitMq((context, cfg) =>
                {

                    cfg.Host(host, virtualHost, h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
