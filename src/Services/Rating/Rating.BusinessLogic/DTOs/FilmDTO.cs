namespace Rating.BusinessLogic.DTOs
{
    public class FilmDTO
    {
        public Guid Id { get; set; }
        public double AverageRating { get; set; }
        public int CountOfScores { get; set; }
    }
}
