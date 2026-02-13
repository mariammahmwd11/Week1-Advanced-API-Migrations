using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityZone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_houses", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_houses_owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "heaters",
                columns: table => new
                {
                    HeaterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    HeaterType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heaters", x => x.HeaterId);
                    table.ForeignKey(
                        name: "FK_heaters_houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "monthlyCostReports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    ReportMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalWorkingHours = table.Column<int>(type: "int", nullable: false),
                    MedianHeaterValue = table.Column<double>(type: "float", nullable: false),
                    MonthlyAverageCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monthlyCostReports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_monthlyCostReports_houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sensorReadings",
                columns: table => new
                {
                    SensorReadingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaterId = table.Column<int>(type: "int", nullable: false),
                    ReadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkingHours = table.Column<int>(type: "int", nullable: false),
                    HeaterValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensorReadings", x => x.SensorReadingId);
                    table.ForeignKey(
                        name: "FK_sensorReadings_heaters_HeaterId",
                        column: x => x.HeaterId,
                        principalTable: "heaters",
                        principalColumn: "HeaterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_heaters_HouseId",
                table: "heaters",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_houses_OwnerId",
                table: "houses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_monthlyCostReports_HouseId",
                table: "monthlyCostReports",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_sensorReadings_HeaterId",
                table: "sensorReadings",
                column: "HeaterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "monthlyCostReports");

            migrationBuilder.DropTable(
                name: "sensorReadings");

            migrationBuilder.DropTable(
                name: "heaters");

            migrationBuilder.DropTable(
                name: "houses");

            migrationBuilder.DropTable(
                name: "owners");
        }
    }
}
