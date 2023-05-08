using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig60 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "TempServisKalems");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "TempServisKalems");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "TempServisKalems");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "TempServisBilgis");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "TempServisBilgis");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "TempServisBilgis");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "ServisKalems");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "ServisKalems");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "ServisKalems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "TempServisKalems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "TempServisKalems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "TempServisKalems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "TempServisBilgis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "TempServisBilgis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "TempServisBilgis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "ServisKalems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "ServisKalems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "ServisKalems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
