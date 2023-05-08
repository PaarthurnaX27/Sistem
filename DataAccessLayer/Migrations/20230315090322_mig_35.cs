using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig35 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalismaDurumu",
                table: "TempCariPersonels");

            migrationBuilder.DropColumn(
                name: "CalismaDurumu",
                table: "CariPersonels");

            migrationBuilder.AddColumn<int>(
                name: "CalismaDurumuId",
                table: "TempCariPersonels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CalismaDurumuId",
                table: "CariPersonels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TempCariPersonels_CalismaDurumuId",
                table: "TempCariPersonels",
                column: "CalismaDurumuId");

            migrationBuilder.CreateIndex(
                name: "IX_CariPersonels_CalismaDurumuId",
                table: "CariPersonels",
                column: "CalismaDurumuId");

            migrationBuilder.AddForeignKey(
                name: "FK_CariPersonels_CalismaDurumus_CalismaDurumuId",
                table: "CariPersonels",
                column: "CalismaDurumuId",
                principalTable: "CalismaDurumus",
                principalColumn: "CalismaDurumuId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TempCariPersonels_CalismaDurumus_CalismaDurumuId",
                table: "TempCariPersonels",
                column: "CalismaDurumuId",
                principalTable: "CalismaDurumus",
                principalColumn: "CalismaDurumuId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CariPersonels_CalismaDurumus_CalismaDurumuId",
                table: "CariPersonels");

            migrationBuilder.DropForeignKey(
                name: "FK_TempCariPersonels_CalismaDurumus_CalismaDurumuId",
                table: "TempCariPersonels");

            migrationBuilder.DropIndex(
                name: "IX_TempCariPersonels_CalismaDurumuId",
                table: "TempCariPersonels");

            migrationBuilder.DropIndex(
                name: "IX_CariPersonels_CalismaDurumuId",
                table: "CariPersonels");

            migrationBuilder.DropColumn(
                name: "CalismaDurumuId",
                table: "TempCariPersonels");

            migrationBuilder.DropColumn(
                name: "CalismaDurumuId",
                table: "CariPersonels");

            migrationBuilder.AddColumn<bool>(
                name: "CalismaDurumu",
                table: "TempCariPersonels",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CalismaDurumu",
                table: "CariPersonels",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
