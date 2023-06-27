using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Configurations
{
    public class FilmCountryConfiguration : IEntityTypeConfiguration<FilmCountry>
    {
        public void Configure(EntityTypeBuilder<FilmCountry> builder)
        {
            builder.HasKey(p => new
            {
                p.FilmId,
                p.CountryId
            });

            builder.HasOne(p => p.Film)
                .WithMany(p => p.FilmCountries)
                .HasForeignKey(p => p.FilmId);
        }
    }
}
