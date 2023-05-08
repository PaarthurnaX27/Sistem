using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig85 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempServisProjeIcerikNo",
                table: "TempServisProjeIceriks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServisProjeIcerikNo",
                table: "ServisProjeIceriks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempServisProjeIcerikNo",
                table: "TempServisProjeIceriks");

            migrationBuilder.DropColumn(
                name: "ServisProjeIcerikNo",
                table: "ServisProjeIceriks");
        }
    }
}
