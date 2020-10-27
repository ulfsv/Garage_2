using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class next222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 27, 8, 20, 50, 32, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 27, 10, 22, 50, 39, DateTimeKind.Local).AddTicks(7023));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 27, 10, 19, 50, 39, DateTimeKind.Local).AddTicks(7253));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 27, 7, 59, 32, 74, DateTimeKind.Local).AddTicks(9448));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 27, 10, 1, 32, 79, DateTimeKind.Local).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 27, 9, 58, 32, 79, DateTimeKind.Local).AddTicks(3827));
        }
    }
}
