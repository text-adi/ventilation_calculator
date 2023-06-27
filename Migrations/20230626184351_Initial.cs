using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentilationCalculator.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "InputData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VariantId = table.Column<long>(type: "INTEGER", nullable: false),
                    CountPrinter = table.Column<long>(type: "INTEGER", nullable: false),
                    CountServer = table.Column<long>(type: "INTEGER", nullable: false),
                    WidthRoomServer = table.Column<double>(type: "REAL", nullable: false),
                    LengthRoomServer = table.Column<double>(type: "REAL", nullable: false),
                    InletTemp = table.Column<long>(type: "INTEGER", nullable: false),
                    OutletTemp = table.Column<long>(type: "INTEGER", nullable: false),
                    WidthRoomOffice = table.Column<double>(type: "REAL", nullable: false),
                    LengthRoomOffice = table.Column<double>(type: "REAL", nullable: false),
                    HeigthRoomOffice = table.Column<double>(type: "REAL", nullable: false),
                    CountPlace = table.Column<long>(type: "INTEGER", nullable: false),
                    AvgTemp = table.Column<long>(type: "INTEGER", nullable: false),
                    OfficeAir = table.Column<double>(type: "REAL", nullable: false),
                    ServerAir = table.Column<double>(type: "REAL", nullable: false),
                    OutputAir = table.Column<double>(type: "REAL", nullable: false),
                    TimeSavePlace = table.Column<double>(type: "REAL", nullable: false),
                    City = table.Column<long>(type: "INTEGER", nullable: false),
                    TypeCity = table.Column<long>(type: "INTEGER", nullable: false),
                    Concetration = table.Column<long>(type: "INTEGER", nullable: false),
                    GCO2 = table.Column<double>(type: "REAL", nullable: false),
                    OutputTempPeople = table.Column<double>(type: "REAL", nullable: false),
                    OutputTempPC = table.Column<double>(type: "REAL", nullable: false),
                    OutputTempTV = table.Column<double>(type: "REAL", nullable: false),
                    OutputTempAnother = table.Column<double>(type: "REAL", nullable: false),
                    OutputTempServer = table.Column<double>(type: "REAL", nullable: false),
                    Zask = table.Column<double>(type: "REAL", nullable: false),
                    TypeFrame = table.Column<long>(type: "INTEGER", nullable: false),
                    SideWorld = table.Column<long>(type: "INTEGER", nullable: false),
                    Coordinate = table.Column<long>(type: "INTEGER", nullable: false),
                    InputTempSolar = table.Column<double>(type: "REAL", nullable: false),
                    CoefK = table.Column<double>(type: "REAL", nullable: false),
                    SaveMaterialSolar = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaterialP = table.Column<double>(type: "REAL", nullable: false),
                    MaterialPFromTable = table.Column<double>(type: "REAL", nullable: false),
                    ReplaceTempC = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputData", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "VirantVentilator",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PathToFile = table.Column<string>(type: "TEXT", nullable: false),
                    Power = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirantVentilator", x => x.Id);
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
                name: "InputData");

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

            migrationBuilder.DropTable(
                name: "VirantVentilator");
        }
    }
}
