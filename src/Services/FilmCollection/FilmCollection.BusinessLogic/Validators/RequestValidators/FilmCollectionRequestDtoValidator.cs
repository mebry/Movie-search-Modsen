using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;

namespace FilmCollection.BusinessLogic.Validators.RequestValidators
{
    public class FilmCollectionRequestDtoValidator : AbstractValidator<FilmCollectionRequestDto>
    {
        public FilmCollectionRequestDtoValidator() 
        {
            RuleFor(fc => fc.CollectionModelId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Collection id is required");

            RuleFor(fc => fc.BaseFilmInfoId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Film id is required");
        }
    }
}
