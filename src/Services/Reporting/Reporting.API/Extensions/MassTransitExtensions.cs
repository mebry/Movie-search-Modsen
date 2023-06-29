using MassTransit;
using Reporting.BusinessLogic.Extensions;
using Reporting.DataAccess.Contexts;
using System.Reflection;

namespace Reporting.API.Extensions
{
    public static class MassTransitExtensions
    {
        public static void ConfigureMassTransit(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddMassTransit(x =>
            {

                var assembly = Assembly.GetAssembly(typeof(ServiceProviderExtensions));
                var host = config["RabbitMQ:Host"];
                var virtualHost = config["RabbitMQ:VirtualHost"];
                var username = config["RabbitMQ:Username"];
                var password = config["RabbitMQ:Password"];

                x.AddEntityFrameworkOutbox<ReportingContext>(o =>
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
