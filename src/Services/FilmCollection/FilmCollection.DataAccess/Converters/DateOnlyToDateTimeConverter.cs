using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FilmCollection.DataAccess.Converters
{
    public class DateOnlyToDateTimeConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyToDateTimeConverter()
            : base(d => d.ToDateTime(TimeOnly.MinValue),
                   d => DateOnly.FromDateTime(d))
        { }
    }
}
