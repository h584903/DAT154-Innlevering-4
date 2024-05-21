using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskModel7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Beds", "IsAvailable", "Name", "NeedsCleaning", "NeedsMaintenance", "NeedsRoomService", "Size" },
                values: new object[,]
                {
                    { 1, 2, true, "Deluxe Suite", false, false, false, "Large" },
                    { 4, 1, true, "Standard Room", false, false, false, "Medium" }
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 1, 12, 9, 44, DateTimeKind.Local).AddTicks(6038));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 1, 12, 9, 44, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CheckInDate", "CheckOutDate", "CustomerName", "IsCheckedIn", "RoomId" },
                values: new object[] { 1, new DateTime(2024, 5, 22, 1, 12, 9, 44, DateTimeKind.Local).AddTicks(5971), new DateTime(2024, 5, 24, 1, 12, 9, 44, DateTimeKind.Local).AddTicks(6019), "John Doe", false, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 1, 6, 17, 536, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 21, 1, 6, 17, 536, DateTimeKind.Local).AddTicks(2430));
        }
    }
}
