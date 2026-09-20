using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAccounts.Migrations
{
    /// <inheritdoc />
    public partial class updateaccountholders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountOpenedDate",
                table: "BankAccount",
                newName: "OpenedDate");

            migrationBuilder.RenameColumn(
                name: "AccountName",
                table: "BankAccount",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BankAccountId",
                table: "BankAccount",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AccountHolderId",
                table: "AccountHolder",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpenedDate",
                table: "BankAccount",
                newName: "AccountOpenedDate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BankAccount",
                newName: "AccountName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BankAccount",
                newName: "BankAccountId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AccountHolder",
                newName: "AccountHolderId");
        }
    }
}
