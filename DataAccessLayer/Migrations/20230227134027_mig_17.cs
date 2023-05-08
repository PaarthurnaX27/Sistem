using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "Personels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "Personels",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "Personels",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "Personels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "Personels",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "IlgiliKisilers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "IlgiliKisilers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "IlgiliKisilers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "IlgiliKisilers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "IlgiliKisilers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "IlgiliKisilers");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "IlgiliKisilers");
        }
    }
}
