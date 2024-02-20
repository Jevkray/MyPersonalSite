using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JevKrayPersonalSite.Migrations
{
    /// <inheritdoc />
    public partial class addCommitName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Commits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Commits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Name" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 2, 13, 21, 38, 49, 937, DateTimeKind.Unspecified).AddTicks(6752), new TimeSpan(0, 3, 0, 0, 0)), "test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Commits");

            migrationBuilder.UpdateData(
                table: "Commits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTimeOffset(new DateTime(2023, 10, 19, 21, 42, 46, 489, DateTimeKind.Unspecified).AddTicks(2126), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
