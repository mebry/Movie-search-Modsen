namespace Reporting.DataAccess.Entities
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? FilmId { get; set; }
        public Film? Film { get; set; }
        public int Score { get; set; }
    }
}
