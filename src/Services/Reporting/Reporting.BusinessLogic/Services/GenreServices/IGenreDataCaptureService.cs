using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.GenreServices
{
    internal interface IGenreDataCaptureService
    {
        public Task Create(ConsumerGenreDTO entity);
        public Task Update(ConsumerGenreDTO entity);
        public Task Delete(Guid id);
    }
}
