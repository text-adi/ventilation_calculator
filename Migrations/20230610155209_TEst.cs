using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentilationCalculator.Migrations
{
    /// <inheritdoc />
    public partial class TEst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirDensityTable");

            migrationBuilder.DropTable(
                name: "AirExchangeRatioTable");

            migrationBuilder.DropTable(
                name: "Co2LevelTable");

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

            migrationBuilder.RenameColumn(
                name: "VariantID",
                table: "InputData",
                newName: "VariantId");

            migrationBuilder.RenameColumn(
                name: "WidthRoom",
                table: "InputData",
                newName: "Zask");

            migrationBuilder.RenameColumn(
                name: "LengthRoom",
                table: "InputData",
                newName: "WidthRoomServer");

            migrationBuilder.AddColumn<long>(
                name: "AvgTemp",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "City",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "CoefK",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "Concetration",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Coordinate",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CountPlace",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "GCO2",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HeigthRoomOffice",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InputTempSolar",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LengthRoomOffice",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LengthRoomServer",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaterialP",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaterialPFromTable",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OfficeAir",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OutputAir",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OutputTempAnother",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OutputTempPC",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OutputTempPeople",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OutputTempServer",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OutputTempTV",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ReplaceTempC",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "SaveMaterialSolar",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "ServerAir",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "SideWorld",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "TimeSavePlace",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "TypeCity",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TypeFrame",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "WidthRoomOffice",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TypeID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Constants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputSolar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    World = table.Column<long>(type: "INTEGER", nullable: false),
                    TypeFrameID = table.Column<long>(type: "INTEGER", nullable: false),
                    Value = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputSolar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutputTempPeople",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Temp = table.Column<double>(type: "REAL", nullable: false),
                    CountTemp = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputTempPeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "P",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Temp = table.Column<double>(type: "REAL", nullable: false),
                    P = table.Column<double>(type: "REAL", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    LimitValue = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeFrame",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFrame", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Constants");

            migrationBuilder.DropTable(
                name: "InputSolar");

            migrationBuilder.DropTable(
                name: "OutputTempPeople");

            migrationBuilder.DropTable(
                name: "P");

            migrationBuilder.DropTable(
                name: "TypeCity");

            migrationBuilder.DropTable(
                name: "TypeFrame");

            migrationBuilder.DropColumn(
                name: "AvgTemp",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "City",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "CoefK",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "Concetration",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "Coordinate",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "CountPlace",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "GCO2",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "HeigthRoomOffice",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "InputTempSolar",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "LengthRoomOffice",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "LengthRoomServer",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "MaterialP",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "MaterialPFromTable",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OfficeAir",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OutputAir",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OutputTempAnother",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OutputTempPC",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OutputTempPeople",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OutputTempServer",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OutputTempTV",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "ReplaceTempC",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "SaveMaterialSolar",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "ServerAir",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "SideWorld",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "TimeSavePlace",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "TypeCity",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "TypeFrame",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "WidthRoomOffice",
                table: "InputData");

            migrationBuilder.RenameColumn(
                name: "VariantId",
                table: "InputData",
                newName: "VariantID");

            migrationBuilder.RenameColumn(
                name: "Zask",
                table: "InputData",
                newName: "WidthRoom");

            migrationBuilder.RenameColumn(
                name: "WidthRoomServer",
                table: "InputData",
                newName: "LengthRoom");

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
                    AirExchangeMultiplier = table.Column<string>(type: "TEXT", nullable: false),
                    RoomType = table.Column<string>(type: "TEXT", nullable: true)
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
                    Co2Limit = table.Column<double>(type: "REAL", nullable: false),
                    Teritory = table.Column<string>(type: "TEXT", nullable: true)
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
                    CategoryID = table.Column<long>(type: "INTEGER", nullable: false),
                    TemperatureID = table.Column<long>(type: "INTEGER", nullable: false),
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
                    InletTemp = table.Column<double>(type: "REAL", nullable: false),
                    СompassDirection = table.Column<string>(type: "TEXT", nullable: false)
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
    }
}
