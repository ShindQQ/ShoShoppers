using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoShoppers.Dal.Migrations
{
    public partial class AddedUserUniqueToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserUniqueToken",
                table: "Orders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserUniqueToken",
                table: "Orders");
        }
    }
}
