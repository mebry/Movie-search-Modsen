using Reporting.BusinessLogic.DTOs.ConsumerDTOs;
using Shared.Enums;

namespace Reporting.BusinessLogic.Services.FilmCountryServices
{
    internal interface IFilmCountryDataCaptureService
    {
        public Task Create(ConsumerFilmCountryDTO filmCountry);
        public Task Delete(Guid filmId, Countries countryEnum);
    }
}
