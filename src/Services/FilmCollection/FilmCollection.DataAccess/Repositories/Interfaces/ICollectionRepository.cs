using FilmCollection.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface ICollectionRepository
    {
        Task CreateCollectionAsync(Collection collection);

        Task DeleteCollection(Collection collection);

        Task UpdateCollection(Collection collection);

        Task<IEnumerable<Collection>> GetAllCollectionsAsync(bool trackChanges);
        Task<Collection> GetCollectionAsync(Guid id, bool trackChanges);
    }
}
