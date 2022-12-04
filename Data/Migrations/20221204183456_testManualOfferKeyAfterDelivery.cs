using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grzejemy.Data.Migrations
{
    /// <inheritdoc />
    public partial class testManualOfferKeyAfterDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_FuelTypes_FuelTypeId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_FuelTypeId",
                table: "Offers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Offers_FuelTypeId",
                table: "Offers",
                column: "FuelTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_FuelTypes_FuelTypeId",
                table: "Offers",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
