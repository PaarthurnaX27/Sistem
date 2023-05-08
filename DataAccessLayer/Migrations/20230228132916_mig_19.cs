using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CariPersonels",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonelAdi = table.Column<string>(type: "text", nullable: false),
                    PersonelAdi2 = table.Column<string>(type: "text", nullable: true),
                    PersonelSoyadi = table.Column<string>(type: "text", nullable: false),
                    PersonelKodu = table.Column<string>(type: "text", nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: false),
                    Adres1 = table.Column<string>(type: "text", nullable: false),
                    Adres2 = table.Column<string>(type: "text", nullable: true),
                    CinsiyetId = table.Column<int>(type: "integer", nullable: false),
                    Silindi = table.Column<bool>(type: "boolean", nullable: false),
                    SonDegistirmeTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonDegistiren = table.Column<int>(type: "integer", nullable: false),
                    Olusturan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CariPersonels", x => x.PersonelId);
                    table.ForeignKey(
                        name: "FK_CariPersonels_Cinsiyets_CinsiyetId",
                        column: x => x.CinsiyetId,
                        principalTable: "Cinsiyets",
                        principalColumn: "CinsiyetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CariPersonels_CinsiyetId",
                table: "CariPersonels",
                column: "CinsiyetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CariPersonels");
        }
    }
}
