namespace Reporting.DataAccess.Interfaces
{
    public interface ISaveChangesAsync
    {
        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public Task SaveChangesAsync();
    }
}
