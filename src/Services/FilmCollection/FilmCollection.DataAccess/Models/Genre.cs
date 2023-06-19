using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Models
{
    public class Genre
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
    }
}
