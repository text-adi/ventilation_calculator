using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentilationCalculator.Migrations
{
    /// <inheritdoc />
    public partial class tete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutputTempAnother",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OutputTempPC",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OutputTempServer",
                table: "InputData");

            migrationBuilder.DropColumn(
                name: "OutputTempTV",
                table: "InputData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
