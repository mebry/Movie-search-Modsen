using FilmCollection.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Extensions
{
    public static class DataAccessDependencyInjection
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSqlContext(configuration);
        }

        private static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FilmCollectionContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }
    }
}
