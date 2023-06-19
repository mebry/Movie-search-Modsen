using Film.DataAccess.Converters;
using Film.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Film.DataAccess.Configurations
{
    /// <summary>
    /// Configures the entity type StaffPersonPosition.
    /// </summary>
    public class StaffPersonPositionConfiguration : IEntityTypeConfiguration<StaffPersonPosition>
    {
        /// <summary>
        /// Configures the entity, specifying its primary key and relationships.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<StaffPersonPosition> builder)
        {
            builder.HasKey(p => new
            {
                p.FilmId,
                p.StaffPersonId,
                p.PositionId
            });

            builder.HasOne(p => p.Film)
                .WithMany(p => p.StaffPersonPositions)
                .HasForeignKey(p => p.FilmId);

            builder.HasOne(p => p.Position)
                .WithMany(p => p.StaffPersonPositions)
                .HasForeignKey(p => p.PositionId);

            builder.HasOne(p => p.StaffPerson)
                .WithMany(p => p.StaffPersonPositions)
                .HasForeignKey(p => p.StaffPersonId);
        }
    }
}
