using Microsoft.EntityFrameworkCore;
using Rating.DataAccess.Contexts;
using Rating.DataAccess.Entities;

namespace Rating.DataAccess.Repositories.RaitingRepositories
{
    internal class RatingFilmRepository : IRatingFilmRepository
    {
        private readonly ApplicationContext _context;

        public RatingFilmRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<double> CalculateAverageRatingByFilmIdAsync(Guid filmId)
             => await _context.Ratings
            .AsNoTracking()
            .Where(a => a.FilmId == filmId)
            .AverageAsync(r => r.Score);

        public void Create(RatingFilm entity)
            => _context.Add(entity);

        public void Delete(RatingFilm entity)
             => _context.Remove(entity);

        public async Task<RatingFilm?> GetByIdAsync(Guid entityId)
             => await _context.Ratings
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == entityId);

        public async Task<bool> IsThereUserIdForFilmIdAsync(Guid filmId, Guid userId)
             => await _context.Ratings
            .Where(r => r.FilmId == filmId)
            .AnyAsync(r => r.UserId == userId);

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();

        public void Update(RatingFilm entity)
            => _context.Update(entity);
    }
}
