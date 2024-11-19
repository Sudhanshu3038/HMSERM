using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMSERM.Migrations
{
    /// <inheritdoc />
    public partial class HmsTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens");

            migrationBuilder.RenameColumn(
                name: "TokenInfo_RefreshTokenExpiry",
                table: "Tokens",
                newName: "RefreshTokenExpiry");

            migrationBuilder.RenameColumn(
                name: "TokenInfo_RefreshToken",
                table: "Tokens",
                newName: "RefreshToken");

            migrationBuilder.RenameColumn(
                name: "TokenInfo_AccessTokenExpiry",
                table: "Tokens",
                newName: "AccessTokenExpiry");

            migrationBuilder.RenameColumn(
                name: "TokenInfo_AccessToken",
                table: "Tokens",
                newName: "AccessToken");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tokens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpiry",
                table: "Tokens",
                newName: "TokenInfo_RefreshTokenExpiry");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                table: "Tokens",
                newName: "TokenInfo_RefreshToken");

            migrationBuilder.RenameColumn(
                name: "AccessTokenExpiry",
                table: "Tokens",
                newName: "TokenInfo_AccessTokenExpiry");

            migrationBuilder.RenameColumn(
                name: "AccessToken",
                table: "Tokens",
                newName: "TokenInfo_AccessToken");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tokens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
