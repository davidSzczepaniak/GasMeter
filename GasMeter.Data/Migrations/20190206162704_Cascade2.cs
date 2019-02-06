using Microsoft.EntityFrameworkCore.Migrations;

namespace GasMeter.Data.Migrations
{
    public partial class Cascade2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measures_CapturedImages_Id",
                table: "Measures");

            migrationBuilder.AddForeignKey(
                name: "FK_CapturedImages_Measures_Id",
                table: "CapturedImages",
                column: "Id",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapturedImages_Measures_Id",
                table: "CapturedImages");

            migrationBuilder.AddForeignKey(
                name: "FK_Measures_CapturedImages_Id",
                table: "Measures",
                column: "Id",
                principalTable: "CapturedImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
