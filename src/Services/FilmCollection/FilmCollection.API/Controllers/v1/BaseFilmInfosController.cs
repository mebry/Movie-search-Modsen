using FilmCollection.API.Extensions;
using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FilmCollection.Shared.RequestParameters;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FilmCollection.API.Controllers.v1
{
    public class BaseFilmInfosController : BaseApiController
    {
        private readonly IBaseFilmInfoService _baseFilmInfoService;

        public BaseFilmInfosController(IBaseFilmInfoService baseFilmInfoService, ILogger<BaseApiController> logger)
            : base(logger)
        {
            _baseFilmInfoService = baseFilmInfoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilmInfosAsync([FromQuery] FilmParameters filmParameters)
        {
            var pagedResult = await _baseFilmInfoService.GetBaseFilmInfosAsync(filmParameters);
            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.baseFilmInfos);
        }

        [HttpGet("{filmId}", Name = "FilmById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFilmInfoAsync(Guid filmId)
        {
            var baseFilmInfoToReturn = await _baseFilmInfoService.GetBaseFilmInfoAsync(filmId);
            return Ok(baseFilmInfoToReturn);
        }
    }
}
