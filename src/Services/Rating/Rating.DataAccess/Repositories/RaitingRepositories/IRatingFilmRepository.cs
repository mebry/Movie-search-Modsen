using Rating.DataAccess.Entities;
using Rating.DataAccess.Interfaces;

namespace Rating.DataAccess.Repositories.RaitingRepositories
{
    public interface IRatingFilmRepository : IRepository<RatingFilm>
    {
        public Task<double> CalculateAverageRatingByFilmId(Guid filmId);
    }
}
