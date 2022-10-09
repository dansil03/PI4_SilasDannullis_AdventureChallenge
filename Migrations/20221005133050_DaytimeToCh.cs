using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureChallenge.Migrations
{
    public partial class DaytimeToCh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DayTime",
                table: "challenges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayTime",
                table: "challenges");
        }
    }
}
