using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Numarator_Tablos",
                columns: table => new
                {
                    NumaratorTabloId = table.Column<int>(name: "Numarator_TabloId", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TabloAdi = table.Column<string>(type: "text", nullable: false),
                    NumaratorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numarator_Tablos", x => x.NumaratorTabloId);
                    table.ForeignKey(
                        name: "FK_Numarator_Tablos_Numarators_NumaratorId",
                        column: x => x.NumaratorId,
                        principalTable: "Numarators",
                        principalColumn: "NumaratorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Numarator_Tablos_NumaratorId",
                table: "Numarator_Tablos",
                column: "NumaratorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Numarator_Tablos");
        }
    }
}
