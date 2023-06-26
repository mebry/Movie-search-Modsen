using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Configurations
{
    public class FilmGenreConfiguration : IEntityTypeConfiguration<FilmGenre>
    {
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
