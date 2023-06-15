using Rating.DataAccess.Entities;
using Rating.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace Rating.DataAccess.Repositories.FilmRepositories
{
    public interface IFilmRepository : IRepository<Film>
    {
        public IEnumerable<Film> GetAllByPredicate(Func<Film, bool> func);
    }
}
