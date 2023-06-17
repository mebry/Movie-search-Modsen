using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces
{
    public interface IFilmGenreServiceValidator
    {
        Task CheckIfAssociationBetweenBaseFilmInfoAndGenreDoesntExistsAndGetAsync(Guid genreId, Guid baseFilmInfoId);
        Task<FilmGenre> CheckIfAssociationBetweenBaseFilmInfoAndGenreExistsAndGetAsync(Guid genreId, Guid baseFilmInfoId, bool trackChanges);
    }
}
