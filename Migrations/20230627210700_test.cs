using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentilationCalculator.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "Coordinate",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "MaterialP",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "SideWorld",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "TypeCity",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "TypeFrame",
                table: "InputData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "City",
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

            migrationBuilder.AddColumn<double>(
                name: "MaterialP",
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
        }
    }
}
