using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grzejemy.Data.Migrations
{
    /// <inheritdoc />
    public partial class ParagonPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParagonId",
                table: "Comments");

            migrationBuilder.AddColumn<byte[]>(
                name: "ParagonPhoto",
                table: "Comments",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParagonPhoto",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ParagonId",
                table: "Comments",
                type: "int",
                nullable: true);
        }
    }
}
