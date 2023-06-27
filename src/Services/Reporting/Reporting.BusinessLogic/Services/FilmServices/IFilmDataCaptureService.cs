using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.FilmServices
{
    internal interface IFilmDataCaptureService
    {
        public Task Create(ConsumerFilmDTO entity);
        public Task Update(ConsumerFilmDTO entity);
        public Task Delete(Guid id);
    }
}
