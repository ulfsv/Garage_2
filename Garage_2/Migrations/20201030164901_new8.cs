using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2.Migrations
{
    public partial class new8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingSpace",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parkedVehicleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSpace_ParkedVehicle_parkedVehicleId",
                        column: x => x.parkedVehicleId,
                        principalTable: "ParkedVehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpace_parkedVehicleId",
                table: "ParkingSpace",
                column: "parkedVehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpace");
        }
    }
}
