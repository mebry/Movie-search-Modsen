using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Configurations
{
    public class FilmCollectionConfiguration : IEntityTypeConfiguration<FilmCollection.DataAccess.Models.FilmCollection>
    {
        public void Configure(EntityTypeBuilder<Models.FilmCollection> builder)
        {
            builder.HasKey(fc => new
            {
                fc.CollectionId,
                fc.BaseFilmInfoId
            });

            builder.HasOne(fc => fc.Collection)
                .WithMany(c => c.FilmCollections)
                .HasForeignKey(fc => fc.CollectionId);

            builder.HasOne(fc => fc.BaseFilmInfo)
                .WithMany(b => b.FilmCollections)
                .HasForeignKey(fc => fc.BaseFilmInfoId);
        }
    }
}
