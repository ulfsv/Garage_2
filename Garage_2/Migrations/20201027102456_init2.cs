using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "Id",
                keyValue: 1111);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "Avatar", "Email", "FirstName", "LastName", "Phone", "SocialSecurityNumber", "Street", "ZIP" },
                values: new object[,]
                {
                    { 1, "https://www.befunky.com/images/wp/wp-2014-08-milky-way-1023340_1280.jpg?auto=webp&format=jpg&width=1600", "s.Jonsson@gmail.com", "Sandy", "Jonsson", "0715184655", "199805200111", "Kvarnväg 12", "0046" },
                    { 2, "https://www.befunky.com/images/wp/wp-2014-08-milky-way-1023340_1280.jpg?auto=webp&format=jpg&width=1600", "s.gg@gmail.com", "Sandrs", "Petersson", "0700084655", "19280509415511", "Gamlebyväg 10", "0046" }
                });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "MemberId", "Model", "ParkedDateTime", "RegisterNumber", "VehicleTypeId", "VehicleTypeVehicType", "WheelsNumber" },
                values: new object[,]
                {
                    { 1, "Airbus", "Blue", 0, "A1", new DateTime(2020, 10, 27, 8, 20, 50, 32, DateTimeKind.Local).AddTicks(3883), "ABC123", 0, "Car", 10 },
                    { 2, "Volvo", "Black", 0, "B2", new DateTime(2020, 10, 27, 10, 22, 50, 39, DateTimeKind.Local).AddTicks(7023), "DKL785", 0, "Bus", 4 },
                    { 3, "Saga", "Red", 0, "C3", new DateTime(2020, 10, 27, 10, 19, 50, 39, DateTimeKind.Local).AddTicks(7253), "UIO159", 0, "Boat", 0 }
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "Id", "VehicType" },
                values: new object[,]
                {
                    { 1111, "Tractor" },
                    { 2, "Tractor2" },
                    { 355, "Tractor3" },
                    { 201, "Tractor2" },
                    { 319, "Tractor3" }
                });
        }
    }
}
