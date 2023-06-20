using Hangfire;
using Rating.BusinessLogic.Services.EventDecisionServices;

namespace Rating.API.Extensions
{
    public static class HangfireExtensions
    {
        public static void ConfigureHagfire(this IServiceCollection services, IConfiguration config)
        {
            services.AddHangfire(configuration => configuration
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(config.GetConnectionString("DefaultConnection")));

            services.AddHangfireServer();
        }

        public static IApplicationBuilder UseHangfireRecurringJobs(this IApplicationBuilder app, IConfiguration config)
        {
            var jobScheduler = app.ApplicationServices.GetService<IRecurringJobManager>();

            var scope = app.ApplicationServices.CreateScope();
            var eventDecisionService = scope.ServiceProvider.GetService<IEventDecisionService>();

            jobScheduler.AddOrUpdate(
                "everyHour",
                () => eventDecisionService!.DecisionToSendCountOfScoresShortChangEventAsync(),
                config["Hangfire:UpdateEveryHour:Schedule"]);

            jobScheduler.AddOrUpdate(
                "everyMonth",
                () => eventDecisionService!.DecisionToSendCountOfScoresLongChangEventAsync(),
                 config["Hangfire:UpdateEveryMonth:Schedule"]);

            return app;
        }
    }
}
