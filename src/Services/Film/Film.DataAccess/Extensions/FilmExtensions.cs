using Film.DataAccess.Entities;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System;

namespace Film.DataAccess.Extensions
{
    /// <summary>
    /// Extension methods for filtering, sorting, and paginating film models.
    /// </summary>
    public static class FilmExtensions
    {
        /// <summary>
        /// Sorts the film models based on the provided order query string.
        /// </summary>
        /// <param name="filmModels">The IQueryable of film models.</param>
        /// <param name="orderByQueryString">The order query string.</param>
        /// <returns>The sorted IQueryable of film models.</returns>
        public static IQueryable<FilmModel> Sort(this IQueryable<FilmModel> filmModels, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return filmModels.OrderBy(e => e.Title);

            var orderParams = orderByQueryString.Trim().Split(',');

            var orderQuery = string.Join(",", orderParams);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return filmModels.OrderBy(e => e.Title);

            return filmModels.OrderBy(orderQuery);
        }

        /// <summary>
        /// Paginates the film models based on the provided page number and page size.
        /// </summary>
        /// <param name="filmModels">The IQueryable of film models.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The paginated IQueryable of film models.</returns>
        public static IQueryable<FilmModel> Paginate(this IQueryable<FilmModel> filmModels,int pageNumber, int pageSize)
        {
            return filmModels.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        /// <summary>
        /// Includes related data for FilmModel entities in the query, including AverageRating, FilmCountries, FilmGenres,
        /// FilmTags, StaffPersonPositions, Position, and StaffPerson entities.
        /// </summary>
        /// <param name="filmModels">The IQueryable of FilmModel entities.</param>
        /// <returns>The IQueryable of FilmModel entities with the related data included.</returns>
        public static IQueryable<FilmModel> IncludeRelatedData(this IQueryable<FilmModel> filmModels)
        {
            return filmModels.Include(f=>f.AverageRating)
                .Include(f=>f.FilmCountries)
                .Include(f => f.FilmGenres)
                    .ThenInclude(sp => sp.Genre)
                .Include(f => f.FilmTags)
                    .ThenInclude(sp => sp.Tag)
                .Include(f => f.StaffPersonPositions)
                    .ThenInclude(sp => sp.Position)
                .Include(f => f.StaffPersonPositions)
                    .ThenInclude(sp => sp.StaffPerson);
        }

        /// <summary>
        /// Filters the film models based on the provided filter query string.
        /// </summary>
        /// <param name="filmModels">The IQueryable of film models.</param>
        /// <param name="filterQueryString">The filter query string.</param>
        /// <returns>The filtered IQueryable of film models.</returns>
        public static IQueryable<FilmModel> Filter(this IQueryable<FilmModel> filmModels, string filterQueryString)
        {
            if (string.IsNullOrWhiteSpace(filterQueryString))
                return filmModels;

            var filterParams = filterQueryString.Trim().Split(',');

            var parameter = Expression.Parameter(typeof(FilmModel), "x");
            Expression predicateBody = null;

            foreach (var filterParam in filterParams)
            {
                var filterPair = filterParam.Split('=');
                if (filterPair.Length != 2)
                    throw new ArgumentException("Invalid filterQueryString format. " +
                        "Expected format: 'param1=value1,param2=value2,...'.");

                var paramName = filterPair[0].Trim();
                var paramValue = filterPair[1].Trim();

                var property = Expression.Property(parameter, paramName);
                var value = Expression.Constant(paramValue);
                var equalExpression = Expression.Equal(property, value);

                if (predicateBody == null)
                    predicateBody = equalExpression;
                else
                    predicateBody = Expression.AndAlso(predicateBody, equalExpression);
            }

            if (predicateBody == null)
                return filmModels;

            var predicateLambda = Expression.Lambda<Func<FilmModel, bool>>(predicateBody, parameter);
            return filmModels.Where(predicateLambda);
        }
    }
}
