using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.PositionServices
{
    internal interface IPositionDataCaptureService
    {
        public Task Create(ConsumerPositionDTO entity);
        public Task Update(ConsumerPositionDTO entity);
        public void DeleteAsync(Guid id);
    }
}
