using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIdCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "varchar(20)", nullable: true),
                    Lastname = table.Column<string>(type: "varchar(30)", nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", nullable: true),
                    Province = table.Column<string>(type: "varchar(2)", nullable: true),
                    CreditCard = table.Column<string>(type: "varchar(16)", nullable: true),
                    IdCode = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdCat = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFulfilled = table.Column<DateOnly>(type: "date", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    taxes = table.Column<decimal>(type: "numeric(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Manufacturer = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    SellPrice = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    ProdCat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    ShoppingCartCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_ShoppingCart_ShoppingCartCartId",
                        column: x => x.ShoppingCartCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "CartId");
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CreditCard", "Email", "Firstname", "IdCode", "Lastname", "PhoneNumber", "Province" },
                values: new object[,]
                {
                    { 1, "456789123789546", "example@example.com", "Cassius", "7f6580af-9d88-4419-8b5e-6866f69e1f56", "Bright", "9874566123", null },
                    { 2, "456989123789546", "letme@example.com", "Guy", "7f6580af-9d88-4419-8b5e-6866f69e1f56", "Ofsomekind", "9874786123", null },
                    { 3, "786989123789546", "Liyrest@example.com", "Olivier", "7f6580af-9d88-4419-8b5e-6866f69e1f56", "Laurence", "9879986123", null }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "DateCreated", "DateFulfilled", "Total", "taxes" },
                values: new object[] { 1, 1, new DateOnly(2026, 6, 3), new DateOnly(2026, 6, 16), 100m, 10m });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderItemId", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1m, 1, 1 },
                    { 2, 1, 1m, 1, 1 },
                    { 3, 1, 1m, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ShoppingCartCartId",
                table: "CartItem",
                column: "ShoppingCartCartId");

            migrationBuilder.CreateIndex(
                name: "X_Customer_CustomerId",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_CustomerId",
                table: "ShoppingCart",
                column: "CustomerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
