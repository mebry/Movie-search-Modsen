namespace Rating.DataAccess.Interfaces
{
    public interface IRepository<TEntity>
    {
        public void Create(TEntity entity);
        public Task<TEntity?> GetByIdAsync(Guid entityId);
        public IEnumerable<TEntity> GetAll();
        public void Delete(TEntity entity);
        public void Update(TEntity entity);
        public Task SaveAsync();
    }
}
