using Mapster;
using Microsoft.Extensions.Logging;
using Reviews.BusinessLogic.DTOs;
using Reviews.BusinessLogic.Exceptions;
using Reviews.BusinessLogic.Services.Interfaces;
using Reviews.DataAccess.Entities;
using Reviews.DataAccess.Repositories.Interfaces;

namespace Reviews.BusinessLogic.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReviewService> _logger;

        public ReviewService(IUnitOfWork unitOfWork, ILogger<ReviewService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ResponseReviewDTO> CreateAsync(RequestReviewDTO review)
        {
            var id = Guid.NewGuid();
            var mapperReview = review.Adapt<Review>();
            mapperReview.Id = id;

            await _unitOfWork.ReviewRepository.CreateAsync(mapperReview);
            await _unitOfWork.SaveChangesAsync();

            var resonseModel = mapperReview.Adapt<ResponseReviewDTO>();

            return resonseModel;
        }

        public async Task<IEnumerable<ResponseReviewDTO>> GetAllByCriticIdAsync(Guid criticId)
        {
            var reviews = await _unitOfWork.ReviewRepository.GetAllByCriticIdAsync(criticId);

            if (reviews.Count() == 0)
            {
                _logger.LogError($"Reviews with critic ID '{criticId}' not found.");

                throw new NotFoundException("There is no data");
            }

            var mapperReviews = reviews.Adapt<IEnumerable<ResponseReviewDTO>>();

            return mapperReviews;
        }

        public async Task<IEnumerable<ResponseReviewDTO>> GetAllByFilmIdAndTypeAsync(Guid filmId, Guid typeOfReviewId)
        {
            var reviews = await _unitOfWork.ReviewRepository.GetAllByFilmIdAndTypeAsync(filmId, typeOfReviewId);

            if (reviews.Count() == 0)
            {
                _logger.LogError($"Reviews with film ID '{filmId}' and typeOfReview ID '{typeOfReviewId}' not found.");

                throw new NotFoundException("There is no data");
            }

            var mapperReviews = reviews.Adapt<IEnumerable<ResponseReviewDTO>>();

            return mapperReviews;
        }

        public async Task<IEnumerable<ResponseReviewDTO>> GetAllByFilmIdAsync(Guid filmId)
        {
            var reviews = await _unitOfWork.ReviewRepository.GetAllByFilmIdAsync(filmId);

            if (reviews.Count() == 0)
            {
                _logger.LogError($"Reviews with film ID '{filmId}' not found.");

                throw new NotFoundException("There is no data");
            }

            var mapperReviews = reviews.Adapt<IEnumerable<ResponseReviewDTO>>();

            return mapperReviews;
        }

        public async Task<ResponseReviewDTO> RemoveReviewAsync(Guid id)
        {
            var existingReview = await _unitOfWork.ReviewRepository.GetByIdAsync(id);

            if (existingReview == null)
            {
                _logger.LogError($"Review with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            _unitOfWork.ReviewRepository.RemoveReview(existingReview);

            await _unitOfWork.SaveChangesAsync();

            var responseModel = existingReview.Adapt<ResponseReviewDTO>();

            return responseModel;
        }

        public async Task<ResponseReviewDTO> UpdateAsync(Guid id, RequestReviewDTO review)
        {
            var existingReview = await _unitOfWork.ReviewRepository.GetByIdAsync(id);

            if (existingReview == null)
            {
                _logger.LogError($"Review with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            var mapperReview = review.Adapt<Review>();
            mapperReview.Id = id;
            _unitOfWork.ReviewRepository.Update(mapperReview);

            await _unitOfWork.SaveChangesAsync();

            var responseModel = mapperReview.Adapt<ResponseReviewDTO>();

            return responseModel;
        }
    }
}
