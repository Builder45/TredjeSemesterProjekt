using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeboerWeb.Persistence.Migrations
{
    public partial class OneToOneFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lejemaal_Lejer_Id",
                table: "Lejemaal");

            migrationBuilder.AddColumn<Guid>(
                name: "LejemaalId",
                table: "Lejer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Lejer_LejemaalId",
                table: "Lejer",
                column: "LejemaalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lejer_Lejemaal_LejemaalId",
                table: "Lejer",
                column: "LejemaalId",
                principalTable: "Lejemaal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lejer_Lejemaal_LejemaalId",
                table: "Lejer");

            migrationBuilder.DropIndex(
                name: "IX_Lejer_LejemaalId",
                table: "Lejer");

            migrationBuilder.DropColumn(
                name: "LejemaalId",
                table: "Lejer");

            migrationBuilder.AddForeignKey(
                name: "FK_Lejemaal_Lejer_Id",
                table: "Lejemaal",
                column: "Id",
                principalTable: "Lejer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
