using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GasMeter.Data.Migrations
{
    public partial class ImageforeignkeyinMeasure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CapturedImages_Measures_Id",
                table: "CapturedImages");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Measures",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_CapturedImages_Measures_Id",
                table: "CapturedImages",
                column: "Id",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
