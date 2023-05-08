using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnaSektorId",
                table: "BagliSektors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BagliSektors_AnaSektorId",
                table: "BagliSektors",
                column: "AnaSektorId");

            migrationBuilder.AddForeignKey(
                name: "FK_BagliSektors_AnaSektors_AnaSektorId",
                table: "BagliSektors",
                column: "AnaSektorId",
                principalTable: "AnaSektors",
                principalColumn: "AnaSektorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BagliSektors_AnaSektors_AnaSektorId",
                table: "BagliSektors");

            migrationBuilder.DropIndex(
                name: "IX_BagliSektors_AnaSektorId",
                table: "BagliSektors");

            migrationBuilder.DropColumn(
                name: "AnaSektorId",
                table: "BagliSektors");
        }
    }
}
