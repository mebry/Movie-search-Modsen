using Authentication.BusinessLogic.Services.Implementations;
using Authentication.BusinessLogic.Services.Interfaces;
using Authentication.BusinessLogic.ServiceValidators.Implementations;
using Authentication.BusinessLogic.ServiceValidators.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MapsterMapper;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BusinessLogic.Extensions
{
    public static class BusinessLogicExtension
    {

        public static void ConfigureBusinessLogic(this IServiceCollection services)
        {
            services.ConfigureServices();
            services.ConfigureServiceValidators();
        }

        private static void ConfigureServiceValidators(this IServiceCollection services)
        {
            services.AddScoped<IUserCheckService, UserCheckService>();
            services.AddScoped<IRoleCheckService, RoleCheckService>();
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
