using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig94 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaturaMails",
                columns: table => new
                {
                    FaturaMailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjeId = table.Column<int>(type: "integer", nullable: false),
                    CariPersonelId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_FaturaMails", x => x.FaturaMailId);
                    table.ForeignKey(
                        name: "FK_FaturaMails_CariPersonels_CariPersonelId",
                        column: x => x.CariPersonelId,
                        principalTable: "CariPersonels",
                        principalColumn: "CariPersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaturaMails_Projes_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Projes",
                        principalColumn: "ProjeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaturaMails_CariPersonelId",
                table: "FaturaMails",
                column: "CariPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaMails_ProjeId",
                table: "FaturaMails",
                column: "ProjeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaturaMails");
        }
    }
}
