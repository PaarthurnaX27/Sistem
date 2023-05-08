using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: false),
                    KullaniciAdi2 = table.Column<string>(type: "text", nullable: true),
                    KullaniciSoyadi = table.Column<string>(type: "text", nullable: false),
                    KullaniciMail = table.Column<string>(type: "text", nullable: false),
                    KullaniciParola = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "ServisKalems",
                columns: table => new
                {
                    KalemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenelAciklama = table.Column<string>(type: "text", nullable: false),
                    KullaniciId = table.Column<int>(type: "integer", nullable: false),
                    IslemYeriId = table.Column<int>(type: "integer", nullable: false),
                    SonDurumId = table.Column<int>(type: "integer", nullable: false),
                    BaslamaZamani = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BitisZamani = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sure = table.Column<string>(type: "text", nullable: false),
                    Aciklama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServisKalems", x => x.KalemId);
                });

            migrationBuilder.CreateTable(
                name: "ServisBilgis",
                columns: table => new
                {
                    ServisId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServisNo = table.Column<string>(type: "text", nullable: false),
                    CariId = table.Column<int>(type: "integer", nullable: false),
                    ServisDepartmanId = table.Column<int>(type: "integer", nullable: false),
                    ModulId = table.Column<int>(type: "integer", nullable: false),
                    DepartmanYetkilisi = table.Column<string>(type: "text", nullable: false),
                    Konu = table.Column<string>(type: "text", nullable: false),
                    OncelikId = table.Column<int>(type: "integer", nullable: false),
                    ServisSekliId = table.Column<int>(type: "integer", nullable: false),
                    ServisTipiId = table.Column<int>(type: "integer", nullable: false),
                    KullaniciId = table.Column<int>(type: "integer", nullable: false),
                    TSuresi = table.Column<string>(type: "text", nullable: false),
                    FTSuresi = table.Column<string>(type: "text", nullable: false),
                    TarihSaat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlanlananTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TahminiSure = table.Column<string>(type: "text", nullable: false),
                    GercekSure = table.Column<string>(type: "text", nullable: false),
                    GirilenSure = table.Column<string>(type: "text", nullable: false),
                    SonDurumTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonDurumID = table.Column<int>(type: "integer", nullable: false),
                    Silindi = table.Column<bool>(type: "boolean", nullable: false),
                    SonDegistirmeTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonDegistiren = table.Column<int>(type: "integer", nullable: false),
                    Olusturan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServisBilgis", x => x.ServisId);
                    table.ForeignKey(
                        name: "FK_ServisBilgis_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "CariId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServisBilgis_Kullanici_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanici",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServisBilgis_Moduls_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Moduls",
                        principalColumn: "ModulId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServisBilgis_Onceliks_OncelikId",
                        column: x => x.OncelikId,
                        principalTable: "Onceliks",
                        principalColumn: "OncelikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServisBilgis_ServisDepartmans_ServisDepartmanId",
                        column: x => x.ServisDepartmanId,
                        principalTable: "ServisDepartmans",
                        principalColumn: "ServisDepartmanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServisBilgis_ServisSeklis_ServisSekliId",
                        column: x => x.ServisSekliId,
                        principalTable: "ServisSeklis",
                        principalColumn: "ServisSekliId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServisBilgis_ServisTipis_ServisTipiId",
                        column: x => x.ServisTipiId,
                        principalTable: "ServisTipis",
                        principalColumn: "ServisTipiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServisBilgis_SonDurums_SonDurumID",
                        column: x => x.SonDurumID,
                        principalTable: "SonDurums",
                        principalColumn: "SonDurumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServisBilgis_CariId",
                table: "ServisBilgis",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisBilgis_KullaniciId",
                table: "ServisBilgis",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisBilgis_ModulId",
                table: "ServisBilgis",
                column: "ModulId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisBilgis_OncelikId",
                table: "ServisBilgis",
                column: "OncelikId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisBilgis_ServisDepartmanId",
                table: "ServisBilgis",
                column: "ServisDepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisBilgis_ServisSekliId",
                table: "ServisBilgis",
                column: "ServisSekliId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisBilgis_ServisTipiId",
                table: "ServisBilgis",
                column: "ServisTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_ServisBilgis_SonDurumID",
                table: "ServisBilgis",
                column: "SonDurumID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServisBilgis");

            migrationBuilder.DropTable(
                name: "ServisKalems");

            migrationBuilder.DropTable(
                name: "Kullanici");
        }
    }
}
