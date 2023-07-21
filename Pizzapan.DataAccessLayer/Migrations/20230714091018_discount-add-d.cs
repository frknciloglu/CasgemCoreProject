using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizzapan.DataAccessLayer.Migrations
{
    public partial class discountaddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountName",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "DiscountLastDate",
                table: "Discounts",
                newName: "EndingDate");

            migrationBuilder.RenameColumn(
                name: "DiscountDate",
                table: "Discounts",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "DiscountCode",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountCount",
                table: "Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountCode",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DiscountCount",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "EndingDate",
                table: "Discounts",
                newName: "DiscountLastDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Discounts",
                newName: "DiscountDate");

            migrationBuilder.AddColumn<string>(
                name: "DiscountName",
                table: "Discounts",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);
        }
    }
}
