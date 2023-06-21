using Shared.Enums;

namespace FilmCollection.DataAccess.Models
{
    public class FilmCountry
    {
        public Guid BaseFilmInfoId { get; set; }    
        public BaseFilmInfo BaseFilmInfo { get; set; }
        public Countries CountryId { get; set; }
    }
}
