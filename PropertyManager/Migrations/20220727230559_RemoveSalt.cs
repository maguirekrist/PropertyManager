using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManager.Migrations
{
    public partial class RemoveSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Residents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Residents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
