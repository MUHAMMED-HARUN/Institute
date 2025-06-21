using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrolmentTeachers_Teachers_TeacherID",
                table: "EnrolmentTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_AuditableEntities_AuditableEntityID",
                table: "TeacherTableView");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_People_PersonID",
                table: "TeacherTableView");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "TeacherTableView");

            migrationBuilder.RenameTable(
                name: "TeacherTableView",
                newName: "clsTeacher");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_PersonID",
                table: "clsTeacher",
                newName: "IX_clsTeacher_PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_AuditableEntityID",
                table: "clsTeacher",
                newName: "IX_clsTeacher_AuditableEntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clsTeacher",
                table: "clsTeacher",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_clsTeacher_AuditableEntities_AuditableEntityID",
                table: "clsTeacher",
                column: "AuditableEntityID",
                principalTable: "AuditableEntities",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_clsTeacher_People_PersonID",
                table: "clsTeacher",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolmentTeachers_clsTeacher_TeacherID",
                table: "EnrolmentTeachers",
                column: "TeacherID",
                principalTable: "clsTeacher",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clsTeacher_AuditableEntities_AuditableEntityID",
                table: "clsTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_clsTeacher_People_PersonID",
                table: "clsTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrolmentTeachers_clsTeacher_TeacherID",
                table: "EnrolmentTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clsTeacher",
                table: "clsTeacher");

            migrationBuilder.RenameTable(
                name: "clsTeacher",
                newName: "TeacherTableView");

            migrationBuilder.RenameIndex(
                name: "IX_clsTeacher_PersonID",
                table: "TeacherTableView",
                newName: "IX_Teachers_PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_clsTeacher_AuditableEntityID",
                table: "TeacherTableView",
                newName: "IX_Teachers_AuditableEntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "TeacherTableView",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolmentTeachers_Teachers_TeacherID",
                table: "EnrolmentTeachers",
                column: "TeacherID",
                principalTable: "TeacherTableView",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AuditableEntities_AuditableEntityID",
                table: "TeacherTableView",
                column: "AuditableEntityID",
                principalTable: "AuditableEntities",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_People_PersonID",
                table: "TeacherTableView",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
