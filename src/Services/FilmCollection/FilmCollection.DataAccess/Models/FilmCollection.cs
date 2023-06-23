namespace FilmCollection.DataAccess.Models
{
    public class FilmCollection
    {
        public Guid CollectionModelId { get; set; }  
        public CollectionModel CollectionModel { get; set; }
        public Guid BaseFilmInfoId { get; set; }   
        public BaseFilmInfo BaseFilmInfo { get; set; }
    }
}
