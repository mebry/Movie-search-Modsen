using Film.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;

namespace Film.BusinessLogic.ModelValidators.RequestDTOs
{
    /// <summary>
    /// Validator for FilmRequestDTO.
    /// </summary>
    public class FilmRequestDTOValidator : AbstractValidator<FilmRequestDTO>
    {
        public FilmRequestDTOValidator()
        {
            RuleFor(film => film.AgeRestrictionId)
                .NotEmpty()
                .WithMessage("Age restriction Id is required.");

            RuleFor(film => film.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(100)
                .WithMessage("Title must not exceed 100 characters.");

            RuleFor(film => film.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Description is required.")
                .MaximumLength(600)
                .WithMessage("Description must not exceed 600 characters.");

            RuleFor(film => film.Slogan)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Slogan must not exceed 100 characters.");

            RuleFor(film => film.ReleaseDate.Year)
                .Must(i=>i>1850)
                .WithMessage("The release date of the film must be later than 1850.");

            RuleFor(film => film.PosterURL)
                .NotNull()
                .NotEmpty()
                .WithMessage("Poster URL is required.");

            RuleFor(film => film.Duration)
                .GreaterThan(TimeSpan.Zero)
                .WithMessage("Duration must be greater than zero.");
        }
    }
}