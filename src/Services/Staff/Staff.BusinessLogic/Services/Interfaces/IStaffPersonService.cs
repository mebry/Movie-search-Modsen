using Staff.BusinessLogic.DTOs;

namespace Staff.BusinessLogic.Services.Interfaces
{
    public interface IStaffPersonService
    {
        public Task<IEnumerable<ResponseStaffPersonDTO>> GetStaffAsync();
        public Task<ResponseStaffPersonDTO> GetStaffPersonByIdAsync(Guid id);
        public Task<ResponseStaffPersonDTO> CreateAsync(RequestStaffPersonDTO staffPerson);
        public Task<ResponseStaffPersonDTO> UpdateAsync(Guid staffPersonId, RequestStaffPersonDTO staffPerson);
    }
}
