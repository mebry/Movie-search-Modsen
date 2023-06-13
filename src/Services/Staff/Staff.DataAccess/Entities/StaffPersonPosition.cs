namespace Staff.DataAccess.Entities
{
    public class StaffPersonPosition
    {
        public int StaffPersonId { get; set; }
        public StaffPerson StaffPerson { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
