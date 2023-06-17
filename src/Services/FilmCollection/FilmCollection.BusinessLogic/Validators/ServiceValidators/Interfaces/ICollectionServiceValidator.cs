using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces
{
    public interface ICollectionServiceValidator
    {
        Task CheckIfCollectionExistsAsync(Guid id);
        Task<Collection> CheckIfCollectionExistsAndGetAsync(Guid id, bool trackChanges);
        Task CheckIfCollectionWithGivenTitleAndDescriptionDoesntExistsAsync(string title, string description);
    }
}
