using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SecoundCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Districts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityID",
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
                        name: "FK_Neighborhoods_Districts_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "Districts",
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
                name: "Teachers",
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
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teachers_AuditableEntities_AuditableEntityID",
                        column: x => x.AuditableEntityID,
                        principalTable: "AuditableEntities",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Teachers_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
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
                name: "EnrolmentTeachers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    EnrolmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndEnrolmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                        name: "FK_EnrolmentTeachers_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
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

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AuditableEntityID",
                table: "Addresses",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_NeighborhoodID",
                table: "Addresses",
                column: "NeighborhoodID");

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
                name: "IX_Countriys_AuditableEntityID",
                table: "Countriys",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_AuditableEntityID",
                table: "Departments",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityID",
                table: "Districts",
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
                name: "IX_Neighborhoods_AuditableEntityID",
                table: "Neighborhoods",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_DistrictID",
                table: "Neighborhoods",
                column: "DistrictID");

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
                name: "IX_Students_AuditableEntityID",
                table: "Students",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PersonID",
                table: "Students",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AuditableEntityID",
                table: "Teachers",
                column: "AuditableEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PersonID",
                table: "Teachers",
                column: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolmentTeachers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "EnrolmentStudent");

            migrationBuilder.DropTable(
                name: "Classes");

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
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countriys");

            migrationBuilder.DropTable(
                name: "AuditableEntities");
        }
    }
}
