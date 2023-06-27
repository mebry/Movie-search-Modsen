namespace Reporting.DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public List<Rating> Ratings { get; set; } = new();
    }
}
