using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grzejemy.Data.Migrations
{
    /// <inheritdoc />
    public partial class VendorNoFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPoints_AspNetUsers_VendorId",
                table: "SalesPoints");

            migrationBuilder.DropIndex(
                name: "IX_SalesPoints_VendorId",
                table: "SalesPoints");

            migrationBuilder.AlterColumn<string>(
                name: "VendorId",
                table: "SalesPoints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VendorId",
                table: "SalesPoints",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPoints_VendorId",
                table: "SalesPoints",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPoints_AspNetUsers_VendorId",
                table: "SalesPoints",
                column: "VendorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
