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
    public class StaffPersonPositionService : IStaffPersonPositionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StaffPersonPositionService> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public StaffPersonPositionService(IUnitOfWork unitOfWork, ILogger<StaffPersonPositionService> logger, IPublishEndpoint publishEndpoint)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<StaffPersonPositionDTO> CreateAsync(Guid staffPersonId, Guid positionId, Guid filmId)
        {
            var existingStaffPersonPosition = await _unitOfWork.StaffPersonPositionRepository.GetPosition(positionId, staffPersonId, filmId);

            if (existingStaffPersonPosition != null)
            {
                _logger.LogError($"Staff person position and film already exists.");

                throw new AlreadyExistException("That is already used");
            }

            var staffPersonPosition = new StaffPersonPosition()
            {
                FilmId = filmId,
                PositionId = positionId,
                StaffPersonId = staffPersonId
            };

            await _unitOfWork.StaffPersonPositionRepository.CreateAsync(staffPersonPosition);

            var message = new CreatedStaffPersonPositionMessage()
            {
                StaffPersonId = staffPersonId,
                PositionId = positionId,
                FilmId = filmId
            };

            await _publishEndpoint.Publish(message);

            await _unitOfWork.SaveChangesAsync();

            var response = await _unitOfWork.StaffPersonPositionRepository.GetPosition(positionId, staffPersonId, filmId);

            var responseModel = response.Adapt<StaffPersonPositionDTO>();

            return responseModel;
        }

        public async Task<IEnumerable<ResponseFilmDTO>> GetFilmsByStaffPersonAndPositionAsync(Guid staffPersonId, Guid positionId)
        {
            var films = await _unitOfWork.StaffPersonPositionRepository.GetFilmsByStaffPersonAndPositionAsync(staffPersonId, positionId);

            if (films.Count() == 0)
            {
                _logger.LogError($"Films with staff person ID '{staffPersonId}' and position Id '{positionId}' not found.");

                throw new NotFoundException("There is no data");
            }

            var mapperFilms = films.Adapt<IEnumerable<ResponseFilmDTO>>();

            return mapperFilms;
        }

        public async Task<IEnumerable<ResponsePositionDTO>> GetPositionsByStaffPersonIdAsync(Guid staffPersonId)
        {
            var staffPersonPosition = await _unitOfWork.StaffPersonPositionRepository.GetPositionsByStaffPersonId(staffPersonId);

            if (staffPersonPosition.Count() == 0)
            {
                _logger.LogError($"Staff person position and film with staff person ID '{staffPersonId}' not found.");

                throw new NotFoundException("This id was not found");
            }

            var responseModel = staffPersonPosition.Adapt<IEnumerable<ResponsePositionDTO>>();

            return responseModel;
        }
    }
}
