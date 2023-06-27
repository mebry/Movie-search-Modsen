using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reporting.DataAccess.Converters;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.ReleaseDate)
                .HasConversion(new DateOnlyToDateTimeConverter());

            builder.HasIndex(i => i.Title);
            builder.HasIndex(i => i.ReleaseDate);

            builder.Property(i => i.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(i => i.ReleaseDate)
                .IsRequired();
            builder.Property(i => i.Duration)
                .IsRequired();
        }
    }
}
