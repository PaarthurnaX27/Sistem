using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig58 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServisNo",
                table: "ServisKalems",
                newName: "ServisKalemNo");

            migrationBuilder.AddColumn<string>(
                name: "ServisKalemNo",
                table: "TempServisKalems",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServisKalemNo",
                table: "TempServisKalems");

            migrationBuilder.RenameColumn(
                name: "ServisKalemNo",
                table: "ServisKalems",
                newName: "ServisNo");
        }
    }
}
