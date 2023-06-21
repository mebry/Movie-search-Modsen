using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;

namespace FilmCollection.BusinessLogic.Validators.RequestValidators
{
    public class FilmGenreRequestDtoValidator : AbstractValidator<FilmGenreRequestDto>
    {
        public FilmGenreRequestDtoValidator() 
        {
            RuleFor(fg => fg.BaseFilmInfoId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Film id is required");

            RuleFor(fg => fg.GenreId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Genre is required");
                
        }
    }
}
