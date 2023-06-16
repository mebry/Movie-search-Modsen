using DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DataAccess.Contexts;

namespace DataAccess.Extensions
{
    public static class DataAccessExtension
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSqlContext(configuration);
            services.ConfigureIdentity();
        }


        private static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, Role>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<AuthContext>()
                .AddDefaultTokenProviders();
        }

        private static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
            });
        }
    }
}
