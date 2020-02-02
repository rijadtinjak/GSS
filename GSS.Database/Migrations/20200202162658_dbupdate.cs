using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSS.Database.Migrations
{
    public partial class dbupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateReportedMissing",
                table: "Searches",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    PersonStatus = table.Column<int>(nullable: false),
                    SearchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Searches_SearchId",
                        column: x => x.SearchId,
                        principalTable: "Searches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "POSCumulativeArchiveEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<double>(nullable: false),
                    SearchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POSCumulativeArchiveEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POSCumulativeArchiveEntry_Searches_SearchId",
                        column: x => x.SearchId,
                        principalTable: "Searches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SortedSegmentArchiveEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PoA = table.Column<double>(nullable: false),
                    SearchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortedSegmentArchiveEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SortedSegmentArchiveEntry_Searches_SearchId",
                        column: x => x.SearchId,
                        principalTable: "Searches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_SearchId",
                table: "Person",
                column: "SearchId");

            migrationBuilder.CreateIndex(
                name: "IX_POSCumulativeArchiveEntry_SearchId",
                table: "POSCumulativeArchiveEntry",
                column: "SearchId");

            migrationBuilder.CreateIndex(
                name: "IX_SortedSegmentArchiveEntry_SearchId",
                table: "SortedSegmentArchiveEntry",
                column: "SearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "POSCumulativeArchiveEntry");

            migrationBuilder.DropTable(
                name: "SortedSegmentArchiveEntry");

            migrationBuilder.DropColumn(
                name: "DateReportedMissing",
                table: "Searches");
        }
    }
}
