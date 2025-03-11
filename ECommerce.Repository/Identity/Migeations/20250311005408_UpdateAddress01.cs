using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Repository.Identity.Migeations
{
    /// <inheritdoc />
    public partial class UpdateAddress01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
