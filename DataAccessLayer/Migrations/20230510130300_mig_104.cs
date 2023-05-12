using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig104 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumaratorDegers",
                columns: table => new
                {
                    NumaratorDegerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SimdikiDeger9 = table.Column<int>(type: "integer", nullable: false),
                    NumaratorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumaratorDegers", x => x.NumaratorDegerId);
                    table.ForeignKey(
                        name: "FK_NumaratorDegers_Numarators_NumaratorId",
                        column: x => x.NumaratorId,
                        principalTable: "Numarators",
                        principalColumn: "NumaratorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumaratorDegers_NumaratorId",
                table: "NumaratorDegers",
                column: "NumaratorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumaratorDegers");
        }
    }
}
