using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCookbook.Api.Migrations
{
    public partial class UpdateNameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Recipe",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Image",
                newName: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Recipe",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Image",
                newName: "Id");
        }
    }
}
