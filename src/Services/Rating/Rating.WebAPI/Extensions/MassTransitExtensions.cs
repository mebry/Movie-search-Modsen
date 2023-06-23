using MassTransit;
using Rating.DataAccess.Contexts;

namespace Rating.WebAPI.Extensions
{
    public static class MassTransitExtensions
    {
        public static void ConfigureMassTransit(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddMassTransit(x =>
            {
                //var assembly = Assembly.GetAssembly(typeof(UpdateAverageRatingMessage));
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

                //x.AddConsumers(assembly);

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
    }
}
