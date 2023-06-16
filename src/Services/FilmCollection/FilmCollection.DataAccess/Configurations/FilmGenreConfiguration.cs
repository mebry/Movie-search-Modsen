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
    public class FilmGenreConfiguration : IEntityTypeConfiguration<FilmGenre>
    {
        public void Configure(EntityTypeBuilder<FilmGenre> builder)
        {
            builder.HasKey(fg => new
            {
                fg.GenreId,
                fg.BaseFilmInfoId
            });

            builder.HasOne(fg => fg.BaseFilmInfo)
                .WithMany(b => b.FilmGenres)
                .HasForeignKey(fg => fg.BaseFilmInfoId);

            builder.HasOne(fg => fg.Genre)
                .WithMany(g => g.FilmGenres)
                .HasForeignKey(fg => fg.GenreId);

        }
    }
}
