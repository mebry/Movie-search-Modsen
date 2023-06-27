using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Configurations
{
    internal class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Score)
               .HasMaxLength(10)
               .IsRequired();

            builder.Property(i => i.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
