using FilmCollection.DataAccess.Contexts;
using FilmCollection.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FilmCollection.DataAccess.Repositories.Implementations
{
    internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FilmCollectionContext FilmCollectionContext { get; set; }

        public RepositoryBase(FilmCollectionContext filmCollectionContext)
        {
            FilmCollectionContext = filmCollectionContext;
        }

        public IQueryable<T> GetAllAsync(bool trackChanges)
        {
            return !trackChanges ?
                FilmCollectionContext.Set<T>()
                    .AsNoTracking() :
                FilmCollectionContext.Set<T>();
        }

        public IQueryable<T> GetByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
                FilmCollectionContext.Set<T>()
                    .Where(expression)
                    .AsNoTracking() :
                FilmCollectionContext.Set<T>()
                    .Where(expression);
        }

        public void Create(T entity)
        {
            FilmCollectionContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            FilmCollectionContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            FilmCollectionContext.Set<T>().Remove(entity);
        }
    }
}
