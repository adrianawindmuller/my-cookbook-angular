using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCookbook.Api.Migrations
{
    public partial class updateRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publicated",
                table: "Recipe");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Recipe",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Recipe",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Published",
                table: "Recipe");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Recipe",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "Publicated",
                table: "Recipe",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
