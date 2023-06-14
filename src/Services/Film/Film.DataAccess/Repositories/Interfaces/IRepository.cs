using Film.DataAccess.Entities;

namespace Film.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// Generic interface for a repository, providing CRUD operations and saving changes asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The created entity.</returns>
        T Create(T entity);

        /// <summary>
        /// Retrieves an entity by its Id asynchronously.
        /// </summary>
        /// <param name="id">The Id of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation and contains the retrieved entity.</returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity by its Id.
        /// </summary>
        /// <param name="id">The Id of the entity to delete.</param>
        void Delete(Guid id);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveChangesAsync();
    }
}
