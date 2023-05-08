using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig70 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "TempDanismans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "TempDanismans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "TempDanismans",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "TempDanismans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "TempDanismans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "TempDanismans");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "TempDanismans");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "TempDanismans");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "TempDanismans");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "TempDanismans");
        }
    }
}
