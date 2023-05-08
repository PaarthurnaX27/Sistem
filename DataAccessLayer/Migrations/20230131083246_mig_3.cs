using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caris_BagliSektors_BagliSektorId",
                table: "Caris");

            migrationBuilder.AlterColumn<int>(
                name: "BagliSektorId",
                table: "Caris",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Caris_BagliSektors_BagliSektorId",
                table: "Caris",
                column: "BagliSektorId",
                principalTable: "BagliSektors",
                principalColumn: "BagliSektorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caris_BagliSektors_BagliSektorId",
                table: "Caris");

            migrationBuilder.AlterColumn<int>(
                name: "BagliSektorId",
                table: "Caris",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Caris_BagliSektors_BagliSektorId",
                table: "Caris",
                column: "BagliSektorId",
                principalTable: "BagliSektors",
                principalColumn: "BagliSektorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
