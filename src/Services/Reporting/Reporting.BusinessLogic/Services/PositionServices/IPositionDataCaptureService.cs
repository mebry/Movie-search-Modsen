using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.PositionServices
{
    internal interface IPositionDataCaptureService
    {
        public Task CreateAsync(ConsumerPositionDTO entity);
        public Task UpdateAsync(ConsumerPositionDTO entity);
        public Task DeleteAsync(Guid id);
    }
}
