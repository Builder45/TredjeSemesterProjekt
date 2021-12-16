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

            var lokaleId1 = Guid.Parse("ddddaaaa-1111-4182-9aff-081c3ae53433");
            var lokaleId2 = Guid.Parse("ddddaaaa-2222-4182-9aff-081c3ae53433");
            var lokaleId3 = Guid.Parse("ddddaaaa-3333-4182-9aff-081c3ae53433");
            var lokaleId4 = Guid.Parse("ddddaaaa-4444-4182-9aff-081c3ae53433");
            var lokaleId5 = Guid.Parse("ddddaaaa-5555-4182-9aff-081c3ae53433");
            var lokaleId6 = Guid.Parse("ddddaaaa-6666-4182-9aff-081c3ae53433");
            var lokaleId7 = Guid.Parse("ddddaaaa-7777-4182-9aff-081c3ae53433");

            var opslagId1 = Guid.Parse("eeeeeeee-1111-4182-9aff-081c3ae53433");
            var opslagId2 = Guid.Parse("eeeeeeee-2222-4182-9aff-081c3ae53433");
            var opslagId3 = Guid.Parse("eeeeeeee-3333-4182-9aff-081c3ae53433");
            var opslagId4 = Guid.Parse("eeeeeeee-4444-4182-9aff-081c3ae53433");
            var opslagId5 = Guid.Parse("eeeeeeee-5555-4182-9aff-081c3ae53433");
            var opslagId6 = Guid.Parse("eeeeeeee-6666-4182-9aff-081c3ae53433");

            var lejerId1 = Guid.Parse("ffffffff-1111-4182-9aff-081c3ae53433");
            var lejerId2 = Guid.Parse("ffffffff-2222-4182-9aff-081c3ae53433");
            var lejerId3 = Guid.Parse("ffffffff-3333-4182-9aff-081c3ae53433");
            var lejerId4 = Guid.Parse("ffffffff-4444-4182-9aff-081c3ae53433");
            var lejerId5 = Guid.Parse("ffffffff-5555-4182-9aff-081c3ae53433");

            var bookingId1 = Guid.Parse("ffffaaaa-1111-4182-9aff-081c3ae53433");
            var bookingId2 = Guid.Parse("ffffaaaa-2222-4182-9aff-081c3ae53433");
            var bookingId3 = Guid.Parse("ffffaaaa-3333-4182-9aff-081c3ae53433");
            var bookingId4 = Guid.Parse("ffffaaaa-4444-4182-9aff-081c3ae53433");
            var bookingId5 = Guid.Parse("ffffaaaa-5555-4182-9aff-081c3ae53433");
            var bookingId6 = Guid.Parse("ffffaaaa-6666-4182-9aff-081c3ae53433");

            var opslagFiller = "Her står bare lidt tilfældige ord, som kan fylde opslaget op med tekst. "
                               + "Her står bare lidt tilfældige ord, som kan fylde opslaget op med tekst. "
                               + "Her står bare lidt tilfældige ord, som kan fylde opslaget op med tekst. "
                               + "Her står bare lidt tilfældige ord, som kan fylde opslaget op med tekst. "
                               + "Her står bare lidt tilfældige ord, som kan fylde opslaget op med tekst. ";


            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = personId1,
                    BrugerId = brugerId1,
                    Fornavn = "Andreas", Efternavn = "Admin", Telefonnr = 12345678
                },
                new Person
                {
                    Id = personId2,
                    BrugerId = brugerId2,
                    Fornavn = "Benny", Efternavn = "Bruger", Telefonnr = 12345678
                },
                new Person
                {
                    Id = personId3,
                    BrugerId = brugerId3,
                    Fornavn = "Lars", Efternavn = "Lejer", Telefonnr = 12345678
                },
                new Person
                {
                    Id = personId4,
                    BrugerId = brugerId4,
                    Fornavn = "Viggo", Efternavn = "Vicevært", Telefonnr = 12345678
                });

            modelBuilder.Entity<Ejendom>().HasData(
                new Ejendom
                {
                    Id = ejendomId1,
                    Adresse = "Alfegade 12", By = "Vejle", Postnr = 7100
                },
                new Ejendom
                {
                    Id = ejendomId2,
                    Adresse = "Bellevej 4", By = "Vejle", Postnr = 7100
                },
                new Ejendom
                {
                    Id = ejendomId3,
                    Adresse = "Cykelallé 33", By = "Vejle", Postnr = 7100
                },
                new Ejendom
                {
                    Id = ejendomId4,
                    Adresse = "Dragevænget 201", By = "Vejle", Postnr = 7100
                },
                new Ejendom
                {
                    Id = ejendomId5,
                    Adresse = "Egetræsbakken 2", By = "Vejle", Postnr = 7100
                });

            modelBuilder.Entity<Lejemaal>().HasData(
                new
                {
                    Id = lejemaalId1, 
                    Adresse = "Alfegade 12", Etage = "Stue", Areal = 55.0, 
                    Husleje = 3300.0, Koekken = true, Badevaerelse = true,
                    EjendomId = ejendomId1
                },
                new
                {
                    Id = lejemaalId2,
                    Adresse = "Alfegade 12", Etage = "1. th", Areal = 40.0,
                    Husleje = 3900.0, Koekken = true, Badevaerelse = true,
                    EjendomId = ejendomId1
                }, 
                new
                {
                    Id = lejemaalId3,
                    Adresse = "Bellevej 4", Etage = "3. tv", Areal = 67.0,
                    Husleje = 4750.0, Koekken = true, Badevaerelse = true,
                    EjendomId = ejendomId2
                },
                new
                {
                    Id = lejemaalId4,
                    Adresse = "Bellevej 5", Etage = "3. th", Areal = 80.0,
                    Husleje = 5120.0, Koekken = true, Badevaerelse = true,
                    EjendomId = ejendomId2
                },
                new
                {
                    Id = lejemaalId5,
                    Adresse = "Cykelallé 33A", Etage = "Stue", Areal = 15.0,
                    Husleje = 1675.0, Koekken = false, Badevaerelse = false,
                    EjendomId = ejendomId3
                },
                new
                {
                    Id = lejemaalId6,
                    Adresse = "Cykelallé 33C", Etage = "Stue", Areal = 25.0,
                    Husleje = 2280.0, Koekken = false, Badevaerelse = true,
                    EjendomId = ejendomId3
                },
                new
                {
                    Id = lejemaalId7,
                    Adresse = "Dragevænget 201", Etage = "1.1", Areal = 54.0,
                    Husleje = 2900.0, Koekken = true, Badevaerelse = true,
                    EjendomId = ejendomId4
                },
                new
                {
                    Id = lejemaalId8,
                    Adresse = "Egetræsbakken 2", Etage = "2. th", Areal = 67.0,
                    Husleje = 4000.0, Koekken = true, Badevaerelse = true,
                    EjendomId = ejendomId5
                }
            );

            modelBuilder.Entity<Lokale>().HasData(
                new
                {
                    Id = lokaleId1, 
                    Navn = "Kælderrum A", Adresse = "Alfegade 12", Etage = "Kælder", Areal = 10.0, 
                    Timepris = 0.0, Koekken = false, Badevaerelse = false,
                    EjendomId = ejendomId1
                },
                new
                {
                    Id = lokaleId2,
                    Navn = "Kælderrum B", Adresse = "Alfegade 12", Etage = "Kælder", Areal = 10.0,
                    Timepris = 0.0, Koekken = false, Badevaerelse = false,
                    EjendomId = ejendomId1
                }, 
                new
                {
                    Id = lokaleId3,
                    Navn = "Kælderrum C", Adresse = "Alfegade 12", Etage = "Kælder", Areal = 10.0,
                    Timepris = 0.0, Koekken = false, Badevaerelse = false,
                    EjendomId = ejendomId1
                }, 
                new
                {
                    Id = lokaleId4,
                    Navn = "Gildesal", Adresse = "Bellevej 4", Etage = "Stue", Areal = 105.0,
                    Timepris = 100.0, Koekken = false, Badevaerelse = true,
                    EjendomId = ejendomId2
                },
                new
                {
                    Id = lokaleId5,
                    Navn = "Gildesal", Adresse = "Bellevej 5", Etage = "Stue", Areal = 110.0,
                    Timepris = 100.0, Koekken = true, Badevaerelse = true,
                    EjendomId = ejendomId2
                },
                new
                {
                    Id = lokaleId6,
                    Navn = "Fællesareal", Adresse = "Cykelallé 33B", Etage = "Stue", Areal = 80.0,
                    Timepris = 0.0, Koekken = false, Badevaerelse = true,
                    EjendomId = ejendomId3
                },
                new
                {
                    Id = lokaleId7,
                    Navn = "Loftrum", Adresse = "Cykelallé 33C", Etage = "4. et", Areal = 25.0,
                    Timepris = 5.0, Koekken = false, Badevaerelse = false,
                    EjendomId = ejendomId3
                }
            );

            modelBuilder.Entity<Opslag>().HasData(
                new
                {
                    Id = opslagId1,
                    Dato = new DateTime(2021, 12, 15), Titel = "Ny affaldssortering 2022",
                    Besked = "I år 2022 kommer der helt ny affaldssortering som vil betyde at " + opslagFiller
                },
                new
                {
                    Id = opslagId2,
                    Dato = new DateTime(2021, 12, 14), Titel = "Hærværk af affaldscontaineren",
                    Besked = "Der har desværre igen været hærværk af affaldscontaineren " + opslagFiller
                },
                new
                {
                    Id = opslagId3,
                    Dato = new DateTime(2021, 12, 12), Titel = "Fibernet på vej til alle",
                    Besked = "Det vil snart være muligt for alle i foreningen at få fibernet " + opslagFiller
                },
                new
                {
                    Id = opslagId4,
                    Dato = new DateTime(2021, 12, 07), Titel = "Nye vandrør på vej",
                    Besked = "Som vi tidligere har meldt ud, vil der blive lagt nye vandrør " + opslagFiller
                },
                new
                {
                    Id = opslagId5,
                    Dato = new DateTime(2021, 11, 30), Titel = "Regelændringer",
                    Besked = "Der har været behov for et par regelændringer. Dette skyldes at " + opslagFiller
                }
                //new
                //{
                //    Id = opslagId6,
                //    Dato = new DateTime(2021, 11, 16), Titel = "Ny lovgivning for lejere i 2022",
                //    Besked = "I år 2022 bliver der indført ny lovgivning for lejere. " + opslagFiller
                //}
            );

            modelBuilder.Entity<Lejer>().HasData(
                new
                {
                    Id = lejerId1,
                    LejeperiodeStart = new DateTime(2021, 12, 1), LejeperiodeSlut = new DateTime(2021, 12, 31),
                    LejemaalId = lejemaalId1,
                },
                new
                {
                    Id = lejerId2,
                    LejeperiodeStart = new DateTime(2020, 1, 1), LejeperiodeSlut = new DateTime(2022, 12, 31),
                    LejemaalId = lejemaalId2,
                },
                new
                {
                    Id = lejerId3,
                    LejeperiodeStart = new DateTime(2021, 1, 1), LejeperiodeSlut = new DateTime(2022, 12, 31),
                    LejemaalId = lejemaalId3,
                }
            );

            modelBuilder.Entity<Lejer>()
                .HasMany(le => le.Personer)
                .WithMany(p => p.Lejere)
                .UsingEntity(lo => lo.HasData(
                    new { LejereId = lejerId1, PersonerId = personId3 },
                    new { LejereId = lejerId2, PersonerId = personId4 },
                    new { LejereId = lejerId3, PersonerId = personId3 },
                    new { LejereId = lejerId3, PersonerId = personId4 }
                ));

            modelBuilder.Entity<Opslag>()
                .HasMany(o => o.Ejendomme)
                .WithMany(e => e.Opslag)
                .UsingEntity(lo => lo.HasData(
                    new { EjendommeId = ejendomId1, OpslagId = opslagId1 },
                    new { EjendommeId = ejendomId2, OpslagId = opslagId1 },
                    new { EjendommeId = ejendomId3, OpslagId = opslagId1 },
                    new { EjendommeId = ejendomId4, OpslagId = opslagId1 },
                    new { EjendommeId = ejendomId5, OpslagId = opslagId1 },
                    new { EjendommeId = ejendomId1, OpslagId = opslagId2 },
                    new { EjendommeId = ejendomId3, OpslagId = opslagId3 },
                    new { EjendommeId = ejendomId4, OpslagId = opslagId4 },
                    new { EjendommeId = ejendomId5, OpslagId = opslagId5 },
                    new { EjendommeId = ejendomId1, OpslagId = opslagId6 },
                    new { EjendommeId = ejendomId2, OpslagId = opslagId6 },
                    new { EjendommeId = ejendomId3, OpslagId = opslagId6 },
                    new { EjendommeId = ejendomId4, OpslagId = opslagId6 },
                    new { EjendommeId = ejendomId5, OpslagId = opslagId6 }
                ));


            //modelBuilder.Entity("OpslagsOversigt").HasData(
            //    new
            //    {
            //        EjendommeId = ejendomId1,
            //        OpslagId = opslagId1
            //    });

            base.OnModelCreating(modelBuilder);
        }
    }
}