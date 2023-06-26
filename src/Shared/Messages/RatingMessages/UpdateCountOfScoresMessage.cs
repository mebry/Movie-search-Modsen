namespace Shared.Messages.RatingMessages
{
    public class UpdateCountOfScoresMessage
    {
        public Guid FilmId { get; set; }
        public int CountOfScores { get; set; }
    }
}
