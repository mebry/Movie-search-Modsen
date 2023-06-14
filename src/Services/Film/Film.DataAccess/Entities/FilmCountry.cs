namespace Film.DataAccess.Entities
{
    public class FilmCountry
    {
        public Guid FilmId { get; set; }

        public Film Film { get; set; }

        public int CountryId { get; set; }
    }
}
