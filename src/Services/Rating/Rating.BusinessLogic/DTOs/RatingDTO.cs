namespace Rating.BusinessLogic.DTOs
{
    public class RatingDTO
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int FilmId { get; set; }
        public int Score { get; set; }
    }
}
