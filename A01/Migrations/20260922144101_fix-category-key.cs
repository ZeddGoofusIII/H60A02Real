using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A01.Migrations
{
    /// <inheritdoc />
    public partial class fixcategorykey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdCatID",
                table: "ProductCategory",
                newName: "ProductCategoryId");

            migrationBuilder.RenameColumn(
                name: "ProdCatId",
                table: "Product",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProdCatId",
                table: "Product",
                newName: "IX_Product_ProductCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "ProductCategory",
                newName: "ProdCatID");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Product",
                newName: "ProdCatId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                newName: "IX_Product_ProdCatId");
        }
    }
}
