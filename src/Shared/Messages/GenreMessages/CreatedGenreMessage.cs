namespace Shared.Messages.GenreMessages
{
    public class CreatedGenreMessage
    {
        /// <summary>
        /// The Id of the genre.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Name of the genre.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
