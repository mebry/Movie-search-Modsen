using Hangfire;
using Rating.BusinessLogic.Services.EventDecisionServices;

namespace Rating.API.Extensions
{
    public static class HangfireExtensions
    {
        public static void ConfigureHagfire(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddHangfire(configuration => configuration
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(config.GetConnectionString("DefaultConnection")));

            services.AddHangfireServer();
        }

        public static IApplicationBuilder UseHangfireRecurringJobs(this IApplicationBuilder app)
        {
            var jobScheduler = app.ApplicationServices.GetService<IRecurringJobManager>();

            var scope = app.ApplicationServices.CreateScope();
            var eventDecisionService = scope.ServiceProvider.GetService<IEventDecisionService>();

            jobScheduler.AddOrUpdate(
                "everyHour",
                () => eventDecisionService!.DecisionToSendCountOfScoresShortChangEventAsync(),
                "* 12 * * Mon");

            jobScheduler.AddOrUpdate(
                "everyMonth",
                () => eventDecisionService!.DecisionToSendCountOfScoresLongChangEventAsync(),
                "0 0 12 1 * ?");

            return app;
        }
    }
}
