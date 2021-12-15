using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem3.Migrations
{
    public partial class BookingTimeSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    company = table.Column<string>(nullable: true),
                    userCredentials = table.Column<int>(nullable: false),
                    standardPrice = table.Column<float>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    maxBookings = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    userCredentials = table.Column<int>(nullable: false),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeID);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    timeSlotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    start = table.Column<DateTime>(nullable: false),
                    end = table.Column<DateTime>(nullable: false),
                    standardPrice = table.Column<float>(nullable: false),
                    specialPrice = table.Column<float>(nullable: false),
                    createrId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.timeSlotID);
                    table.ForeignKey(
                        name: "FK_TimeSlots_ApplicationUser_createrId",
                        column: x => x.createrId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    bookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    startTime = table.Column<DateTime>(nullable: false),
                    duration = table.Column<float>(nullable: false),
                    topic = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    timeSlotID = table.Column<int>(nullable: true),
                    createrId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.bookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_ApplicationUser_createrId",
                        column: x => x.createrId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_TimeSlots_timeSlotID",
                        column: x => x.timeSlotID,
                        principalTable: "TimeSlots",
                        principalColumn: "timeSlotID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_createrId",
                table: "Bookings",
                column: "createrId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_timeSlotID",
                table: "Bookings",
                column: "timeSlotID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_createrId",
                table: "TimeSlots",
                column: "createrId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
