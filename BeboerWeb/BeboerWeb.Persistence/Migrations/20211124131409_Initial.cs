using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeboerWeb.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afdeling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afdeling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Fornavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efternavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefonnr = table.Column<int>(type: "int", nullable: false),
                    BrugerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ejendom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postnr = table.Column<int>(type: "int", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfdelingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejendom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ejendom_Afdeling_AfdelingId",
                        column: x => x.AfdelingId,
                        principalTable: "Afdeling",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Boligadminstrator",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boligadminstrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boligadminstrator_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vicevaert",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vicevaert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vicevaert_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lejemaal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Husleje = table.Column<double>(type: "float", nullable: false),
                    Areal = table.Column<double>(type: "float", nullable: false),
                    Koekken = table.Column<bool>(type: "bit", nullable: false),
                    Badevaerelse = table.Column<bool>(type: "bit", nullable: false),
                    EjendomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejemaal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lejemaal_Ejendom_EjendomId",
                        column: x => x.EjendomId,
                        principalTable: "Ejendom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lokale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timepris = table.Column<double>(type: "float", nullable: false),
                    Areal = table.Column<double>(type: "float", nullable: false),
                    Koekken = table.Column<bool>(type: "bit", nullable: false),
                    Badevaerelse = table.Column<bool>(type: "bit", nullable: false),
                    EjendomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lokale_Ejendom_EjendomId",
                        column: x => x.EjendomId,
                        principalTable: "Ejendom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdminOversigt",
                columns: table => new
                {
                    AfdelingerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoligadministratorerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminOversigt", x => new { x.AfdelingerId, x.BoligadministratorerId });
                    table.ForeignKey(
                        name: "FK_AdminOversigt_Afdeling_AfdelingerId",
                        column: x => x.AfdelingerId,
                        principalTable: "Afdeling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminOversigt_Boligadminstrator_BoligadministratorerId",
                        column: x => x.BoligadministratorerId,
                        principalTable: "Boligadminstrator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOversigt",
                columns: table => new
                {
                    EjendommeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VicevaerterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOversigt", x => new { x.EjendommeId, x.VicevaerterId });
                    table.ForeignKey(
                        name: "FK_ServiceOversigt_Ejendom_EjendommeId",
                        column: x => x.EjendommeId,
                        principalTable: "Ejendom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOversigt_Vicevaert_VicevaerterId",
                        column: x => x.VicevaerterId,
                        principalTable: "Vicevaert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lejer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    LejeperiodeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LejeperiodeSlut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LejemaalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lejer_Lejemaal_LejemaalId",
                        column: x => x.LejemaalId,
                        principalTable: "Lejemaal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    BookingPeriodeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingPeriodeSlut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LokaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Lokale_LokaleId",
                        column: x => x.LokaleId,
                        principalTable: "Lokale",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Booking_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LejerOversigt",
                columns: table => new
                {
                    LejereId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LejerOversigt", x => new { x.LejereId, x.PersonerId });
                    table.ForeignKey(
                        name: "FK_LejerOversigt_Lejer_LejereId",
                        column: x => x.LejereId,
                        principalTable: "Lejer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LejerOversigt_Person_PersonerId",
                        column: x => x.PersonerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminOversigt_BoligadministratorerId",
                table: "AdminOversigt",
                column: "BoligadministratorerId");

            migrationBuilder.CreateIndex(
                name: "IX_Boligadminstrator_PersonId",
                table: "Boligadminstrator",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_LokaleId",
                table: "Booking",
                column: "LokaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PersonId",
                table: "Booking",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Ejendom_AfdelingId",
                table: "Ejendom",
                column: "AfdelingId");

            migrationBuilder.CreateIndex(
                name: "IX_Lejemaal_EjendomId",
                table: "Lejemaal",
                column: "EjendomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lejer_LejemaalId",
                table: "Lejer",
                column: "LejemaalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LejerOversigt_PersonerId",
                table: "LejerOversigt",
                column: "PersonerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokale_EjendomId",
                table: "Lokale",
                column: "EjendomId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOversigt_VicevaerterId",
                table: "ServiceOversigt",
                column: "VicevaerterId");

            migrationBuilder.CreateIndex(
                name: "IX_Vicevaert_PersonId",
                table: "Vicevaert",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminOversigt");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "LejerOversigt");

            migrationBuilder.DropTable(
                name: "ServiceOversigt");

            migrationBuilder.DropTable(
                name: "Boligadminstrator");

            migrationBuilder.DropTable(
                name: "Lokale");

            migrationBuilder.DropTable(
                name: "Lejer");

            migrationBuilder.DropTable(
                name: "Vicevaert");

            migrationBuilder.DropTable(
                name: "Lejemaal");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Ejendom");

            migrationBuilder.DropTable(
                name: "Afdeling");
        }
    }
}
