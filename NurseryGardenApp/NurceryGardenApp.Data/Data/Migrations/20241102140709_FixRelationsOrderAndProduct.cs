using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurseryGardenApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationsOrderAndProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_AspNetUsers_ClientId",
                table: "OrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrdersProducts_ClientId",
                table: "OrdersProducts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "OrdersProducts");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "OrdersProducts",
                type: "bit",
                nullable: false,
                comment: "Is deleted flag",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrdersProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Product identifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductId",
                table: "OrdersProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Products_ProductId",
                table: "OrdersProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Products_ProductId",
                table: "OrdersProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrdersProducts_ProductId",
                table: "OrdersProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrdersProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "OrdersProducts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Is deleted flag");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "OrdersProducts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Client identifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts",
                columns: new[] { "OrderId", "ClientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ClientId",
                table: "OrdersProducts",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_AspNetUsers_ClientId",
                table: "OrdersProducts",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
