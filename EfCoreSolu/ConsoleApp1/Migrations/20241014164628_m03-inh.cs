using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class m03inh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_c2ss",
                table: "c2ss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_c1ss",
                table: "c1ss");

            migrationBuilder.RenameTable(
                name: "c2ss",
                newName: "c2s");

            migrationBuilder.RenameTable(
                name: "c1ss",
                newName: "c1s");

            migrationBuilder.AddPrimaryKey(
                name: "PK_c2s",
                table: "c2s",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_c1s",
                table: "c1s",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_c2s",
                table: "c2s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_c1s",
                table: "c1s");

            migrationBuilder.RenameTable(
                name: "c2s",
                newName: "c2ss");

            migrationBuilder.RenameTable(
                name: "c1s",
                newName: "c1ss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_c2ss",
                table: "c2ss",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_c1ss",
                table: "c1ss",
                column: "Id");
        }
    }
}
