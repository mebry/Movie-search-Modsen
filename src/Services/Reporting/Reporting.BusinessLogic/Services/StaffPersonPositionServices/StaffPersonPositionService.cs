using Mapster;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Repositories.FilmRepositories;
using Reporting.DataAccess.Repositories.PositionRepositories;
using Reporting.DataAccess.Repositories.StaffPersonPositironRepositories;
using Reporting.DataAccess.Repositories.StaffPersonRepositories;
using Shared.Exceptions;

namespace Reporting.BusinessLogic.Services.StaffPersonPositionServices
{
    internal class StaffPersonPositionService : IStaffPersonPositionDataCaptureService, IStaffPersonPositionReportingService
    {
        private readonly IStaffPersonPositionRepository _staffPersonPositionRepository;
        private readonly IStaffPersonRepository _staffPersonRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly ILogger<StaffPersonPositionService> _logger;

        public StaffPersonPositionService(IStaffPersonPositionRepository satffPersonPositionRepository,
            IStaffPersonRepository staffPersonRepository, IPositionRepository positionRepository,
            IFilmRepository filmRepository, ILogger<StaffPersonPositionService> logger)
        {
            _staffPersonPositionRepository = satffPersonPositionRepository;
            _staffPersonRepository = staffPersonRepository;
            _positionRepository = positionRepository;
            _filmRepository = filmRepository;
            _logger = logger;
        }

        public async Task CreateAsync(ConsumerStaffPersonPositionDTO staffPerson)
        {
            var existingFilm = await _filmRepository.GetByIdAsync(staffPerson.FilmId);

            if(existingFilm is null)
            {
                _logger.LogError("The film was not found");

                throw new NotFoundException("The film was not found");
            }

            var existingPosition = await _positionRepository.GetByIdAsync(staffPerson.PositionId);

            if(existingPosition is null)
            {
                _logger.LogError("The position was not found");

                throw new NotFoundException("The position was not found");
            }

            var existingStaffPerson = await _staffPersonRepository.GetByIdAsync(staffPerson.StaffPersonId);

            if(existingStaffPerson is null)
            {
                _logger.LogError("The staff person was not found");

                throw new NotFoundException("The staff person was not found");
            }

            var mapperModel = staffPerson.Adapt<StaffPersonPosition>();
            _staffPersonPositionRepository.Create(mapperModel);

            await _staffPersonPositionRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid filmId, Guid staffPersonId, Guid positionId)
        {
            _staffPersonPositionRepository.Delete(filmId, staffPersonId, positionId);

            await _staffPersonPositionRepository.SaveChangesAsync();
        }
    }
}
