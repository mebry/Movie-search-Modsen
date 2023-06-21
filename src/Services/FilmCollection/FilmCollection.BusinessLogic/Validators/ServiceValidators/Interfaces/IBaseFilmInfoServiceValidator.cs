using FilmCollection.DataAccess.Models;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces
{
    public interface IBaseFilmInfoServiceValidator
    {
        Task CheckIfBaseFilmInfoExistsAsync(Guid id);
        Task<BaseFilmInfo> CheckIfBaseFilmInfoExistsAndGetAsync(Guid id, bool trackChanges);

        Task CheckIfBaseFilmInfoNotExistsWithGivingTitleAndReleaseDateAsync(DateOnly releaseDate, string title);
        Task CheckIfBaseFilmInfoNotExistsWithGivingTitleAndReleaseDateAsync(DateOnly releaseDate, string title, Guid filmId);
    }
}
