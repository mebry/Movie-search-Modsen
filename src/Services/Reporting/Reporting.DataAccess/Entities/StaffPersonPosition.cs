namespace Reporting.DataAccess.Entities
{
    public class StaffPersonPosition
    {
        public Guid StaffPersonId { get; set; }
        public StaffPerson? StaffPerson { get; set; }
        public Guid PositionId { get; set; }
        public Position? Position { get; set; }
        public Guid FilmId { get; set; }
        public Film? Film { get; set; }
    }
}
