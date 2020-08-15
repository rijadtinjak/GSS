using Microsoft.EntityFrameworkCore.Migrations;

namespace GSS.Database.Migrations
{
    public partial class tewst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Searches_SearchId",
                table: "Managers");

            migrationBuilder.RenameColumn(
                name: "SearchId",
                table: "Managers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_SearchId",
                table: "Managers",
                newName: "IX_Managers_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Users_UserId",
                table: "Managers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Users_UserId",
                table: "Managers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Managers",
                newName: "SearchId");

            migrationBuilder.RenameIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                newName: "IX_Managers_SearchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Searches_SearchId",
                table: "Managers",
                column: "SearchId",
                principalTable: "Searches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
