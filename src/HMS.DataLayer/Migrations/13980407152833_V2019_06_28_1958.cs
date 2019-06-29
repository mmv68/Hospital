using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DataLayer.Migrations
{
    public partial class V2019_06_28_1958 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonEducations",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    CertificateTypeId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true),
                    FieldStudyId = table.Column<int>(nullable: true),
                    UniversityType = table.Column<byte>(nullable: false),
                    UniversityName = table.Column<string>(maxLength: 50, nullable: true),
                    GraduatedDate = table.Column<DateTime>(type: "date", nullable: true),
                    Average = table.Column<decimal>(type: "decimal(4, 2)", nullable: true),
                    Applied = table.Column<bool>(nullable: true),
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
                    table.PrimaryKey("PK_PersonEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonEducations_BaseInformations_CertificateTypeId",
                        column: x => x.CertificateTypeId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonEducations_BaseInformations_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonEducations_BaseInformations_FieldStudyId",
                        column: x => x.FieldStudyId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonEducations_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "hms",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonLocations",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    ProvianceId = table.Column<int>(nullable: true),
                    TownshipId = table.Column<int>(nullable: true),
                    SectionId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    Addres = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(type: "varchar(11)", nullable: true),
                    Mobile = table.Column<string>(type: "varchar(11)", nullable: true),
                    PersonalEmail = table.Column<string>(nullable: true),
                    OrganizationEmail = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_PersonLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonLocations_BaseInformations_CityId",
                        column: x => x.CityId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonLocations_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "hms",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLocations_BaseInformations_ProvianceId",
                        column: x => x.ProvianceId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonLocations_BaseInformations_SectionId",
                        column: x => x.SectionId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonLocations_BaseInformations_TownshipId",
                        column: x => x.TownshipId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonMarriages",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    MarriageDivorce = table.Column<byte>(nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "date", nullable: true),
                    OfficeNumber = table.Column<string>(maxLength: 10, nullable: true),
                    RegisterNumber = table.Column<string>(maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_PersonMarriages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonMarriages_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "hms",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_CertificateTypeId",
                schema: "hms",
                table: "PersonEducations",
                column: "CertificateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_DepartmentId",
                schema: "hms",
                table: "PersonEducations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_FieldStudyId",
                schema: "hms",
                table: "PersonEducations",
                column: "FieldStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_PersonId",
                schema: "hms",
                table: "PersonEducations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducation",
                schema: "hms",
                table: "PersonEducations",
                column: "UniversityName");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLocations_CityId",
                schema: "hms",
                table: "PersonLocations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLocations_PersonId",
                schema: "hms",
                table: "PersonLocations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLocations_ProvianceId",
                schema: "hms",
                table: "PersonLocations",
                column: "ProvianceId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLocations_SectionId",
                schema: "hms",
                table: "PersonLocations",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLocations_TownshipId",
                schema: "hms",
                table: "PersonLocations",
                column: "TownshipId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonMarriages_PersonId",
                schema: "hms",
                table: "PersonMarriages",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonEducations",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "PersonLocations",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "PersonMarriages",
                schema: "hms");
        }
    }
}
