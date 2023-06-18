using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.DTOs.ResponseDTOs
{
    public class FilmCollectionResponseDto
    {
        public Guid CollectionId { get; set; }
        public Guid BaseFilmInfoId { get; set; }
    }
}
