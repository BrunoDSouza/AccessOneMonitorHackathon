using AccessOneMonitor.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccessOneMonitor.Data.Configuration
{
    public class DbContextConfiguration : DbContext
    {
        public DbContextConfiguration(DbContextOptions options) : base(options) { }

        public DbSet<Computer> Computers { get; set; }
        public DbSet<Execution> Executions { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Computer>().ToTable("Computers")
                .HasMany(x => x.Executions)
                .WithOne(x => x.Computer)
                .HasForeignKey(x => x.ComputerId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Command>().ToTable("Commands")
                .HasMany(x => x.Executions)
                .WithOne(x => x.Command)
                .HasForeignKey(x => x.CommandId)
                .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Execution>().ToTable("Executions").HasKey(x => x.Id);
        }
    }
}
