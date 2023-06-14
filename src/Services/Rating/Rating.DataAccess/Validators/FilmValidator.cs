using FluentValidation;
using Rating.DataAccess.Entities;

namespace Rating.DataAccess.Validators
{
    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator()
        {
            RuleFor(x => x.AverageRating).Must(x => x >= 1);
        }
    }
}
