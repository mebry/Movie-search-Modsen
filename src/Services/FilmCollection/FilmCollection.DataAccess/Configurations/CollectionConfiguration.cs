using FilmCollection.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmCollection.DataAccess.Configurations
{
    public class CollectionConfiguration : IEntityTypeConfiguration<CollectionModel>
    {
        public void Configure(EntityTypeBuilder<CollectionModel> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Title)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(400)
                .IsRequired();
        }
    }
}
