using FilmCollection.DataAccess.Converters;
using FilmCollection.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Configurations
{
    public class BaseFilmInfoConfiguration : IEntityTypeConfiguration<BaseFilmInfo>
    {
        public void Configure(EntityTypeBuilder<BaseFilmInfo> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(b => b.Title);
            builder.HasIndex(b => b.ReleaseDate);
            builder.HasIndex(b => b.AverageRating)
                .HasFilter("[AverageRating] > 0");

            builder.HasIndex(b => b.NumberOfRatings)
                .HasFilter("[NumberOfRatings] > 0");

            builder.Property(b => b.ReleaseDate)
                .HasConversion(new DateOnlyToDateTimeConverter())
               .IsRequired();
            builder.Property(b => b.PosterURL)
                .IsRequired();
            builder.Property(b => b.Duration)
                .IsRequired();
            builder.Property(b => b.NumberOfRatings)
                .IsRequired();
            builder.Property(b => b.AverageRating)
                .IsRequired();
        }
    }
}
