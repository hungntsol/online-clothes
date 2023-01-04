using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineClothes.Persistence.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSerial_ClotheBrands_BrandId",
                table: "ProductSerial");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ProductSerial",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "BrandId",
                table: "ProductSerial",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSerial_ClotheBrands_BrandId",
                table: "ProductSerial",
                column: "BrandId",
                principalTable: "ClotheBrands",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSerial_ClotheBrands_BrandId",
                table: "ProductSerial");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "ProductSerial",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrandId",
                table: "ProductSerial",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSerial_ClotheBrands_BrandId",
                table: "ProductSerial",
                column: "BrandId",
                principalTable: "ClotheBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
