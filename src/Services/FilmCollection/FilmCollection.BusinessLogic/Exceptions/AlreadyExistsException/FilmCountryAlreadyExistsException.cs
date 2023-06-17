using FilmCollection.DataAccess.Models;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException
{
    public class FilmCountryAlreadyExistsException : AlreadyExistsException
    {
        public FilmCountryAlreadyExistsException(Guid baseFilmInfoId, Countries countryId) 
            : base($"Base information about the film with {baseFilmInfoId} id already associated with the country with {countryId} id")
        {
        }
    }
}
