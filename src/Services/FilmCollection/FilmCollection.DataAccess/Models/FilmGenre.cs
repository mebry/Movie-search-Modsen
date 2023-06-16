using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Models
{
    public class FilmGenre
    {
        public Guid GenreId { get; set; }   
        public Genre Genre { get; set; }
        public Guid BaseFilmInfoId { get; set; } 
        public BaseFilmInfo BaseFilmInfo { get; set; }
    }
}
