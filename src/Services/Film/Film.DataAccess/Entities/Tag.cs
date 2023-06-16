namespace Film.DataAccess.Entities
{
    /// <summary>
    /// Represents a tag that can be associated with films.
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// The unique identifier of the tag.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the tag.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The list of film tags associated with this tag.
        /// </summary>
        public List<FilmTag> FilmTags { get; set; } = new();
    }
}
