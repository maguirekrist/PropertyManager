using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManager.Migrations
{
    public partial class RemoveFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Residents_ResidentId",
                table: "Guests");

            migrationBuilder.AlterColumn<long>(
                name: "ResidentId",
                table: "Guests",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Residents_ResidentId",
                table: "Guests",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Residents_ResidentId",
                table: "Guests");

            migrationBuilder.AlterColumn<long>(
                name: "ResidentId",
                table: "Guests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Residents_ResidentId",
                table: "Guests",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
