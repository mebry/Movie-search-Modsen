using FilmCollection.DataAccess.Models;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.ServiceValidators.Interfaces
{
    public interface IFilmCountryServiceValidator
    {
        Task CheckIfAssociationBetweenBaseFilmInfoAndCountryDoesntExistsAndGetAsync(Countries countryId, Guid baseFilmInfoId);
        Task<FilmCountry> CheckIfAssociationBetweenBaseFilmInfoAndCountryExistsAndGetAsync(Countries countryId, Guid baseFilmInfoId, bool trackChanges);
    }
}
