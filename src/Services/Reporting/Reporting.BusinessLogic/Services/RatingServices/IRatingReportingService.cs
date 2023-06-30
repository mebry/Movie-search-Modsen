using Reporting.BusinessLogic.DTOs.ResponseDTOs;

namespace Reporting.BusinessLogic.Services.RatingServices
{
    public interface IRatingReportingService
    {
        public Task<ResponseGroupNumberOfFilmsByRating> GetResponseGroupNumberOfFilmsByRating(Guid userId);
    }
}
