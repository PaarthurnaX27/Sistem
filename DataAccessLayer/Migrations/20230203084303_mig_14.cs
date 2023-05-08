using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personels",
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
                    DepartmanId = table.Column<int>(type: "integer", nullable: true),
                    CinsiyetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelId);
                    table.ForeignKey(
                        name: "FK_Personels_Cinsiyets_CinsiyetId",
                        column: x => x.CinsiyetId,
                        principalTable: "Cinsiyets",
                        principalColumn: "CinsiyetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personels_Departmans_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmans",
                        principalColumn: "DepartmanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personels_CinsiyetId",
                table: "Personels",
                column: "CinsiyetId");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_DepartmanId",
                table: "Personels",
                column: "DepartmanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personels");
        }
    }
}
