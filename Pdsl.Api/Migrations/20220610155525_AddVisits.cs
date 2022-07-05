using Microsoft.EntityFrameworkCore.Migrations;

namespace Pdsl.Api.Migrations
{
    public partial class AddVisits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationUtcDateTime",
                table: "Visitors",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedUtcDateTime",
                table: "Visitors",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitorId = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    UtcDateTime = table.Column<DateTime>(type: "datetime2", maxLength: 55, nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => new { x.VisitorId, x.Id });
                    table.ForeignKey(
                        name: "FK_Visits_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropColumn(
                name: "CreationUtcDateTime",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUtcDateTime",
                table: "Visitors");
        }
    }
}
