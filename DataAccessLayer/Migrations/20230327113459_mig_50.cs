using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig50 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempServisKalems",
                columns: table => new
                {
                    KalemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenelAciklama = table.Column<string>(type: "text", nullable: false),
                    PersonelId = table.Column<int>(type: "integer", nullable: false),
                    IslemYeriId = table.Column<int>(type: "integer", nullable: false),
                    SonDurumId = table.Column<int>(type: "integer", nullable: false),
                    BaslamaZamani = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BitisZamani = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sure = table.Column<string>(type: "text", nullable: false),
                    Aciklama = table.Column<string>(type: "text", nullable: false),
                    ServisBilgiServisId = table.Column<int>(type: "integer", nullable: true),
                    ServisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempServisKalems", x => x.KalemId);
                    table.ForeignKey(
                        name: "FK_TempServisKalems_ServisBilgis_ServisBilgiServisId",
                        column: x => x.ServisBilgiServisId,
                        principalTable: "ServisBilgis",
                        principalColumn: "ServisId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TempServisKalems_ServisBilgiServisId",
                table: "TempServisKalems",
                column: "ServisBilgiServisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempServisKalems");
        }
    }
}
