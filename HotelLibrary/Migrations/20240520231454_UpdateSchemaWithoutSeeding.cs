using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemaWithoutSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

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
                keyValue: 4);
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
                    { 4, 1, true, "Standard Room", false, false, false, "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CheckInDate", "CheckOutDate", "CustomerName", "IsCheckedIn", "RoomId" },
                values: new object[] { 1, new DateTime(2024, 5, 22, 1, 12, 9, 44, DateTimeKind.Local).AddTicks(5971), new DateTime(2024, 5, 24, 1, 12, 9, 44, DateTimeKind.Local).AddTicks(6019), "John Doe", false, 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "Description", "Notes", "RoomId", "Status", "TaskType" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 5, 21, 1, 12, 9, 44, DateTimeKind.Local).AddTicks(6038), "Clean the Deluxe Suite", null, 1, "New", "Cleaning" },
                    { 2, null, new DateTime(2024, 5, 21, 1, 12, 9, 44, DateTimeKind.Local).AddTicks(6041), "Fix the air conditioner", null, 4, "New", "Maintenance" }
                });
        }
    }
}
