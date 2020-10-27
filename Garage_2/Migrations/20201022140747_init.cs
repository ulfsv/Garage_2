using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkedVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<int>(nullable: false),
                    RegisterNumber = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    WheelsNumber = table.Column<int>(nullable: false),
                    ParkedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "ParkedDateTime", "RegisterNumber", "VehicleType", "WheelsNumber" },
                values: new object[] { 1, "Airbus", "Blue", "A1", new DateTime(2020, 10, 22, 14, 5, 46, 50, DateTimeKind.Local).AddTicks(7439), "ABC123", 2, 10 });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "ParkedDateTime", "RegisterNumber", "VehicleType", "WheelsNumber" },
                values: new object[] { 2, "Volvo", "Black", "B2", new DateTime(2020, 10, 22, 16, 7, 46, 65, DateTimeKind.Local).AddTicks(426), "DKL785", 4, 4 });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "ParkedDateTime", "RegisterNumber", "VehicleType", "WheelsNumber" },
                values: new object[] { 3, "Saga", "Red", "C3", new DateTime(2020, 10, 22, 16, 4, 46, 65, DateTimeKind.Local).AddTicks(538), "UIO159", 3, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicle");
        }
    }
}
