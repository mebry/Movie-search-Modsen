namespace FilmCollection.DataAccess.Models
{
    public class FilmCollection
    {
        public Guid CollectionId { get; set; }  
        public CollectionModel Collection { get; set; }
        public Guid BaseFilmInfoId { get; set; }   
        public BaseFilmInfo BaseFilmInfo { get; set; }
    }
}
