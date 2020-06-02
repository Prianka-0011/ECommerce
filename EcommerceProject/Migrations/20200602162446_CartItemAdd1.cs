using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceProject.Migrations
{
    public partial class CartItemAdd1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Queantity",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Queantity",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
