using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Staff.DataAccess.Contexts;

namespace Staff.DataAccess.Extensions
{
    public static class DatabaseConfigurationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<StaffsDbContext>();
            dbContext?.Database.Migrate();
        }
    }
}
