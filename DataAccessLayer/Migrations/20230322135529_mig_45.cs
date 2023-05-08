using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServisBilgis_Kullanici_KullaniciId",
                table: "ServisBilgis");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "ServisBilgis",
                newName: "PersonelId");

            migrationBuilder.RenameIndex(
                name: "IX_ServisBilgis_KullaniciId",
                table: "ServisBilgis",
                newName: "IX_ServisBilgis_PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServisBilgis_Personels_PersonelId",
                table: "ServisBilgis",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServisBilgis_Personels_PersonelId",
                table: "ServisBilgis");

            migrationBuilder.RenameColumn(
                name: "PersonelId",
                table: "ServisBilgis",
                newName: "KullaniciId");

            migrationBuilder.RenameIndex(
                name: "IX_ServisBilgis_PersonelId",
                table: "ServisBilgis",
                newName: "IX_ServisBilgis_KullaniciId");

            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: false),
                    KullaniciAdi2 = table.Column<string>(type: "text", nullable: true),
                    KullaniciMail = table.Column<string>(type: "text", nullable: false),
                    KullaniciParola = table.Column<string>(type: "text", nullable: false),
                    KullaniciSoyadi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ServisBilgis_Kullanici_KullaniciId",
                table: "ServisBilgis",
                column: "KullaniciId",
                principalTable: "Kullanici",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
