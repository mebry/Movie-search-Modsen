using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Staff.DataAccess.Entities;

namespace Staff.DataAccess.Configuration
{
    public class StaffPersonConfiguration : IEntityTypeConfiguration<StaffPerson>
    {
        public void Configure(EntityTypeBuilder<StaffPerson> builder)
        {
            builder.Property(x => x.StaffName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.StaffSurname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();
        }
    }
}
