using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomCleaningAndMaintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NeedsCleaning",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NeedsMaintenance",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 5, 20, 21, 51, 16, 381, DateTimeKind.Local).AddTicks(7837), new DateTime(2024, 5, 22, 21, 51, 16, 381, DateTimeKind.Local).AddTicks(7891) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NeedsCleaning", "NeedsMaintenance" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "NeedsCleaning", "NeedsMaintenance" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "NeedsCleaning", "NeedsMaintenance" },
                values: new object[] { false, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedsCleaning",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NeedsMaintenance",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 5, 20, 21, 21, 16, 306, DateTimeKind.Local).AddTicks(3791), new DateTime(2024, 5, 22, 21, 21, 16, 306, DateTimeKind.Local).AddTicks(3841) });
        }
    }
}
