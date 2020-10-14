using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 14, 13, 55, 34, 428, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 14, 15, 57, 34, 438, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 14, 15, 54, 34, 438, DateTimeKind.Local).AddTicks(5975));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 14, 13, 36, 52, 505, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 14, 15, 38, 52, 513, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 14, 15, 35, 52, 513, DateTimeKind.Local).AddTicks(197));
        }
    }
}
