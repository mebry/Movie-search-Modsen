namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for StaffPerson responses.
    /// </summary>
    public class StaffPersonResponseDTO
    {
        /// <summary>
        /// The Id of the person
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the staff person.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The surname of the staff person.
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// The URL of the staff person's image.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// The list of positions associated with this person.
        /// </summary>
        public List<PositionResponseDTO> Positions { get; set; } = new();
    }
}
