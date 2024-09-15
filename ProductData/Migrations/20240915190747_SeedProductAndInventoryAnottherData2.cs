using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductData.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductAndInventoryAnottherData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 3, 50 },
                    { 2, 4, 100 },
                    { 3, 5, 100 }
                });
        }
    }
}
