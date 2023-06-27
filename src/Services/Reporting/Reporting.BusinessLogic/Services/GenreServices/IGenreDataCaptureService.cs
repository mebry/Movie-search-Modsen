using Reporting.BusinessLogic.DTOs.ConsumerDTOs;

namespace Reporting.BusinessLogic.Services.GenreServices
{
    internal interface IGenreDataCaptureService
    {
        public Task CreateAsync(ConsumerGenreDTO entity);
        public Task UpdateAsync(ConsumerGenreDTO entity);
        public Task DeleteAsync(Guid id);
    }
}
