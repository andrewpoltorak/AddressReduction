using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressReduction.Migrations
{
    public partial class ChangeFieldTypeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "Address",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
