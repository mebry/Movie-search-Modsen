using Film.BusinessLogic.Extensions;
using Film.DataAccess.Extensions;
using Microsoft.AspNetCore.Mvc;

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
            builder.Services.AddFilmDatabase(builder.Configuration)
            .AddRepositories()
            .ConfigureValidators()
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
            });

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
    }
}
