using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.DTOs.ResponseDTOs
{
    public class FilmGenreResponseDto
    {
        public Guid GenreId { get; set; }
        public Guid BaseFilmInfoId { get; set; }
    }
}
