using Microsoft.EntityFrameworkCore.Migrations;

namespace Blackjack.Data.Migrations
{
    public partial class NewSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ACT");

            migrationBuilder.RenameTable(
                name: "UserProfile",
                newName: "UserProfile",
                newSchema: "ACT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserProfile",
                schema: "ACT",
                newName: "UserProfile");
        }
    }
}
