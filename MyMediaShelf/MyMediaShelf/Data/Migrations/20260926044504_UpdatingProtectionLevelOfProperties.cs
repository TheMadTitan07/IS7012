using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMediaShelf.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingProtectionLevelOfProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MediaItem_MediaTypeID",
                table: "MediaItem",
                column: "MediaTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaItem_MediaType_MediaTypeID",
                table: "MediaItem",
                column: "MediaTypeID",
                principalTable: "MediaType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaItem_MediaType_MediaTypeID",
                table: "MediaItem");

            migrationBuilder.DropIndex(
                name: "IX_MediaItem_MediaTypeID",
                table: "MediaItem");
        }
    }
}
