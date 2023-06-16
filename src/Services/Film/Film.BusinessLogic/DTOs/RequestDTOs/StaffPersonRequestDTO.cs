namespace Film.BusinessLogic.DTOs.RequestDTOs
{
    /// <summary>
    /// Data transfer object for StaffPerson requests.
    /// </summary>
    public class StaffPersonRequestDTO
    {
        /// <summary>
        /// The name of the staff person.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The surname of the staff person.
        /// </summary>
        public string Surname { get; set; } = string.Empty;
    }
}
