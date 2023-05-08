using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CalismaDurumu",
                table: "Personels",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmanId",
                table: "Personels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PozisyonId",
                table: "Personels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnvanId",
                table: "Personels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_DepartmanId",
                table: "Personels",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_PozisyonId",
                table: "Personels",
                column: "PozisyonId");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_UnvanId",
                table: "Personels",
                column: "UnvanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Departmans_DepartmanId",
                table: "Personels",
                column: "DepartmanId",
                principalTable: "Departmans",
                principalColumn: "DepartmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Pozisyons_PozisyonId",
                table: "Personels",
                column: "PozisyonId",
                principalTable: "Pozisyons",
                principalColumn: "PozisyonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Unvans_UnvanId",
                table: "Personels",
                column: "UnvanId",
                principalTable: "Unvans",
                principalColumn: "UnvanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Departmans_DepartmanId",
                table: "Personels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Pozisyons_PozisyonId",
                table: "Personels");

            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Unvans_UnvanId",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_DepartmanId",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_PozisyonId",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_UnvanId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "CalismaDurumu",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "DepartmanId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "PozisyonId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "UnvanId",
                table: "Personels");
        }
    }
}
