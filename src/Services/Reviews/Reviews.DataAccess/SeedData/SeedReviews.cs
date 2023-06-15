using Reviews.DataAccess.Entities;

namespace Reviews.DataAccess.SeedData
{
    public static class SeedReviews
    {
        public static TypeOfReview PositiveTypeOfReview { get; } = new() { Id = Guid.NewGuid(), Name = "Positive" };
        public static TypeOfReview NegativeTypeOfReview { get; } = new() { Id = Guid.NewGuid(), Name = "Negative" };
        public static TypeOfReview NeutralTypeOfReview { get; } = new() { Id = Guid.NewGuid(), Name = "Neutral" };
    }
}
