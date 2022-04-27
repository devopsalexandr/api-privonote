using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Privnote.Migrations
{
    public partial class AddReadAttemps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReadAttempts",
                table: "notes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadAttempts",
                table: "notes");
        }
    }
}
