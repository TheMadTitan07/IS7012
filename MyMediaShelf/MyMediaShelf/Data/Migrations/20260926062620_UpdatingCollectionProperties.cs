using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMediaShelf.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingCollectionProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_AspNetUsers_ApplicationUserId",
                table: "Collection");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Collection",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_AspNetUsers_ApplicationUserId",
                table: "Collection",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_AspNetUsers_ApplicationUserId",
                table: "Collection");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Collection",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_AspNetUsers_ApplicationUserId",
                table: "Collection",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
