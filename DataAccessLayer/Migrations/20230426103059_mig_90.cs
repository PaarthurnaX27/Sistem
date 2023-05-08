using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig90 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Projes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgramsProgramId",
                table: "Projes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projes_ProgramsProgramId",
                table: "Projes",
                column: "ProgramsProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projes_Programs_ProgramsProgramId",
                table: "Projes",
                column: "ProgramsProgramId",
                principalTable: "Programs",
                principalColumn: "ProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projes_Programs_ProgramsProgramId",
                table: "Projes");

            migrationBuilder.DropIndex(
                name: "IX_Projes_ProgramsProgramId",
                table: "Projes");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Projes");

            migrationBuilder.DropColumn(
                name: "ProgramsProgramId",
                table: "Projes");
        }
    }
}
