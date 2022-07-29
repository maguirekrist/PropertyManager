using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManager.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Residents_ResidentId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Mediae_Properties_PropertyId",
                table: "Mediae");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Residents_ResidentId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Mediae");

            migrationBuilder.AlterColumn<long>(
                name: "ResidentId",
                table: "Properties",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PropertyId",
                table: "Mediae",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Mediae_Properties_PropertyId",
                table: "Mediae",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Residents_ResidentId",
                table: "Properties",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Residents_ResidentId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Mediae_Properties_PropertyId",
                table: "Mediae");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Residents_ResidentId",
                table: "Properties");

            migrationBuilder.AlterColumn<long>(
                name: "ResidentId",
                table: "Properties",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyId",
                table: "Mediae",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Mediae",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Mediae_Properties_PropertyId",
                table: "Mediae",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Residents_ResidentId",
                table: "Properties",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");
        }
    }
}
