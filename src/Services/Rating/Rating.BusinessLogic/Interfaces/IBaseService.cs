namespace Rating.BusinessLogic.Interfaces
{
    public interface IBaseService<T>
    {
        public Task<T> Create(T model);
        public Task<T?> GetByIdAsync(Guid id);
        public Task<T> Delete(T model);
        public Task<T> Update(T model);
    }
}
