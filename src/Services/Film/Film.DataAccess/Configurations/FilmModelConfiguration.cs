using Film.DataAccess.Converters;
using Film.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Film.DataAccess.Configurations
{
    /// <summary>
    /// Configures the entity type FilmModel.
    /// </summary>
    public class FilmModelConfiguration : IEntityTypeConfiguration<FilmModel>
    {
        /// <summary>
        /// Configures the entity, specifying its primary key, indexes, and property constraints.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<FilmModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.ReleaseDate)
                .HasConversion(new DateOnlyToDateTimeConverter());

            builder.HasIndex(i=>i.Title);
            builder.HasIndex(i=>i.ReleaseDate);

            builder.HasIndex(i=>i.AverageRating)
                .HasFilter("[AverageRating] > 0");
            builder.HasIndex(i=>i.CountScores)
                .HasFilter("[CountScores] > 0");

            builder.Property(i => i.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(i => i.Description)
                .HasMaxLength(600)
                .IsRequired();

            builder.Property(i => i.ReleaseDate)
                .IsRequired();
            builder.Property(i => i.PosterURL)
                .IsRequired();
            builder.Property(i => i.Duration)
                .IsRequired();
            builder.Property(i => i.CountScores)
                .IsRequired();
            builder.Property(i => i.AverageRating)
                .IsRequired();
        }
    }
}
