using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.StaffPersonPositionServices
{
    internal interface IStaffPersonPositionDataCaptureService
    {
        public Task CreateAsync(ConsumerStaffPersonPositionDTO staffPerson);
        public Task DeleteAsync(Guid filmId, Guid staffPersonId, Guid positionId);
    }
}
