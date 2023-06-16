using Film.DataAccess.Contexts;
using Film.DataAccess.Entities;
using Film.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Film.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Repository class for managing tags.
    /// </summary>
    public class TagRepository : ITagRepository
    {
        private readonly FilmContext _context;

        public TagRepository(FilmContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new tag entity.
        /// </summary>
        /// <param name="entity">The tag entity to create.</param>
        public void Create(Tag entity)
        {
            _context.Tags.Add(entity);
        }

        /// <summary>
        /// Deletes a tag entity by Id.
        /// </summary>
        /// <param name="id">The Id of the tag entity to delete.</param>
        public void Delete(Guid id)
        {
            _context.Tags.Remove(new Tag { Id = id });
        }

        /// <summary>
        /// Retrieves a tag entity by Id asynchronously.
        /// </summary>
        /// <param name="id">The Id of the tag entity to retrieve.</param>
        /// <returns>The task result contains the tag entity if found; otherwise, null.</returns>
        public async Task<Tag> GetByIdAsync(Guid id)
        {
            var tag = await _context.Tags.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return tag;
        }

        /// <summary>
        /// Retrieves a tag entity by name asynchronously.
        /// </summary>
        /// <param name="name">The name of the tag entity to retrieve.</param>
        /// <returns>The task result contains the tag entity if found; otherwise, null.</returns>
        public async Task<Tag> GetTagByNameAsync(string name)
        {
            var tag = await _context.Tags.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name);

            return tag;
        }

        /// <summary>
        /// Retrieves all tag entities asynchronously.
        /// </summary>
        /// <returns>The task result contains the list of tag entities.</returns>
        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            var tags = await _context.Tags.AsNoTracking()
                .ToListAsync();

            return tags;
        }

        /// <summary>
        /// Saves the changes made to the context asynchronously.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing tag entity.
        /// </summary>
        /// <param name="entity">The tag entity to update.</param>
        public void Update(Tag entity)
        {
            _context.Tags.Update(entity);
        }
    }
}
