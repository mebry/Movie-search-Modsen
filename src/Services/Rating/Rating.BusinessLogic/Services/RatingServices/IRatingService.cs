using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Services.RatingServices
{
    public interface IRatingService
    {
        public Task<RatingDTO> CreateAsync(RatingDTO model);
        public Task<RatingDTO?> GetByIdAsync(Guid id);
        public Task<RatingDTO> DeleteAsync(RatingDTO model);
        public Task<RatingDTO> UpdateAsync(RatingDTO model);
    }
}
