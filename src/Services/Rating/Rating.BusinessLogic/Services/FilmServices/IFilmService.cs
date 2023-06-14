using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Services.FilmServices
{
    public interface IFilmService
    {
        public Task<FilmDTO> CreateAsync(Guid id);
        public Task<FilmDTO?> GetByIdAsync(Guid id);
        public Task<FilmDTO> DeleteAsync(Guid id);
        public Task<FilmDTO> UpdateAsync(FilmDTO model);
    }
}
