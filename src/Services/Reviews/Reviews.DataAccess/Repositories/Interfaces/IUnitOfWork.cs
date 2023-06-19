namespace Reviews.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public ICriticRepository CriticRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public ITypeOfReviewRepository TypeOfReviewRepository { get; }
        public Task SaveChangesAsync();
    }
}
