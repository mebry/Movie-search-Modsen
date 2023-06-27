using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Reporting.DataAccess.Extensions
{
    public static class DatabaseConfigurationExtensions
    {
        public static void ApplyMigrations<TDbContext>(this IApplicationBuilder app)
            where TDbContext : DbContext
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<TDbContext>();
            dbContext?.Database.Migrate();
        }
    }
}
