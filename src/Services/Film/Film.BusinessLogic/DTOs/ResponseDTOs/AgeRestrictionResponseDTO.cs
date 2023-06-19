namespace Film.BusinessLogic.DTOs.ResponseDTOs
{
    /// <summary>
    /// Data transfer object for AgeRestriction responses.
    /// </summary>
    public class AgeRestrictionResponseDTO
    {
        /// <summary>
        /// The Id of the age restriction.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The age value for the AgeRestriction.
        /// </summary>
        public int Age { get; set; }
    }
}
