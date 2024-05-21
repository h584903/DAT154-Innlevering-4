using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskModel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 5, 22, 0, 55, 30, 287, DateTimeKind.Local).AddTicks(2459), new DateTime(2024, 5, 24, 0, 55, 30, 287, DateTimeKind.Local).AddTicks(2503) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "Description", "Notes", "RoomId", "Status", "TaskType" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 5, 21, 0, 55, 30, 287, DateTimeKind.Local).AddTicks(2524), "Clean the Deluxe Suite", null, 1, "New", "Cleaning" },
                    { 2, null, new DateTime(2024, 5, 21, 0, 55, 30, 287, DateTimeKind.Local).AddTicks(2527), "Fix the air conditioner", null, 2, "New", "Maintenance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 5, 22, 0, 54, 25, 845, DateTimeKind.Local).AddTicks(3368), new DateTime(2024, 5, 24, 0, 54, 25, 845, DateTimeKind.Local).AddTicks(3417) });
        }
    }
}
