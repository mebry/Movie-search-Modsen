using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staff.DataAccess.Entities;

namespace Staff.DataAccess.Configuration
{
    public class StaffPersonPositionConfiguration : IEntityTypeConfiguration<StaffPersonPosition>
    {
        public void Configure(EntityTypeBuilder<StaffPersonPosition> builder)
        {
            builder.Property(x => new { x.StaffPersonId, x.PositionId });

            builder
                .HasOne(x => x.StaffPerson)
                .WithMany(x => x.StaffPersonPositions)
                .HasForeignKey(x => x.StaffPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Position)
                .WithMany(x => x.StaffPersonPositions)
                .HasForeignKey(x => x.PositionId);
        }
    }
}
