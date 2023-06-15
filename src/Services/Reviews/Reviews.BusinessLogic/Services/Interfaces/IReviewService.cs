using Reviews.BusinessLogic.DTOs;

namespace Reviews.BusinessLogic.Services.Interfaces
{
    public interface IReviewService
    {
        public Task<ResponseReviewDTO> CreateAsync(RequestReviewDTO review);
        public Task<ResponseReviewDTO> UpdateAsync(Guid id, RequestReviewDTO review);
        public Task<ResponseReviewDTO> RemoveReviewAsync(Guid id);
        public Task<IEnumerable<ResponseReviewDTO>> GetAllByFilmIdAsync(Guid filmId);
        public Task<IEnumerable<ResponseReviewDTO>> GetAllByCriticIdAsync(Guid criticId);
        public Task<IEnumerable<ResponseReviewDTO>> GetAllByFilmIdAndTypeAsync(Guid filmId, Guid typeOfReviewId);
    }
}
