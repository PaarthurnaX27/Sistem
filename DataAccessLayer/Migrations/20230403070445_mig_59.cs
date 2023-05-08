using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig59 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "TempServisKalems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "TempServisKalems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "TempServisKalems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "TempServisBilgis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "TempServisBilgis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "TempServisBilgis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "ServisKalems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "ServisKalems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "ServisKalems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "TempServisKalems");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "TempServisKalems");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "TempServisKalems");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "TempServisKalems");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "TempServisKalems");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "TempServisBilgis");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "TempServisBilgis");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "TempServisBilgis");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "TempServisBilgis");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "TempServisBilgis");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "ServisKalems");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "ServisKalems");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "ServisKalems");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "ServisKalems");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "ServisKalems");
        }
    }
}
