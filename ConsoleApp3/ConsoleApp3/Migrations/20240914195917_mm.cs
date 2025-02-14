using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp3.Migrations
{
    /// <inheritdoc />
    public partial class mm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salary",
                table: "employees",
                newName: "sal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sal",
                table: "employees",
                newName: "salary");
        }
    }
}
