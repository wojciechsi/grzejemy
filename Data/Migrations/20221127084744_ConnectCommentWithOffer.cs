using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace grzejemy.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConnectCommentWithOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Comment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_OfferId",
                table: "Comment",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Offers_OfferId",
                table: "Comment",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Offers_OfferId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_OfferId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Comment");
        }
    }
}
