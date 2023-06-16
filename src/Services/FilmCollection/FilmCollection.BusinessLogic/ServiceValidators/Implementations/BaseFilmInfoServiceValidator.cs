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
    public class BaseFilmInfoServiceValidator : IBaseFilmInfoServiceValidator
    {
        private readonly IBaseFilmInfoRepository _baseFilmInfoRepository;

        public BaseFilmInfoServiceValidator(IBaseFilmInfoRepository baseFilmInfoRepository)
        {
            _baseFilmInfoRepository = baseFilmInfoRepository;
        }

        public async Task<BaseFilmInfo> CheckIfBaseFilmInfoExistsAndGetAsync(Guid id, bool trackChanges)
        {
            var baseFilmInfo = await _baseFilmInfoRepository.GetBaseFilmInfoByIdAsync(id, trackChanges);
            if (baseFilmInfo == null)
            {
                throw new BaseFilmInfoNotFoundException();
            }
            return baseFilmInfo;
        }

        public async Task CheckIfBaseFilmInfoExists(Guid id)
        {
            await CheckIfBaseFilmInfoExistsAndGetAsync(id,false);
        }

        public async Task CheckIfBaseFilmInfoNotExistsWithGivingTitleAndReleaseDateAsync(DateOnly releaseDate, string title)
        {
            var baseFilmInfo = await _baseFilmInfoRepository.GetBaseFilmInfoByTitleAndReleaseDate(title, releaseDate, false);
            if(baseFilmInfo != null) 
            { 
                throw new BaseFilmInfoAlreadyExistsException();
            }
        }
    }
}
