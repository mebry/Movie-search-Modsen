namespace Staff.DataAccess.Entities
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<StaffPersonPosition> StaffPersonPositions { get; set; }
    }
}
