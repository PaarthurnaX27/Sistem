using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig95 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FaturalamaPeriyoduId",
                table: "Projes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projes_FaturalamaPeriyoduId",
                table: "Projes",
                column: "FaturalamaPeriyoduId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projes_FaturalamaPeriyodus_FaturalamaPeriyoduId",
                table: "Projes",
                column: "FaturalamaPeriyoduId",
                principalTable: "FaturalamaPeriyodus",
                principalColumn: "FaturalamaPeriyoduId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projes_FaturalamaPeriyodus_FaturalamaPeriyoduId",
                table: "Projes");

            migrationBuilder.DropIndex(
                name: "IX_Projes_FaturalamaPeriyoduId",
                table: "Projes");

            migrationBuilder.DropColumn(
                name: "FaturalamaPeriyoduId",
                table: "Projes");
        }
    }
}
