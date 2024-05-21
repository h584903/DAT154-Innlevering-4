using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskModel6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CompletedDate", "CreatedDate", "Description", "Notes", "RoomId", "Status", "TaskType" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 5, 21, 1, 6, 17, 536, DateTimeKind.Local).AddTicks(2368), "Clean the Deluxe Suite", null, 1, "New", "Cleaning" },
                    { 2, null, new DateTime(2024, 5, 21, 1, 6, 17, 536, DateTimeKind.Local).AddTicks(2430), "Fix the air conditioner", null, 4, "New", "Maintenance" }
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
        }
    }
}
