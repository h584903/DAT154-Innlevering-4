using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCheckedInToReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCheckedIn",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate", "IsCheckedIn" },
                values: new object[] { new DateTime(2024, 5, 20, 21, 21, 16, 306, DateTimeKind.Local).AddTicks(3791), new DateTime(2024, 5, 22, 21, 21, 16, 306, DateTimeKind.Local).AddTicks(3841), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheckedIn",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 5, 20, 17, 14, 30, 891, DateTimeKind.Local).AddTicks(757), new DateTime(2024, 5, 22, 17, 14, 30, 891, DateTimeKind.Local).AddTicks(814) });
        }
    }
}
