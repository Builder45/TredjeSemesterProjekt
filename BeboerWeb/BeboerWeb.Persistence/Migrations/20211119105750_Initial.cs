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
                    Telefonnr = table.Column<int>(type: "int", nullable: false)
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
                name: "Boligadminstratorer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boligadminstratorer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boligadminstratorer_Person_PersonId",
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
                name: "Bygning",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postnr = table.Column<int>(type: "int", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EjendomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bygning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bygning_Ejendom_EjendomId",
                        column: x => x.EjendomId,
                        principalTable: "Ejendom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AfdelingBoligadministrator",
                columns: table => new
                {
                    AfdelingerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoligadministratorerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfdelingBoligadministrator", x => new { x.AfdelingerId, x.BoligadministratorerId });
                    table.ForeignKey(
                        name: "FK_AfdelingBoligadministrator_Afdeling_AfdelingerId",
                        column: x => x.AfdelingerId,
                        principalTable: "Afdeling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AfdelingBoligadministrator_Boligadminstratorer_BoligadministratorerId",
                        column: x => x.BoligadministratorerId,
                        principalTable: "Boligadminstratorer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EjendomVicevaert",
                columns: table => new
                {
                    EjendommeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VicevaerterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjendomVicevaert", x => new { x.EjendommeId, x.VicevaerterId });
                    table.ForeignKey(
                        name: "FK_EjendomVicevaert_Ejendom_EjendommeId",
                        column: x => x.EjendommeId,
                        principalTable: "Ejendom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EjendomVicevaert_Vicevaert_VicevaerterId",
                        column: x => x.VicevaerterId,
                        principalTable: "Vicevaert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lejemaal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Husleje = table.Column<double>(type: "float", nullable: false),
                    Etage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Areal = table.Column<double>(type: "float", nullable: false),
                    Koekken = table.Column<bool>(type: "bit", nullable: false),
                    Badevaerelse = table.Column<bool>(type: "bit", nullable: false),
                    BygningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejemaal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lejemaal_Bygning_BygningId",
                        column: x => x.BygningId,
                        principalTable: "Bygning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lokale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Etage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timepris = table.Column<double>(type: "float", nullable: false),
                    Areal = table.Column<double>(type: "float", nullable: false),
                    Koekken = table.Column<bool>(type: "bit", nullable: false),
                    Badevaerelse = table.Column<bool>(type: "bit", nullable: false),
                    BygningId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lokale_Bygning_BygningId",
                        column: x => x.BygningId,
                        principalTable: "Bygning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lejer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    LejeperiodeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LejeperiodeSlut = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lejer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lejer_Lejemaal_Id",
                        column: x => x.Id,
                        principalTable: "Lejemaal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookinger",
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
                    table.PrimaryKey("PK_Bookinger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookinger_Lokale_LokaleId",
                        column: x => x.LokaleId,
                        principalTable: "Lokale",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookinger_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LejerPerson",
                columns: table => new
                {
                    LejereId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LejerPerson", x => new { x.LejereId, x.PersonerId });
                    table.ForeignKey(
                        name: "FK_LejerPerson_Lejer_LejereId",
                        column: x => x.LejereId,
                        principalTable: "Lejer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LejerPerson_Person_PersonerId",
                        column: x => x.PersonerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AfdelingBoligadministrator_BoligadministratorerId",
                table: "AfdelingBoligadministrator",
                column: "BoligadministratorerId");

            migrationBuilder.CreateIndex(
                name: "IX_Boligadminstratorer_PersonId",
                table: "Boligadminstratorer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookinger_LokaleId",
                table: "Bookinger",
                column: "LokaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookinger_PersonId",
                table: "Bookinger",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Bygning_EjendomId",
                table: "Bygning",
                column: "EjendomId");

            migrationBuilder.CreateIndex(
                name: "IX_Ejendom_AfdelingId",
                table: "Ejendom",
                column: "AfdelingId");

            migrationBuilder.CreateIndex(
                name: "IX_EjendomVicevaert_VicevaerterId",
                table: "EjendomVicevaert",
                column: "VicevaerterId");

            migrationBuilder.CreateIndex(
                name: "IX_Lejemaal_BygningId",
                table: "Lejemaal",
                column: "BygningId");

            migrationBuilder.CreateIndex(
                name: "IX_LejerPerson_PersonerId",
                table: "LejerPerson",
                column: "PersonerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokale_BygningId",
                table: "Lokale",
                column: "BygningId");

            migrationBuilder.CreateIndex(
                name: "IX_Vicevaert_PersonId",
                table: "Vicevaert",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfdelingBoligadministrator");

            migrationBuilder.DropTable(
                name: "Bookinger");

            migrationBuilder.DropTable(
                name: "EjendomVicevaert");

            migrationBuilder.DropTable(
                name: "LejerPerson");

            migrationBuilder.DropTable(
                name: "Boligadminstratorer");

            migrationBuilder.DropTable(
                name: "Lokale");

            migrationBuilder.DropTable(
                name: "Vicevaert");

            migrationBuilder.DropTable(
                name: "Lejer");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Lejemaal");

            migrationBuilder.DropTable(
                name: "Bygning");

            migrationBuilder.DropTable(
                name: "Ejendom");

            migrationBuilder.DropTable(
                name: "Afdeling");
        }
    }
}
