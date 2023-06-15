﻿using Microsoft.EntityFrameworkCore;
using Reviews.DataAccess.Contexts;
using Reviews.DataAccess.Entities;
using Reviews.DataAccess.Repositories.Interfaces;

namespace Reviews.DataAccess.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ReviewsDbContext _dbContext;

        public ReviewRepository(ReviewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Review review)
        {
            await _dbContext.Reviews.AddAsync(review);
        }

        public async Task<IEnumerable<Review>> GetAllByCriticIdAsync(Guid criticId)
        {
            return await _dbContext.Reviews
                .Where(x => x.CriticId == criticId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetAllByFilmIdAndType(Guid filmId, Guid typeOfReviewId)
        {
            return await _dbContext.Reviews
                .Where(x => x.FilmId == filmId && x.TypeOfReviewId == typeOfReviewId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetAllByFilmIdAsync(Guid filmId)
        {
            return await _dbContext.Reviews
                .Where(x => x.FilmId == filmId)
                .AsNoTracking()
                .ToListAsync();
        }

        public void RemoveReview(Review review)
        {
            _dbContext.Reviews.Remove(review);
        }

        public void Update(Review review)
        {
            _dbContext.Reviews.Update(review);
        }
    }
}
