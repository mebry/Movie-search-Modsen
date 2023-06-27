using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Shared.Enums;

namespace Reporting.BusinessLogic.Services.FilmCountryServices
{
    internal interface IFilmCountryDataCaptureService
    {
        public Task CreateAsync(ConsumerFilmCountryDTO filmCountry);
        public Task DeleteAsync(Guid filmId, Countries countryEnum);
    }
}
