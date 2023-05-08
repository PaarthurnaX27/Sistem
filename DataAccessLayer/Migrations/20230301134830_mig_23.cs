using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CalismaDurumu",
                table: "CariPersonels",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DepartmanId",
                table: "CariPersonels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PozisyonId",
                table: "CariPersonels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SerivsMailGonder",
                table: "CariPersonels",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServisFaturaGonder",
                table: "CariPersonels",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UnvanId",
                table: "CariPersonels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CariPersonels_DepartmanId",
                table: "CariPersonels",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_CariPersonels_PozisyonId",
                table: "CariPersonels",
                column: "PozisyonId");

            migrationBuilder.CreateIndex(
                name: "IX_CariPersonels_UnvanId",
                table: "CariPersonels",
                column: "UnvanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CariPersonels_Departmans_DepartmanId",
                table: "CariPersonels",
                column: "DepartmanId",
                principalTable: "Departmans",
                principalColumn: "DepartmanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CariPersonels_Pozisyons_PozisyonId",
                table: "CariPersonels",
                column: "PozisyonId",
                principalTable: "Pozisyons",
                principalColumn: "PozisyonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CariPersonels_Unvans_UnvanId",
                table: "CariPersonels",
                column: "UnvanId",
                principalTable: "Unvans",
                principalColumn: "UnvanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CariPersonels_Departmans_DepartmanId",
                table: "CariPersonels");

            migrationBuilder.DropForeignKey(
                name: "FK_CariPersonels_Pozisyons_PozisyonId",
                table: "CariPersonels");

            migrationBuilder.DropForeignKey(
                name: "FK_CariPersonels_Unvans_UnvanId",
                table: "CariPersonels");

            migrationBuilder.DropIndex(
                name: "IX_CariPersonels_DepartmanId",
                table: "CariPersonels");

            migrationBuilder.DropIndex(
                name: "IX_CariPersonels_PozisyonId",
                table: "CariPersonels");

            migrationBuilder.DropIndex(
                name: "IX_CariPersonels_UnvanId",
                table: "CariPersonels");

            migrationBuilder.DropColumn(
                name: "CalismaDurumu",
                table: "CariPersonels");

            migrationBuilder.DropColumn(
                name: "DepartmanId",
                table: "CariPersonels");

            migrationBuilder.DropColumn(
                name: "PozisyonId",
                table: "CariPersonels");

            migrationBuilder.DropColumn(
                name: "SerivsMailGonder",
                table: "CariPersonels");

            migrationBuilder.DropColumn(
                name: "ServisFaturaGonder",
                table: "CariPersonels");

            migrationBuilder.DropColumn(
                name: "UnvanId",
                table: "CariPersonels");
        }
    }
}
