using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grzejemy.Data.Migrations
{
    /// <inheritdoc />
    public partial class RollbackToInitialORM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Offers_FuelTypeId",
                table: "Offers",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SalesPointId",
                table: "Offers",
                column: "SalesPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_FuelTypes_FuelTypeId",
                table: "Offers",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_SalesPoints_SalesPointId",
                table: "Offers",
                column: "SalesPointId",
                principalTable: "SalesPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPoints_AspNetUsers_VendorId",
                table: "SalesPoints",
                column: "VendorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_FuelTypes_FuelTypeId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_SalesPoints_SalesPointId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPoints_AspNetUsers_VendorId",
                table: "SalesPoints");

            migrationBuilder.DropIndex(
                name: "IX_SalesPoints_VendorId",
                table: "SalesPoints");

            migrationBuilder.DropIndex(
                name: "IX_Offers_FuelTypeId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_SalesPointId",
                table: "Offers");

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
    }
}
