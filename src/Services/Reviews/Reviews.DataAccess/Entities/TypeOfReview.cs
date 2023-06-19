namespace Reviews.DataAccess.Entities
{
    public class TypeOfReview
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public ICollection<Review> Reviews { get; set; }
    }
}
