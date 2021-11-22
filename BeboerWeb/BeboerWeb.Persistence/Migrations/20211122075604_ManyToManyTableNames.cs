using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeboerWeb.Persistence.Migrations
{
    public partial class ManyToManyTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AfdelingBoligadministrator_Afdeling_AfdelingerId",
                table: "AfdelingBoligadministrator");

            migrationBuilder.DropForeignKey(
                name: "FK_AfdelingBoligadministrator_Boligadminstrator_BoligadministratorerId",
                table: "AfdelingBoligadministrator");

            migrationBuilder.DropForeignKey(
                name: "FK_EjendomVicevaert_Ejendom_EjendommeId",
                table: "EjendomVicevaert");

            migrationBuilder.DropForeignKey(
                name: "FK_EjendomVicevaert_Vicevaert_VicevaerterId",
                table: "EjendomVicevaert");

            migrationBuilder.DropForeignKey(
                name: "FK_LejerPerson_Lejer_LejereId",
                table: "LejerPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_LejerPerson_Person_PersonerId",
                table: "LejerPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LejerPerson",
                table: "LejerPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EjendomVicevaert",
                table: "EjendomVicevaert");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AfdelingBoligadministrator",
                table: "AfdelingBoligadministrator");

            migrationBuilder.RenameTable(
                name: "LejerPerson",
                newName: "LejerOversigt");

            migrationBuilder.RenameTable(
                name: "EjendomVicevaert",
                newName: "ServiceOversigt");

            migrationBuilder.RenameTable(
                name: "AfdelingBoligadministrator",
                newName: "AdminOversigt");

            migrationBuilder.RenameIndex(
                name: "IX_LejerPerson_PersonerId",
                table: "LejerOversigt",
                newName: "IX_LejerOversigt_PersonerId");

            migrationBuilder.RenameIndex(
                name: "IX_EjendomVicevaert_VicevaerterId",
                table: "ServiceOversigt",
                newName: "IX_ServiceOversigt_VicevaerterId");

            migrationBuilder.RenameIndex(
                name: "IX_AfdelingBoligadministrator_BoligadministratorerId",
                table: "AdminOversigt",
                newName: "IX_AdminOversigt_BoligadministratorerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LejerOversigt",
                table: "LejerOversigt",
                columns: new[] { "LejereId", "PersonerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOversigt",
                table: "ServiceOversigt",
                columns: new[] { "EjendommeId", "VicevaerterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminOversigt",
                table: "AdminOversigt",
                columns: new[] { "AfdelingerId", "BoligadministratorerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdminOversigt_Afdeling_AfdelingerId",
                table: "AdminOversigt",
                column: "AfdelingerId",
                principalTable: "Afdeling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminOversigt_Boligadminstrator_BoligadministratorerId",
                table: "AdminOversigt",
                column: "BoligadministratorerId",
                principalTable: "Boligadminstrator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LejerOversigt_Lejer_LejereId",
                table: "LejerOversigt",
                column: "LejereId",
                principalTable: "Lejer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LejerOversigt_Person_PersonerId",
                table: "LejerOversigt",
                column: "PersonerId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOversigt_Ejendom_EjendommeId",
                table: "ServiceOversigt",
                column: "EjendommeId",
                principalTable: "Ejendom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOversigt_Vicevaert_VicevaerterId",
                table: "ServiceOversigt",
                column: "VicevaerterId",
                principalTable: "Vicevaert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminOversigt_Afdeling_AfdelingerId",
                table: "AdminOversigt");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminOversigt_Boligadminstrator_BoligadministratorerId",
                table: "AdminOversigt");

            migrationBuilder.DropForeignKey(
                name: "FK_LejerOversigt_Lejer_LejereId",
                table: "LejerOversigt");

            migrationBuilder.DropForeignKey(
                name: "FK_LejerOversigt_Person_PersonerId",
                table: "LejerOversigt");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOversigt_Ejendom_EjendommeId",
                table: "ServiceOversigt");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOversigt_Vicevaert_VicevaerterId",
                table: "ServiceOversigt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOversigt",
                table: "ServiceOversigt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LejerOversigt",
                table: "LejerOversigt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminOversigt",
                table: "AdminOversigt");

            migrationBuilder.RenameTable(
                name: "ServiceOversigt",
                newName: "EjendomVicevaert");

            migrationBuilder.RenameTable(
                name: "LejerOversigt",
                newName: "LejerPerson");

            migrationBuilder.RenameTable(
                name: "AdminOversigt",
                newName: "AfdelingBoligadministrator");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOversigt_VicevaerterId",
                table: "EjendomVicevaert",
                newName: "IX_EjendomVicevaert_VicevaerterId");

            migrationBuilder.RenameIndex(
                name: "IX_LejerOversigt_PersonerId",
                table: "LejerPerson",
                newName: "IX_LejerPerson_PersonerId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminOversigt_BoligadministratorerId",
                table: "AfdelingBoligadministrator",
                newName: "IX_AfdelingBoligadministrator_BoligadministratorerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EjendomVicevaert",
                table: "EjendomVicevaert",
                columns: new[] { "EjendommeId", "VicevaerterId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LejerPerson",
                table: "LejerPerson",
                columns: new[] { "LejereId", "PersonerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AfdelingBoligadministrator",
                table: "AfdelingBoligadministrator",
                columns: new[] { "AfdelingerId", "BoligadministratorerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AfdelingBoligadministrator_Afdeling_AfdelingerId",
                table: "AfdelingBoligadministrator",
                column: "AfdelingerId",
                principalTable: "Afdeling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AfdelingBoligadministrator_Boligadminstrator_BoligadministratorerId",
                table: "AfdelingBoligadministrator",
                column: "BoligadministratorerId",
                principalTable: "Boligadminstrator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EjendomVicevaert_Ejendom_EjendommeId",
                table: "EjendomVicevaert",
                column: "EjendommeId",
                principalTable: "Ejendom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EjendomVicevaert_Vicevaert_VicevaerterId",
                table: "EjendomVicevaert",
                column: "VicevaerterId",
                principalTable: "Vicevaert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LejerPerson_Lejer_LejereId",
                table: "LejerPerson",
                column: "LejereId",
                principalTable: "Lejer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LejerPerson_Person_PersonerId",
                table: "LejerPerson",
                column: "PersonerId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
