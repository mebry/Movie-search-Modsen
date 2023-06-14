namespace Film.DataAccess.Entities
{
    public class FilmGenre
    {
        public Guid FilmId { get; set; }

        public Film Film { get; set; }

        public Guid GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
