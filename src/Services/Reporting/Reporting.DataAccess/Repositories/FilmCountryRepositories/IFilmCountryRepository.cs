using Reporting.DataAccess.Entities;
using Reporting.DataAccess.Interfaces;
using Shared.Enums;

namespace Reporting.DataAccess.Repositories.FilmCountryRepositories
{
    public interface IFilmCountryRepository : ISaveChangesAsync
    {
        public void Create(FilmCountry filmCountry);
        public void Delete(Guid filmId, Countries countryEnum);
    }
}
