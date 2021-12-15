using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem3.Data.Migrations
{
    public partial class BookingUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxBookings",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "StandardPrice",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "VATnumber",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxBookings",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StandardPrice",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VATnumber",
                table: "AspNetUsers");
        }
    }
}
