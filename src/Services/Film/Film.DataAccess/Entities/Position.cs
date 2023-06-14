namespace Film.DataAccess.Entities
{
    public class Position
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<StaffPersonPosition> StaffPersonPositions { get; set; } = new();
    }
}
