using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentilationCalculator.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirDensityCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    AirDensity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirDensityCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirDensityTemp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Temperature = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirDensityTemp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirExchangeRatioTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomType = table.Column<string>(type: "TEXT", nullable: true),
                    AirExchangeMultiplier = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirExchangeRatioTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryWork",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryWork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Co2LevelTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Teritory = table.Column<string>(type: "TEXT", nullable: true),
                    Co2Limit = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Co2LevelTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrameType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrameType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VariantID = table.Column<long>(type: "INTEGER", nullable: false),
                    CountPrinter = table.Column<long>(type: "INTEGER", nullable: false),
                    CountServer = table.Column<long>(type: "INTEGER", nullable: false),
                    WidthRoom = table.Column<double>(type: "REAL", nullable: false),
                    LengthRoom = table.Column<double>(type: "REAL", nullable: false),
                    InletTemp = table.Column<long>(type: "INTEGER", nullable: false),
                    OutletTemp = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TempWork",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    CountInWorkPlace = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempWork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirDensityTable",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemperatureID = table.Column<long>(type: "INTEGER", nullable: false),
                    CategoryID = table.Column<long>(type: "INTEGER", nullable: false),
                    atmosphericPressure = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirDensityTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirDensityTable_AirDensityCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "AirDensityCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AirDensityTable_AirDensityTemp_TemperatureID",
                        column: x => x.TemperatureID,
                        principalTable: "AirDensityTemp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolarHeatGainThroughGlazing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FrameTypeID = table.Column<long>(type: "INTEGER", nullable: true),
                    СompassDirection = table.Column<string>(type: "TEXT", nullable: false),
                    InletTemp = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarHeatGainThroughGlazing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolarHeatGainThroughGlazing_FrameType_FrameTypeID",
                        column: x => x.FrameTypeID,
                        principalTable: "FrameType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeopleHeatOutput",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryWorkID = table.Column<long>(type: "INTEGER", nullable: false),
                    TempWorkID = table.Column<long>(type: "INTEGER", nullable: false),
                    AirTemp = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleHeatOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleHeatOutput_CategoryWork_CategoryWorkID",
                        column: x => x.CategoryWorkID,
                        principalTable: "CategoryWork",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeopleHeatOutput_TempWork_TempWorkID",
                        column: x => x.TempWorkID,
                        principalTable: "TempWork",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirDensityTable_CategoryID",
                table: "AirDensityTable",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AirDensityTable_TemperatureID",
                table: "AirDensityTable",
                column: "TemperatureID");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleHeatOutput_CategoryWorkID",
                table: "PeopleHeatOutput",
                column: "CategoryWorkID");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleHeatOutput_TempWorkID",
                table: "PeopleHeatOutput",
                column: "TempWorkID");

            migrationBuilder.CreateIndex(
                name: "IX_SolarHeatGainThroughGlazing_FrameTypeID",
                table: "SolarHeatGainThroughGlazing",
                column: "FrameTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirDensityTable");

            migrationBuilder.DropTable(
                name: "AirExchangeRatioTable");

            migrationBuilder.DropTable(
                name: "Co2LevelTable");

            migrationBuilder.DropTable(
                name: "InputData");

            migrationBuilder.DropTable(
                name: "PeopleHeatOutput");

            migrationBuilder.DropTable(
                name: "SolarHeatGainThroughGlazing");

            migrationBuilder.DropTable(
                name: "AirDensityCategory");

            migrationBuilder.DropTable(
                name: "AirDensityTemp");

            migrationBuilder.DropTable(
                name: "CategoryWork");

            migrationBuilder.DropTable(
                name: "TempWork");

            migrationBuilder.DropTable(
                name: "FrameType");
        }
    }
}
