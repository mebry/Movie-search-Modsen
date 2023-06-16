using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Models
{
    public class BaseFilmInfo
    {
        public Guid Id { get; set; }
        public string Tiltle { get; set; }
        public string PosterUrl { get; set; }   
        public DateOnly ReleaseDate { get; set; }   
        public TimeSpan Duration { get; set; }
        public double AverageRating { get; set; }
        public int CountOfScores { get; set; }  
        public ICollection<FilmCollection> Collections { get; set;}
    }
}
