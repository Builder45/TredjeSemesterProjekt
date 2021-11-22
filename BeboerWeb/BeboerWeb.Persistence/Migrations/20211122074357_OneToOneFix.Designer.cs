﻿// <auto-generated />
using System;
using BeboerWeb.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeboerWeb.Persistence.Migrations
{
    [DbContext(typeof(BeboerWebContext))]
    [Migration("20211122074357_OneToOneFix")]
    partial class OneToOneFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AfdelingBoligadministrator", b =>
                {
                    b.Property<Guid>("AfdelingerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BoligadministratorerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AfdelingerId", "BoligadministratorerId");

                    b.HasIndex("BoligadministratorerId");

                    b.ToTable("AfdelingBoligadministrator");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Afdeling", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Navn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Afdeling");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Boligadministrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Boligadminstrator");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("BookingPeriodeSlut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingPeriodeStart")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LokaleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LokaleId");

                    b.HasIndex("PersonId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Bygning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EjendomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Postnr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EjendomId");

                    b.ToTable("Bygning");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Ejendom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AfdelingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Postnr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AfdelingId");

                    b.ToTable("Ejendom");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Lejemaal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<double>("Areal")
                        .HasColumnType("float");

                    b.Property<bool>("Badevaerelse")
                        .HasColumnType("bit");

                    b.Property<Guid?>("BygningId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Etage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Husleje")
                        .HasColumnType("float");

                    b.Property<bool>("Koekken")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BygningId");

                    b.ToTable("Lejemaal");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Lejer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("LejemaalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LejeperiodeSlut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LejeperiodeStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LejemaalId")
                        .IsUnique();

                    b.ToTable("Lejer");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Lokale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<double>("Areal")
                        .HasColumnType("float");

                    b.Property<bool>("Badevaerelse")
                        .HasColumnType("bit");

                    b.Property<Guid?>("BygningId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Etage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Koekken")
                        .HasColumnType("bit");

                    b.Property<double>("Timepris")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BygningId");

                    b.ToTable("Lokale");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Efternavn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fornavn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefonnr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Vicevaert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Vicevaert");
                });

            modelBuilder.Entity("EjendomVicevaert", b =>
                {
                    b.Property<Guid>("EjendommeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VicevaerterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EjendommeId", "VicevaerterId");

                    b.HasIndex("VicevaerterId");

                    b.ToTable("EjendomVicevaert");
                });

            modelBuilder.Entity("LejerPerson", b =>
                {
                    b.Property<Guid>("LejereId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LejereId", "PersonerId");

                    b.HasIndex("PersonerId");

                    b.ToTable("LejerPerson");
                });

            modelBuilder.Entity("AfdelingBoligadministrator", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Afdeling", null)
                        .WithMany()
                        .HasForeignKey("AfdelingerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeboerWeb.Domain.Models.Boligadministrator", null)
                        .WithMany()
                        .HasForeignKey("BoligadministratorerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Boligadministrator", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Booking", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Lokale", "Lokale")
                        .WithMany("Bookinger")
                        .HasForeignKey("LokaleId");

                    b.HasOne("BeboerWeb.Domain.Models.Person", "Person")
                        .WithMany("Bookinger")
                        .HasForeignKey("PersonId");

                    b.Navigation("Lokale");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Bygning", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Ejendom", "Ejendom")
                        .WithMany("Bygninger")
                        .HasForeignKey("EjendomId");

                    b.Navigation("Ejendom");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Ejendom", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Afdeling", "Afdeling")
                        .WithMany("Ejendomme")
                        .HasForeignKey("AfdelingId");

                    b.Navigation("Afdeling");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Lejemaal", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Bygning", "Bygning")
                        .WithMany("Lejemaal")
                        .HasForeignKey("BygningId");

                    b.Navigation("Bygning");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Lejer", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Lejemaal", "Lejemaal")
                        .WithOne("Lejer")
                        .HasForeignKey("BeboerWeb.Domain.Models.Lejer", "LejemaalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lejemaal");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Lokale", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Bygning", "Bygning")
                        .WithMany("Lokaler")
                        .HasForeignKey("BygningId");

                    b.Navigation("Bygning");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Vicevaert", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EjendomVicevaert", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Ejendom", null)
                        .WithMany()
                        .HasForeignKey("EjendommeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeboerWeb.Domain.Models.Vicevaert", null)
                        .WithMany()
                        .HasForeignKey("VicevaerterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LejerPerson", b =>
                {
                    b.HasOne("BeboerWeb.Domain.Models.Lejer", null)
                        .WithMany()
                        .HasForeignKey("LejereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeboerWeb.Domain.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Afdeling", b =>
                {
                    b.Navigation("Ejendomme");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Bygning", b =>
                {
                    b.Navigation("Lejemaal");

                    b.Navigation("Lokaler");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Ejendom", b =>
                {
                    b.Navigation("Bygninger");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Lejemaal", b =>
                {
                    b.Navigation("Lejer");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Lokale", b =>
                {
                    b.Navigation("Bookinger");
                });

            modelBuilder.Entity("BeboerWeb.Domain.Models.Person", b =>
                {
                    b.Navigation("Bookinger");
                });
#pragma warning restore 612, 618
        }
    }
}
