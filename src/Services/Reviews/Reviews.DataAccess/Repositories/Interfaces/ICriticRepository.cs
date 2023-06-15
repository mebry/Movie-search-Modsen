using Reviews.DataAccess.Entities;

namespace Reviews.DataAccess.Repositories.Interfaces
{
    public interface ICriticRepository
    {
        public Task CreateAsync(Critic critic);
        public void Update(Critic critic);
        public void RemoveCritic(Critic critic);
    }
}
