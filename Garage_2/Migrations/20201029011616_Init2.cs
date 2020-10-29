using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GarageId",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingSpaceNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkedVehicle_GarageId",
                table: "ParkedVehicle",
                column: "GarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkedVehicle_Garage_GarageId",
                table: "ParkedVehicle",
                column: "GarageId",
                principalTable: "Garage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkedVehicle_Garage_GarageId",
                table: "ParkedVehicle");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropIndex(
                name: "IX_ParkedVehicle_GarageId",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "GarageId",
                table: "ParkedVehicle");
        }
    }
}
