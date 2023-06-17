using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.ServiceValidators.Interfaces
{
    public interface IGenreServiceValidator
    {
        Task<Genre> CheckIfGenreExistsAndGetAsync(Guid genreId, bool trackChanges);
        Task CheckIfGenreExistsAsync(Guid genreId);
        Task CheckIfGenreWithGivenNameDoesntExistsAsync(string name);
    }
}
