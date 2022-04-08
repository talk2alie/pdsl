using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pdsl.Api.Migrations
{
    public partial class UpdateTitleAndAbstractColumnLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PressReleases",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Abstract",
                table: "PressReleases",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: -111,
                column: "LocatorId",
                value: "608a657d-a188-4165-8895-3446b9979a08");

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2020, 4, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8317), new DateTime(2020, 4, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8328) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2019, 4, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8330), new DateTime(2019, 4, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8331) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2021, 7, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8333), new DateTime(2021, 7, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8335) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2021, 8, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8336), new DateTime(2021, 8, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8336) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2021, 7, 29, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8338), new DateTime(2021, 8, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8343) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2021, 8, 3, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8345), new DateTime(2021, 8, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8345) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 2, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8347), new DateTime(2022, 2, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8348) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 9, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8349), new DateTime(2022, 3, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8350) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 29, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8388), new DateTime(2022, 3, 29, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 29, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8391), new DateTime(2022, 3, 29, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8391) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 31, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8393), new DateTime(2022, 3, 31, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8393) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 4, 2, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8394), new DateTime(2022, 4, 2, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8395) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 25, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8396), new DateTime(2022, 3, 25, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8396) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 4, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8397), new DateTime(2022, 4, 8, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8398) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 4, 6, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8399), new DateTime(2022, 4, 6, 23, 47, 1, 438, DateTimeKind.Utc).AddTicks(8400) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PressReleases",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Abstract",
                table: "PressReleases",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: -111,
                column: "LocatorId",
                value: "bb9f3ef8-b64e-4d37-ba48-6a7bac99a9a3");

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2020, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1483), new DateTime(2020, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1490) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2019, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1492), new DateTime(2019, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1493) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2021, 7, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1494), new DateTime(2021, 7, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1496) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2021, 8, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1497), new DateTime(2021, 8, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1498) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2021, 7, 24, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1499), new DateTime(2021, 8, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1503) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2021, 7, 29, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1504), new DateTime(2021, 8, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1505) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 2, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1506), new DateTime(2022, 2, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 4, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1508), new DateTime(2022, 3, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1509) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 24, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1511), new DateTime(2022, 3, 24, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 24, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1512), new DateTime(2022, 3, 24, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1512) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 26, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1543), new DateTime(2022, 3, 26, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1544) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 28, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1545), new DateTime(2022, 3, 28, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1546) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 3, 20, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1547), new DateTime(2022, 3, 20, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1547) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1548), new DateTime(2022, 4, 3, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1549) });

            migrationBuilder.UpdateData(
                table: "PressReleases",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ReleaseDate", "UploadDate" },
                values: new object[] { new DateTime(2022, 4, 1, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1550), new DateTime(2022, 4, 1, 11, 42, 34, 796, DateTimeKind.Utc).AddTicks(1550) });
        }
    }
}
