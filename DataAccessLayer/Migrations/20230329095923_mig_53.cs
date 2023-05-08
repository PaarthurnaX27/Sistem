using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig53 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempServisBilgis",
                columns: table => new
                {
                    TempServisId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServisNo = table.Column<string>(type: "text", nullable: false),
                    CariId = table.Column<int>(type: "integer", nullable: false),
                    ServisDepartmanId = table.Column<int>(type: "integer", nullable: false),
                    ModulId = table.Column<int>(type: "integer", nullable: false),
                    DepartmanYetkilisi = table.Column<string>(type: "text", nullable: false),
                    Konu = table.Column<string>(type: "text", nullable: false),
                    ServisSekliId = table.Column<int>(type: "integer", nullable: false),
                    OncelikId = table.Column<int>(type: "integer", nullable: false),
                    ServisTipiId = table.Column<int>(type: "integer", nullable: false),
                    PersonelId = table.Column<int>(type: "integer", nullable: false),
                    TSuresi = table.Column<string>(type: "text", nullable: false),
                    FTSuresi = table.Column<string>(type: "text", nullable: false),
                    TarihSaat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlanlananTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TahminiSure = table.Column<string>(type: "text", nullable: false),
                    GercekSure = table.Column<string>(type: "text", nullable: false),
                    GirilenSure = table.Column<string>(type: "text", nullable: false),
                    SonDurumTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonDurumID = table.Column<int>(type: "integer", nullable: false),
                    Ay = table.Column<string>(type: "text", nullable: false),
                    Yil = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempServisBilgis", x => x.TempServisId);
                    table.ForeignKey(
                        name: "FK_TempServisBilgis_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "CariId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempServisBilgis_Moduls_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Moduls",
                        principalColumn: "ModulId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempServisBilgis_Onceliks_OncelikId",
                        column: x => x.OncelikId,
                        principalTable: "Onceliks",
                        principalColumn: "OncelikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempServisBilgis_Personels_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personels",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempServisBilgis_ServisDepartmans_ServisDepartmanId",
                        column: x => x.ServisDepartmanId,
                        principalTable: "ServisDepartmans",
                        principalColumn: "ServisDepartmanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempServisBilgis_ServisTipis_ServisTipiId",
                        column: x => x.ServisTipiId,
                        principalTable: "ServisTipis",
                        principalColumn: "ServisTipiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempServisBilgis_SonDurums_SonDurumID",
                        column: x => x.SonDurumID,
                        principalTable: "SonDurums",
                        principalColumn: "SonDurumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempServisBilgis_CariId",
                table: "TempServisBilgis",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_TempServisBilgis_ModulId",
                table: "TempServisBilgis",
                column: "ModulId");

            migrationBuilder.CreateIndex(
                name: "IX_TempServisBilgis_OncelikId",
                table: "TempServisBilgis",
                column: "OncelikId");

            migrationBuilder.CreateIndex(
                name: "IX_TempServisBilgis_PersonelId",
                table: "TempServisBilgis",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_TempServisBilgis_ServisDepartmanId",
                table: "TempServisBilgis",
                column: "ServisDepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_TempServisBilgis_ServisTipiId",
                table: "TempServisBilgis",
                column: "ServisTipiId");

            migrationBuilder.CreateIndex(
                name: "IX_TempServisBilgis_SonDurumID",
                table: "TempServisBilgis",
                column: "SonDurumID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempServisBilgis");
        }
    }
}
