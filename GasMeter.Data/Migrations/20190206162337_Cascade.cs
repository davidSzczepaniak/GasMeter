using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GasMeter.Data.Migrations
{
    public partial class Cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measures_CapturedImages_ImageId",
                table: "Measures");

            migrationBuilder.DropIndex(
                name: "IX_Measures_ImageId",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Measures");

            migrationBuilder.AddForeignKey(
                name: "FK_Measures_CapturedImages_Id",
                table: "Measures",
                column: "Id",
                principalTable: "CapturedImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measures_CapturedImages_Id",
                table: "Measures");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Measures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measures_ImageId",
                table: "Measures",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measures_CapturedImages_ImageId",
                table: "Measures",
                column: "ImageId",
                principalTable: "CapturedImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
