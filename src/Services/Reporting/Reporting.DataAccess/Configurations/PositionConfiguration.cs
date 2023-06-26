using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
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
