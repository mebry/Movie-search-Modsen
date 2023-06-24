namespace Reporting.DataAccess.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<FilmGenre> FilmGenres { get; set; } = new();
    }
}
