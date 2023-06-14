using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Services.RatingServices
{
    public interface IRatingService
    {
        public Task<ResponseRatingDTO> CreateAsync(RequestRatingDTO model);
        public Task<ResponseRatingDTO?> GetByIdAsync(Guid id);
        public Task<ResponseRatingDTO> DeleteAsync(Guid id);
        public Task<ResponseRatingDTO> UpdateAsync(Guid id, RequestRatingDTO model);
    }
}
