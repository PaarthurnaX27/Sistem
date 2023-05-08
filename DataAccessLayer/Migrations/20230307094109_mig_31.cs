using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempCariPersonels",
                columns: table => new
                {
                    CariPersonelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CariPersonelAdi = table.Column<string>(type: "text", nullable: false),
                    CariPersonelAdi2 = table.Column<string>(type: "text", nullable: true),
                    CariPersonelSoyadi = table.Column<string>(type: "text", nullable: false),
                    CariPersonelKodu = table.Column<string>(type: "text", nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: false),
                    Adres1 = table.Column<string>(type: "text", nullable: false),
                    Adres2 = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: false),
                    UnvanId = table.Column<int>(type: "integer", nullable: false),
                    DepartmanId = table.Column<int>(type: "integer", nullable: false),
                    PozisyonId = table.Column<int>(type: "integer", nullable: false),
                    CalismaDurumu = table.Column<bool>(type: "boolean", nullable: false),
                    CinsiyetId = table.Column<int>(type: "integer", nullable: false),
                    SerivsMailGonder = table.Column<bool>(type: "boolean", nullable: false),
                    ServisFaturaGonder = table.Column<bool>(type: "boolean", nullable: false),
                    IseGirisTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IstenCikisTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Silindi = table.Column<bool>(type: "boolean", nullable: false),
                    SonDegistirmeTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonDegistiren = table.Column<int>(type: "integer", nullable: false),
                    Olusturan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempCariPersonels", x => x.CariPersonelId);
                    table.ForeignKey(
                        name: "FK_TempCariPersonels_Cinsiyets_CinsiyetId",
                        column: x => x.CinsiyetId,
                        principalTable: "Cinsiyets",
                        principalColumn: "CinsiyetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCariPersonels_Departmans_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmans",
                        principalColumn: "DepartmanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCariPersonels_Pozisyons_PozisyonId",
                        column: x => x.PozisyonId,
                        principalTable: "Pozisyons",
                        principalColumn: "PozisyonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCariPersonels_Unvans_UnvanId",
                        column: x => x.UnvanId,
                        principalTable: "Unvans",
                        principalColumn: "UnvanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempCariPersonels_CinsiyetId",
                table: "TempCariPersonels",
                column: "CinsiyetId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCariPersonels_DepartmanId",
                table: "TempCariPersonels",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCariPersonels_PozisyonId",
                table: "TempCariPersonels",
                column: "PozisyonId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCariPersonels_UnvanId",
                table: "TempCariPersonels",
                column: "UnvanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempCariPersonels");
        }
    }
}
