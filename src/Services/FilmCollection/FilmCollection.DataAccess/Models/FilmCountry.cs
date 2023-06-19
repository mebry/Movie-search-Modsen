using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Models
{
    public class FilmCountry
    {
        public Guid BaseFilmInfoId { get; set; }    
        public BaseFilmInfo BaseFilmInfo { get; set; }
        public Countries CountryId { get; set; }
    }
}
