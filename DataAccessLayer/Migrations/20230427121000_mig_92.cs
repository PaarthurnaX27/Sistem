using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig92 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempFaturaMails_FaturalamaPeriyodus_FaturalamaPeriyoduId",
                table: "TempFaturaMails");

            migrationBuilder.DropIndex(
                name: "IX_TempFaturaMails_FaturalamaPeriyoduId",
                table: "TempFaturaMails");

            migrationBuilder.DropColumn(
                name: "FaturalamaPeriyoduId",
                table: "TempFaturaMails");

            migrationBuilder.AddColumn<int>(
                name: "FaturalamaPeriyoduId",
                table: "TempCariPrograms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TempCariPrograms_FaturalamaPeriyoduId",
                table: "TempCariPrograms",
                column: "FaturalamaPeriyoduId");

            migrationBuilder.AddForeignKey(
                name: "FK_TempCariPrograms_FaturalamaPeriyodus_FaturalamaPeriyoduId",
                table: "TempCariPrograms",
                column: "FaturalamaPeriyoduId",
                principalTable: "FaturalamaPeriyodus",
                principalColumn: "FaturalamaPeriyoduId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TempCariPrograms_FaturalamaPeriyodus_FaturalamaPeriyoduId",
                table: "TempCariPrograms");

            migrationBuilder.DropIndex(
                name: "IX_TempCariPrograms_FaturalamaPeriyoduId",
                table: "TempCariPrograms");

            migrationBuilder.DropColumn(
                name: "FaturalamaPeriyoduId",
                table: "TempCariPrograms");

            migrationBuilder.AddColumn<int>(
                name: "FaturalamaPeriyoduId",
                table: "TempFaturaMails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TempFaturaMails_FaturalamaPeriyoduId",
                table: "TempFaturaMails",
                column: "FaturalamaPeriyoduId");

            migrationBuilder.AddForeignKey(
                name: "FK_TempFaturaMails_FaturalamaPeriyodus_FaturalamaPeriyoduId",
                table: "TempFaturaMails",
                column: "FaturalamaPeriyoduId",
                principalTable: "FaturalamaPeriyodus",
                principalColumn: "FaturalamaPeriyoduId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
