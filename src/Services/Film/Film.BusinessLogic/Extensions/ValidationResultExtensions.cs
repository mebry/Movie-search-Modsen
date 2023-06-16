using FluentValidation.Results;
using System.Text;

namespace Film.BusinessLogic.Extensions
{
    /// <summary>
    /// Extension methods for working with FluentValidation's ValidationResult.
    /// </summary>
    public static class ValidationResultExtensions
    {
        /// <summary>
        /// Retrieves the error messages from a ValidationResult.
        /// </summary>
        /// <param name="result">The ValidationResult instance.</param>
        /// <returns>A string containing the error messages.</returns>
        public static string GetErrorMessages(this ValidationResult result)
        {
            var stringBuilder = new StringBuilder();

            foreach (var failure in result.Errors)
            {

                stringBuilder.Append($"Property: {failure.PropertyName} Error Code: {failure.ErrorCode}");
            }

            return stringBuilder.ToString();
        }
    }
}
