using Film.DataAccess.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Film.DataAccess.Extensions
{
    public static class DatabaseMigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<FilmContext>();
            dbContext?.Database.Migrate();
        }
    }
}
