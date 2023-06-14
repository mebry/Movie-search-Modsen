namespace Film.DataAccess.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<FilmTag> FilmTags { get; set; } = new();
    }
}
