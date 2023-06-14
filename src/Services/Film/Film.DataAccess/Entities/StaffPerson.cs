namespace Film.DataAccess.Entities
{
    public class StaffPerson
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
