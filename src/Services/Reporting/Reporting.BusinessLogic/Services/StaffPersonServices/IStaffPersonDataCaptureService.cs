using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.StaffPersonServices
{
    internal interface IStaffPersonDataCaptureService
    {
        public Task CreateAsync(ConsumerStaffPersonDTO entity);
        public Task UpdateAsync(ConsumerStaffPersonDTO entity);
        public Task DeleteAsync(Guid id);
    }
}
