using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IlgiliKisiAdi",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "IlgiliKisiCinsiyet",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "IlgiliKisiDahiliTelefon",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "IlgiliKisiDepartman",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "IlgiliKisiDurumu",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "IlgiliKisiKullaniciAdi",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "IlgiliKisiMail",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "IlgiliKisiParola",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "IlgiliKisiPozisyon",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "IlgiliKisiSoyadi",
                table: "IlgiliKisilers");

            migrationBuilder.RenameColumn(
                name: "IlgiliKisiTelefon",
                table: "IlgiliKisilers",
                newName: "IlgiliKisiKodu");

            migrationBuilder.RenameColumn(
                name: "IlgiliKisiNo",
                table: "IlgiliKisilers",
                newName: "UnvanId");

            migrationBuilder.AddColumn<bool>(
                name: "CalismaDurumu",
                table: "IlgiliKisilers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CariId",
                table: "IlgiliKisilers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmanId",
                table: "IlgiliKisilers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "IlgiliKisilers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PozisyonId",
                table: "IlgiliKisilers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SerivsMailGonder",
                table: "IlgiliKisilers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServisFaturaGonder",
                table: "IlgiliKisilers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_IlgiliKisilers_PozisyonId",
                table: "IlgiliKisilers",
                column: "PozisyonId");

            migrationBuilder.AddForeignKey(
                name: "FK_IlgiliKisilers_Pozisyons_PozisyonId",
                table: "IlgiliKisilers",
                column: "PozisyonId",
                principalTable: "Pozisyons",
                principalColumn: "PozisyonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IlgiliKisilers_Pozisyons_PozisyonId",
                table: "IlgiliKisilers");

            migrationBuilder.DropIndex(
                name: "IX_IlgiliKisilers_PozisyonId",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "CalismaDurumu",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "CariId",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "DepartmanId",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "PozisyonId",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "SerivsMailGonder",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "ServisFaturaGonder",
                table: "IlgiliKisilers");

            migrationBuilder.RenameColumn(
                name: "UnvanId",
                table: "IlgiliKisilers",
                newName: "IlgiliKisiNo");

            migrationBuilder.RenameColumn(
                name: "IlgiliKisiKodu",
                table: "IlgiliKisilers",
                newName: "IlgiliKisiTelefon");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiAdi",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiCinsiyet",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiDahiliTelefon",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiDepartman",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiDurumu",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiKullaniciAdi",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiMail",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiParola",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiPozisyon",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiSoyadi",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
