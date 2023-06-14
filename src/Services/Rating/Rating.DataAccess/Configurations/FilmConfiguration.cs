using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rating.DataAccess.Entities;

namespace Rating.DataAccess.Configurations
{
    internal class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.Property(x => x.AverageRaiting)
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
