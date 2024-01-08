using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    public partial class Addforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_classe",
                table: "Utenti",
                newName: "ClassiId");

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_ClassiId",
                table: "Utenti",
                column: "ClassiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utenti_Classi_ClassiId",
                table: "Utenti",
                column: "ClassiId",
                principalTable: "Classi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utenti_Classi_ClassiId",
                table: "Utenti");

            migrationBuilder.DropIndex(
                name: "IX_Utenti_ClassiId",
                table: "Utenti");

            migrationBuilder.RenameColumn(
                name: "ClassiId",
                table: "Utenti",
                newName: "Id_classe");
        }
    }
}
