﻿using Microsoft.EntityFrameworkCore;
using Staff.DataAccess.Entities;
using System.Reflection;

namespace Staff.DataAccess.Contexts
{
    public class StaffsDbContext : DbContext
    {
        //private readonly IConfiguration _configuration;
        public virtual DbSet<StaffPerson> Staff { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<StaffPersonPosition> StaffPersonPositions { get; set; }

        public StaffsDbContext(DbContextOptions<StaffsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
