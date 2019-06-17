using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DataLayer.Migrations
{
    public partial class V2019_06_17_1553 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                schema: "hms",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "Relation",
                schema: "hms",
                table: "Persons",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Relation",
                schema: "hms",
                table: "Persons");
        }
    }
}
