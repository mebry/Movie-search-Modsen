using Film.DataAccess.Converters;
using Film.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Film.DataAccess.Configurations
{
    /// <summary>
    /// Configures the entity type Position.
    /// </summary>
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        /// <summary>
        /// Configures the entity, specifying its primary key and property constraints.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
