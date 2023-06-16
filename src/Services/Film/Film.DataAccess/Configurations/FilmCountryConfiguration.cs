using Film.DataAccess.Converters;
using Film.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Film.DataAccess.Configurations
{
    /// <summary>
    /// Configures the entity type FilmCountry.
    /// </summary>
    public class FilmCountryConfiguration : IEntityTypeConfiguration<FilmCountry>
    {
        /// <summary>
        /// Configures the entity, specifying its primary key and relationships.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
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
