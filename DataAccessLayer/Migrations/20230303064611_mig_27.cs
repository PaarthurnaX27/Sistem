using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IlgiliKisilers_Pozisyons_PozisyonId",
                table: "IlgiliKisilers");

            migrationBuilder.DropIndex(
                name: "IX_IlgiliKisilers_PozisyonId",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "CalismaDurumu",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "DepartmanId",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "IlgiliKisiKodu",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "PozisyonId",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "SerivsMailGonder",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "ServisFaturaGonder",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "UnvanId",
                table: "IlgiliKisilers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CalismaDurumu",
                table: "IlgiliKisilers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DepartmanId",
                table: "IlgiliKisilers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IlgiliKisiKodu",
                table: "IlgiliKisilers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PozisyonId",
                table: "IlgiliKisilers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SerivsMailGonder",
                table: "IlgiliKisilers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ServisFaturaGonder",
                table: "IlgiliKisilers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UnvanId",
                table: "IlgiliKisilers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IlgiliKisilers_PozisyonId",
                table: "IlgiliKisilers",
                column: "PozisyonId");

            migrationBuilder.AddForeignKey(
                name: "FK_IlgiliKisilers_Pozisyons_PozisyonId",
                table: "IlgiliKisilers",
                column: "PozisyonId",
                principalTable: "Pozisyons",
                principalColumn: "PozisyonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
