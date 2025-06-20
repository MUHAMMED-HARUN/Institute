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
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_People_PersonID",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
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
                newName: "Teachers");

            migrationBuilder.RenameIndex(
                name: "IX_clsTeacher_PersonID",
                table: "Teachers",
                newName: "IX_Teachers_PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_clsTeacher_AuditableEntityID",
                table: "Teachers",
                newName: "IX_Teachers_AuditableEntityID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolmentTeachers_Teachers_TeacherID",
                table: "EnrolmentTeachers",
                column: "TeacherID",
                principalTable: "Teachers",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_AuditableEntities_AuditableEntityID",
                table: "Teachers",
                column: "AuditableEntityID",
                principalTable: "AuditableEntities",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_People_PersonID",
                table: "Teachers",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
