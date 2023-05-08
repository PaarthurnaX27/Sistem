using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig79 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempServisProjeIceriks",
                columns: table => new
                {
                    ServisProjeIcerikId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjeId = table.Column<int>(type: "integer", nullable: false),
                    ModulId = table.Column<int>(type: "integer", nullable: true),
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
                    table.PrimaryKey("PK_TempServisProjeIceriks", x => x.ServisProjeIcerikId);
                    table.ForeignKey(
                        name: "FK_TempServisProjeIceriks_Moduls_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Moduls",
                        principalColumn: "ModulId");
                    table.ForeignKey(
                        name: "FK_TempServisProjeIceriks_ParaBirimis_ParaBirimiId",
                        column: x => x.ParaBirimiId,
                        principalTable: "ParaBirimis",
                        principalColumn: "ParaBirimiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempServisProjeIceriks_Projes_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Projes",
                        principalColumn: "ProjeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempServisProjeIceriks_ModulId",
                table: "TempServisProjeIceriks",
                column: "ModulId");

            migrationBuilder.CreateIndex(
                name: "IX_TempServisProjeIceriks_ParaBirimiId",
                table: "TempServisProjeIceriks",
                column: "ParaBirimiId");

            migrationBuilder.CreateIndex(
                name: "IX_TempServisProjeIceriks_ProjeId",
                table: "TempServisProjeIceriks",
                column: "ProjeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempServisProjeIceriks");
        }
    }
}
