using FluentValidation.Results;

namespace Rating.BusinessLogic.Extensions
{
    internal static class ResultErrorExtension
    {
        public static string ResultErrorMessage(this ValidationResult result)
            => String.Join("\n", result.Errors.Select(x => x.ErrorMessage));
    }
}
