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
            var existingPosition = await _ratingRepository.GetByIdAsync(id);

            if(existingPosition is null)
            {
                _logger.LogError("The rating was not found");

                throw new NotFoundException("The rating was not found");
            }

            _ratingRepository.Delete(id);

            await _ratingRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ConsumerRatingDTO entity)
        {
            var existingPosition = await _ratingRepository.GetByIdAsync(entity.Id);

            if(existingPosition is null)
            {
                _logger.LogError("The rating was not found");

                throw new NotFoundException("The rating was not found");
            }

            entity.Adapt(existingPosition);
            _ratingRepository.Update(existingPosition);

            await _ratingRepository.SaveChangesAsync();
        }
    }
}
