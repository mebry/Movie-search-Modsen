using Microsoft.OpenApi.Models;

namespace FilmCollection.API.Extensions
{
    public static class APIDependencyInjection
    {
        public static void ConfigureAPI(this IServiceCollection services)
        {
            services.ConfigureCors();
            services.AddControllers();
            services.ConfigureSwagger();
        }

        private static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        private static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity Service", Version = "v1" });
            });
        }
    }
}
