using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace FilmCollection.API.Extensions
{
    public static class APIDependencyInjection
    {
        public static void ConfigureAPI(this IServiceCollection services)
        {
            services.ConfigureCors();
            services.AddControllers();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.ConfigureSwagger();
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

        private static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmCollection Service", Version = "v1" });
            });
        }
    }
}
