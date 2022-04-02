using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pdsl.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LocatorId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PressReleases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Abstract = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    HeroImageFilePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DataFilePath = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LocatorId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false, defaultValueSql: "NEWID()"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UploaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressReleases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PressReleases_Employees_UploaderId",
                        column: x => x.UploaderId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "LocatorId", "MiddleName", "Suffix", "Title" },
                values: new object[] { -111, "Hafiz", "Pussah", "2b7855c3-2f09-4bf7-ad0a-a4e449fe7308", "Mohamed", null, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocatorId",
                table: "Employees",
                column: "LocatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PressReleases_LocatorId",
                table: "PressReleases",
                column: "LocatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PressReleases_UploaderId",
                table: "PressReleases",
                column: "UploaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PressReleases");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
