using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressReduction.Migrations
{
    public partial class ChangeFieldsNameAndType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Address",
                newName: "Clicked");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Address",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Clicked",
                table: "Address",
                newName: "Count");

            migrationBuilder.AddColumn<string>(
                name: "date",
                table: "Address",
                nullable: true);
        }
    }
}
