using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig52 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempServisKalems_ServisBilgis_ServisBilgiServisId",
                table: "TempServisKalems");

            migrationBuilder.DropIndex(
                name: "IX_TempServisKalems_ServisBilgiServisId",
                table: "TempServisKalems");

            migrationBuilder.DropColumn(
                name: "ServisBilgiServisId",
                table: "TempServisKalems");

            migrationBuilder.DropColumn(
                name: "ServisId",
                table: "TempServisKalems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServisBilgiServisId",
                table: "TempServisKalems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServisId",
                table: "TempServisKalems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TempServisKalems_ServisBilgiServisId",
                table: "TempServisKalems",
                column: "ServisBilgiServisId");

            migrationBuilder.AddForeignKey(
                name: "FK_TempServisKalems_ServisBilgis_ServisBilgiServisId",
                table: "TempServisKalems",
                column: "ServisBilgiServisId",
                principalTable: "ServisBilgis",
                principalColumn: "ServisId");
        }
    }
}
