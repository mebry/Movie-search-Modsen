using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Services.Interfaces
{
    public interface IFilmGenreService
    {
        Task<FilmGenreResponseDto> CreateFilmGenreAsync(FilmGenreRequestDto filmGenreRequest);
        Task DeleteFilmGenreAsync(FilmGenreRequestDto filmGenreRequestDto);
        Task<FilmGenreResponseDto> GetFilmGenreAsync(Guid filmId, Guid genreId);
    }
}
