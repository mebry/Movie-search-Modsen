using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.ServiceValidators.Interfaces
{
    public interface IBaseFilmInfoServiceValidator
    {
        Task CheckIfBaseFilmInfoExists(Guid id);
        Task<BaseFilmInfo> CheckIfBaseFilmInfoExistsAndGetAsync(Guid id, bool trackChanges);

        Task CheckIfBaseFilmInfoNotExistsWithGivingTitleAndReleaseDateAsync(DateOnly releaseDate, string title);
    }
}
