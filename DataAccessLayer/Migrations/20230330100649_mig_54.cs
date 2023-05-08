using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig54 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Kapandi",
                table: "TempServisBilgis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MusteriOnayi",
                table: "TempServisBilgis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Kapandi",
                table: "ServisBilgis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MusteriOnayi",
                table: "ServisBilgis",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kapandi",
                table: "TempServisBilgis");

            migrationBuilder.DropColumn(
                name: "MusteriOnayi",
                table: "TempServisBilgis");

            migrationBuilder.DropColumn(
                name: "Kapandi",
                table: "ServisBilgis");

            migrationBuilder.DropColumn(
                name: "MusteriOnayi",
                table: "ServisBilgis");
        }
    }
}
