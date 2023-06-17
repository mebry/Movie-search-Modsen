using FilmCollection.BusinessLogic.DTOs.RequestDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Validators.RequestValidators
{
    internal class BaseFilmInfoRequestDtoValidator : AbstractValidator<BaseFilmInfoRequestDto>
    {
        public BaseFilmInfoRequestDtoValidator() 
        {

            RuleFor(b => b.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(100)
                .WithMessage("Title must not contain more than 100 characters.");

            RuleFor(b => b.ReleaseDate.Year)
                .Must(i => i > 1850)
                .WithMessage("The release date of the film must be later than 1850.");

            RuleFor(b => b.PosterURL)
                .NotNull()
                .NotEmpty()
                .WithMessage("Poster URL is required.");

            RuleFor(b => b.Duration)
                .GreaterThan(TimeSpan.Zero)
                .WithMessage("Duration must be greater than zero.");

            RuleFor(b => b.AverageRating)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Average rating cannot be negative");

            RuleFor(b => b.NumberOfRatings)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Number of ratings cannot be negative");
        }
    }
}
