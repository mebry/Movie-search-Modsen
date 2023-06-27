using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Reporting.DataAccess.Converters
{
    /// <summary>
    /// Converts between DateOnly and DateTime values.
    /// </summary>
    public class DateOnlyToDateTimeConverter : ValueConverter<DateOnly, DateTime>
    {
        /// <summary>
        /// Initializes a new instance of the DateOnlyToDateTimeConverter class.
        /// </summary>
        public DateOnlyToDateTimeConverter() : base(
            v => v.ToDateTime(TimeOnly.MinValue),
            v => new DateOnly(v.Year, v.Month, v.Day))
        { }
    }
}
