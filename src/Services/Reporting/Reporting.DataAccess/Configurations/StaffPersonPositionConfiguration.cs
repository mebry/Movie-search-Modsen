using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Configurations
{
    public class StaffPersonPositionConfiguration : IEntityTypeConfiguration<StaffPersonPosition>
    {
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
