using Reviews.DataAccess.Entities;

namespace Reviews.DataAccess.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        public Task CreateAsync(Review review);
        public void Update(Review review);
        public void RemoveReview(Review review);
        public Task<IEnumerable<Review>> GetAllByFilmIdAsync(Guid filmId);
        public Task<IEnumerable<Review>> GetAllByCriticIdAsync(Guid criticId);
        public Task<IEnumerable<Review>> GetAllByFilmIdAndType(Guid filmId, Guid typeOfReviewId);
    }
}
