using FilmCollection.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.Property(g => g.Name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
