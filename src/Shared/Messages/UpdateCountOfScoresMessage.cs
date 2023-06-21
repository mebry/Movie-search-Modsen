namespace Shared.Messages
{
    public class UpdateCountOfScoresMessage
    {
        public Guid FilmId { get; set; }
        public int CountOfScores { get; set; }
    }
}
