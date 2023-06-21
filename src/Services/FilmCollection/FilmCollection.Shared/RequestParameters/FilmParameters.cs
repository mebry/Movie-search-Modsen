using Shared.Enums;

namespace FilmCollection.Shared.RequestParameters
{
    public class FilmParameters : RequestParameters
    {
        public FilmParameters() 
        {
            OrderBy = "title";
        }

        public string SearchTerm { get; set; }
        public Guid GenreId { get; set; }
        public Countries CountryId { get; set; } 
        public Guid CollectionId { get; set; }
        public uint MinReleaseYear { get; set; } = 1;
        public uint MaxReleaseYear { get; set; } = (uint)(DateTime.Now.Year + 10);

    }
}
