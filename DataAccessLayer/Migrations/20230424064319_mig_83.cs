using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig83 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempServisProjeIceriks_Projes_ProjeId",
                table: "TempServisProjeIceriks");

            migrationBuilder.DropIndex(
                name: "IX_TempServisProjeIceriks_ProjeId",
                table: "TempServisProjeIceriks");

            migrationBuilder.DropColumn(
                name: "ProjeId",
                table: "TempServisProjeIceriks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjeId",
                table: "TempServisProjeIceriks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TempServisProjeIceriks_ProjeId",
                table: "TempServisProjeIceriks",
                column: "ProjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TempServisProjeIceriks_Projes_ProjeId",
                table: "TempServisProjeIceriks",
                column: "ProjeId",
                principalTable: "Projes",
                principalColumn: "ProjeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
