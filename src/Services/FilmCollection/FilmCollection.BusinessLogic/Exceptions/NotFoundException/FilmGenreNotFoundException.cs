using SharedExceptions = Shared.Exceptions;

namespace FilmCollection.BusinessLogic.Exceptions.NotFoundException
{
    public class FilmGenreNotFoundException : SharedExceptions.NotFoundException
    {
        public FilmGenreNotFoundException(Guid genreId, Guid baseFilmInfoId) 
            : base($"The association between base film info with ${baseFilmInfoId} and genre with ${genreId} doesn't exists")
        {
        }
    }
}
