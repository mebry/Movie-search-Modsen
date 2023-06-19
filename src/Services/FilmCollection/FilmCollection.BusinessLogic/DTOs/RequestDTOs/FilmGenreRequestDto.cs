using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.DTOs.RequestDTOs
{
    public class FilmGenreRequestDto
    {
        public Guid GenreId { get; set; }
        public Guid BaseFilmInfoId { get; set; }
    }
}
