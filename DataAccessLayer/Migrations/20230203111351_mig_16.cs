using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caris_Unvans_UnvanId",
                table: "Caris");

            migrationBuilder.DropIndex(
                name: "IX_Caris_UnvanId",
                table: "Caris");

            migrationBuilder.DropColumn(
                name: "UnvanId",
                table: "Caris");

            migrationBuilder.AddColumn<string>(
                name: "CariAdi",
                table: "Caris",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CariAdi",
                table: "Caris");

            migrationBuilder.AddColumn<int>(
                name: "UnvanId",
                table: "Caris",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Caris_UnvanId",
                table: "Caris",
                column: "UnvanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Caris_Unvans_UnvanId",
                table: "Caris",
                column: "UnvanId",
                principalTable: "Unvans",
                principalColumn: "UnvanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
