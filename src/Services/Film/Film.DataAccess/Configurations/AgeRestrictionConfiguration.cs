using Film.DataAccess.Converters;
using Film.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Film.DataAccess.Configurations
{
    /// <summary>
    /// Configures the entity type AgeRestriction.
    /// </summary>
    public class AgeRestrictionConfiguration : IEntityTypeConfiguration<AgeRestriction>
    {
        /// <summary>
        /// Configures the entity, specifying its primary key, properties, and table constraints.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<AgeRestriction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.Property(i => i.Age)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("Age", "Age > 0 AND Age <= 30"));
        }
    }
}
