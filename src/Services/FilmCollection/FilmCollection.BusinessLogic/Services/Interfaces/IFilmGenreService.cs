using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;

namespace FilmCollection.BusinessLogic.Services.Interfaces
{
    public interface IFilmGenreService
    {
        Task<FilmGenreResponseDto> CreateFilmGenreAsync(FilmGenreRequestDto filmGenreRequest);
        Task DeleteFilmGenreAsync(Guid filmId, Guid genreId);
        Task<FilmGenreResponseDto> GetFilmGenreAsync(Guid filmId, Guid genreId);
    }
}
