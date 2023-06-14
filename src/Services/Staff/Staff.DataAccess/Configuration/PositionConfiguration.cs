using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staff.DataAccess.Entities;
using Staff.DataAccess.SeedData;

namespace Staff.DataAccess.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                SeedPositions.ActorPosition,
                SeedPositions.RegisseurPosition,
                SeedPositions.ProducerPosition,
                SeedPositions.OperatorPosition,
                SeedPositions.ComposerPosition,
                SeedPositions.ArtistPosition,
                SeedPositions.MontagePosition);
        }
    }
}
