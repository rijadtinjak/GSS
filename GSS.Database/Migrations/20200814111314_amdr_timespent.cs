using Microsoft.EntityFrameworkCore.Migrations;

namespace GSS.Database.Migrations
{
    public partial class amdr_timespent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AMDR",
                table: "SegmentSearchHistory",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TimeSpent",
                table: "SegmentSearchHistory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AMDR",
                table: "SegmentSearchHistory");

            migrationBuilder.DropColumn(
                name: "TimeSpent",
                table: "SegmentSearchHistory");
        }
    }
}
