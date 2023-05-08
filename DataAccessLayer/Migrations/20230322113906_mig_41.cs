using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig41 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServisBilgiServisId",
                table: "ServisKalems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServisId",
                table: "ServisKalems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServisKalems_ServisBilgiServisId",
                table: "ServisKalems",
                column: "ServisBilgiServisId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServisKalems_ServisBilgis_ServisBilgiServisId",
                table: "ServisKalems",
                column: "ServisBilgiServisId",
                principalTable: "ServisBilgis",
                principalColumn: "ServisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServisKalems_ServisBilgis_ServisBilgiServisId",
                table: "ServisKalems");

            migrationBuilder.DropIndex(
                name: "IX_ServisKalems_ServisBilgiServisId",
                table: "ServisKalems");

            migrationBuilder.DropColumn(
                name: "ServisBilgiServisId",
                table: "ServisKalems");

            migrationBuilder.DropColumn(
                name: "ServisId",
                table: "ServisKalems");
        }
    }
}
