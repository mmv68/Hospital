using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DataLayer.Migrations
{
    public partial class V2019_06_17_2044 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Relation",
                schema: "hms",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                schema: "hms",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RelationId",
                schema: "hms",
                table: "Persons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ParentId",
                schema: "hms",
                table: "Persons",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RelationId",
                schema: "hms",
                table: "Persons",
                column: "RelationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Persons_ParentId",
                schema: "hms",
                table: "Persons",
                column: "ParentId",
                principalSchema: "hms",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_BaseInformations_RelationId",
                schema: "hms",
                table: "Persons",
                column: "RelationId",
                principalSchema: "hms",
                principalTable: "BaseInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Persons_ParentId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_BaseInformations_RelationId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ParentId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_RelationId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "RelationId",
                schema: "hms",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                schema: "hms",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Relation",
                schema: "hms",
                table: "Persons",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
