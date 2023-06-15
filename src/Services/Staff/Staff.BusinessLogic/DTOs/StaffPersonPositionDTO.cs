namespace Staff.BusinessLogic.DTOs
{
    public class StaffPersonPositionDTO
    {
        public Guid StaffPersonId { get; set; }
        public ResponsePositionDTO Position { get; set; }
        public ResponseFilmDTO Film { get; set; }
    }
}
