using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig43 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServisBilgis_ServisSeklis_ServisSekliId",
                table: "ServisBilgis");

            migrationBuilder.DropIndex(
                name: "IX_ServisBilgis_ServisSekliId",
                table: "ServisBilgis");

            migrationBuilder.DropColumn(
                name: "ServisSekliId",
                table: "ServisBilgis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServisSekliId",
                table: "ServisBilgis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServisBilgis_ServisSekliId",
                table: "ServisBilgis",
                column: "ServisSekliId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServisBilgis_ServisSeklis_ServisSekliId",
                table: "ServisBilgis",
                column: "ServisSekliId",
                principalTable: "ServisSeklis",
                principalColumn: "ServisSekliId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
