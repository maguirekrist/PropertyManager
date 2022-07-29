using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManager.Migrations
{
    public partial class BigUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "Mediae",
                newName: "Url");

            migrationBuilder.AddColumn<long>(
                name: "CreatedById",
                table: "Tickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Mediae",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Mediae",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<long>(
                name: "PropertyId",
                table: "Mediae",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guest_Residents_ResidentId",
                        column: x => x.ResidentId,
                        principalTable: "Residents",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketReply",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    TicketId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketReply_Residents_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Residents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketReply_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatedById",
                table: "Tickets",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Mediae_PropertyId",
                table: "Mediae",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_ResidentId",
                table: "Guest",
                column: "ResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReply_CreatedById",
                table: "TicketReply",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReply_TicketId",
                table: "TicketReply",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mediae_Properties_PropertyId",
                table: "Mediae",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Residents_CreatedById",
                table: "Tickets",
                column: "CreatedById",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mediae_Properties_PropertyId",
                table: "Mediae");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Residents_CreatedById",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "TicketReply");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CreatedById",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Mediae_PropertyId",
                table: "Mediae");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Mediae");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Mediae");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Mediae",
                newName: "url");

            migrationBuilder.AlterColumn<string>(
                name: "url",
                table: "Mediae",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
