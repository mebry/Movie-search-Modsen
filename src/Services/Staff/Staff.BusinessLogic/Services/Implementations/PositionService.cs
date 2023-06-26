using Mapster;
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messages.StaffMessages;
using Staff.BusinessLogic.DTOs;
using Staff.BusinessLogic.Exceptions;
using Staff.BusinessLogic.Services.Interfaces;
using Staff.DataAccess.Entities;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.BusinessLogic.Services.Implementations
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PositionService> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public PositionService(IUnitOfWork unitOfWork, ILogger<PositionService> logger, IPublishEndpoint publishEndpoint)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<ResponsePositionDTO> CreateAsync(RequestPositionDTO requestPositionDTO)
        {
            var id = new Guid();

            var mapperPosition = requestPositionDTO.Adapt<Position>();

            mapperPosition.Id = id;

            await _unitOfWork.PositionRepository.CreateAsync(mapperPosition);

            var responseModel = mapperPosition.Adapt<ResponsePositionDTO>();

            var message = new CreatedPositionMessage()
            {
                Id = responseModel.Id,
                Name = responseModel.Name
            };

            await _publishEndpoint.Publish(message);

            await _unitOfWork.SaveChangesAsync();

            return responseModel;
        }

        public async Task<ResponsePositionDTO> GetPositionByIdAsync(Guid id)
        {
            var existingPosition = await _unitOfWork.PositionRepository.GetPositionByIdAsync(id);

            if (existingPosition == null)
            {
                _logger.LogError($"Position with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            var mapperPosition = existingPosition.Adapt<ResponsePositionDTO>();

            return mapperPosition;
        }

        public async Task<IEnumerable<ResponsePositionDTO>> GetPositionsAsync()
        {
            var positions = await _unitOfWork.PositionRepository.GetPositionsAsync();

            if (positions.Count() == 0)
            {
                _logger.LogError("Can't get all positions, there is no data");

                throw new NotFoundException("There is no data");
            }

            var responseModel = positions.Adapt<IEnumerable<ResponsePositionDTO>>();

            return responseModel;
        }
    }
}
