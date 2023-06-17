using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.DTOs.RequestDTOs
{
    public class FilmCollectionRequestDto
    {
        public Guid CollectionId { get; set; }
        public Guid BaseFilmInfoId { get; set; }
    }
}
