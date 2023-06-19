using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
