using FilmCollection.BusinessLogic.Validators.ServiceValidators.Interfaces;
using FilmCollection.DataAccess.Models;
using FilmCollection.DataAccess.Repositories.Interfaces;
using FilmCollection.BusinessLogic.Exceptions.NotFoundException;
using FilmCollection.BusinessLogic.Exceptions.AlreadyExistsException;

namespace FilmCollection.BusinessLogic.Validators.ServiceValidators.Implementations
{
    internal class FilmGenreServiceValidator : IFilmGenreServiceValidator
    {
        private readonly IFilmGenreRepository _filmGenreRepository;
        
        public FilmGenreServiceValidator(IFilmGenreRepository filmGenreRepository)
        {
            _filmGenreRepository = filmGenreRepository;
        }

        public async Task<FilmGenre> CheckIfAssociationBetweenBaseFilmInfoAndGenreExistsAndGetAsync(Guid genreId, Guid baseFilmInfoId, bool trackChanges)
        {
            var association = await _filmGenreRepository.GetFilmGenreAsync(baseFilmInfoId, genreId, trackChanges);
            if(association == null) 
            {
                throw new FilmGenreNotFoundException(genreId, baseFilmInfoId);
            }
            return association;
        }

        public async Task CheckIfAssociationBetweenBaseFilmInfoAndGenreDoesntExistsAsync(Guid genreId, Guid baseFilmInfoId)
        {
            var association = await _filmGenreRepository.GetFilmGenreAsync(baseFilmInfoId, genreId, false);
            if (association != null)
                throw new FilmGenreAlreadyExistsException(baseFilmInfoId, genreId);
        }
    }
}
