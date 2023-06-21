namespace FilmCollection.DataAccess.Models
{
    public class Collection
    {
        public Guid Id { get; set; }    
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<FilmCollection> FilmCollections { get; set; }
    }
}
