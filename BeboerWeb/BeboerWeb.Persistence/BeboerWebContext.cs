using BeboerWeb.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace BeboerWeb.Persistence
{
    public class BeboerWebContext:DbContext
    {
        public BeboerWebContext(DbContextOptions<BeboerWebContext> options) : base(options)
        {
        }

        public DbSet<Afdeling> Afdeling { get; set; }
        public DbSet<Boligadministrator> Boligadminstrator { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Bygning> Bygning { get; set; }
        public DbSet<Ejendom> Ejendom { get; set; }
        public DbSet<Lejemaal> Lejemaal { get; set; }
        public DbSet<Lejer> Lejer { get; set; }
        public DbSet<Lokale> Lokale { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Vicevaert> Vicevaert { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}