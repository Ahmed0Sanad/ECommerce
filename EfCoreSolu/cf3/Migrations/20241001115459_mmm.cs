using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cf3.Migrations
{
    /// <inheritdoc />
    public partial class mmm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "departmentid",
                table: "events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_events_departmentid",
                table: "events",
                column: "departmentid");

            migrationBuilder.AddForeignKey(
                name: "FK_events_Departments_departmentid",
                table: "events",
                column: "departmentid",
                principalTable: "Departments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_Departments_departmentid",
                table: "events");

            migrationBuilder.DropIndex(
                name: "IX_events_departmentid",
                table: "events");

            migrationBuilder.DropColumn(
                name: "departmentid",
                table: "events");

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
    }
}
