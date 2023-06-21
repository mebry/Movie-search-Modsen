using Shared.Enums;

namespace FilmCollection.BusinessLogic.DTOs.ResponseDTOs
{
    public class FilmCountryResponseDto
    {
        public Guid BaseFilmInfoId { get; set; }
        public Countries CountryId { get; set; }
    }
}
