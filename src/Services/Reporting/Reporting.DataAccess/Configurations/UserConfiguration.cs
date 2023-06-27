using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
               .IsRequired();

            builder.HasIndex(i => i.Username);
        }
    }
}
