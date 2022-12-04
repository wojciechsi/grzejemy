using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grzejemy.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeOfferList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_SalesPoints_SalesPointId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_SalesPointId",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "SalesPointId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SalesPointId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SalesPointId",
                table: "Offers",
                column: "SalesPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_SalesPoints_SalesPointId",
                table: "Offers",
                column: "SalesPointId",
                principalTable: "SalesPoints",
                principalColumn: "Id");
        }
    }
}
