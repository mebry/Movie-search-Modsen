using Film.DataAccess.Converters;
using Film.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Film.DataAccess.Configurations
{
    /// <summary>
    /// Configures the entity type FilmTag.
    /// </summary>
    public class FilmTagConfiguration : IEntityTypeConfiguration<FilmTag>
    {
        /// <summary>
        /// Configures the entity, specifying its primary key and relationships.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<FilmTag> builder)
        {
            builder.HasKey(p => new
            {
                p.FilmId,
                p.TagId
            });

            builder.HasOne(p => p.Film)
                .WithMany(p => p.FilmTags)
                .HasForeignKey(p => p.FilmId);

            builder.HasOne(p => p.Tag)
                .WithMany(p => p.FilmTags)
                .HasForeignKey(p => p.TagId);
        }
    }
}
