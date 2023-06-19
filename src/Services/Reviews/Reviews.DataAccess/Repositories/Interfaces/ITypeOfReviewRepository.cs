using Reviews.DataAccess.Entities;

namespace Reviews.DataAccess.Repositories.Interfaces
{
    public interface ITypeOfReviewRepository
    {
        public Task CreateAsync(TypeOfReview typeOfReview);
    }
}
