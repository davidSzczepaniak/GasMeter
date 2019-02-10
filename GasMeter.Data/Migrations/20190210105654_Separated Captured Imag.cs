using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GasMeter.Data.Migrations
{
    public partial class SeparatedCapturedImag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTaken",
                table: "CapturedImages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTaken",
                table: "CapturedImages");
        }
    }
}
