using Staff.BusinessLogic.DTOs;

namespace Staff.BusinessLogic.Services.Interfaces
{
    public interface IFilmService
    {
        public Task<ResponseFilmDTO> RemoveFilmAsync(Guid id);
        public Task<ResponseFilmDTO> CreateAsync(RequestFilmDTO film);
        public Task<ResponseFilmDTO> UpdateAsync(Guid id, RequestFilmDTO film);
        public Task<ResponseFilmDTO> GetFilmByIdAsync(Guid id);
    }
}
