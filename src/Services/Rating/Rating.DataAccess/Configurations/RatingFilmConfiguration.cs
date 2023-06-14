using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rating.DataAccess.Entities;

namespace Rating.DataAccess.Configurations
{
    internal class RatingFilmConfiguration : IEntityTypeConfiguration<RatingFilm>
    {
        public void Configure(EntityTypeBuilder<RatingFilm> builder)
        {
            builder.Property(x => x.Score)
               .HasMaxLength(10)
               .IsRequired();
        }
    }
}
