using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Caris",
                newName: "Telefon2");

            migrationBuilder.AddColumn<string>(
                name: "Telefon1",
                table: "Caris",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefon1",
                table: "Caris");

            migrationBuilder.RenameColumn(
                name: "Telefon2",
                table: "Caris",
                newName: "Telefon");
        }
    }
}
