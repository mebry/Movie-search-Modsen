using Reviews.BusinessLogic.DTOs;

namespace Reviews.BusinessLogic.Services.Interfaces
{
    public interface ITypeOfReviewService
    {
        public Task<ResponseTypeOfReviewDTO> CreateAsync(RequestTypeOfReviewDTO typeOfReview);
    }
}
