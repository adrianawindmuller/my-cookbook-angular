using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCookbook.Infrastructure.Data.Migrations
{
    public partial class addpropertydifficulty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 1,
                column: "Difficulty",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 2,
                column: "Difficulty",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 3,
                column: "Difficulty",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Recipe");
        }
    }
}
