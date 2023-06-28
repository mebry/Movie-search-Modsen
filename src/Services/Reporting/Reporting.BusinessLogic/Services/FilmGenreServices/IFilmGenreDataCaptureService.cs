using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.FilmGenreServices
{
    internal interface IFilmGenreDataCaptureService
    {
        public Task CreateAsync(ConsumerFilmGenreDTO filmGenre);
        public Task DeleteAsync(Guid filmId, Guid genreId);
    }
}