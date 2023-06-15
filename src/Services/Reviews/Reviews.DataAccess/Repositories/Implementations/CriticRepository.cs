using Reviews.DataAccess.Contexts;
using Reviews.DataAccess.Entities;
using Reviews.DataAccess.Repositories.Interfaces;

namespace Reviews.DataAccess.Repositories.Implementations
{
    public class CriticRepository : ICriticRepository
    {
        private readonly ReviewsDbContext _dbContext;

        public CriticRepository(ReviewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Critic critic)
        {
            await _dbContext.Critics.AddAsync(critic);
        }

        public void RemoveCritic(Critic critic)
        {
            _dbContext.Critics.Remove(critic);
        }

        public void Update(Critic critic)
        {
            _dbContext.Critics.Update(critic);
        }
    }
}
