namespace Reviews.DataAccess.Entities
{
    public class Review
    {
        public Guid Id { get; set; }

        public Guid CriticId { get; set; }
        public Critic Critic { get; set; }

        public Guid TypeOfReviewId { get; set; }
        public TypeOfReview TypeOfReview { get; set; }

        public Guid FilmId { get; set; }
        public DateTime DateTimeOfCreation { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}
