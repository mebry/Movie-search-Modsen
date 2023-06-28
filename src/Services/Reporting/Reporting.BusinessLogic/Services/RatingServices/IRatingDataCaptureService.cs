using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.RatingServices
{
    internal interface IRatingDataCaptureService
    {
        public Task CreateAsync(ConsumerRatingDTO entity);
        public Task UpdateAsync(ConsumerRatingDTO entity);
        public Task DeleteAsync(Guid id);
    }
}
