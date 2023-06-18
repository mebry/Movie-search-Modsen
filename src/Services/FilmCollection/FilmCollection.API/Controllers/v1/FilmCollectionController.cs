using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FilmCollection.BusinessLogic.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FilmCollection.API.Controllers.v1
{
    public class FilmCollectionController : BaseApiController
    {
        private readonly IFilmCollectionService _filmCollectionService;
        private readonly IValidator<FilmCollectionRequestDto> _validator;

        public FilmCollectionController(
            ILogger<BaseApiController> logger,
            IFilmCollectionService filmCollectionService,
            IValidator<FilmCollectionRequestDto> validator
            )
            : base(logger)
        {
            _filmCollectionService = filmCollectionService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilmCollection(FilmCollectionRequestDto filmCollectionRequest)
        {
            var result = await _validator.ValidateAsync(filmCollectionRequest);
            if (!result.IsValid)
                ProcessInvalidValidationResult(result, "Invalid data was provided when trying to create a FilmCollection association");
            var createdFilmCollection = await _filmCollectionService.CreateFilmCollectionAssociationAsync(filmCollectionRequest);
            return;
        }

        

    }
}
