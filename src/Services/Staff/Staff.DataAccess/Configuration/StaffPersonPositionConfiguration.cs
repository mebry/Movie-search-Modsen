using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staff.DataAccess.Entities;

namespace Staff.DataAccess.Configuration
{
    public class StaffPersonPositionConfiguration : IEntityTypeConfiguration<StaffPersonPosition>
    {
        public void Configure(EntityTypeBuilder<StaffPersonPosition> builder)
        {
            builder.HasKey(x => new { x.StaffPersonId, x.PositionId, x.FilmId });

            builder.Property(x => x.StaffPersonId);
            builder.Property(x => x.PositionId);
            builder.Property(x => x.FilmId);

            builder
                .HasOne(x => x.StaffPerson)
                .WithMany(x => x.StaffPersonPositions)
                .HasForeignKey(x => x.StaffPersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Position)
                .WithMany(x => x.StaffPersonPositions)
                .HasForeignKey(x => x.PositionId);
            builder
                .HasOne(x => x.Film)
                .WithMany(x => x.StaffPersonPositions)
                .HasForeignKey(x => x.FilmId);
        }
    }
}
