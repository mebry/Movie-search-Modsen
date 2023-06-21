using FluentValidation;
using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Validators
{
    internal class FilmDTOValidator : AbstractValidator<FilmDTO>
    {
        public FilmDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id cannot be empty");

            RuleFor(x => x.AverageRating)
                .Must(x => x >= 1)
                .WithMessage("The AverageRating must be greater than or equal to 1 and less than or equal to 10");

            RuleFor(x => x.CountOfScores)
                .Must(x => x >= 0)
                .WithMessage("The CountOfScores must be greater than or equal to 0");
        }
    }
}
