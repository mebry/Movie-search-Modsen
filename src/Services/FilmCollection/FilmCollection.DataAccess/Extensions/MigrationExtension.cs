using FilmCollection.DataAccess.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Extensions
{
    public static class MigrationExtension
    {
        public static async Task ApplyMigration(this IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();

            var dbContext = scope.ServiceProvider.GetService<FilmCollectionContext>();
            await dbContext?.Database.MigrateAsync();
        }
    }
}
