using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grzejemy.Data.Migrations
{
    /// <inheritdoc />
    public partial class FuelTypesUnitField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "FuelTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "FuelTypes");
        }
    }
}
