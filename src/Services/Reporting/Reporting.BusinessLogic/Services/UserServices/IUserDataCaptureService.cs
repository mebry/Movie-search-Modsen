using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.UserServices
{
    internal interface IUserDataCaptureService
    {
        public Task CreateAsync(ConsumerUserDTO entity);
        public Task UpdateAsync(ConsumerUserDTO entity);
        public Task DeleteAsync(Guid id);
    }
}
