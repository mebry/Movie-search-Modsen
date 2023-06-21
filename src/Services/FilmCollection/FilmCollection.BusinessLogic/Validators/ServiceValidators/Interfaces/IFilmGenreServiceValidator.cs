using FilmCollection.DataAccess.Models;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces
{
    public interface IFilmGenreServiceValidator
    {
        Task CheckIfAssociationBetweenBaseFilmInfoAndGenreDoesntExistsAsync(Guid genreId, Guid baseFilmInfoId);
        Task<FilmGenre> CheckIfAssociationBetweenBaseFilmInfoAndGenreExistsAndGetAsync(Guid genreId, Guid baseFilmInfoId, bool trackChanges);
    }
}
