using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCookbook.Api.Migrations
{
    public partial class updatepublished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Publicated",
                table: "Recipe",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Publicated",
                table: "Recipe",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));
        }
    }
}
