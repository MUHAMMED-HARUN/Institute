using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ADDNominationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clsNomination_BasicTestInfos_BasicTestID",
                table: "clsNomination");

            migrationBuilder.DropForeignKey(
                name: "FK_clsNomination_QuranStudents_QuranStudentID",
                table: "clsNomination");

            migrationBuilder.DropForeignKey(
                name: "FK_QuranTests_clsNomination_NominationID",
                table: "QuranTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clsNomination",
                table: "clsNomination");

            migrationBuilder.RenameTable(
                name: "clsNomination",
                newName: "Nominations");

            migrationBuilder.RenameIndex(
                name: "IX_clsNomination_QuranStudentID",
                table: "Nominations",
                newName: "IX_Nominations_QuranStudentID");

            migrationBuilder.RenameIndex(
                name: "IX_clsNomination_BasicTestID",
                table: "Nominations",
                newName: "IX_Nominations_BasicTestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nominations",
                table: "Nominations",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nominations_BasicTestInfos_BasicTestID",
                table: "Nominations",
                column: "BasicTestID",
                principalTable: "BasicTestInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Nominations_QuranStudents_QuranStudentID",
                table: "Nominations",
                column: "QuranStudentID",
                principalTable: "QuranStudents",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_QuranTests_Nominations_NominationID",
                table: "QuranTests",
                column: "NominationID",
                principalTable: "Nominations",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nominations_BasicTestInfos_BasicTestID",
                table: "Nominations");

            migrationBuilder.DropForeignKey(
                name: "FK_Nominations_QuranStudents_QuranStudentID",
                table: "Nominations");

            migrationBuilder.DropForeignKey(
                name: "FK_QuranTests_Nominations_NominationID",
                table: "QuranTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nominations",
                table: "Nominations");

            migrationBuilder.RenameTable(
                name: "Nominations",
                newName: "clsNomination");

            migrationBuilder.RenameIndex(
                name: "IX_Nominations_QuranStudentID",
                table: "clsNomination",
                newName: "IX_clsNomination_QuranStudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Nominations_BasicTestID",
                table: "clsNomination",
                newName: "IX_clsNomination_BasicTestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clsNomination",
                table: "clsNomination",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_clsNomination_BasicTestInfos_BasicTestID",
                table: "clsNomination",
                column: "BasicTestID",
                principalTable: "BasicTestInfos",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_clsNomination_QuranStudents_QuranStudentID",
                table: "clsNomination",
                column: "QuranStudentID",
                principalTable: "QuranStudents",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_QuranTests_clsNomination_NominationID",
                table: "QuranTests",
                column: "NominationID",
                principalTable: "clsNomination",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
