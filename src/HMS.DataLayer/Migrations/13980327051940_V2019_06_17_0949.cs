using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DataLayer.Migrations
{
    public partial class V2019_06_17_0949 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "MaritalStatusDate",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Nationality",
                schema: "hms",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "IdentitySerial",
                schema: "hms",
                table: "Persons",
                type: "varchar(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentitySeries",
                schema: "hms",
                table: "Persons",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "IdentitySeriesNumber",
                schema: "hms",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                schema: "hms",
                table: "Persons",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "Sex",
                schema: "hms",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentitySerial",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdentitySeries",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IdentitySeriesNumber",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "MotherName",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Sex",
                schema: "hms",
                table: "Persons");

            migrationBuilder.AddColumn<byte>(
                name: "MaritalStatus",
                schema: "hms",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaritalStatusDate",
                schema: "hms",
                table: "Persons",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Nationality",
                schema: "hms",
                table: "Persons",
                nullable: true);
        }
    }
}
