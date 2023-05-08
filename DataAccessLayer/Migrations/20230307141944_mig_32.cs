using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempCaris",
                columns: table => new
                {
                    CariId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirmaNo = table.Column<int>(type: "integer", nullable: false),
                    CariAdi = table.Column<string>(type: "text", nullable: false),
                    CariTipiId = table.Column<int>(type: "integer", nullable: false),
                    HesapKodu = table.Column<string>(type: "text", nullable: false),
                    VergiDairesi = table.Column<string>(type: "text", nullable: false),
                    VergiNo = table.Column<string>(type: "text", nullable: false),
                    CariDil = table.Column<string>(type: "text", nullable: false),
                    UlkeId = table.Column<int>(type: "integer", nullable: false),
                    SehirId = table.Column<int>(type: "integer", nullable: false),
                    IlceId = table.Column<int>(type: "integer", nullable: false),
                    CariDurumId = table.Column<int>(type: "integer", nullable: false),
                    ParaBirimiId = table.Column<int>(type: "integer", nullable: false),
                    WebSitesi = table.Column<string>(type: "text", nullable: false),
                    Telefon1 = table.Column<string>(type: "text", nullable: false),
                    Telefon2 = table.Column<string>(type: "text", nullable: false),
                    Adres = table.Column<string>(type: "text", nullable: false),
                    MailAdresi1 = table.Column<string>(type: "text", nullable: false),
                    MailAdresi2 = table.Column<string>(type: "text", nullable: false),
                    AnaSektorId = table.Column<int>(type: "integer", nullable: false),
                    BagliSektorId = table.Column<int>(type: "integer", nullable: true),
                    eFaturaMukellefi = table.Column<bool>(type: "boolean", nullable: false),
                    eIrsaliyeMukellefi = table.Column<bool>(type: "boolean", nullable: false),
                    Silindi = table.Column<bool>(type: "boolean", nullable: false),
                    SonDegistirmeTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonDegistiren = table.Column<int>(type: "integer", nullable: false),
                    Olusturan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempCaris", x => x.CariId);
                    table.ForeignKey(
                        name: "FK_TempCaris_AnaSektors_AnaSektorId",
                        column: x => x.AnaSektorId,
                        principalTable: "AnaSektors",
                        principalColumn: "AnaSektorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCaris_BagliSektors_BagliSektorId",
                        column: x => x.BagliSektorId,
                        principalTable: "BagliSektors",
                        principalColumn: "BagliSektorId");
                    table.ForeignKey(
                        name: "FK_TempCaris_CariDurums_CariDurumId",
                        column: x => x.CariDurumId,
                        principalTable: "CariDurums",
                        principalColumn: "CariDurumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCaris_CariTipis_CariTipiId",
                        column: x => x.CariTipiId,
                        principalTable: "CariTipis",
                        principalColumn: "CariTipiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCaris_Ilces_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilces",
                        principalColumn: "IlceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCaris_ParaBirimis_ParaBirimiId",
                        column: x => x.ParaBirimiId,
                        principalTable: "ParaBirimis",
                        principalColumn: "ParaBirimiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCaris_Sehirs_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirs",
                        principalColumn: "SehirId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCaris_Ulkes_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulkes",
                        principalColumn: "UlkeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempCaris_AnaSektorId",
                table: "TempCaris",
                column: "AnaSektorId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCaris_BagliSektorId",
                table: "TempCaris",
                column: "BagliSektorId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCaris_CariDurumId",
                table: "TempCaris",
                column: "CariDurumId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCaris_CariTipiId",
                table: "TempCaris",
                column: "CariTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCaris_IlceId",
                table: "TempCaris",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCaris_ParaBirimiId",
                table: "TempCaris",
                column: "ParaBirimiId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCaris_SehirId",
                table: "TempCaris",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCaris_UlkeId",
                table: "TempCaris",
                column: "UlkeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempCaris");
        }
    }
}
