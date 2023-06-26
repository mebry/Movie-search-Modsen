namespace Shared.Messages.StaffMessages
{
    public class CreatedStaffPersonPositionMessage
    {
        public Guid StaffPersonId { get; set; }
        public Guid PositionId { get; set; }
        public Guid FilmId { get; set; }
    }
}
