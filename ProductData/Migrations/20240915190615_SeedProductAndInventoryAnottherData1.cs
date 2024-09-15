using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductData.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductAndInventoryAnottherData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductId",
                value: 4);

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "ProductId", "Quantity" },
                values: new object[] { 3, 5, 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductId",
                value: 2);
        }
    }
}
