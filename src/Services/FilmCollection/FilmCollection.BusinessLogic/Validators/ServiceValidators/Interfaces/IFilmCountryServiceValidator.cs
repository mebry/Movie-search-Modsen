using FilmCollection.DataAccess.Models;
using Shared.Enums;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces
{
    public interface IFilmCountryServiceValidator
    {
        Task CheckIfAssociationBetweenBaseFilmInfoAndCountryDoesntExistsAndGetAsync(Countries countryId, Guid baseFilmInfoId);
        Task<FilmCountry> CheckIfAssociationBetweenBaseFilmInfoAndCountryExistsAndGetAsync(Countries countryId, Guid baseFilmInfoId, bool trackChanges);
    }
}
