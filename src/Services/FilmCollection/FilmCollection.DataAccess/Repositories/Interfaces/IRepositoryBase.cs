using System.Linq.Expressions;

namespace FilmCollection.DataAccess.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAllAsync(bool trackChanges);
        IQueryable<T> GetByConditionAsync(Expression<Func<T, bool>> expression,
            bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
