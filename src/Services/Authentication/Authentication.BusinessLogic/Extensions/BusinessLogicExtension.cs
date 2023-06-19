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
using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Authentication.BusinessLogic.Validators.RequestValidators;

namespace Authentication.BusinessLogic.Extensions
{
    public static class BusinessLogicExtension
    {

        public static void ConfigureBusinessLogic(this IServiceCollection services)
        {
            services.ConfigureServices();
            services.ConfigureServiceValidators();
            services.AddMappings();
            services.ConfigureFluentValidators();
        }

        private static void ConfigureServiceValidators(this IServiceCollection services)
        {
            services.AddScoped<IUserCheckService, UserCheckService>();
            services.AddScoped<IRoleCheckService, RoleCheckService>();
        }

        private static void ConfigureFluentValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<UserRequestValidator>();
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddScoped<IUserService, UserService>();
        }

        private static void AddMappings(this IServiceCollection services) 
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}
