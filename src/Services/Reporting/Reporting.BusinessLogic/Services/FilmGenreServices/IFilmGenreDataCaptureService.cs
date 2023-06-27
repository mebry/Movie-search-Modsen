using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.FilmGenreServices
{
    internal interface IFilmGenreDataCaptureService
    {
        public Task Create(ConsumerFilmGenreDTO filmGenre);
        public Task Delete(Guid filmId, Guid genreId);
    }
}