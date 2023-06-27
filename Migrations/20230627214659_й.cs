using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentilationCalculator.Migrations
{
    /// <inheritdoc />
    public partial class й : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VariantText",
                table: "InputData",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VariantText",
                table: "InputData");
        }
    }
}
