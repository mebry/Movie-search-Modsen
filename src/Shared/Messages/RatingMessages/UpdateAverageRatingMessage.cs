namespace Shared.Messages.RatingMessages
{
    public class UpdateAverageRatingMessage
    {
        public Guid FilmId { get; set; }
        public double AverageRating { get; set; }
    }
}