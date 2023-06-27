using Mapster;
using Microsoft.Extensions.Logging;
using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Repositories.RatingRepositories;
using Reporting.DataAccess.Repositories.StaffPersonRepositories;
using Shared.Exceptions;

namespace Reporting.BusinessLogic.Services.StaffPersonServices
{
    internal class StaffPersonService : IStaffPersonDataCaptureService, IStaffPersonReportingService
    {
        private readonly IStaffPersonRepository _staffPersonRepository;
        private readonly ILogger<StaffPersonService> _logger;

        public StaffPersonService(IStaffPersonRepository staffPersonRepository, ILogger<StaffPersonService> logger)
        {
            _staffPersonRepository = staffPersonRepository;
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
