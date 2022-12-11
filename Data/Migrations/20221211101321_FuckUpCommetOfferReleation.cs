using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grzejemy.Data.Migrations
{
    /// <inheritdoc />
    public partial class FuckUpCommetOfferReleation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Offers_OfferId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Offers_OfferId",
                table: "Comments",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Offers_OfferId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "OfferId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Offers_OfferId",
                table: "Comments",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id");
        }
    }
}
