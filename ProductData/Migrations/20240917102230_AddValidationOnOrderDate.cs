using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductData.Migrations
{
    /// <inheritdoc />
    public partial class AddValidationOnOrderDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 17, 13, 22, 30, 18, DateTimeKind.Local).AddTicks(9738));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 17, 13, 22, 30, 18, DateTimeKind.Local).AddTicks(9784));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 17, 13, 17, 48, 373, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2024, 9, 17, 13, 17, 48, 373, DateTimeKind.Local).AddTicks(8941));
        }
    }
}
