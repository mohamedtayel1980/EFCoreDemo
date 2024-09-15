using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductData.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductAndInventoryAnottherData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Laptop", 999.99m },
                    { 2, 1, "Smartphone", 499.99m }
                });
        }
    }
}
