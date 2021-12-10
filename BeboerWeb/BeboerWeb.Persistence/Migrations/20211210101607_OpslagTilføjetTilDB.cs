using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeboerWeb.Persistence.Migrations
{
    public partial class OpslagTilføjetTilDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opslag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Dato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Besked = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opslag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpslagsOversigt",
                columns: table => new
                {
                    EjendommeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpslagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpslagsOversigt", x => new { x.EjendommeId, x.OpslagId });
                    table.ForeignKey(
                        name: "FK_OpslagsOversigt_Ejendom_EjendommeId",
                        column: x => x.EjendommeId,
                        principalTable: "Ejendom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpslagsOversigt_Opslag_OpslagId",
                        column: x => x.OpslagId,
                        principalTable: "Opslag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpslagsOversigt_OpslagId",
                table: "OpslagsOversigt",
                column: "OpslagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpslagsOversigt");

            migrationBuilder.DropTable(
                name: "Opslag");
        }
    }
}
