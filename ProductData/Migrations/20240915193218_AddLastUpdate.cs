using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductData.Migrations
{
    /// <inheritdoc />
    public partial class AddLastUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Inventories");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 3, 1, "Tablet", 299.99m },
                    { 4, 1, "Smartwatch", 199.99m },
                    { 5, 1, "Desktop", 1200.00m },
                    { 6, 1, "Monitor", 300.00m }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 4, 3, 50 },
                    { 5, 4, 100 },
                    { 6, 5, 100 }
                });
        }
    }
}
