using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoShoppers.Dal.Migrations
{
    public partial class AddedIsOrderMadeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOrderMade",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOrderMade",
                table: "Orders");
        }
    }
}
