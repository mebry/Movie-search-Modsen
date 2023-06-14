namespace Film.DataAccess.Entities
{
    /// <summary>
    /// Represents an age restriction for certain content.
    /// </summary>
    public class AgeRestriction
    {
        /// <summary>
        /// The unique identifier of the age restriction.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The minimum age for the content.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// The list of films associated with this age restriction.
        /// </summary>
        public List<FilmModel> Films { get; set; } = new();
    }
}
