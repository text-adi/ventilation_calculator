using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentilationCalculator.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CoefK",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "GCO2",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "MaterialPFromTable",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OutputTempPeople",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "TimeSavePlace",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "Zask",
                table: "InputData");

            migrationBuilder.RenameColumn(
                name: "Concetration",
                table: "InputData",
                newName: "textBoxPeopleInCity");

            migrationBuilder.AddColumn<int>(
                name: "comboBoxCategoryWork",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "comboBoxP",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "comboBoxRoom",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "comboBoxTypeRame",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "comboBoxWord",
                table: "InputData",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comboBoxCategoryWork",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "comboBoxP",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "comboBoxRoom",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "comboBoxTypeRame",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "comboBoxWord",
                table: "InputData");

            migrationBuilder.RenameColumn(
                name: "textBoxPeopleInCity",
                table: "InputData",
                newName: "Concetration");

            migrationBuilder.AddColumn<double>(
                name: "CoefK",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GCO2",
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
                name: "OutputTempPeople",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TimeSavePlace",
                table: "InputData",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Zask",
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
                    TypeFrameID = table.Column<long>(type: "INTEGER", nullable: false),
                    Value = table.Column<long>(type: "INTEGER", nullable: false),
                    World = table.Column<long>(type: "INTEGER", nullable: false)
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
                    CountTemp = table.Column<long>(type: "INTEGER", nullable: false),
                    Temp = table.Column<double>(type: "REAL", nullable: false)
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
                    P = table.Column<double>(type: "REAL", nullable: false),
                    Temp = table.Column<double>(type: "REAL", nullable: false),
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
                    LimitValue = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
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
    }
}
