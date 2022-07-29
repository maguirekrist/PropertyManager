using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManager.Migrations
{
    public partial class Quicky : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Residents_ResidentId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketReply_Residents_CreatedById",
                table: "TicketReply");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketReply_Tickets_TicketId",
                table: "TicketReply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketReply",
                table: "TicketReply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guest",
                table: "Guest");

            migrationBuilder.RenameTable(
                name: "TicketReply",
                newName: "TicketReplies");

            migrationBuilder.RenameTable(
                name: "Guest",
                newName: "Guests");

            migrationBuilder.RenameIndex(
                name: "IX_TicketReply_TicketId",
                table: "TicketReplies",
                newName: "IX_TicketReplies_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketReply_CreatedById",
                table: "TicketReplies",
                newName: "IX_TicketReplies_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Guest_ResidentId",
                table: "Guests",
                newName: "IX_Guests_ResidentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketReplies",
                table: "TicketReplies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Residents_ResidentId",
                table: "Guests",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReplies_Residents_CreatedById",
                table: "TicketReplies",
                column: "CreatedById",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReplies_Tickets_TicketId",
                table: "TicketReplies",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Residents_ResidentId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketReplies_Residents_CreatedById",
                table: "TicketReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketReplies_Tickets_TicketId",
                table: "TicketReplies");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketReplies",
                table: "TicketReplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.RenameTable(
                name: "TicketReplies",
                newName: "TicketReply");

            migrationBuilder.RenameTable(
                name: "Guests",
                newName: "Guest");

            migrationBuilder.RenameIndex(
                name: "IX_TicketReplies_TicketId",
                table: "TicketReply",
                newName: "IX_TicketReply_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketReplies_CreatedById",
                table: "TicketReply",
                newName: "IX_TicketReply_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Guests_ResidentId",
                table: "Guest",
                newName: "IX_Guest_ResidentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketReply",
                table: "TicketReply",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guest",
                table: "Guest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Residents_ResidentId",
                table: "Guest",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReply_Residents_CreatedById",
                table: "TicketReply",
                column: "CreatedById",
                principalTable: "Residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReply_Tickets_TicketId",
                table: "TicketReply",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
