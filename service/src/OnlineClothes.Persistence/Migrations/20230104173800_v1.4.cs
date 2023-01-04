using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineClothes.Persistence.Migrations
{
    public partial class v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClotheCategoryProductSerial_ProductSerial_ProductSerialsId",
                table: "ClotheCategoryProductSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Product_ProductSku",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductSerial_SerialId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategories_ClotheCategories_CategoryId",
                table: "ProductInCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategories_ProductSerial_SerialId",
                table: "ProductInCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInMaterial_Product_ProductSku",
                table: "ProductInMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSerial_ClotheBrands_BrandId",
                table: "ProductSerial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSerial",
                table: "ProductSerial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInCategories",
                table: "ProductInCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ProductSerial",
                newName: "ProductSerials");

            migrationBuilder.RenameTable(
                name: "ProductInCategories",
                newName: "SerialInCategories");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSerial_BrandId",
                table: "ProductSerials",
                newName: "IX_ProductSerials_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInCategories_CategoryId",
                table: "SerialInCategories",
                newName: "IX_SerialInCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_SerialId",
                table: "Products",
                newName: "IX_Products_SerialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSerials",
                table: "ProductSerials",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SerialInCategories",
                table: "SerialInCategories",
                columns: new[] { "SerialId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Sku");

            migrationBuilder.AddForeignKey(
                name: "FK_ClotheCategoryProductSerial_ProductSerials_ProductSerialsId",
                table: "ClotheCategoryProductSerial",
                column: "ProductSerialsId",
                principalTable: "ProductSerials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Products_ProductSku",
                table: "OrderItem",
                column: "ProductSku",
                principalTable: "Products",
                principalColumn: "Sku",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInMaterial_Products_ProductSku",
                table: "ProductInMaterial",
                column: "ProductSku",
                principalTable: "Products",
                principalColumn: "Sku",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSerials_SerialId",
                table: "Products",
                column: "SerialId",
                principalTable: "ProductSerials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSerials_ClotheBrands_BrandId",
                table: "ProductSerials",
                column: "BrandId",
                principalTable: "ClotheBrands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SerialInCategories_ClotheCategories_CategoryId",
                table: "SerialInCategories",
                column: "CategoryId",
                principalTable: "ClotheCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SerialInCategories_ProductSerials_SerialId",
                table: "SerialInCategories",
                column: "SerialId",
                principalTable: "ProductSerials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClotheCategoryProductSerial_ProductSerials_ProductSerialsId",
                table: "ClotheCategoryProductSerial");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Products_ProductSku",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInMaterial_Products_ProductSku",
                table: "ProductInMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSerials_SerialId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSerials_ClotheBrands_BrandId",
                table: "ProductSerials");

            migrationBuilder.DropForeignKey(
                name: "FK_SerialInCategories_ClotheCategories_CategoryId",
                table: "SerialInCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SerialInCategories_ProductSerials_SerialId",
                table: "SerialInCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SerialInCategories",
                table: "SerialInCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductSerials",
                table: "ProductSerials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "SerialInCategories",
                newName: "ProductInCategories");

            migrationBuilder.RenameTable(
                name: "ProductSerials",
                newName: "ProductSerial");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_SerialInCategories_CategoryId",
                table: "ProductInCategories",
                newName: "IX_ProductInCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSerials_BrandId",
                table: "ProductSerial",
                newName: "IX_ProductSerial_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SerialId",
                table: "Product",
                newName: "IX_Product_SerialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInCategories",
                table: "ProductInCategories",
                columns: new[] { "SerialId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductSerial",
                table: "ProductSerial",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Sku");

            migrationBuilder.AddForeignKey(
                name: "FK_ClotheCategoryProductSerial_ProductSerial_ProductSerialsId",
                table: "ClotheCategoryProductSerial",
                column: "ProductSerialsId",
                principalTable: "ProductSerial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Product_ProductSku",
                table: "OrderItem",
                column: "ProductSku",
                principalTable: "Product",
                principalColumn: "Sku",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductSerial_SerialId",
                table: "Product",
                column: "SerialId",
                principalTable: "ProductSerial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategories_ClotheCategories_CategoryId",
                table: "ProductInCategories",
                column: "CategoryId",
                principalTable: "ClotheCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategories_ProductSerial_SerialId",
                table: "ProductInCategories",
                column: "SerialId",
                principalTable: "ProductSerial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInMaterial_Product_ProductSku",
                table: "ProductInMaterial",
                column: "ProductSku",
                principalTable: "Product",
                principalColumn: "Sku",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSerial_ClotheBrands_BrandId",
                table: "ProductSerial",
                column: "BrandId",
                principalTable: "ClotheBrands",
                principalColumn: "Id");
        }
    }
}
