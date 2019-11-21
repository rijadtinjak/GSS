using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSS.Database.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Searches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateClosed = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Searches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Searches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SearchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Searches_SearchId",
                        column: x => x.SearchId,
                        principalTable: "Searches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false),
                    Pden = table.Column<double>(nullable: false),
                    PoA = table.Column<double>(nullable: false),
                    SearchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Searches_SearchId",
                        column: x => x.SearchId,
                        principalTable: "Searches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consensus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZoneId = table.Column<int>(nullable: false),
                    ManagerId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consensus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consensus_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consensus_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false),
                    ZoneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Segments_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SegmentSearchHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pden = table.Column<double>(nullable: false),
                    PoA = table.Column<double>(nullable: false),
                    Coverage = table.Column<double>(nullable: false),
                    PoD = table.Column<double>(nullable: false),
                    PoDCumulative = table.Column<double>(nullable: false),
                    PoS = table.Column<double>(nullable: false),
                    PoSCumulative = table.Column<double>(nullable: false),
                    DeltaPoS = table.Column<double>(nullable: false),
                    NoOfSearchers = table.Column<int>(nullable: false),
                    TrackLength = table.Column<double>(nullable: false),
                    SweepWidth = table.Column<double>(nullable: false),
                    TypeOfSearcher = table.Column<int>(nullable: false),
                    SegmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegmentSearchHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SegmentSearchHistory_Segments_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "Segments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consensus_ManagerId",
                table: "Consensus",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Consensus_ZoneId",
                table: "Consensus",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_SearchId",
                table: "Managers",
                column: "SearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Searches_UserId",
                table: "Searches",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_ZoneId",
                table: "Segments",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentSearchHistory_SegmentId",
                table: "SegmentSearchHistory",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_SearchId",
                table: "Zones",
                column: "SearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consensus");

            migrationBuilder.DropTable(
                name: "SegmentSearchHistory");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Searches");
        }
    }
}
