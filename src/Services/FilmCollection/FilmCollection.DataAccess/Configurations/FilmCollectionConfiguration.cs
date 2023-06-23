using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmCollection.DataAccess.Configurations
{
    public class FilmCollectionConfiguration : IEntityTypeConfiguration<FilmCollection.DataAccess.Models.FilmCollection>
    {
        public void Configure(EntityTypeBuilder<Models.FilmCollection> builder)
        {
            builder.HasKey(fc => new
            {
                fc.CollectionModelId,
                fc.BaseFilmInfoId
            });

            builder.HasOne(fc => fc.CollectionModel)
                .WithMany(c => c.FilmCollections)
                .HasForeignKey(fc => fc.CollectionModelId);

            builder.HasOne(fc => fc.BaseFilmInfo)
                .WithMany(b => b.FilmCollections)
                .HasForeignKey(fc => fc.BaseFilmInfoId);
        }
    }
}
