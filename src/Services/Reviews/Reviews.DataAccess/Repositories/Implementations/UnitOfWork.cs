using Reviews.DataAccess.Contexts;
using Reviews.DataAccess.Repositories.Interfaces;

namespace Reviews.DataAccess.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReviewsDbContext _dbContext;
        private ICriticRepository _criticRepository;
        private IReviewRepository _reviewRepository;
        private ITypeOfReviewRepository _typeOfReviewRepository;

        public UnitOfWork(ReviewsDbContext dbContext,
            ICriticRepository criticRepository,
            IReviewRepository reviewRepository,
            ITypeOfReviewRepository typeOfReviewRepository)
        {
            _dbContext = dbContext;
            _criticRepository = criticRepository;
            _reviewRepository = reviewRepository;
            _typeOfReviewRepository = typeOfReviewRepository;
        }

        public ICriticRepository CriticRepository => _criticRepository ??= new CriticRepository(_dbContext);

        public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(_dbContext);

        public ITypeOfReviewRepository TypeOfReviewRepository => _typeOfReviewRepository ??= new TypeOfReviewRepository(_dbContext);

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
