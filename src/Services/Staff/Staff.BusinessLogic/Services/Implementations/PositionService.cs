using Mapster;
using Microsoft.Extensions.Logging;
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

        public PositionService(IUnitOfWork unitOfWork, ILogger<PositionService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ResponsePositionDTO> CreateAsync(RequestPositionDTO requestPositionDTO)
        {
            var id = new Guid();
            var mapperPosition = requestPositionDTO.Adapt<Position>();
            mapperPosition.Id = id;
            await _unitOfWork.PositionRepository.CreateAsync(mapperPosition);
            await _unitOfWork.SaveChangesAsync();

            var responseModel = mapperPosition.Adapt<ResponsePositionDTO>();

            return responseModel;
        }

        public async Task<ResponsePositionDTO> GetPositionByIdAsync(Guid id)
        {
            var position = await _unitOfWork.PositionRepository.GetPositionByIdAsync(id);

            if (position == null)
            {
                _logger.LogError($"Position with ID '{id}' not found.");

                throw new NotFoundException("This id was not found");
            }

            var mapperPosition = position.Adapt<ResponsePositionDTO>();

            return mapperPosition;
        }

        public async Task<IEnumerable<ResponsePositionDTO>> GetPositionsAsync()
        {
            var position = await _unitOfWork.PositionRepository.GetPositionsAsync();

            if (position.Count() == 0)
            {
                _logger.LogError("Can't get all positions, there is no data");

                throw new NotFoundException("There is no data");
            }

            var positions = position.Adapt<IEnumerable<ResponsePositionDTO>>();

            return positions;
        }
    }
}
