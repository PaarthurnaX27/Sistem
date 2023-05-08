using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig75 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempFiyatLists_ParaBirimis_ParaBirimiId",
                table: "TempFiyatLists");

            migrationBuilder.AlterColumn<int>(
                name: "ParaBirimiId",
                table: "TempFiyatLists",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GecerlilikTarihBitis",
                table: "TempFiyatLists",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GecerlilikTarihBaslangic",
                table: "TempFiyatLists",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Fiyat",
                table: "TempFiyatLists",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_TempFiyatLists_ParaBirimis_ParaBirimiId",
                table: "TempFiyatLists",
                column: "ParaBirimiId",
                principalTable: "ParaBirimis",
                principalColumn: "ParaBirimiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempFiyatLists_ParaBirimis_ParaBirimiId",
                table: "TempFiyatLists");

            migrationBuilder.AlterColumn<int>(
                name: "ParaBirimiId",
                table: "TempFiyatLists",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GecerlilikTarihBitis",
                table: "TempFiyatLists",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GecerlilikTarihBaslangic",
                table: "TempFiyatLists",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fiyat",
                table: "TempFiyatLists",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TempFiyatLists_ParaBirimis_ParaBirimiId",
                table: "TempFiyatLists",
                column: "ParaBirimiId",
                principalTable: "ParaBirimis",
                principalColumn: "ParaBirimiId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
