using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineClothes.Persistence.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Products",
                newName: "IsPublish");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPublish",
                table: "Products",
                newName: "IsDeleted");
        }
    }
}
