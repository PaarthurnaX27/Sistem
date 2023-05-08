using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig80 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServisProjeIcerikId",
                table: "TempServisProjeIceriks",
                newName: "TempServisProjeIcerikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TempServisProjeIcerikId",
                table: "TempServisProjeIceriks",
                newName: "ServisProjeIcerikId");
        }
    }
}
