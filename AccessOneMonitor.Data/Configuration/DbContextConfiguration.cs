using AccessOneMonitor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessOneMonitor.Data.Configuration
{
    public class DbContextConfiguration : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Execution> Executions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Computer>().ToTable("dbo.Computers").HasKey(x => x.Id);
            modelBuilder.Entity<Process>().ToTable("dbo.Processes").HasKey(x => x.Id);
            modelBuilder.Entity<Execution>().ToTable("dbo.Executions").HasKey(x => x.Id);
        }
    }
}
