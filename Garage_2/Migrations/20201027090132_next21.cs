using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class next21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 27, 7, 56, 52, 394, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 27, 9, 58, 52, 398, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParkedDateTime",
                value: new DateTime(2020, 10, 27, 9, 55, 52, 398, DateTimeKind.Local).AddTicks(7075));
        }
    }
}
