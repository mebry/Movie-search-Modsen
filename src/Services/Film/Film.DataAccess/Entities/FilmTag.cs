namespace Film.DataAccess.Entities
{
    public class FilmTag
    {
        public Guid FilmId { get; set; }

        public Film Film { get; set; }

        public Guid TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
