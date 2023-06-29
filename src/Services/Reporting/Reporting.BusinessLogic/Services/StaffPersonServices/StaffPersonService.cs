using Mapster;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.BusinessLogic.DTOs.ResponseDTOs;
using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Repositories.StaffPersonPositironRepositories;
using Reporting.DataAccess.Repositories.StaffPersonRepositories;
using Shared.Exceptions;

namespace Reporting.BusinessLogic.Services.StaffPersonServices
{
    internal class StaffPersonService : IStaffPersonDataCaptureService, IStaffPersonReportingService
    {
        private readonly IStaffPersonRepository _staffPersonRepository;
        private readonly IStaffPersonPositionRepository _staffPersonPositionRepository;
        private readonly ILogger<StaffPersonService> _logger;

        public StaffPersonService(IStaffPersonRepository staffPersonRepository,
            IStaffPersonPositionRepository staffPersonPositionRepository, ILogger<StaffPersonService> logger)
        {
            _staffPersonRepository = staffPersonRepository;
            _staffPersonPositionRepository = staffPersonPositionRepository;
            _logger = logger;
        }

        public async Task CreateAsync(ConsumerStaffPersonDTO entity)
        {
            var mapperModel = entity.Adapt<StaffPerson>();
            _staffPersonRepository.Create(mapperModel);

            await _staffPersonRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingStaffPerson = await _staffPersonRepository.GetByIdAsync(id);

            if(existingStaffPerson is null)
            {
                _logger.LogError("The staff person was not found");

                throw new NotFoundException("The staff person was not found");
            }

            _staffPersonRepository.Delete(id);

            await _staffPersonRepository.SaveChangesAsync();
        }

        public async Task<ResponseStaffPersonPositionsInFilms> GetAllPositionsInFIlms(Guid staffPersonId)
        {
            var existingStaffPerson = await _staffPersonRepository.GetByIdAsync(staffPersonId);

            if(existingStaffPerson is null)
            {
                _logger.LogError("The staff person was not found");

                throw new NotFoundException("The staff person was not found");
            }

            var positionFilms = await _staffPersonPositionRepository.GetAllByStaffPersonId(staffPersonId);

            var dictionaryPositionFilms = new Dictionary<ResponsePosition, List<ResponseFilm>>();

            positionFilms.GroupBy(
                    s => s.Position,
                    s => s.Film,
                    (key, f) => new { StaffPersonPosition = key, Films = f.ToList() })
                .ToList()
                .ForEach(s =>
                {
                    var position = s.StaffPersonPosition!.Adapt<ResponsePosition>();
                    var films = s.Films.Adapt<IEnumerable<ResponseFilm>>()
                                        .ToList();

                    dictionaryPositionFilms.Add(position, films);
                });

            var responseStaffPersonPositionsInFilms = new ResponseStaffPersonPositionsInFilms()
            {
                StaffPersonId = staffPersonId,
                PositionFilms = dictionaryPositionFilms
            };

            return responseStaffPersonPositionsInFilms;
        }

        public async Task UpdateAsync(ConsumerStaffPersonDTO entity)
        {
            var existingStaffPerson = await _staffPersonRepository.GetByIdAsync(entity.Id);

            if(existingStaffPerson is null)
            {
                _logger.LogError("The staff person was not found");

                throw new NotFoundException("The staff person was not found");
            }

            entity.Adapt(existingStaffPerson);
            _staffPersonRepository.Update(existingStaffPerson);

            await _staffPersonRepository.SaveChangesAsync();
        }
    }
}
