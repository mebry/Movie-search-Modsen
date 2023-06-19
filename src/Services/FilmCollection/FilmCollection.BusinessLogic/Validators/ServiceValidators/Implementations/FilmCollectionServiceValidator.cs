using FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException;
using FilmCollection.BusinessLogic.Exceptions.NotFoundException;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Implementations
{
    internal class FilmCollectionServiceValidator : IFilmCollectionServiceValidator
    {
        private readonly IFilmCollectionRepository _filmCollectionRepository;
        
        public FilmCollectionServiceValidator(IFilmCollectionRepository filmCollectionRepository)
        {
            _filmCollectionRepository = filmCollectionRepository;
        }

        public async Task CheckIfAssociationBetweenFilmInfoAndCollectionNotExistsAsync(Guid baseFilmInfoId, Guid collectionId)
        {
            var association = await _filmCollectionRepository.GetFilmCollectionAsync(collectionId, baseFilmInfoId, false);
            if (association != null)
            {
                throw new FilmCollectionAlreadyExistsException(collectionId, baseFilmInfoId);
            }
        }

        public async Task<FilmCollection.DataAccess.Models.FilmCollection> CheckIfAsocciationBetweenFilmInfoAndCollectionExistsAndGetAsync(Guid baseFilmInfoId, Guid collectionId, bool trackChanges)
        {
            var association = await _filmCollectionRepository.GetFilmCollectionAsync(collectionId, baseFilmInfoId, trackChanges);
            if (association == null)
            {
                throw new FilmCollectionNotFoundException(collectionId, baseFilmInfoId);
            }
            return association;
        }
    }
}
