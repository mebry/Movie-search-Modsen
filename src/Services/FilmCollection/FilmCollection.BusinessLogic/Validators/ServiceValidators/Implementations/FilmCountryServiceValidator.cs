using FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException;
using FilmCollection.BusinessLogic.Exceptions.NotFoundException;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Implementations
{
    internal class FilmCountryServiceValidator : IFilmCountryServiceValidator
    {
        private readonly IFilmCountryRepository _filmCountryRepository;

        public FilmCountryServiceValidator(IFilmCountryRepository filmCountryRepository)
        {
            _filmCountryRepository = filmCountryRepository;
        }

        public async Task CheckIfAssociationBetweenBaseFilmInfoAndCountryDoesntExistsAndGetAsync(Countries countryId, Guid baseFilmInfoId)
        {
            var association = await _filmCountryRepository.GetFilmCountryAsync(countryId, baseFilmInfoId, false);
            if (association != null)
                throw new FilmCountryAlreadyExistsException(baseFilmInfoId, countryId);
        }

        public async Task<FilmCountry> CheckIfAssociationBetweenBaseFilmInfoAndCountryExistsAndGetAsync(Countries countryId, Guid baseFilmInfoId, bool trackChanges)
        {
            var association = await _filmCountryRepository.GetFilmCountryAsync(countryId, baseFilmInfoId, trackChanges);
            if(association == null) 
                throw new FilmCountryNotFoundException(baseFilmInfoId, countryId);
            return association;
        }
    }
}
