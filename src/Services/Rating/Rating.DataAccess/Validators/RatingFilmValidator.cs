using FluentValidation;
using Rating.DataAccess.Entities;

namespace Rating.DataAccess.Validators
{
    internal class RatingFilmValidator : AbstractValidator<RatingFilm>
    {
        public RatingFilmValidator()
        {
            RuleFor(x => x.Score).Must(x => x >= 1);
        }
    }
}
