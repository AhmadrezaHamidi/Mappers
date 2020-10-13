using Microsoft.EntityFrameworkCore.Migrations;

namespace BookAndShelve.Migrations
{
    public partial class gfefg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RooleAccepthing",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RooleAccepthing",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
