using Mapster;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Repositories.PositionRepositories;
using Reporting.DataAccess.Repositories.RatingRepositories;
using Shared.Exceptions;

namespace Reporting.BusinessLogic.Services.RatingServices
{
    internal class RatingService : IRatingDataCaptureService, IRatingReportingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ILogger<RatingService> _logger;

        public RatingService(IRatingRepository ratingRepository, ILogger<RatingService> logger)
        {
            _ratingRepository = ratingRepository;
            _logger = logger;
        }

        public async Task CreateAsync(ConsumerRatingDTO entity)
        {
            var mapperModel = entity.Adapt<Rating>();
            _ratingRepository.Create(mapperModel);

            await _ratingRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingRating = await _ratingRepository.GetByIdAsync(id);

            if(existingRating is null)
            {
                _logger.LogError("The rating was not found");

                throw new NotFoundException("The rating was not found");
            }

            _ratingRepository.Delete(id);

            await _ratingRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ConsumerRatingDTO entity)
        {
            var existingRating = await _ratingRepository.GetByIdAsync(entity.Id);

            if(existingRating is null)
            {
                _logger.LogError("The rating was not found");

                throw new NotFoundException("The rating was not found");
            }

            entity.Adapt(existingRating);
            _ratingRepository.Update(existingRating);

            await _ratingRepository.SaveChangesAsync();
        }
    }
}
