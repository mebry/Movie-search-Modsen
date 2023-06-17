using FilmCollection.BusinessLogic.ServiceValidators.Interfaces;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmCollection.BusinessLogic.Exceptions.NotFoundException;
using FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException;

namespace FilmCollection.BusinessLogic.ServiceValidators.Implementations
{
    internal class GenreServiceValidator : IGenreServiceValidator
    {
        private readonly IGenreRepository _genreRepository;

        public GenreServiceValidator(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }   

        public async Task<Genre> CheckIfGenreExistsAndGetAsync(Guid genreId, bool trackChanges)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(genreId, trackChanges);
            if (genre == null)
            {
                throw new GenreNotFoundException(genreId);
            }
            return genre;
        }

        public async Task CheckIfGenreExistsAsync(Guid genreId)
        {
            await CheckIfGenreExistsAndGetAsync(genreId, false);
        }

        public async Task CheckIfGenreWithGivenNameDoesntExistsAsync(string name)
        {
            var genre = await _genreRepository.GetGenreByNameAsync(name, false);
            if (genre != null)
                throw new GenreAlreadyExistsException();
        }
    }
}
