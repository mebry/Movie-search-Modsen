namespace Reporting.BusinessLogic.DTOs.ResponseDTOs
{
    public class ResponseStaffPersonPositionsInFilms
    {
        public Guid StaffPersonId { get; set; }
        public Dictionary<ResponsePosition, List<ResponseFilm>> PositionFilms { get; set; } = new();
    }
}
