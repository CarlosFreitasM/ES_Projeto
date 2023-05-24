using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_ESFase2.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nominee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nominee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionNominee",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    NomineeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionNominee", x => new { x.CompetitionId, x.NomineeId });
                    table.ForeignKey(
                        name: "FK_CompetitionNominee_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionNominee_Nominee_NomineeId",
                        column: x => x.NomineeId,
                        principalTable: "Nominee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionNominee_NomineeId",
                table: "CompetitionNominee",
                column: "NomineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionNominee");

            migrationBuilder.DropTable(
                name: "Nominee");
        }
    }
}
