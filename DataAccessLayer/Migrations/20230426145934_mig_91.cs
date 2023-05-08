using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig91 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempFaturaMails",
                columns: table => new
                {
                    TempFaturaMailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CariPersonelId = table.Column<int>(type: "integer", nullable: false),
                    FaturalamaPeriyoduId = table.Column<int>(type: "integer", nullable: false),
                    ServisMailiGonderilecekMi = table.Column<bool>(type: "boolean", nullable: false),
                    FaturaMailiGonderilecekMi = table.Column<bool>(type: "boolean", nullable: false),
                    Silindi = table.Column<bool>(type: "boolean", nullable: false),
                    SonDegistirmeTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonDegistiren = table.Column<int>(type: "integer", nullable: false),
                    Olusturan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempFaturaMails", x => x.TempFaturaMailId);
                    table.ForeignKey(
                        name: "FK_TempFaturaMails_CariPersonels_CariPersonelId",
                        column: x => x.CariPersonelId,
                        principalTable: "CariPersonels",
                        principalColumn: "CariPersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempFaturaMails_FaturalamaPeriyodus_FaturalamaPeriyoduId",
                        column: x => x.FaturalamaPeriyoduId,
                        principalTable: "FaturalamaPeriyodus",
                        principalColumn: "FaturalamaPeriyoduId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempFaturaMails_CariPersonelId",
                table: "TempFaturaMails",
                column: "CariPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_TempFaturaMails_FaturalamaPeriyoduId",
                table: "TempFaturaMails",
                column: "FaturalamaPeriyoduId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempFaturaMails");
        }
    }
}
