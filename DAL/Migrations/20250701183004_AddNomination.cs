using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNomination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuranTests_BasicTestInfos_TestID",
                table: "QuranTests");

            migrationBuilder.DropForeignKey(
                name: "FK_QuranTests_QuranStudents_QuranStudentID",
                table: "QuranTests");

            migrationBuilder.DropIndex(
                name: "IX_QuranTests_QuranStudentID",
                table: "QuranTests");

            migrationBuilder.DropColumn(
                name: "QuranStudentID",
                table: "QuranTests");

            migrationBuilder.RenameColumn(
                name: "TestID",
                table: "QuranTests",
                newName: "NominationID");

            migrationBuilder.RenameIndex(
                name: "IX_QuranTests_TestID",
                table: "QuranTests",
                newName: "IX_QuranTests_NominationID");

            migrationBuilder.CreateTable(
                name: "clsNomination",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicTestID = table.Column<int>(type: "int", nullable: false),
                    QuranStudentID = table.Column<int>(type: "int", nullable: false),
                    NominationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clsNomination", x => x.ID);
                    table.ForeignKey(
                        name: "FK_clsNomination_BasicTestInfos_BasicTestID",
                        column: x => x.BasicTestID,
                        principalTable: "BasicTestInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_clsNomination_QuranStudents_QuranStudentID",
                        column: x => x.QuranStudentID,
                        principalTable: "QuranStudents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clsNomination_BasicTestID",
                table: "clsNomination",
                column: "BasicTestID");

            migrationBuilder.CreateIndex(
                name: "IX_clsNomination_QuranStudentID",
                table: "clsNomination",
                column: "QuranStudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuranTests_clsNomination_NominationID",
                table: "QuranTests",
                column: "NominationID",
                principalTable: "clsNomination",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuranTests_clsNomination_NominationID",
                table: "QuranTests");

            migrationBuilder.DropTable(
                name: "clsNomination");

            migrationBuilder.RenameColumn(
                name: "NominationID",
                table: "QuranTests",
                newName: "TestID");

            migrationBuilder.RenameIndex(
                name: "IX_QuranTests_NominationID",
                table: "QuranTests",
                newName: "IX_QuranTests_TestID");

            migrationBuilder.AddColumn<int>(
                name: "QuranStudentID",
                table: "QuranTests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuranTests_QuranStudentID",
                table: "QuranTests",
                column: "QuranStudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuranTests_BasicTestInfos_TestID",
                table: "QuranTests",
                column: "TestID",
                principalTable: "BasicTestInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_QuranTests_QuranStudents_QuranStudentID",
                table: "QuranTests",
                column: "QuranStudentID",
                principalTable: "QuranStudents",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
