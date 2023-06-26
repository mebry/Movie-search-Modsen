using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Interfaces;

namespace Reporting.DataAccess.Repositories
{
    internal abstract class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly ReportingContext _context;

        protected EFRepository(ReportingContext context)
        {
            _context = context;
        }

        public void Create(T entity)
            => _context.Add(entity);

        public void Update(T entity)
             => _context.Update(entity);

        public void Delete(Guid id)
        {
            var obj = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(obj!);
        }

        public abstract Task<T> GetByIdAsync(Guid id);

        public async Task SaveChangesAsync()
             => await _context.SaveChangesAsync();
    }
}
