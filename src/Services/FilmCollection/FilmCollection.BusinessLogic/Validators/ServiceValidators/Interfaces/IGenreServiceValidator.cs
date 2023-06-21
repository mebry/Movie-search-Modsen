using FilmCollection.DataAccess.Models;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces
{
    public interface IGenreServiceValidator
    {
        Task<Genre> CheckIfGenreExistsAndGetAsync(Guid genreId, bool trackChanges);
        Task CheckIfGenreExistsAsync(Guid genreId);
        Task CheckIfGenreWithGivenNameDoesntExistsAsync(string name);
    }
}
