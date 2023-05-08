using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Departmans_DepartmanId",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Personels_DepartmanId",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "DepartmanId",
                table: "Personels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmanId",
                table: "Personels",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personels_DepartmanId",
                table: "Personels",
                column: "DepartmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Departmans_DepartmanId",
                table: "Personels",
                column: "DepartmanId",
                principalTable: "Departmans",
                principalColumn: "DepartmanId");
        }
    }
}
