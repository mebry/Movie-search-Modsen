using Film.DataAccess.Converters;
using Film.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Film.DataAccess.Configurations
{
    /// <summary>
    /// Configures the entity type StaffPerson.
    /// </summary>
    public class StaffPersonConfiguration : IEntityTypeConfiguration<StaffPerson>
    {
        /// <summary>
        /// Configures the entity, specifying its primary key, indexes, and property constraints.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<StaffPerson> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(u => new { u.Name, u.Surname });

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Surname)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
