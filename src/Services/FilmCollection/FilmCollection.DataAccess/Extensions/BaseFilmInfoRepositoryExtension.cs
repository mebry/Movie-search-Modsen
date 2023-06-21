using FilmCollection.DataAccess.Extensions.Utilities;
using FilmCollection.DataAccess.Models;
using System.Linq.Dynamic.Core;
using Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace FilmCollection.DataAccess.Extensions
{
    internal static class BaseFilmInfoRepositoryExtension
    {
        public static IQueryable<BaseFilmInfo> FilterFilmInfosByReleaseYear(this IQueryable<BaseFilmInfo> filmInfos,
            uint minReleaseYear, uint maxReleaseYear) =>
              filmInfos.Where(b => (b.ReleaseDate >= new DateOnly((int)minReleaseYear,1,1) && b.ReleaseDate <= new DateOnly((int)maxReleaseYear, 11, 28)));

        public static IQueryable<BaseFilmInfo> Search(this IQueryable<BaseFilmInfo> filmInfos, string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
                return filmInfos;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return filmInfos.Where(f => f.Title.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<BaseFilmInfo> GenresContains(this IQueryable<BaseFilmInfo> baseFilmInfos, Guid genreId)
        {
            if (genreId == Guid.Empty)
                return baseFilmInfos;

            return baseFilmInfos.Where(film => film.FilmGenres.Any(fg => fg.GenreId.Equals(genreId)));
        }

        public static IQueryable<BaseFilmInfo> CountriesContains(this IQueryable<BaseFilmInfo> baseFilmInfos, Countries countryId)
        {
            if(countryId == 0)
                return baseFilmInfos;

            return baseFilmInfos.Where(film => film.FilmCountries.Any(fc => fc.CountryId.Equals(countryId)));
        }

        public static IQueryable<BaseFilmInfo> CollectionContains(this IQueryable<BaseFilmInfo> baseFilmInfos, Guid collectionId)
        {
            if(Guid.Empty == collectionId)
                return baseFilmInfos;
            return baseFilmInfos.Where(film => film.FilmCollections.Any(fm => fm.CollectionId == collectionId));
        }

        public static IQueryable<BaseFilmInfo> IncludeAllRelatedData(this IQueryable<BaseFilmInfo> baseFilmInfos)
        {
            return baseFilmInfos.Include(b => b.FilmCollections)
                                    .ThenInclude(fc => fc.Collection)
                                .Include(b => b.FilmGenres)
                                    .ThenInclude(fm => fm.Genre)
                                .Include(b => b.FilmCountries);
        }

        public static IQueryable<BaseFilmInfo> Paginate(this IQueryable<BaseFilmInfo> baseFilmInfos, int page, int pageSize)
        {
            return baseFilmInfos.Skip((page - 1) * pageSize)
                                .Take(pageSize);
        }

        public static IQueryable<BaseFilmInfo> Sort(this IQueryable<BaseFilmInfo> baseFilmInfos,
            string sortTerm)
        {
            if (string.IsNullOrWhiteSpace(sortTerm) || sortTerm.ToLower().Trim() == "all")
                return baseFilmInfos.OrderBy(b => b.Title);

            var orderQuery = OrderQueryBuilder.CreateOrderyQuery<BaseFilmInfo>(sortTerm);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return baseFilmInfos.OrderBy(b => b.Title);

            return baseFilmInfos.OrderBy(orderQuery);
        }
    }
}
