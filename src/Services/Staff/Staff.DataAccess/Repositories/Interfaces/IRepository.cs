using System.Linq.Expressions;

namespace Staff.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public Task<ICollection<T>> GetAllAsync();
        public Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        public Task<T> GetAsync(Guid id);
        public Task<T> GetAsync(Expression<Func<T, bool>> filter);
        public Task CreateAsync(T entity);
        public Task RemoveAsync(Guid id);
        public Task UpdateAsync(T entity);
    }
}
