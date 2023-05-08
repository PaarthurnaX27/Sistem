using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations.SmSec
{
    /// <inheritdoc />
    public partial class mig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicis",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: false),
                    KullaniciSoyadi = table.Column<string>(type: "text", nullable: false),
                    KullaniciMail = table.Column<string>(type: "text", nullable: false),
                    KullaniciParola = table.Column<string>(type: "text", nullable: false),
                    KullaniciFirma = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicis", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "SecCmps",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyNo = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    ServerName = table.Column<string>(type: "text", nullable: false),
                    DatabaseName = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecCmps", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciFirmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciId = table.Column<int>(type: "integer", nullable: false),
                    SecCmpCompanyId = table.Column<int>(type: "integer", nullable: true),
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciFirmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciFirmas_Kullanicis_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciFirmas_SecCmps_SecCmpCompanyId",
                        column: x => x.SecCmpCompanyId,
                        principalTable: "SecCmps",
                        principalColumn: "CompanyId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciFirmas_KullaniciId",
                table: "KullaniciFirmas",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciFirmas_SecCmpCompanyId",
                table: "KullaniciFirmas",
                column: "SecCmpCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KullaniciFirmas");

            migrationBuilder.DropTable(
                name: "Kullanicis");

            migrationBuilder.DropTable(
                name: "SecCmps");
        }
    }
}
