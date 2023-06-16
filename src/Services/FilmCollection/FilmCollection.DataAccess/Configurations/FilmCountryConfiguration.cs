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
