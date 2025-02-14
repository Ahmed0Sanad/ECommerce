using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cf3.Migrations
{
    /// <inheritdoc />
    public partial class adding_class : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "class1id",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_class1id",
                table: "Departments",
                column: "class1id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_events_class1id",
                table: "Departments",
                column: "class1id",
                principalTable: "events",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_events_class1id",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_class1id",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "class1id",
                table: "Departments");
        }
    }
}
