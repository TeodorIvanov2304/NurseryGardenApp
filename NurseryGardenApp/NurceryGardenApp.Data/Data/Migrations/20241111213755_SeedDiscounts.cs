using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NurseryGardenApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDiscounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "DiscountValue", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 25.00m, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), "25 percent discount", new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 10.00m, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Local), "10 percent discount", new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
