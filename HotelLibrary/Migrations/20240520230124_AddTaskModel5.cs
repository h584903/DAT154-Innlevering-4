using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskModel5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Beds", "IsAvailable", "Name", "NeedsCleaning", "NeedsMaintenance", "NeedsRoomService", "Size" },
                values: new object[,]
                {
                    { 1, 2, true, "Deluxe Suite", false, false, false, "Large" },
                    { 2, 1, true, "Standard Room", false, false, false, "Medium" },
                    { 3, 1, true, "Single Room", false, false, false, "Small" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CheckInDate", "CheckOutDate", "CustomerName", "IsCheckedIn", "RoomId" },
                values: new object[] { 1, new DateTime(2024, 5, 22, 0, 55, 30, 287, DateTimeKind.Local).AddTicks(2459), new DateTime(2024, 5, 24, 0, 55, 30, 287, DateTimeKind.Local).AddTicks(2503), "John Doe", false, 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "Description", "Notes", "RoomId", "Status", "TaskType" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 5, 21, 0, 55, 30, 287, DateTimeKind.Local).AddTicks(2524), "Clean the Deluxe Suite", null, 1, "New", "Cleaning" },
                    { 2, null, new DateTime(2024, 5, 21, 0, 55, 30, 287, DateTimeKind.Local).AddTicks(2527), "Fix the air conditioner", null, 2, "New", "Maintenance" }
                });
        }
    }
}
