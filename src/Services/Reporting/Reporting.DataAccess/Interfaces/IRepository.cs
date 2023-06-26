namespace Reporting.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        public void Create(T entity);

        /// <summary>
        /// Retrieves an entity by its Id asynchronously.
        /// </summary>
        /// <param name="id">The Id of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation and contains the retrieved entity.</returns>
        public Task<T?> GetByIdAsync(Guid id);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public void Update(T entity);

        /// <summary>
        /// Deletes an entity by its Id.
        /// </summary>
        /// <param name="id">The Id of the entity to delete.</param>
        public void Delete(Guid id);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public Task SaveChangesAsync();
    }
}
