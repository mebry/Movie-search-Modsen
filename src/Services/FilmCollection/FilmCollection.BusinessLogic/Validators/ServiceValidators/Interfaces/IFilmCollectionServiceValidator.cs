namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces
{
    public interface IFilmCollectionServiceValidator
    {
        Task<DataAccess.Models.FilmCollection> CheckIfAsocciationBetweenFilmInfoAndCollectionExistsAndGetAsync(Guid baseFilmInfoId, Guid collectionId, bool trackChanges);
        Task CheckIfAssociationBetweenFilmInfoAndCollectionNotExistsAsync(Guid baseFilmInfoId, Guid collectionId);
    }
}
