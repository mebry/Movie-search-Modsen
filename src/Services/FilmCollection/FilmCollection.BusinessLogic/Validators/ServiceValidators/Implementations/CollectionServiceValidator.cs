using FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using FilmCollection.BusinessLogic.Exceptions.NotFoundException;
using FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Implementations
{
    internal class CollectionServiceValidator : ICollectionServiceValidator
    {
        private readonly ICollectionRepository _collectionRepository;

        public CollectionServiceValidator(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task<Collection> CheckIfCollectionExistsAndGetAsync(Guid id, bool trackChanges)
        {
            var collection = await _collectionRepository.GetCollectionAsync(id, trackChanges);
            if(collection == null) 
            {
                throw new CollectionNotFoundException(id);
            }
            return collection;  
        }

        public async Task CheckIfCollectionExistsAsync(Guid id)
        {
            await CheckIfCollectionExistsAndGetAsync(id, false);
        }

        public async Task CheckIfCollectionWithGivenTitleAndDescriptionDoesntExistsAsync(string title, string description)
        {
            var collection = await _collectionRepository.GetCollectionByTitleAndDescriptionAsync(title, description,false);
            if(collection != null)
            {
                throw new CollectionAlreadyExistsException();
            }
        }

        public async Task CheckIfCollectionWithGivenTitleDoesntExistsAsync(string title)
        {
            var collection = await _collectionRepository.GetCollectionByTitleAsync(title, false);
            if (collection != null)
                throw new CollectionAlreadyExistsException();
        }

        public async Task CheckIfCollectionWithGivenTitleDoesntExistsAsync(string title, Guid collectionId)
        {
            var collection = await _collectionRepository.GetCollectionByTitleAsync(title, false);
            if (collection != null && !collection.Id.Equals(collectionId))
                throw new CollectionAlreadyExistsException();

        }
    }
}
