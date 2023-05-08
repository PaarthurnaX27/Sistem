using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig39 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServisDepartmanId",
                table: "Moduls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Moduls_ServisDepartmanId",
                table: "Moduls",
                column: "ServisDepartmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moduls_ServisDepartmans_ServisDepartmanId",
                table: "Moduls",
                column: "ServisDepartmanId",
                principalTable: "ServisDepartmans",
                principalColumn: "ServisDepartmanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moduls_ServisDepartmans_ServisDepartmanId",
                table: "Moduls");

            migrationBuilder.DropIndex(
                name: "IX_Moduls_ServisDepartmanId",
                table: "Moduls");

            migrationBuilder.DropColumn(
                name: "ServisDepartmanId",
                table: "Moduls");
        }
    }
}
