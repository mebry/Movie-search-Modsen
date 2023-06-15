namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for StaffPersonPosition responses.
    /// </summary>
    public class StaffPersonPositionResponseDTO
    {
        /// <summary>
        /// The unique identifier of the staff person.
        /// </summary>
        public Guid StaffPersonId { get; set; }

        /// <summary>
        /// The unique identifier of the position.
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// The unique identifier of the film.
        /// </summary>
        public Guid FilmId { get; set; }
    }
}
