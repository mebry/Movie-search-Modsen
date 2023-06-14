namespace Staff.BusinessLogic.DTOs
{
    public class StaffPersonPositionDTO
    {
        public Guid StaffPersonId { get; set; }
        public PositionDTO Position { get; set; }
        public FilmDTO Film { get; set; }
    }
}
