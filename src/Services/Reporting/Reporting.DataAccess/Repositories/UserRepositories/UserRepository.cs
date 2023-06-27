using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.UserRepository
{
    internal class UserRepository : IUserRepository
    {
        private readonly ReportingContext _context;

        protected UserRepository(ReportingContext context)
        {
            _context = context;
        }

        public void Create(User entity)
            => _context.Add(entity);

        public async Task<User?> GetByIdAsync(Guid id)
              => await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public void Update(User entity)
             => _context.Update(entity);

        public void Delete(Guid id)
        {
            var obj = _context.Users.Find(id);
            _context.Users.Remove(obj!);
        }

        public async Task SaveChangesAsync()
           => await _context.SaveChangesAsync();
    }
}
