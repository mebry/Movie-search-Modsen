namespace FilmCollection.DataAccess.Models
{
    public class BaseFilmInfo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PosterURL { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        public double AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
        public ICollection<FilmCollection> FilmCollections { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
        public ICollection<FilmCountry> FilmCountries { get; set; }
    }
}
