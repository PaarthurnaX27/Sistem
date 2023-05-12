using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParcaTipi",
                table: "Numarators");

            migrationBuilder.RenameColumn(
                name: "Yil",
                table: "Numarators",
                newName: "Karakter5");

            migrationBuilder.RenameColumn(
                name: "YenilemeParcalari",
                table: "Numarators",
                newName: "Karakter4");

            migrationBuilder.RenameColumn(
                name: "Gun",
                table: "Numarators",
                newName: "Karakter3");

            migrationBuilder.RenameColumn(
                name: "Ay",
                table: "Numarators",
                newName: "Karakter2");

            migrationBuilder.AddColumn<string>(
                name: "Karakter1",
                table: "Numarators",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sira1",
                table: "Numarators",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sira2",
                table: "Numarators",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sira3",
                table: "Numarators",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sira4",
                table: "Numarators",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sira5",
                table: "Numarators",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sira6",
                table: "Numarators",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Karakter1",
                table: "Numarators");

            migrationBuilder.DropColumn(
                name: "Sira1",
                table: "Numarators");

            migrationBuilder.DropColumn(
                name: "Sira2",
                table: "Numarators");

            migrationBuilder.DropColumn(
                name: "Sira3",
                table: "Numarators");

            migrationBuilder.DropColumn(
                name: "Sira4",
                table: "Numarators");

            migrationBuilder.DropColumn(
                name: "Sira5",
                table: "Numarators");

            migrationBuilder.DropColumn(
                name: "Sira6",
                table: "Numarators");

            migrationBuilder.RenameColumn(
                name: "Karakter5",
                table: "Numarators",
                newName: "Yil");

            migrationBuilder.RenameColumn(
                name: "Karakter4",
                table: "Numarators",
                newName: "YenilemeParcalari");

            migrationBuilder.RenameColumn(
                name: "Karakter3",
                table: "Numarators",
                newName: "Gun");

            migrationBuilder.RenameColumn(
                name: "Karakter2",
                table: "Numarators",
                newName: "Ay");

            migrationBuilder.AddColumn<int>(
                name: "ParcaTipi",
                table: "Numarators",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
