using Film.DataAccess.Converters;
using Film.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Film.DataAccess.Configurations
{
    /// <summary>
    /// Configures the entity type Tag.
    /// </summary>
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        /// <summary>
        /// Configures the entity, specifying its primary key and property constraints.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
