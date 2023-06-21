using FilmCollection.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmCollection.DataAccess.Configurations
{
    public class FilmCountryConfiguration : IEntityTypeConfiguration<FilmCountry>
    {
        public void Configure(EntityTypeBuilder<FilmCountry> builder)
        {
            builder.HasKey(fc => new
            {
                fc.CountryId,
                fc.BaseFilmInfoId
            });

            builder.HasOne(fc => fc.BaseFilmInfo)
                .WithMany(b => b.FilmCountries)
                .HasForeignKey(fc => fc.BaseFilmInfoId);
        }
    }
}
