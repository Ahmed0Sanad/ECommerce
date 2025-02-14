using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class m02inh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_inhirtance",
                table: "inhirtance");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "inhirtance");

            migrationBuilder.DropColumn(
                name: "hireDate",
                table: "inhirtance");

            migrationBuilder.RenameTable(
                name: "inhirtance",
                newName: "c2ss");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ddDate",
                table: "c2ss",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_c2ss",
                table: "c2ss",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "c1ss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_c1ss", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "c1ss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_c2ss",
                table: "c2ss");

            migrationBuilder.RenameTable(
                name: "c2ss",
                newName: "inhirtance");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ddDate",
                table: "inhirtance",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "inhirtance",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "hireDate",
                table: "inhirtance",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_inhirtance",
                table: "inhirtance",
                column: "Id");
        }
    }
}
