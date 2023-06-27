using MassTransit;
using Rating.BusinessLogic.MassTransit.Consumers;
using Rating.DataAccess.Contexts;
using Shared.Messages.FilmMessages;
using Shared.Messages.RatingMessages;
using System.Reflection;

namespace Rating.WebAPI.Extensions
{
    public static class MassTransitExtensions
    {
        public static void ConfigureMassTransit(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddMassTransit(x =>
            {
                var assembly = Assembly.GetAssembly(typeof(CreateFilmMessageConsumer));
                var host = config["RabbitMQ:Host"];
                var virtualHost = config["RabbitMQ:VirtualHost"];
                var username = config["RabbitMQ:Username"];
                var password = config["RabbitMQ:Password"];

                x.AddEntityFrameworkOutbox<ApplicationContext>(o =>
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

                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
