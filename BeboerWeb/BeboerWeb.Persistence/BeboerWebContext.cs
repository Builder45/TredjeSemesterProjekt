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
        public DbSet<Ejendom> Ejendom { get; set; }
        public DbSet<Lejemaal> Lejemaal { get; set; }
        public DbSet<Lejer> Lejer { get; set; }
        public DbSet<Lokale> Lokale { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Vicevaert> Vicevaert { get; set; }
        public DbSet<Opslag> Opslag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var personId1 = Guid.Parse("aaaaaaaa-1111-4182-9aff-081c3ae53433");
            var personId2 = Guid.Parse("aaaaaaaa-2222-4182-9aff-081c3ae53433");
            var personId3 = Guid.Parse("aaaaaaaa-3333-4182-9aff-081c3ae53433");
            var personId4 = Guid.Parse("aaaaaaaa-4444-4182-9aff-081c3ae53433");

            var brugerId1 = Guid.Parse("bbbbbbbb-1111-4182-9aff-081c3ae53433");
            var brugerId2 = Guid.Parse("bbbbbbbb-2222-4182-9aff-081c3ae53433");
            var brugerId3 = Guid.Parse("bbbbbbbb-3333-4182-9aff-081c3ae53433");
            var brugerId4 = Guid.Parse("bbbbbbbb-4444-4182-9aff-081c3ae53433");

            var ejendomId1 = Guid.Parse("cccccccc-1111-4182-9aff-081c3ae53433");
            var ejendomId2 = Guid.Parse("cccccccc-2222-4182-9aff-081c3ae53433");
            var ejendomId3 = Guid.Parse("cccccccc-3333-4182-9aff-081c3ae53433");
            var ejendomId4 = Guid.Parse("cccccccc-4444-4182-9aff-081c3ae53433");
            var ejendomId5 = Guid.Parse("cccccccc-5555-4182-9aff-081c3ae53433");

            var lejemaalId1 = Guid.Parse("dddddddd-1111-4182-9aff-081c3ae53433");
            var lejemaalId2 = Guid.Parse("dddddddd-2222-4182-9aff-081c3ae53433");
            var lejemaalId3 = Guid.Parse("dddddddd-3333-4182-9aff-081c3ae53433");
            var lejemaalId4 = Guid.Parse("dddddddd-4444-4182-9aff-081c3ae53433");
            var lejemaalId5 = Guid.Parse("dddddddd-5555-4182-9aff-081c3ae53433");
            var lejemaalId6 = Guid.Parse("dddddddd-6666-4182-9aff-081c3ae53433");
            var lejemaalId7 = Guid.Parse("dddddddd-7777-4182-9aff-081c3ae53433");
            var lejemaalId8 = Guid.Parse("dddddddd-8888-4182-9aff-081c3ae53433");

            var opslagId1 = Guid.Parse("eeeeeeee-1111-4182-9aff-081c3ae53433");



            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = personId1,
                    BrugerId = brugerId1,
                    Fornavn = "Andreas",
                    Efternavn = "Admin",
                    Telefonnr = 12345678
                },
                new Person
                {
                    Id = personId2,
                    BrugerId = brugerId2,
                    Fornavn = "Benny",
                    Efternavn = "Bruger",
                    Telefonnr = 12345678
                },
                new Person
                {
                    Id = personId3,
                    BrugerId = brugerId3,
                    Fornavn = "Lars",
                    Efternavn = "Lejer",
                    Telefonnr = 12345678
                },
                new Person
                {
                    Id = personId4,
                    BrugerId = brugerId4,
                    Fornavn = "Viggo",
                    Efternavn = "Vicevært",
                    Telefonnr = 12345678
                });

            modelBuilder.Entity<Ejendom>().HasData(
                new Ejendom
                {
                    Id = ejendomId1,
                    Adresse = "Alfegade 12",
                    By = "Vejle",
                    Postnr = 7100
                },
                new Ejendom
                {
                    Id = ejendomId2,
                    Adresse = "Bellevej 4",
                    By = "Vejle",
                    Postnr = 7100
                },
                new Ejendom
                {
                    Id = ejendomId3,
                    Adresse = "Cykelallé 33",
                    By = "Vejle",
                    Postnr = 7100
                },
                new Ejendom
                {
                    Id = ejendomId4,
                    Adresse = "Dragevænget 201",
                    By = "Vejle",
                    Postnr = 7100
                },
                new Ejendom
                {
                    Id = ejendomId5,
                    Adresse = "Egetræsbakken 2",
                    By = "Vejle",
                    Postnr = 7100
                });

            modelBuilder.Entity<Lejemaal>().HasData(
                new
                {
                    Id = lejemaalId1,
                    Adresse = "Alfegade 12",
                    Etage = "Stue",
                    Areal = 55.0,
                    Husleje = 2300.0,
                    Koekken = true,
                    Badevaerelse = true,
                    EjendomId = ejendomId1
                },
                new
                {
                    Id = lejemaalId2,
                    Adresse = "Alfegade 12",
                    Etage = "1. th",
                    Areal = 40.0,
                    Husleje = 1900.0,
                    Koekken = true,
                    Badevaerelse = true,
                    EjendomId = ejendomId1
                });

            modelBuilder.Entity<Opslag>().HasData(
                new
                {
                    Id = opslagId1,
                    Dato = new DateTime(2021, 12, 20),
                    Titel = "Test Titel",
                    Besked = "Test Besked"
                }
            );

            //modelBuilder.Entity("OpslagsOversigt").HasData(
            //    new
            //    {
            //        Id = 1,
            //        EjendommeId = ejendomId1, 
            //        OpslagId = opslagId1
            //    });
        }
    }
}