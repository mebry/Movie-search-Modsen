using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Services.FilmServices
{
    public interface IFilmService
    {
        public Task<FilmDTO> CreateAsync(FilmDTO model);
        public Task<FilmDTO?> GetByIdAsync(Guid id);
        public Task<FilmDTO> DeleteAsync(FilmDTO model);
        public Task<FilmDTO> UpdateAsync(FilmDTO model);
    }
}
