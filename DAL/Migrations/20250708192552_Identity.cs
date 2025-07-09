using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditableEntities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditableEntities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BasicTestInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxGrade = table.Column<short>(type: "smallint", nullable: false),
                    MinGrade = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicTestInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Countriys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countriys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Countriys_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentDiscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Departments_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReadingDay",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingDay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReadingDay_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cities_Countriys_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countriys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalssDiscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionFee = table.Column<float>(type: "real", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Classes_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Classes_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.ID);
                    table.ForeignKey(
                        name: "FK_District_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeighborhoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictID = table.Column<int>(type: "int", nullable: false),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Neighborhoods_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Neighborhoods_District_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "District",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeighborhoodID = table.Column<int>(type: "int", nullable: false),
                    AddressDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Addresses_Neighborhoods_NeighborhoodID",
                        column: x => x.NeighborhoodID,
                        principalTable: "Neighborhoods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrandFatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipStatus = table.Column<short>(type: "smallint", nullable: false),
                    Gendor = table.Column<bool>(type: "bit", nullable: false),
                    PlaceOfBirthID = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalIDImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_People_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_People_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_People_Cities_PlaceOfBirthID",
                        column: x => x.PlaceOfBirthID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "clsTeacher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clsTeacher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_clsTeacher_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_clsTeacher_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Members_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Members_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Students_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EnrolmentTeachers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    EnrolmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndEnrolmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnrollmentStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolmentTeachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnrolmentTeachers_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EnrolmentTeachers_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrolmentTeachers_clsTeacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "clsTeacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EnrolmentStudent",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    EnrolmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrollmentEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnrollmentStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolmentStudent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EnrolmentStudent_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EnrolmentStudent_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EnrolmentStudent_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QuranStudents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    TotalSavedPages = table.Column<short>(type: "smallint", nullable: false),
                    TotalInstalledParts = table.Column<byte>(type: "tinyint", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    performanceRating = table.Column<byte>(type: "tinyint", nullable: true),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuranStudents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuranStudents_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_QuranStudents_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_QuranStudents_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_QuranStudents_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentEnrollmentId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidAmount = table.Column<float>(type: "real", nullable: false),
                    AmountDue = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_EnrolmentStudent_StudentEnrollmentId",
                        column: x => x.StudentEnrollmentId,
                        principalTable: "EnrolmentStudent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Nominations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicTestID = table.Column<int>(type: "int", nullable: false),
                    QuranStudentID = table.Column<int>(type: "int", nullable: false),
                    FromPart = table.Column<byte>(type: "tinyint", nullable: false),
                    ToPart = table.Column<byte>(type: "tinyint", nullable: true),
                    NominationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestStatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nominations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nominations_BasicTestInfos_BasicTestID",
                        column: x => x.BasicTestID,
                        principalTable: "BasicTestInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Nominations_QuranStudents_QuranStudentID",
                        column: x => x.QuranStudentID,
                        principalTable: "QuranStudents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadedPageNum = table.Column<short>(type: "smallint", nullable: false),
                    PerformanceRating = table.Column<byte>(type: "tinyint", nullable: false),
                    ReadigType = table.Column<byte>(type: "tinyint", nullable: false),
                    ReadingDayID = table.Column<int>(type: "int", nullable: false),
                    QuranStudentID = table.Column<int>(type: "int", nullable: false),
                    AuditableEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Readings_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Readings_QuranStudents_QuranStudentID",
                        column: x => x.QuranStudentID,
                        principalTable: "QuranStudents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Readings_ReadingDay_ReadingDayID",
                        column: x => x.ReadingDayID,
                        principalTable: "ReadingDay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QuranTests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NominationID = table.Column<int>(type: "int", nullable: false),
                    CommitteeID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuranTests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuranTests_Groups_CommitteeID",
                        column: x => x.CommitteeID,
                        principalTable: "Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_QuranTests_Nominations_NominationID",
                        column: x => x.NominationID,
                        principalTable: "Nominations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AuditableEntityID",
                table: "Addresses",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NeighborhoodID",
                table: "Addresses",
                column: "NeighborhoodID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_AuditableEntityID",
                table: "Cities",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_AuditableEntityID",
                table: "Classes",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_DepartmentID",
                table: "Classes",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_clsTeacher_AuditableEntityID",
                table: "clsTeacher",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_clsTeacher_PersonID",
                table: "clsTeacher",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Countriys_AuditableEntityID",
                table: "Countriys",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_AuditableEntityID",
                table: "Departments",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_District_CityID",
                table: "District",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentStudent_AuditableEntityID",
                table: "EnrolmentStudent",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentStudent_ClassID",
                table: "EnrolmentStudent",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentStudent_StudentID",
                table: "EnrolmentStudent",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentTeachers_AuditableEntityID",
                table: "EnrolmentTeachers",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentTeachers_ClassID",
                table: "EnrolmentTeachers",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentTeachers_TeacherID",
                table: "EnrolmentTeachers",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_GroupID",
                table: "Members",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PersonID",
                table: "Members",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_AuditableEntityID",
                table: "Neighborhoods",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_DistrictID",
                table: "Neighborhoods",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_Nominations_BasicTestID",
                table: "Nominations",
                column: "BasicTestID");

            migrationBuilder.CreateIndex(
                name: "IX_Nominations_QuranStudentID",
                table: "Nominations",
                column: "QuranStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StudentEnrollmentId",
                table: "Payments",
                column: "StudentEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AddressID",
                table: "People",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_People_AuditableEntityID",
                table: "People",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_People_PlaceOfBirthID",
                table: "People",
                column: "PlaceOfBirthID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AuditableEntityID",
                table: "Projects",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_QuranStudents_AuditableEntityID",
                table: "QuranStudents",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_QuranStudents_ClassID",
                table: "QuranStudents",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_QuranStudents_ProjectID",
                table: "QuranStudents",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_QuranStudents_StudentID",
                table: "QuranStudents",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_QuranTests_CommitteeID",
                table: "QuranTests",
                column: "CommitteeID");

            migrationBuilder.CreateIndex(
                name: "IX_QuranTests_NominationID",
                table: "QuranTests",
                column: "NominationID");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingDay_AuditableEntityID",
                table: "ReadingDay",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_AuditableEntityID",
                table: "Readings",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_QuranStudentID",
                table: "Readings",
                column: "QuranStudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Readings_ReadingDayID",
                table: "Readings",
                column: "ReadingDayID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AuditableEntityID",
                table: "Students",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PersonID",
                table: "Students",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EnrolmentTeachers");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "QuranTests");

            migrationBuilder.DropTable(
                name: "Readings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "clsTeacher");

            migrationBuilder.DropTable(
                name: "EnrolmentStudent");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Nominations");

            migrationBuilder.DropTable(
                name: "ReadingDay");

            migrationBuilder.DropTable(
                name: "BasicTestInfos");

            migrationBuilder.DropTable(
                name: "QuranStudents");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countriys");

            migrationBuilder.DropTable(
                name: "AuditableEntities");
        }
    }
}
