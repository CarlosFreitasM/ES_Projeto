using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_ESFase2.Migrations
{
    /// <inheritdoc />
    public partial class AddedNumberOfVotesNominee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "numberOfVotes",
                table: "CompetitionNominee",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numberOfVotes",
                table: "CompetitionNominee");
        }
    }
}
