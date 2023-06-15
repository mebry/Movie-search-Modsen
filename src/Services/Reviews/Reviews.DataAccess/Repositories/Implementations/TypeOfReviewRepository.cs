using Reviews.DataAccess.Contexts;
using Reviews.DataAccess.Entities;
using Reviews.DataAccess.Repositories.Interfaces;

namespace Reviews.DataAccess.Repositories.Implementations
{
    public class TypeOfReviewRepository : ITypeOfReviewRepository
    {
        private readonly ReviewsDbContext _dbContext;

        public TypeOfReviewRepository(ReviewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(TypeOfReview typeOfReview)
        {
            await _dbContext.TypesOfReview.AddAsync(typeOfReview);
        }
    }
}
