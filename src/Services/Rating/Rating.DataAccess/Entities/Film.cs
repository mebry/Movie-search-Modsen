namespace Rating.DataAccess.Entities
{
    public class Film
    {
        public Guid Id { get; set; }
        public double AverageRating { get; set; } = 1;
        public uint CountOfScores { get; set; }
        public uint OldCountOfScores { get; set; }
        public List<RatingFilm> RatingFilms { get; set; } = new();
    }
}
