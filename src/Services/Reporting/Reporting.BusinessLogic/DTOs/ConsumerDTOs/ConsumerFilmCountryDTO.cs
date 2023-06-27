using Shared.Enums;

namespace Reporting.BusinessLogic.DTOs.ConsumerDTOs
{
    public class ConsumerFilmCountryDTO
    {
        public Guid FilmId { get; set; }
        public Countries CountryId { get; set; }
    }
}
