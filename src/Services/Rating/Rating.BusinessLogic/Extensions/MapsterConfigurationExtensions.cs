using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Rating.BusinessLogic.Extensions
{
    internal static class MapsterConfigurationExtensions
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
        }
    }
}
