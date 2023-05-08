using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig97 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CariId",
                table: "ProjeIceriks");

            migrationBuilder.AddColumn<int>(
                name: "CariId",
                table: "ServisProjeIceriks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CariId",
                table: "ServisProjeIceriks");

            migrationBuilder.AddColumn<int>(
                name: "CariId",
                table: "ProjeIceriks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
