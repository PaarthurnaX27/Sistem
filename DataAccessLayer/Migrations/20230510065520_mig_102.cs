using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Numarators",
                columns: table => new
                {
                    NumaratorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumaratorAciklama = table.Column<string>(type: "text", nullable: false),
                    ParcaTipi = table.Column<int>(type: "integer", nullable: false),
                    ParcaUzunlugu = table.Column<int>(type: "integer", nullable: false),
                    Gun = table.Column<string>(type: "text", nullable: true),
                    Ay = table.Column<string>(type: "text", nullable: true),
                    Yil = table.Column<string>(type: "text", nullable: true),
                    Numara = table.Column<int>(type: "integer", nullable: true),
                    Parametre1 = table.Column<string>(type: "text", nullable: true),
                    Parametre2 = table.Column<string>(type: "text", nullable: true),
                    OnEk = table.Column<string>(type: "text", nullable: true),
                    BaslangicSayisi = table.Column<int>(type: "integer", nullable: false),
                    ArttirmaAraligi = table.Column<int>(type: "integer", nullable: false),
                    YenilemeParcalari = table.Column<string>(type: "text", nullable: true),
                    DoldurmaKarakteri = table.Column<string>(type: "text", nullable: true),
                    SonEk = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numarators", x => x.NumaratorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Numarators");
        }
    }
}
