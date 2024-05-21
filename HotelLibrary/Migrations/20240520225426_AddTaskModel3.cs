using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 5, 22, 0, 52, 9, 194, DateTimeKind.Local).AddTicks(5749), new DateTime(2024, 5, 24, 0, 52, 9, 194, DateTimeKind.Local).AddTicks(5923) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "Description", "Notes", "RoomId", "Status", "TaskType" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clean the Deluxe Suite", null, 1, "New", "Cleaning" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fix the air conditioner", null, 4, "New", "Maintenance" }
                });
        }
    }
}
