namespace Shared.Messages
{
    public class UpdateAverageRatingMessage
    {
        public Guid FilmId { get; set; }
        public double AverageRating { get; set; }
    }
}