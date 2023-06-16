using Film.DataAccess.Converters;
using Film.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Film.DataAccess.Configurations
{
    /// <summary>
    /// Configures the entity type FilmGenre.
    /// </summary>
    public class FilmGenreConfiguration : IEntityTypeConfiguration<FilmGenre>
    {
        /// <summary>
        /// Configures the entity, specifying its primary key and relationships.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<FilmGenre> builder)
        {
            builder.HasKey(p => new
            {
                p.FilmId,
                p.GenreId
            });

            builder.HasOne(p => p.Film)
                .WithMany(p => p.FilmGenres)
                .HasForeignKey(p => p.FilmId);

            builder.HasOne(p => p.Genre)
                .WithMany(p => p.FilmGenres)
                .HasForeignKey(p => p.GenreId);
        }
    }
}
