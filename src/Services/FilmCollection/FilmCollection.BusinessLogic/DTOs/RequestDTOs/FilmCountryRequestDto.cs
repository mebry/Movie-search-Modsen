using Shared.Enums;

namespace FilmCollection.BusinessLogic.DTOs.RequestDTOs
{
    public class FilmCountryRequestDto
    {
        public Guid BaseFilmInfoId { get; set; }
        public Countries CountryId { get; set; }
    }
}
