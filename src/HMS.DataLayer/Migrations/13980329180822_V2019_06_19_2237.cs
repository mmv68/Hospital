using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DataLayer.Migrations
{
    public partial class V2019_06_19_2237 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrithPlaceSectionId",
                schema: "hms",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrithPlaceTownshipId",
                schema: "hms",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BrithPlaceSectionId",
                schema: "hms",
                table: "Persons",
                column: "BrithPlaceSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BrithPlaceTownshipId",
                schema: "hms",
                table: "Persons",
                column: "BrithPlaceTownshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_BaseInformations_BrithPlaceSectionId",
                schema: "hms",
                table: "Persons",
                column: "BrithPlaceSectionId",
                principalSchema: "hms",
                principalTable: "BaseInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_BaseInformations_BrithPlaceTownshipId",
                schema: "hms",
                table: "Persons",
                column: "BrithPlaceTownshipId",
                principalSchema: "hms",
                principalTable: "BaseInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_BaseInformations_BrithPlaceSectionId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_BaseInformations_BrithPlaceTownshipId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_BrithPlaceSectionId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_BrithPlaceTownshipId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BrithPlaceSectionId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BrithPlaceTownshipId",
                schema: "hms",
                table: "Persons");
        }
    }
}
