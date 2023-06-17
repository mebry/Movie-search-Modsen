using FilmCollection.DataAccess.Models;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.DTOs.RequestDTOs
{
    public class FilmCountryRequestDto
    {
        public Guid BaseFilmInfoId { get; set; }
        public Countries CountryId { get; set; }
    }
}
