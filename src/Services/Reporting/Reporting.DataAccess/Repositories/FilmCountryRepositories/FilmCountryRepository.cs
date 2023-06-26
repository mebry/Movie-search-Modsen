using Reporting.DataAccess.Contexts;
using Reporting.DataAccess.Entities;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.DataAccess.Repositories.FilmCountryRepositories
{
    internal class FilmCountryRepository : IFilmCountryRepository
    {
        private readonly ReportingContext _context;

        public FilmCountryRepository(ReportingContext context)
        {
            _context = context;
        }

        public void Create(FilmCountry filmCountry)
            => _context.FilmCountries.Add(filmCountry);


        public void Delete(Guid filmId, Countries countryEnum)
        {
            var filmCountry = _context.FilmCountries
                .FirstOrDefault(fc => (fc.FilmId == filmId)
                && (fc.CountryId == countryEnum));

            if(filmCountry != null)
                _context.FilmCountries.Remove(filmCountry);
        }

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
