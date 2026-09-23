using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace A01.Migrations
{
    /// <inheritdoc />
    public partial class populatecustomertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CreditCard", "Email", "Firstname", "Lastname", "PhoneNumber", "Province" },
                values: new object[,]
                {
                    { 1, "456789123789546", "example@example.com", "Cassius", "Bright", "9874566123", null },
                    { 2, "456989123789546", "letme@example.com", "Guy", "Ofsomekind", "9874786123", null },
                    { 3, "786989123789546", "Liyrest@example.com", "Olivier", "Laurence", "9879986123", null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "DateCreated", "DateFulfilled", "Total", "taxes" },
                values: new object[] { 1, 1, new DateOnly(2026, 6, 3), new DateOnly(2026, 6, 16), 100m, 10m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1);
        }
    }
}
