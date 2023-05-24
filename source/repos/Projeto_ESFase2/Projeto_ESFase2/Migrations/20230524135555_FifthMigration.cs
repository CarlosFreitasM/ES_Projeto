using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_ESFase2.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionUser_Competition_CompetitionsId",
                table: "CompetitionUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionUser_User_UsersId",
                table: "CompetitionUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "CompetitionUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CompetitionsId",
                table: "CompetitionUser",
                newName: "CompetitionId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetitionUser_UsersId",
                table: "CompetitionUser",
                newName: "IX_CompetitionUser_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionUser_Competition_CompetitionId",
                table: "CompetitionUser",
                column: "CompetitionId",
                principalTable: "Competition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionUser_User_UserId",
                table: "CompetitionUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionUser_Competition_CompetitionId",
                table: "CompetitionUser");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionUser_User_UserId",
                table: "CompetitionUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CompetitionUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "CompetitionId",
                table: "CompetitionUser",
                newName: "CompetitionsId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetitionUser_UserId",
                table: "CompetitionUser",
                newName: "IX_CompetitionUser_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionUser_Competition_CompetitionsId",
                table: "CompetitionUser",
                column: "CompetitionsId",
                principalTable: "Competition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetitionUser_User_UsersId",
                table: "CompetitionUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
