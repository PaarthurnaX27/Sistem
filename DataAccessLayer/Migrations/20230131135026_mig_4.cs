using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "Unvans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "Unvans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "Unvans",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "Unvans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "Unvans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "Ulkes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "Ulkes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "Ulkes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "Ulkes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "Ulkes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "Pozisyons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "Pozisyons",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "Pozisyons",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "Pozisyons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "Pozisyons",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "ParaBirimis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "ParaBirimis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "ParaBirimis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "ParaBirimis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "ParaBirimis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "Ilces",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "Ilces",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "Ilces",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "Ilces",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "Ilces",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "Departmans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "Departmans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "Departmans",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "Departmans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "Departmans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "Cinsiyets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "Cinsiyets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "Cinsiyets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "Cinsiyets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "Cinsiyets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "CariTipis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "CariTipis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "CariTipis",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "CariTipis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "CariTipis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "Caris",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "Caris",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "Caris",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "Caris",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "Caris",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "CariDurums",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "CariDurums",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "CariDurums",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "CariDurums",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "CariDurums",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "BagliSektors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "BagliSektors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "BagliSektors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "BagliSektors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "BagliSektors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Olusturan",
                table: "AnaSektors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OlusturulmaTarih",
                table: "AnaSektors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Silindi",
                table: "AnaSektors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SonDegistiren",
                table: "AnaSektors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonDegistirmeTarih",
                table: "AnaSektors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "Unvans");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "Unvans");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "Unvans");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "Unvans");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "Unvans");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "Ulkes");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "Ulkes");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "Ulkes");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "Ulkes");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "Ulkes");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "Pozisyons");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "Pozisyons");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "Pozisyons");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "Pozisyons");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "Pozisyons");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "ParaBirimis");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "ParaBirimis");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "ParaBirimis");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "ParaBirimis");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "ParaBirimis");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "Ilces");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "Ilces");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "Ilces");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "Ilces");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "Ilces");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "Departmans");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "Departmans");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "Departmans");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "Departmans");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "Departmans");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "Cinsiyets");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "Cinsiyets");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "Cinsiyets");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "Cinsiyets");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "Cinsiyets");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "CariTipis");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "CariTipis");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "CariTipis");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "CariTipis");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "CariTipis");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "Caris");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "Caris");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "Caris");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "Caris");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "Caris");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "CariDurums");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "CariDurums");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "CariDurums");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "CariDurums");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "CariDurums");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "BagliSektors");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "BagliSektors");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "BagliSektors");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "BagliSektors");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "BagliSektors");

            migrationBuilder.DropColumn(
                name: "Olusturan",
                table: "AnaSektors");

            migrationBuilder.DropColumn(
                name: "OlusturulmaTarih",
                table: "AnaSektors");

            migrationBuilder.DropColumn(
                name: "Silindi",
                table: "AnaSektors");

            migrationBuilder.DropColumn(
                name: "SonDegistiren",
                table: "AnaSektors");

            migrationBuilder.DropColumn(
                name: "SonDegistirmeTarih",
                table: "AnaSektors");
        }
    }
}
