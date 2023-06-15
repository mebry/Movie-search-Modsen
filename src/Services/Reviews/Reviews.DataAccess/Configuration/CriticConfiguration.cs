using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviews.DataAccess.Entities;

namespace Reviews.DataAccess.Configuration
{
    public class CriticConfiguration : IEntityTypeConfiguration<Critic>
    {
        public void Configure(EntityTypeBuilder<Critic> builder)
        {
            builder.Property(x => x.Username).IsRequired();
        }
    }
}
