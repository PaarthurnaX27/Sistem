using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig67 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projes",
                columns: table => new
                {
                    ProjeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CariId = table.Column<int>(type: "integer", nullable: false),
                    Silindi = table.Column<bool>(type: "boolean", nullable: false),
                    SonDegistirmeTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonDegistiren = table.Column<int>(type: "integer", nullable: false),
                    Olusturan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projes", x => x.ProjeId);
                    table.ForeignKey(
                        name: "FK_Projes_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "CariId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TempDanismans",
                columns: table => new
                {
                    TempDanismanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonelId = table.Column<int>(type: "integer", nullable: false),
                    PersonelTipiId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempDanismans", x => x.TempDanismanId);
                    table.ForeignKey(
                        name: "FK_TempDanismans_PersonelTipis_PersonelTipiId",
                        column: x => x.PersonelTipiId,
                        principalTable: "PersonelTipis",
                        principalColumn: "PersonelTipiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempDanismans_Personels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personels",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjeIceriks",
                columns: table => new
                {
                    ProjeIcerikId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjeId = table.Column<int>(type: "integer", nullable: false),
                    PersonelId = table.Column<int>(type: "integer", nullable: true),
                    PersonelTipiId = table.Column<int>(type: "integer", nullable: true),
                    GecerlilikTarihBaslangic = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GecerlilikTarihBitis = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ParaBirimiId = table.Column<int>(type: "integer", nullable: false),
                    Fiyat = table.Column<string>(type: "text", nullable: false),
                    Silindi = table.Column<bool>(type: "boolean", nullable: false),
                    SonDegistirmeTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonDegistiren = table.Column<int>(type: "integer", nullable: false),
                    Olusturan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeIceriks", x => x.ProjeIcerikId);
                    table.ForeignKey(
                        name: "FK_ProjeIceriks_ParaBirimis_ParaBirimiId",
                        column: x => x.ParaBirimiId,
                        principalTable: "ParaBirimis",
                        principalColumn: "ParaBirimiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeIceriks_PersonelTipis_PersonelTipiId",
                        column: x => x.PersonelTipiId,
                        principalTable: "PersonelTipis",
                        principalColumn: "PersonelTipiId");
                    table.ForeignKey(
                        name: "FK_ProjeIceriks_Personels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personels",
                        principalColumn: "PersonelId");
                    table.ForeignKey(
                        name: "FK_ProjeIceriks_Projes_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Projes",
                        principalColumn: "ProjeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjeIceriks_ParaBirimiId",
                table: "ProjeIceriks",
                column: "ParaBirimiId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeIceriks_PersonelId",
                table: "ProjeIceriks",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeIceriks_PersonelTipiId",
                table: "ProjeIceriks",
                column: "PersonelTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeIceriks_ProjeId",
                table: "ProjeIceriks",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projes_CariId",
                table: "Projes",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_TempDanismans_PersonelId",
                table: "TempDanismans",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_TempDanismans_PersonelTipiId",
                table: "TempDanismans",
                column: "PersonelTipiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjeIceriks");

            migrationBuilder.DropTable(
                name: "TempDanismans");

            migrationBuilder.DropTable(
                name: "Projes");
        }
    }
}
