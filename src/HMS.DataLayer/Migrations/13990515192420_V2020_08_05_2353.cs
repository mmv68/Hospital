using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DataLayer.Migrations
{
    public partial class V2020_08_05_2353 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "hms",
                table: "Structures",
                nullable: false,
                oldClrType: typeof(int))
                .OldAn notation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);*/

            migrationBuilder.CreateTable(
                name: "PersonPayment",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    CardNumber = table.Column<string>(type: "varchar(16)", nullable: true),
                    ShabaNumber = table.Column<string>(type: "varchar(26)", nullable: true),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsImported = table.Column<bool>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonPayment_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "hms",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPeyment",
                schema: "hms",
                table: "PersonPayment",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPayment_PersonId",
                schema: "hms",
                table: "PersonPayment",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPayment",
                schema: "hms");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "hms",
                table: "Structures",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
