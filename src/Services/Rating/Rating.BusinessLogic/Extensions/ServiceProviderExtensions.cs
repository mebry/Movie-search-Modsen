using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Rating.BusinessLogic.DTOs;
using Rating.BusinessLogic.Services.AlgorithmServices;
using Rating.BusinessLogic.Services.EventDecisionServices;
using Rating.BusinessLogic.Services.RatingServices;
using Rating.BusinessLogic.Validators;
using Rating.DataAccess.Extensions;

namespace Rating.BusinessLogic.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddBusinessLogicService(this IServiceCollection services)
        {
            services.AddDataAccessService();
            services.AddServices();
            services.AddValidators();
            services.RegisterMapsterConfiguration();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IEventDecisionService, EventDecisionService>();
            services.AddScoped<IAlgorithmsForEventDecisionService, AlgorithmsForEventDecisionService>();
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<FilmDTO>, FilmDTOValidator>();
            services.AddScoped<IValidator<RequestRatingDTO>, ResponseRatingDTOValidator>();
        }
    }
}
