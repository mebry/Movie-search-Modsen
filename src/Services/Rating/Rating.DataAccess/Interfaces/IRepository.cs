namespace Rating.DataAccess.Interfaces
{
    public interface IRepository<TEntity>
    {
        public void Create(TEntity item);
        public Task<TEntity?> GetByIdAsync(Guid entityId);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public void Delete(Guid entityId);
        public void Update(TEntity item);
        public Task SaveAsync();
    }
}
