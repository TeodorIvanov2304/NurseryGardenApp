using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurseryGardenApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ClassId", "Name" },
                values: new object[] { 7, 2, "Trees" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
