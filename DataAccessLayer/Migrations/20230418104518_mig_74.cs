using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig74 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempFiyatLists",
                columns: table => new
                {
                    TempFiyatListId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    table.PrimaryKey("PK_TempFiyatLists", x => x.TempFiyatListId);
                    table.ForeignKey(
                        name: "FK_TempFiyatLists_ParaBirimis_ParaBirimiId",
                        column: x => x.ParaBirimiId,
                        principalTable: "ParaBirimis",
                        principalColumn: "ParaBirimiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempFiyatLists_PersonelTipis_PersonelTipiId",
                        column: x => x.PersonelTipiId,
                        principalTable: "PersonelTipis",
                        principalColumn: "PersonelTipiId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempFiyatLists_ParaBirimiId",
                table: "TempFiyatLists",
                column: "ParaBirimiId");

            migrationBuilder.CreateIndex(
                name: "IX_TempFiyatLists_PersonelTipiId",
                table: "TempFiyatLists",
                column: "PersonelTipiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempFiyatLists");
        }
    }
}
