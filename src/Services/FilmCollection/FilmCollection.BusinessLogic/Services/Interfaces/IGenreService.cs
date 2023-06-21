using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;

namespace FilmCollection.BusinessLogic.Services.Interfaces
{
    public interface IGenreService
    {
        Task<GenreResponseDto> CreateGenreAsync(GenreRequestDto genreRequestDto);
        Task DeleteGenreAsync(Guid genreId);
        Task<IEnumerable<GenreResponseDto>> GetAllGenresAsync();
        Task<GenreResponseDto> GetGenreAsync(Guid genreId);
    }
}
