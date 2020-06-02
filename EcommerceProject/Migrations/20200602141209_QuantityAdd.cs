using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceProject.Migrations
{
    public partial class QuantityAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Queantity",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Queantity",
                table: "Products");
        }
    }
}
