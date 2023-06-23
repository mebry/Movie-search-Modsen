using DataAccess.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extensions
{
    public static class MigrationExtension
    {
        public static async Task ApplyMigrationAsync(this IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();

            var dbContext = scope.ServiceProvider.GetService<AuthContext>();
            await dbContext?.Database.MigrateAsync();
        }
    }
}
