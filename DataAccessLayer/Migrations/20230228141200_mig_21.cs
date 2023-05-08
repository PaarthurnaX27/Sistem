using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonelSoyadi",
                table: "CariPersonels",
                newName: "CariPersonelSoyadi");

            migrationBuilder.RenameColumn(
                name: "PersonelKodu",
                table: "CariPersonels",
                newName: "CariPersonelKodu");

            migrationBuilder.RenameColumn(
                name: "PersonelAdi2",
                table: "CariPersonels",
                newName: "CariPersonelAdi2");

            migrationBuilder.RenameColumn(
                name: "PersonelAdi",
                table: "CariPersonels",
                newName: "CariPersonelAdi");

            migrationBuilder.RenameColumn(
                name: "PersonelId",
                table: "CariPersonels",
                newName: "CariPersonelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CariPersonelSoyadi",
                table: "CariPersonels",
                newName: "PersonelSoyadi");

            migrationBuilder.RenameColumn(
                name: "CariPersonelKodu",
                table: "CariPersonels",
                newName: "PersonelKodu");

            migrationBuilder.RenameColumn(
                name: "CariPersonelAdi2",
                table: "CariPersonels",
                newName: "PersonelAdi2");

            migrationBuilder.RenameColumn(
                name: "CariPersonelAdi",
                table: "CariPersonels",
                newName: "PersonelAdi");

            migrationBuilder.RenameColumn(
                name: "CariPersonelId",
                table: "CariPersonels",
                newName: "PersonelId");
        }
    }
}
