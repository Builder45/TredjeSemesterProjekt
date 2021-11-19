using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeboerWeb.Persistence.Migrations
{
    public partial class OneToOneUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AfdelingBoligadministrator_Boligadminstratorer_BoligadministratorerId",
                table: "AfdelingBoligadministrator");

            migrationBuilder.DropForeignKey(
                name: "FK_Boligadminstratorer_Person_PersonId",
                table: "Boligadminstratorer");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookinger_Lokale_LokaleId",
                table: "Bookinger");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookinger_Person_PersonId",
                table: "Bookinger");

            migrationBuilder.DropForeignKey(
                name: "FK_Lejer_Lejemaal_Id",
                table: "Lejer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookinger",
                table: "Bookinger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boligadminstratorer",
                table: "Boligadminstratorer");

            migrationBuilder.RenameTable(
                name: "Bookinger",
                newName: "Booking");

            migrationBuilder.RenameTable(
                name: "Boligadminstratorer",
                newName: "Boligadminstrator");

            migrationBuilder.RenameIndex(
                name: "IX_Bookinger_PersonId",
                table: "Booking",
                newName: "IX_Booking_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookinger_LokaleId",
                table: "Booking",
                newName: "IX_Booking_LokaleId");

            migrationBuilder.RenameIndex(
                name: "IX_Boligadminstratorer_PersonId",
                table: "Boligadminstrator",
                newName: "IX_Boligadminstrator_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boligadminstrator",
                table: "Boligadminstrator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AfdelingBoligadministrator_Boligadminstrator_BoligadministratorerId",
                table: "AfdelingBoligadministrator",
                column: "BoligadministratorerId",
                principalTable: "Boligadminstrator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boligadminstrator_Person_PersonId",
                table: "Boligadminstrator",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Lokale_LokaleId",
                table: "Booking",
                column: "LokaleId",
                principalTable: "Lokale",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Person_PersonId",
                table: "Booking",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lejemaal_Lejer_Id",
                table: "Lejemaal",
                column: "Id",
                principalTable: "Lejer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AfdelingBoligadministrator_Boligadminstrator_BoligadministratorerId",
                table: "AfdelingBoligadministrator");

            migrationBuilder.DropForeignKey(
                name: "FK_Boligadminstrator_Person_PersonId",
                table: "Boligadminstrator");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Lokale_LokaleId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Person_PersonId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Lejemaal_Lejer_Id",
                table: "Lejemaal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boligadminstrator",
                table: "Boligadminstrator");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookinger");

            migrationBuilder.RenameTable(
                name: "Boligadminstrator",
                newName: "Boligadminstratorer");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_PersonId",
                table: "Bookinger",
                newName: "IX_Bookinger_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_LokaleId",
                table: "Bookinger",
                newName: "IX_Bookinger_LokaleId");

            migrationBuilder.RenameIndex(
                name: "IX_Boligadminstrator_PersonId",
                table: "Boligadminstratorer",
                newName: "IX_Boligadminstratorer_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookinger",
                table: "Bookinger",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boligadminstratorer",
                table: "Boligadminstratorer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AfdelingBoligadministrator_Boligadminstratorer_BoligadministratorerId",
                table: "AfdelingBoligadministrator",
                column: "BoligadministratorerId",
                principalTable: "Boligadminstratorer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boligadminstratorer_Person_PersonId",
                table: "Boligadminstratorer",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookinger_Lokale_LokaleId",
                table: "Bookinger",
                column: "LokaleId",
                principalTable: "Lokale",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookinger_Person_PersonId",
                table: "Bookinger",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lejer_Lejemaal_Id",
                table: "Lejer",
                column: "Id",
                principalTable: "Lejemaal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
