using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JevKrayPersonalSite.Migrations
{
    /// <inheritdoc />
    public partial class addCapchaSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Commits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2024, 2, 17, 5, 41, 45, 742, DateTimeKind.Unspecified).AddTicks(1496), new TimeSpan(0, 3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Commits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2024, 2, 13, 21, 38, 49, 937, DateTimeKind.Unspecified).AddTicks(6752), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
