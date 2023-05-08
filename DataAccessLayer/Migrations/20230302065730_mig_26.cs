using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "UnvanId",
                table: "Personels",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PozisyonId",
                table: "Personels",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmanId",
                table: "Personels",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CalismaDurumu",
                table: "Personels",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Departmans_DepartmanId",
                table: "Personels",
                column: "DepartmanId",
                principalTable: "Departmans",
                principalColumn: "DepartmanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Pozisyons_PozisyonId",
                table: "Personels",
                column: "PozisyonId",
                principalTable: "Pozisyons",
                principalColumn: "PozisyonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Unvans_UnvanId",
                table: "Personels",
                column: "UnvanId",
                principalTable: "Unvans",
                principalColumn: "UnvanId",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AlterColumn<int>(
                name: "UnvanId",
                table: "Personels",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PozisyonId",
                table: "Personels",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmanId",
                table: "Personels",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "CalismaDurumu",
                table: "Personels",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

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
    }
}
