using Staff.BusinessLogic.DTOs;

namespace Staff.BusinessLogic.Services.Interfaces
{
    public interface IPositionService
    {
        public Task<IEnumerable<ResponsePositionDTO>> GetPositionsAsync();
        public Task<ResponsePositionDTO> GetPositionByIdAsync(Guid id);
        public Task<ResponsePositionDTO> CreateAsync(RequestPositionDTO requestPositionDTO);
    }
}
