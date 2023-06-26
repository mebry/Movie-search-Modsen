using Shared.Enums;

namespace Reporting.DataAccess.Entities
{
    public class FilmCountry
    {
        public Guid FilmId { get; set; }
        public Film? Film { get; set; }
        public Countries CountryId { get; set; }
    }
}
