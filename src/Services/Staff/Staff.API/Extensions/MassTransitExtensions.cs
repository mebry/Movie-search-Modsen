using MassTransit;
using Shared.Messages;
using Staff.BusinessLogic.MassTransit.Consumers;
using Staff.DataAccess.Contexts;
using System.Reflection;

namespace Staff.API.Extensions
{
    public static class MassTransitExtensions
    {
        public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration config)
        {
            services.AddMassTransit(x =>
            {
                var assembly = Assembly.GetAssembly(typeof(UpdateAverageRatingMessageConsumer));
                var host = config["RabbitMQ:Host"];
                var virtualHost = config["RabbitMQ:VirtualHost"];
                var username = config["RabbitMQ:Username"];
                var password = config["RabbitMQ:Password"];

                x.AddEntityFrameworkOutbox<StaffsDbContext>(o =>
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

                    cfg.ReceiveEndpoint(config["RabbitMQ:ReceiveEndpoints:AverageRatingUpdate"], x =>
                    {
                        x.Bind<UpdateAverageRatingMessage>();
                        x.ConfigureConsumer<UpdateAverageRatingMessageConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(config["RabbitMQ:ReceiveEndpoints:CountOfScoresUpdate"], x =>
                    {
                        x.Bind<UpdateCountOfScoresMessage>();
                        x.ConfigureConsumer<UpdateCountOfScoresMessageConsumer>(context);
                    });

                });

            });
        }
    }
}
