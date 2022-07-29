using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManager.Migrations
{
    public partial class ConditionOnProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Condition",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Properties");
        }
    }
}
