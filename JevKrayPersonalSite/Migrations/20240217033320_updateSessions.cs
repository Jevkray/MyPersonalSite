using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JevKrayPersonalSite.Migrations
{
    /// <inheritdoc />
    public partial class updateSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "CapchaSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Commits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2024, 2, 17, 6, 33, 20, 879, DateTimeKind.Unspecified).AddTicks(774), new TimeSpan(0, 3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "CapchaSessions");

            migrationBuilder.UpdateData(
                table: "Commits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2024, 2, 17, 6, 1, 36, 290, DateTimeKind.Unspecified).AddTicks(5853), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
