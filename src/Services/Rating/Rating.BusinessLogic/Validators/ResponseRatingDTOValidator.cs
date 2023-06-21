using FluentValidation;
using Rating.BusinessLogic.DTOs;

namespace Rating.BusinessLogic.Validators
{
    internal class ResponseRatingDTOValidator : AbstractValidator<RequestRatingDTO>
    {
        public ResponseRatingDTOValidator()
        {
            RuleFor(x => x.UserId)
               .NotEmpty()
               .WithMessage("UserId cannot be empty");

            RuleFor(x => x.FilmId)
               .NotEmpty()
               .WithMessage("FilmId cannot be empty");

            RuleFor(x => x.Score)
                .Must(x => x >= 1 && x <= 10)
                .WithMessage("The score must be greater than or equal to 1 and less than or equal to 10");
        }
    }
}
