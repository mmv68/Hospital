using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HMS.DataLayer.Migrations
{
    public partial class V2019_07_05_2242 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hms");

            migrationBuilder.CreateTable(
                name: "AppDataProtectionKeys",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FriendlyName = table.Column<string>(nullable: true),
                    XmlData = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppLogItems",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    LogLevel = table.Column<string>(nullable: true),
                    Logger = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    StateJson = table.Column<string>(nullable: true),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsImported = table.Column<bool>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLogItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    RoleDescription = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppSqlCache",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 449, nullable: false),
                    Value = table.Column<byte[]>(nullable: false),
                    ExpiresAtTime = table.Column<DateTimeOffset>(nullable: false),
                    SlidingExpirationInSeconds = table.Column<long>(nullable: true),
                    AbsoluteExpiration = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSqlCache", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 450, nullable: true),
                    LastName = table.Column<string>(maxLength: 450, nullable: true),
                    PhotoFileName = table.Column<string>(maxLength: 450, nullable: true),
                    BirthDate = table.Column<DateTimeOffset>(nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    LastVisitDateTime = table.Column<DateTimeOffset>(nullable: true),
                    IsEmailPublic = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    CreatedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IsImported = table.Column<bool>(nullable: true),
                    ModifiedByBrowserName = table.Column<string>(maxLength: 1000, nullable: true),
                    ModifiedByIp = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedByUserId = table.Column<int>(nullable: true),
                    ModifiedDateTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseInformations",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<short>(nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_BaseInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseInformations_BaseInformations_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Structures",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 30, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 11, nullable: true),
                    Kousar = table.Column<string>(maxLength: 5, nullable: true),
                    Proviance = table.Column<byte>(nullable: true),
                    City = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
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
                    table.PrimaryKey("PK_Structures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Structures_Structures_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "hms",
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaims_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "hms",
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "hms",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                schema: "hms",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_AppUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AppUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "hms",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                schema: "hms",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "hms",
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "hms",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                schema: "hms",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_AppUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AppUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "hms",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserUsedPasswords",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HashedPassword = table.Column<string>(maxLength: 450, nullable: false),
                    UserId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_AppUserUsedPasswords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserUsedPasswords_AppUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "hms",
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 80, nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: false),
                    MotherName = table.Column<string>(maxLength: 50, nullable: false),
                    IdentityNumber = table.Column<string>(type: "varchar(10)", nullable: true),
                    IdentitySeries = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    IdentitySeriesNumber = table.Column<short>(nullable: true),
                    IdentitySerial = table.Column<string>(type: "varchar(6)", nullable: true),
                    NationalCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    BrithDate = table.Column<DateTime>(type: "date", nullable: true),
                    BrithPlaceProvianceId = table.Column<int>(nullable: true),
                    BrithPlaceTownshipId = table.Column<int>(nullable: true),
                    BrithPlaceSectionId = table.Column<int>(nullable: true),
                    BrithPlaceCityId = table.Column<int>(nullable: true),
                    Religion = table.Column<byte>(nullable: true),
                    Denomation = table.Column<byte>(nullable: true),
                    Sex = table.Column<byte>(nullable: true),
                    RelationId = table.Column<int>(nullable: true),
                    Timestamp = table.Column<byte[]>(maxLength: 8, rowVersion: true, nullable: true),
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
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_BaseInformations_BrithPlaceCityId",
                        column: x => x.BrithPlaceCityId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_BaseInformations_BrithPlaceProvianceId",
                        column: x => x.BrithPlaceProvianceId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_BaseInformations_BrithPlaceSectionId",
                        column: x => x.BrithPlaceSectionId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_BaseInformations_BrithPlaceTownshipId",
                        column: x => x.BrithPlaceTownshipId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_Persons_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "hms",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persons_BaseInformations_RelationId",
                        column: x => x.RelationId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonAdditionalInformations",
                schema: "hms",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    BloodGroup = table.Column<byte>(nullable: true),
                    HairColor = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    Weight = table.Column<short>(nullable: true),
                    Height = table.Column<short>(nullable: true),
                    ShoeSize = table.Column<short>(nullable: true),
                    Wrist = table.Column<short>(nullable: true),
                    ClothingSize = table.Column<short>(nullable: true),
                    CoverSize = table.Column<short>(nullable: true),
                    PantsSize = table.Column<short>(nullable: true),
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
                    table.PrimaryKey("PK_PersonAdditionalInformations", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_PersonAdditionalInformations_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "hms",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Personnel",
                schema: "hms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    StructureId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(type: "varchar(10)", nullable: true),
                    CardNumber = table.Column<string>(type: "varchar(10)", nullable: true),
                    ExportDate = table.Column<DateTime>(type: "date", nullable: true),
                    MembershipTypeId = table.Column<int>(nullable: true),
                    MembershipDate = table.Column<DateTime>(type: "date", nullable: true),
                    EntryDateCorps = table.Column<DateTime>(type: "date", nullable: true),
                    EntryDateHealthcare = table.Column<DateTime>(type: "date", nullable: true),
                    EntryDateTreatmentcenter = table.Column<DateTime>(type: "date", nullable: true),
                    TransferInDate = table.Column<DateTime>(type: "date", nullable: true),
                    TransferOutDate = table.Column<DateTime>(type: "date", nullable: true),
                    MilitaryBranchId = table.Column<int>(nullable: true),
                    DegreeApproved = table.Column<byte>(nullable: true),
                    DegreeSalary = table.Column<byte>(nullable: true),
                    Rating = table.Column<byte>(nullable: true),
                    ConditionId = table.Column<int>(nullable: true),
                    JobCode = table.Column<string>(type: "varchar(40)", nullable: true),
                    JobName = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Personnel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personnel_BaseInformations_ConditionId",
                        column: x => x.ConditionId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personnel_BaseInformations_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personnel_BaseInformations_MilitaryBranchId",
                        column: x => x.MilitaryBranchId,
                        principalSchema: "hms",
                        principalTable: "BaseInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personnel_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "hms",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnel_Structures_StructureId",
                        column: x => x.StructureId,
                        principalSchema: "hms",
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppDataProtectionKeys_FriendlyName",
                schema: "hms",
                table: "AppDataProtectionKeys",
                column: "FriendlyName",
                unique: true,
                filter: "[FriendlyName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_RoleId",
                schema: "hms",
                table: "AppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "hms",
                table: "AppRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Index_ExpiresAtTime",
                schema: "hms",
                table: "AppSqlCache",
                column: "ExpiresAtTime");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_UserId",
                schema: "hms",
                table: "AppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLogins_UserId",
                schema: "hms",
                table: "AppUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_RoleId",
                schema: "hms",
                table: "AppUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "hms",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "hms",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserUsedPasswords_UserId",
                schema: "hms",
                table: "AppUserUsedPasswords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseInformations_ParentId",
                schema: "hms",
                table: "BaseInformations",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseInformation",
                schema: "hms",
                table: "BaseInformations",
                column: "Title");

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
                name: "IX_PersonLocation",
                schema: "hms",
                table: "PersonLocations",
                column: "Mobile");

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

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_ConditionId",
                schema: "hms",
                table: "Personnel",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_MembershipTypeId",
                schema: "hms",
                table: "Personnel",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_MilitaryBranchId",
                schema: "hms",
                table: "Personnel",
                column: "MilitaryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_PersonId",
                schema: "hms",
                table: "Personnel",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnel_StructureId",
                schema: "hms",
                table: "Personnel",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BrithPlaceCityId",
                schema: "hms",
                table: "Persons",
                column: "BrithPlaceCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_BrithPlaceProvianceId",
                schema: "hms",
                table: "Persons",
                column: "BrithPlaceProvianceId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Perosn",
                schema: "hms",
                table: "Persons",
                columns: new[] { "FirstName", "LastName", "NationalCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Structures_ParentId",
                schema: "hms",
                table: "Structures",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Structure",
                schema: "hms",
                table: "Structures",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDataProtectionKeys",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "AppLogItems",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "AppRoleClaims",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "AppSqlCache",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "AppUserClaims",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "AppUserLogins",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "AppUserRoles",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "AppUserTokens",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "AppUserUsedPasswords",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "PersonAdditionalInformations",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "PersonEducations",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "PersonLocations",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "PersonMarriages",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "Personnel",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "AppRoles",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "Structures",
                schema: "hms");

            migrationBuilder.DropTable(
                name: "BaseInformations",
                schema: "hms");
        }
    }
}
