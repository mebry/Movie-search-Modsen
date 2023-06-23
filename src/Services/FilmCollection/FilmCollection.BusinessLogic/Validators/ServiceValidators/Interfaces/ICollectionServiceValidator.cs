using FilmCollection.DataAccess.Models;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces
{
    public interface ICollectionServiceValidator
    {
        Task CheckIfCollectionExistsAsync(Guid id);
        Task<CollectionModel> CheckIfCollectionExistsAndGetAsync(Guid id, bool trackChanges);
        Task CheckIfCollectionWithGivenTitleAndDescriptionDoesntExistsAsync(string title, string description);
        Task CheckIfCollectionWithGivenTitleDoesntExistsAsync(string title);
        Task CheckIfCollectionWithGivenTitleDoesntExistsAsync(string title, Guid collectionId);
    }
}
