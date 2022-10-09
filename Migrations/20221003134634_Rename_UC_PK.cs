using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureChallenge.Migrations
{
    public partial class Rename_UC_PK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "userChallenges",
                newName: "UserChallengeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserChallengeId",
                table: "userChallenges",
                newName: "Id");
        }
    }
}
