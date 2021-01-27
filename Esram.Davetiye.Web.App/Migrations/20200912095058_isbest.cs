using Microsoft.EntityFrameworkCore.Migrations;

namespace Esram.Davetiye.Web.App.Migrations
{
    public partial class isbest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBest",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBest",
                table: "Products");
        }
    }
}
