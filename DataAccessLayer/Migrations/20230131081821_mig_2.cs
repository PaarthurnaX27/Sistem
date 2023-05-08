using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caris_AnaSektors_AnaSektorId",
                table: "Caris");

            migrationBuilder.DropColumn(
                name: "Sektor",
                table: "Caris");

            migrationBuilder.AlterColumn<int>(
                name: "AnaSektorId",
                table: "Caris",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Caris_AnaSektors_AnaSektorId",
                table: "Caris",
                column: "AnaSektorId",
                principalTable: "AnaSektors",
                principalColumn: "AnaSektorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caris_AnaSektors_AnaSektorId",
                table: "Caris");

            migrationBuilder.AlterColumn<int>(
                name: "AnaSektorId",
                table: "Caris",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Sektor",
                table: "Caris",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Caris_AnaSektors_AnaSektorId",
                table: "Caris",
                column: "AnaSektorId",
                principalTable: "AnaSektors",
                principalColumn: "AnaSektorId");
        }
    }
}
