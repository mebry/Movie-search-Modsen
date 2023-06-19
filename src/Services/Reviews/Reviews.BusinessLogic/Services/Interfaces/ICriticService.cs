using Reviews.BusinessLogic.DTOs;

namespace Reviews.BusinessLogic.Services.Interfaces
{
    public interface ICriticService
    {
        public Task<ResponseCriticDTO> CreateAsync(RequestCriticDTO critic);
        public Task<ResponseCriticDTO> UpdateAsync(Guid id, RequestCriticDTO critic);
        public Task<ResponseCriticDTO> RemoveCriticAsync(Guid criticId);
        public Task<ResponseCriticDTO> GetByIdAsync(Guid id);
    }
}
