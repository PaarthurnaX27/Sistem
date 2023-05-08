using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CariId",
                table: "TempCariPersonels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CariId",
                table: "CariPersonels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TempCariPersonels_CariId",
                table: "TempCariPersonels",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_CariPersonels_CariId",
                table: "CariPersonels",
                column: "CariId");

            migrationBuilder.AddForeignKey(
                name: "FK_CariPersonels_Caris_CariId",
                table: "CariPersonels",
                column: "CariId",
                principalTable: "Caris",
                principalColumn: "CariId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TempCariPersonels_Caris_CariId",
                table: "TempCariPersonels",
                column: "CariId",
                principalTable: "Caris",
                principalColumn: "CariId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CariPersonels_Caris_CariId",
                table: "CariPersonels");

            migrationBuilder.DropForeignKey(
                name: "FK_TempCariPersonels_Caris_CariId",
                table: "TempCariPersonels");

            migrationBuilder.DropIndex(
                name: "IX_TempCariPersonels_CariId",
                table: "TempCariPersonels");

            migrationBuilder.DropIndex(
                name: "IX_CariPersonels_CariId",
                table: "CariPersonels");

            migrationBuilder.DropColumn(
                name: "CariId",
                table: "TempCariPersonels");

            migrationBuilder.DropColumn(
                name: "CariId",
                table: "CariPersonels");
        }
    }
}
