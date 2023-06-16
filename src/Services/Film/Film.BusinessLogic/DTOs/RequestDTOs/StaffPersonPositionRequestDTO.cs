namespace Film.BusinessLogic.DTOs.RequestDTOs
{
    /// <summary>
    /// Data transfer object for StaffPersonPosition requests.
    /// </summary>
    public class StaffPersonPositionRequestDTO
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
