using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureChallenge.Migrations
{
    public partial class AddUcStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "userChallenges",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "userChallenges");
        }
    }
}
