using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveTrack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leaves",
                columns: new[] { "Id", "CreatedByUserId", "EmployeeId", "EndDate", "IsDeleted", "LeaveTypeId", "StartDate" },
                values: new object[,]
                {
                    { 11, 1, 3, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, 4, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, 5, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, 6, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, 7, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, 8, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, 9, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, 10, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, 1, new DateTime(2024, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1, 2, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, 3, new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 1, 4, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 1, 5, new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 1, 6, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 1, 7, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 1, 8, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 1, 9, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 1, 10, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 1, 1, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 1, 2, new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
