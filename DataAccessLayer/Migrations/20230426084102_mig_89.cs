using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig89 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempCariPrograms",
                columns: table => new
                {
                    TempCariProgramId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CariId = table.Column<int>(type: "integer", nullable: false),
                    ProgramsProgramId = table.Column<int>(type: "integer", nullable: true),
                    ProgramId = table.Column<int>(type: "integer", nullable: false),
                    Silindi = table.Column<bool>(type: "boolean", nullable: false),
                    SonDegistirmeTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OlusturulmaTarih = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SonDegistiren = table.Column<int>(type: "integer", nullable: false),
                    Olusturan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempCariPrograms", x => x.TempCariProgramId);
                    table.ForeignKey(
                        name: "FK_TempCariPrograms_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "CariId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempCariPrograms_Programs_ProgramsProgramId",
                        column: x => x.ProgramsProgramId,
                        principalTable: "Programs",
                        principalColumn: "ProgramId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempCariPrograms_CariId",
                table: "TempCariPrograms",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCariPrograms_ProgramsProgramId",
                table: "TempCariPrograms",
                column: "ProgramsProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempCariPrograms");
        }
    }
}
