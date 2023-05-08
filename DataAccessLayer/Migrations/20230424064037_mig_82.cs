using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig82 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempServisProjeIceriks_Caris_CariId",
                table: "TempServisProjeIceriks");

            migrationBuilder.DropIndex(
                name: "IX_TempServisProjeIceriks_CariId",
                table: "TempServisProjeIceriks");

            migrationBuilder.DropColumn(
                name: "CariId",
                table: "TempServisProjeIceriks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CariId",
                table: "TempServisProjeIceriks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TempServisProjeIceriks_CariId",
                table: "TempServisProjeIceriks",
                column: "CariId");

            migrationBuilder.AddForeignKey(
                name: "FK_TempServisProjeIceriks_Caris_CariId",
                table: "TempServisProjeIceriks",
                column: "CariId",
                principalTable: "Caris",
                principalColumn: "CariId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
