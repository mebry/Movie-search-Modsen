using Mapster;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Repositories.GenreRepositories;
using Reporting.DataAccess.Repositories.PositionRepositories;
using Shared.Exceptions;

namespace Reporting.BusinessLogic.Services.PositionServices
{
    internal class PositionService : IPositionDataCaptureService, IPositionReportingService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly ILogger<PositionService> _logger;

        public PositionService(IPositionRepository positionRepository, ILogger<PositionService> logger)
        {
            _positionRepository = positionRepository;
            _logger = logger;
        }

        public async Task Create(ConsumerPositionDTO entity)
        {
            var mapperModel = entity.Adapt<Position>();
            _positionRepository.Create(mapperModel);

            await _positionRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingPosition = await _positionRepository.GetByIdAsync(id);

            if(existingPosition is null)
            {
                _logger.LogError("The position was not found");

                throw new NotFoundException("The position was not found");
            }

            _positionRepository.Delete(id);

            await _positionRepository.SaveChangesAsync();
        }

        public async Task Update(ConsumerPositionDTO entity)
        {
            var existingPosition = await _positionRepository.GetByIdAsync(entity.Id);

            if(existingPosition is null)
            {
                _logger.LogError("The position was not found");

                throw new NotFoundException("The position was not found");
            }

            entity.Adapt(existingPosition);
            _positionRepository.Update(existingPosition);

            await _positionRepository.SaveChangesAsync();
        }
    }
}
