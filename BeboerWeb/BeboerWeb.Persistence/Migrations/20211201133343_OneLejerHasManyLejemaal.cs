using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeboerWeb.Persistence.Migrations
{
    public partial class OneLejerHasManyLejemaal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lejer_LejemaalId",
                table: "Lejer");

            migrationBuilder.CreateIndex(
                name: "IX_Lejer_LejemaalId",
                table: "Lejer",
                column: "LejemaalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lejer_LejemaalId",
                table: "Lejer");

            migrationBuilder.CreateIndex(
                name: "IX_Lejer_LejemaalId",
                table: "Lejer",
                column: "LejemaalId",
                unique: true);
        }
    }
}
