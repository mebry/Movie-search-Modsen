using Microsoft.Extensions.DependencyInjection;
using Reporting.BusinessLogic.Services.FilmCountryServices;
using Reporting.BusinessLogic.Services.FilmGenreServices;
using Reporting.BusinessLogic.Services.FilmServices;
using Reporting.BusinessLogic.Services.GenreServices;
using Reporting.BusinessLogic.Services.PositionServices;
using Reporting.BusinessLogic.Services.RatingServices;
using Reporting.BusinessLogic.Services.StaffPersonPositionServices;
using Reporting.BusinessLogic.Services.StaffPersonServices;
using Reporting.BusinessLogic.Services.UserServices;
using Reporting.DataAccess.Extensions;

namespace Reporting.BusinessLogic.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddBusinessLogicService(this IServiceCollection services)
        {
            services.AddDataAccessService();
            services.AddReportingServices();
            services.AddDataCaptureServices();
            services.RegisterMapsterConfiguration();
        }

        private static void AddReportingServices(this IServiceCollection services)
        {
            services.AddScoped<IFilmReportingService, FilmService>();
            services.AddScoped<IFilmGenreReportingService, FilmGenreService>();
            services.AddScoped<IFilmCountryReportingService, FilmCountryService>();
            services.AddScoped<IGenreReportingService, GenreService>();
            services.AddScoped<IPositionReportingService, PositionService>();
            services.AddScoped<IRatingReportingService, RatingService>();
            services.AddScoped<IStaffPersonReportingService, StaffPersonService>();
            services.AddScoped<IStaffPersonPositionReportingService, StaffPersonPositionService>();
            services.AddScoped<IUserReportingService, UserService>();
        }

        private static void AddDataCaptureServices(this IServiceCollection services)
        {
            services.AddScoped<IFilmDataCaptureService, FilmService>();
            services.AddScoped<IFilmGenreDataCaptureService, FilmGenreService>();
            services.AddScoped<IFilmCountryDataCaptureService, FilmCountryService>();
            services.AddScoped<IGenreDataCaptureService, GenreService>();
            services.AddScoped<IPositionDataCaptureService, PositionService>();
            services.AddScoped<IRatingDataCaptureService, RatingService>();
            services.AddScoped<IStaffPersonDataCaptureService, StaffPersonService>();
            services.AddScoped<IStaffPersonPositionDataCaptureService, StaffPersonPositionService>();
            services.AddScoped<IUserDataCaptureService, UserService>();
        }
    }
}
