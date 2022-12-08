using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoShoppers.Dal.Migrations
{
    public partial class AddedItemAmmountAndProductionTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemAmmount",
                table: "BaseEntityForSale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ItemInProduction",
                table: "BaseEntityForSale",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemAmmount",
                table: "BaseEntityForSale");

            migrationBuilder.DropColumn(
                name: "ItemInProduction",
                table: "BaseEntityForSale");
        }
    }
}
