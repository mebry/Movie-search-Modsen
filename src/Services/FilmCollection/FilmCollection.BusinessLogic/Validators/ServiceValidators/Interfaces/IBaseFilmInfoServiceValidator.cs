using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
