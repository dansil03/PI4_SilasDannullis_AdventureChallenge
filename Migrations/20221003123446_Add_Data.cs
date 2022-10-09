using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureChallenge.Migrations
{
    public partial class Add_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChallengeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPlayers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_challenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userChallenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProofText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userChallenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userChallenges_challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userChallenges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userChallenges_ChallengeId",
                table: "userChallenges",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_userChallenges_UserId",
                table: "userChallenges",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userChallenges");

            migrationBuilder.DropTable(
                name: "challenges");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
