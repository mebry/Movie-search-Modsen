using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.DataAccess.Contexts
{
    internal class FilmCollectionContext : DbContext
    {
        public FilmCollectionContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
