using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSS.Database.Migrations
{
    public partial class ManagerNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Managers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Managers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Managers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Managers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Managers");
        }
    }
}
