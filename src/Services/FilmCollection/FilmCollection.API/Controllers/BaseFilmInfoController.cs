using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FilmCollection.API.Controllers
{
    [Route("api/v1/films")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class BaseFilmInfoController
    {
        private readonly IBaseFilmInfoService _baseFilmInfoService;
        private readonly IValidator<BaseFilmInfoRequestDto> _validator;
        private readonly ILogger _logger;

        public BaseFilmInfoController(IBaseFilmInfoService baseFilmInfoService, IValidator<BaseFilmInfoRequestDto> validator, ILogger logger)
        {
            _baseFilmInfoService = baseFilmInfoService;
            _validator = validator;
            _logger = logger;
        }


    }
}
