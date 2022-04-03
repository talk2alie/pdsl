using System;
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
                values: new object[] { -111, "Hafiz", "Pussah", "bb9f3ef8-b64e-4d37-ba48-6a7bac99a9a3", "Mohamed", null, "Admin" });

            migrationBuilder.InsertData(
                table: "PressReleases",
                columns: new[] { "Id", "Abstract", "DataFilePath", "HeroImageFilePath", "LocatorId", "ReleaseDate", "Title", "UploadDate", "UploaderId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6fc9d-4b8c-4738-8f1c-038bcec82e0c", new DateTime(2020, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1483), "2 Years Ago", new DateTime(2020, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1490), -111 },
                    { 2, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6fc9d-4b8c-4738-8f1c-038bcec82e0b", new DateTime(2019, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1492), "3 Years Ago", new DateTime(2019, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1493), -111 },
                    { 3, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "deb6fc9d-4b8c-4738-8f1c-038bcec82e09", new DateTime(2021, 7, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1494), "9 Months Ago", new DateTime(2021, 7, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1496), -111 },
                    { 4, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "ceb6fc9d-4b8c-4738-8f1c-038bcec82e09", new DateTime(2021, 8, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1497), "8 Months Ago", new DateTime(2021, 8, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1498), -111 },
                    { 5, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "bec6fc9d-4b8c-4728-8f1c-038bcec82e09", new DateTime(2021, 7, 24, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1499), "8 Months Ago", new DateTime(2021, 8, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1503), -111 },
                    { 6, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6fc9d-4b8c-4738-8f1c-038b3ec82e09", new DateTime(2021, 7, 29, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1504), "8 Months", new DateTime(2021, 8, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1505), -111 },
                    { 7, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6fc9d-4b8c-4738-8f1c-038bcec82e19", new DateTime(2022, 2, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1506), "2 Months Ago", new DateTime(2022, 2, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1507), -111 },
                    { 8, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6fc9d-3b8c-4738-8f1c-038bcec82e09", new DateTime(2022, 3, 4, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1508), "1 Month Ago", new DateTime(2022, 3, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1509), -111 },
                    { 9, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6f99d-4b8c-4738-8f1c-038bcec82e09", new DateTime(2022, 3, 24, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1511), "10 Days Ago", new DateTime(2022, 3, 24, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1511), -111 },
                    { 10, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "bee6fc9d-4b8c-4738-8f1c-038bcec82e09", new DateTime(2022, 3, 24, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1512), "10 Days Ago Another", new DateTime(2022, 3, 24, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1512), -111 },
                    { 11, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6fc9d-4b8c-4738-8f1c-038bcec82e09", new DateTime(2022, 3, 26, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1543), "8 Days Ago", new DateTime(2022, 3, 26, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1544), -111 },
                    { 12, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6fc9d-4b8c-4728-8f1c-038bcec82e09", new DateTime(2022, 3, 28, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1545), "6 Days Ago", new DateTime(2022, 3, 28, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1546), -111 },
                    { 13, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6fc9d-4b8c-4738-811c-038bcec82e09", new DateTime(2022, 3, 20, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1547), "14 Days Ago", new DateTime(2022, 3, 20, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1547), -111 },
                    { 14, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6fc9d-4b8c-4738-8f1c-038b2ec82e09", new DateTime(2022, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1548), "Today", new DateTime(2022, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1549), -111 },
                    { 15, "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", "a393cfbf-97af-4ccf-95b6-e19c9ffcf519.pdf", "a047e9fe-581d-481a-9adc-bc5510fbc93e.jpg", "beb6fc9d-4b5c-4738-8f1c-038bcec82e09", new DateTime(2022, 4, 1, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1550), "2 Days Ago", new DateTime(2022, 4, 1, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1550), -111 }
                });

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
