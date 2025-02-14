using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cfCore_2.Migrations
{
    /// <inheritdoc />
    public partial class m0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticketets_Events_eventId",
                table: "Ticketets");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticketets_Users_userId",
                table: "Ticketets");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticketets_Events_eventId",
                table: "Ticketets",
                column: "eventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticketets_Users_userId",
                table: "Ticketets",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticketets_Events_eventId",
                table: "Ticketets");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticketets_Users_userId",
                table: "Ticketets");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticketets_Events_eventId",
                table: "Ticketets",
                column: "eventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticketets_Users_userId",
                table: "Ticketets",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
