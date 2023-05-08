using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnaSektors",
                columns: table => new
                {
                    AnaSektorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnaSektorAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaSektors", x => x.AnaSektorId);
                });

            migrationBuilder.CreateTable(
                name: "BagliSektors",
                columns: table => new
                {
                    BagliSektorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BagliSektorAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagliSektors", x => x.BagliSektorId);
                });

            migrationBuilder.CreateTable(
                name: "CariDurums",
                columns: table => new
                {
                    CariDurumId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CariDurumAciklama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariDurums", x => x.CariDurumId);
                });

            migrationBuilder.CreateTable(
                name: "CariTipis",
                columns: table => new
                {
                    CariTipiId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CariTipiAciklama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariTipis", x => x.CariTipiId);
                });

            migrationBuilder.CreateTable(
                name: "Cinsiyets",
                columns: table => new
                {
                    CinsiyetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CinsiyetAciklama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsiyets", x => x.CinsiyetId);
                });

            migrationBuilder.CreateTable(
                name: "Departmans",
                columns: table => new
                {
                    DepartmanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmanAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmans", x => x.DepartmanId);
                });

            migrationBuilder.CreateTable(
                name: "IlgiliKisilers",
                columns: table => new
                {
                    IlgiliKisiId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IlgiliKisiNo = table.Column<int>(type: "integer", nullable: false),
                    IlgiliKisiAdi = table.Column<string>(type: "text", nullable: false),
                    IlgiliKisiSoyadi = table.Column<string>(type: "text", nullable: false),
                    IlgiliKisiCinsiyet = table.Column<string>(type: "text", nullable: false),
                    IlgiliKisiDepartman = table.Column<string>(type: "text", nullable: false),
                    IlgiliKisiPozisyon = table.Column<string>(type: "text", nullable: false),
                    IlgiliKisiKullaniciAdi = table.Column<string>(type: "text", nullable: false),
                    IlgiliKisiParola = table.Column<string>(type: "text", nullable: false),
                    IlgiliKisiTelefon = table.Column<string>(type: "text", nullable: false),
                    IlgiliKisiDahiliTelefon = table.Column<string>(type: "text", nullable: false),
                    IlgiliKisiDurumu = table.Column<string>(type: "text", nullable: false),
                    IlgiliKisiMail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IlgiliKisilers", x => x.IlgiliKisiId);
                });

            migrationBuilder.CreateTable(
                name: "ParaBirimis",
                columns: table => new
                {
                    ParaBirimiId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParaBirimiAdi = table.Column<string>(type: "text", nullable: false),
                    ParaBirimiKisaltma = table.Column<string>(type: "text", nullable: false),
                    ParaBirimiSimge = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParaBirimis", x => x.ParaBirimiId);
                });

            migrationBuilder.CreateTable(
                name: "Subes",
                columns: table => new
                {
                    SubeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Telefon = table.Column<string>(type: "text", nullable: false),
                    Telefon2 = table.Column<string>(type: "text", nullable: false),
                    Mail = table.Column<string>(type: "text", nullable: false),
                    WebSite = table.Column<string>(type: "text", nullable: false),
                    Adres = table.Column<string>(type: "text", nullable: false),
                    Ulke = table.Column<string>(type: "text", nullable: false),
                    Sehir = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subes", x => x.SubeId);
                });

            migrationBuilder.CreateTable(
                name: "Ulkes",
                columns: table => new
                {
                    UlkeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UlkeAdi = table.Column<string>(type: "text", nullable: false),
                    BinaryCode = table.Column<string>(type: "text", nullable: false),
                    TripleCode = table.Column<string>(type: "text", nullable: false),
                    TelefonKodu = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulkes", x => x.UlkeId);
                });

            migrationBuilder.CreateTable(
                name: "Unvans",
                columns: table => new
                {
                    UnvanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnvanAciklama = table.Column<string>(type: "text", nullable: false),
                    UnvanKisaltma = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unvans", x => x.UnvanId);
                });

            migrationBuilder.CreateTable(
                name: "AnaSektor_BagliSektors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnaSektorId = table.Column<int>(type: "integer", nullable: false),
                    BagliSektorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaSektor_BagliSektors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnaSektor_BagliSektors_AnaSektors_AnaSektorId",
                        column: x => x.AnaSektorId,
                        principalTable: "AnaSektors",
                        principalColumn: "AnaSektorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnaSektor_BagliSektors_BagliSektors_BagliSektorId",
                        column: x => x.BagliSektorId,
                        principalTable: "BagliSektors",
                        principalColumn: "BagliSektorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pozisyons",
                columns: table => new
                {
                    PozisyonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PozisyonAdi = table.Column<string>(type: "text", nullable: false),
                    DepartmanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozisyons", x => x.PozisyonId);
                    table.ForeignKey(
                        name: "FK_Pozisyons_Departmans_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmans",
                        principalColumn: "DepartmanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sehirs",
                columns: table => new
                {
                    SehirId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SehirAdi = table.Column<string>(type: "text", nullable: false),
                    PlakaKodu = table.Column<string>(type: "text", nullable: false),
                    TelefonKodu = table.Column<string>(type: "text", nullable: false),
                    PostaKodu = table.Column<string>(type: "text", nullable: false),
                    Silindi = table.Column<bool>(type: "boolean", nullable: false),
                    SonDegistirmeTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UlkeId = table.Column<int>(type: "integer", nullable: false),
                    SonDegistiren = table.Column<int>(type: "integer", nullable: false),
                    Olusturan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirs", x => x.SehirId);
                    table.ForeignKey(
                        name: "FK_Sehirs_Ulkes_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulkes",
                        principalColumn: "UlkeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ilces",
                columns: table => new
                {
                    IlceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SehirId = table.Column<int>(type: "integer", nullable: false),
                    IlceAdi = table.Column<string>(type: "text", nullable: false),
                    PostaKodu = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilces", x => x.IlceId);
                    table.ForeignKey(
                        name: "FK_Ilces_Sehirs_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirs",
                        principalColumn: "SehirId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Caris",
                columns: table => new
                {
                    CariId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirmaNo = table.Column<int>(type: "integer", nullable: false),
                    CariTipiId = table.Column<int>(type: "integer", nullable: false),
                    HesapKodu = table.Column<string>(type: "text", nullable: false),
                    UnvanId = table.Column<int>(type: "integer", nullable: false),
                    VergiDairesi = table.Column<string>(type: "text", nullable: false),
                    VergiNo = table.Column<string>(type: "text", nullable: false),
                    CariDil = table.Column<string>(type: "text", nullable: false),
                    UlkeId = table.Column<int>(type: "integer", nullable: false),
                    SehirId = table.Column<int>(type: "integer", nullable: false),
                    IlceId = table.Column<int>(type: "integer", nullable: false),
                    CariDurumId = table.Column<int>(type: "integer", nullable: false),
                    ParaBirimiId = table.Column<int>(type: "integer", nullable: false),
                    WebSitesi = table.Column<string>(type: "text", nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: false),
                    Adres = table.Column<string>(type: "text", nullable: false),
                    MailAdresi1 = table.Column<string>(type: "text", nullable: false),
                    MailAdresi2 = table.Column<string>(type: "text", nullable: false),
                    AnaSektorId = table.Column<int>(type: "integer", nullable: true),
                    Sektor = table.Column<int>(type: "integer", nullable: false),
                    BagliSektorId = table.Column<int>(type: "integer", nullable: false),
                    eFaturaMukellefi = table.Column<bool>(type: "boolean", nullable: false),
                    eIrsaliyeMukellefi = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caris", x => x.CariId);
                    table.ForeignKey(
                        name: "FK_Caris_AnaSektors_AnaSektorId",
                        column: x => x.AnaSektorId,
                        principalTable: "AnaSektors",
                        principalColumn: "AnaSektorId");
                    table.ForeignKey(
                        name: "FK_Caris_BagliSektors_BagliSektorId",
                        column: x => x.BagliSektorId,
                        principalTable: "BagliSektors",
                        principalColumn: "BagliSektorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caris_CariDurums_CariDurumId",
                        column: x => x.CariDurumId,
                        principalTable: "CariDurums",
                        principalColumn: "CariDurumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caris_CariTipis_CariTipiId",
                        column: x => x.CariTipiId,
                        principalTable: "CariTipis",
                        principalColumn: "CariTipiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caris_Ilces_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilces",
                        principalColumn: "IlceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caris_ParaBirimis_ParaBirimiId",
                        column: x => x.ParaBirimiId,
                        principalTable: "ParaBirimis",
                        principalColumn: "ParaBirimiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caris_Sehirs_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirs",
                        principalColumn: "SehirId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caris_Ulkes_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulkes",
                        principalColumn: "UlkeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caris_Unvans_UnvanId",
                        column: x => x.UnvanId,
                        principalTable: "Unvans",
                        principalColumn: "UnvanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnaSektor_BagliSektors_AnaSektorId",
                table: "AnaSektor_BagliSektors",
                column: "AnaSektorId");

            migrationBuilder.CreateIndex(
                name: "IX_AnaSektor_BagliSektors_BagliSektorId",
                table: "AnaSektor_BagliSektors",
                column: "BagliSektorId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_AnaSektorId",
                table: "Caris",
                column: "AnaSektorId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_BagliSektorId",
                table: "Caris",
                column: "BagliSektorId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_CariDurumId",
                table: "Caris",
                column: "CariDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_CariTipiId",
                table: "Caris",
                column: "CariTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_IlceId",
                table: "Caris",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_ParaBirimiId",
                table: "Caris",
                column: "ParaBirimiId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_SehirId",
                table: "Caris",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_UlkeId",
                table: "Caris",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_UnvanId",
                table: "Caris",
                column: "UnvanId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilces_SehirId",
                table: "Ilces",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Pozisyons_DepartmanId",
                table: "Pozisyons",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Sehirs_UlkeId",
                table: "Sehirs",
                column: "UlkeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnaSektor_BagliSektors");

            migrationBuilder.DropTable(
                name: "Caris");

            migrationBuilder.DropTable(
                name: "Cinsiyets");

            migrationBuilder.DropTable(
                name: "IlgiliKisilers");

            migrationBuilder.DropTable(
                name: "Pozisyons");

            migrationBuilder.DropTable(
                name: "Subes");

            migrationBuilder.DropTable(
                name: "AnaSektors");

            migrationBuilder.DropTable(
                name: "BagliSektors");

            migrationBuilder.DropTable(
                name: "CariDurums");

            migrationBuilder.DropTable(
                name: "CariTipis");

            migrationBuilder.DropTable(
                name: "Ilces");

            migrationBuilder.DropTable(
                name: "ParaBirimis");

            migrationBuilder.DropTable(
                name: "Unvans");

            migrationBuilder.DropTable(
                name: "Departmans");

            migrationBuilder.DropTable(
                name: "Sehirs");

            migrationBuilder.DropTable(
                name: "Ulkes");
        }
    }
}
