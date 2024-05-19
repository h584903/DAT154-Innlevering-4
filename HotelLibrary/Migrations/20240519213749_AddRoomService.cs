using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NeedsRoomService",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 5, 20, 23, 37, 48, 882, DateTimeKind.Local).AddTicks(9166), new DateTime(2024, 5, 22, 23, 37, 48, 882, DateTimeKind.Local).AddTicks(9215) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "NeedsRoomService",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "NeedsRoomService",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "NeedsRoomService",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NeedsRoomService",
                table: "Rooms");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 5, 20, 21, 51, 16, 381, DateTimeKind.Local).AddTicks(7837), new DateTime(2024, 5, 22, 21, 51, 16, 381, DateTimeKind.Local).AddTicks(7891) });
        }
    }
}
