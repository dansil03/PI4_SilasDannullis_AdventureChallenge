using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureChallenge.Migrations
{
    public partial class AddProofImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "userChallenges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "userChallenges");
        }
    }
}
