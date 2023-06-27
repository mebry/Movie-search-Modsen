using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Configurations
{
    public class StaffPersonConfiguration : IEntityTypeConfiguration<StaffPerson>
    {
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
