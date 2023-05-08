using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BagliSektors_AnaSektors_AnaSektorId",
                table: "BagliSektors");

            migrationBuilder.AlterColumn<int>(
                name: "AnaSektorId",
                table: "BagliSektors",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_BagliSektors_AnaSektors_AnaSektorId",
                table: "BagliSektors",
                column: "AnaSektorId",
                principalTable: "AnaSektors",
                principalColumn: "AnaSektorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BagliSektors_AnaSektors_AnaSektorId",
                table: "BagliSektors");

            migrationBuilder.AlterColumn<int>(
                name: "AnaSektorId",
                table: "BagliSektors",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BagliSektors_AnaSektors_AnaSektorId",
                table: "BagliSektors",
                column: "AnaSektorId",
                principalTable: "AnaSektors",
                principalColumn: "AnaSektorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
